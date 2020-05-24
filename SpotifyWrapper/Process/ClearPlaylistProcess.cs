using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using SpotifyWrapper.interfaces;
using SpotifyWrapper.Requests;
using SpotifyWrapper.Responses.Playlist;
using SpotifyWrapper.validation;
using SpotifyWrapper.Validation;

namespace SpotifyWrapper.concrete
{
    public class ClearPlaylistProcess : IProcess
    {
        private readonly IValidator validator;
        private SpotifyWebAPI spotifyWebApi;
        private readonly IMapper Mapper;
        private readonly IAPIProcess apiProcess;
        public ClearPlaylistProcess(IValidator validator, SpotifyWebAPI spotifyWebApi, IMapper mapper, IAPIProcess apiProcess)
        {
            this.apiProcess = apiProcess;
            this.validator = validator;
            this.spotifyWebApi = spotifyWebApi;
            Mapper = mapper;
        }

        public IResponseMessage Validate(IRequest request)
        {
            IResponseMessage responseMessage = new ReponseMessage();
            
            try
            {
                validator
                    .AddRule(new NotNullRule())
                    .AddRule(new NotNullPlaylistID());

                if (validator.ValidateRequest(request))
                    responseMessage.StatusCode = Status.SUCCESS;
            }
            catch (Exception ex)
            {

            }

            return responseMessage;
        }

        public IResponseMessage Process(IRequest request)
        {
            try
            {
                GetPlaylistResponseMessage playlistGetResponseMessage = GetPlaylist(request) as GetPlaylistResponseMessage;

                if (playlistGetResponseMessage.StatusCode == Status.FAILURE)
                    return playlistGetResponseMessage;

                ClearPlaylistRequest clearPlaylistRequest = request as ClearPlaylistRequest;
               List<DeleteTrackUri> PlaylistTracks = playlistGetResponseMessage.Playlist.Tracks.Items.Select(x => new DeleteTrackUri(x.Track.Uri)).ToList();

                spotifyWebApi.AccessToken = request.Token.AccessToken;
                spotifyWebApi.TokenType = request.Token.TokenType;

                var retVal = spotifyWebApi.RemovePlaylistTracks(request.PlaylistUri, PlaylistTracks);

            }
            catch (Exception ex) { }

            return null;
        }

        private IResponseMessage GetPlaylist(IRequest request)
        {
            GetPlaylistRequest getPlaylistRequest = new GetPlaylistRequest()
            {
                PlaylistUri = request.PlaylistUri,
                Token = request.Token,
                RequestType = RequestType.GET_PLAYLIST
            };

            return apiProcess.RunCommand<GetPlaylistRequest>(getPlaylistRequest);
        }
    }
}
