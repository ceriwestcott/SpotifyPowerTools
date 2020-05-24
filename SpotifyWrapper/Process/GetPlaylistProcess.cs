using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using SpotifyWrapper.interfaces;
using SpotifyWrapper.Responses.Playlist;
using SpotifyWrapper.validation;
using SpotifyWrapper.Validation;

namespace SpotifyWrapper.concrete
{
    public class GetPlaylistProcess : IProcess
    {
        private readonly IValidator validator;
        private SpotifyWebAPI spotifyWebApi;
        private readonly IMapper Mapper;
        public GetPlaylistProcess(IValidator validator, SpotifyWebAPI spotifyWebApi, IMapper mapper)
        {
            this.validator = validator;
            this.spotifyWebApi = spotifyWebApi;
            Mapper = mapper;
        }

        public IResponseMessage Validate(IRequest request)
        {
            IResponseMessage responseMessage = new ReponseMessage();
            try
            {
                validator.AddRule(new NotNullRule());
                validator.AddRule(new NotNullPlaylistID());

                if (validator.ValidateRequest(request)) 
                    responseMessage.StatusCode = Status.SUCCESS;
                
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            return responseMessage;
        }

        public IResponseMessage Process(IRequest request)
        {
            GetPlaylistRequest concreteRequest = request as GetPlaylistRequest;

            spotifyWebApi.TokenType = concreteRequest.Token.TokenType;
            spotifyWebApi.AccessToken = concreteRequest.Token.AccessToken;

            FullPlaylist retVal = spotifyWebApi.GetPlaylist(concreteRequest.PlaylistUri);

            GetPlaylistResponseMessage responseMessage = Mapper.Map<FullPlaylist, GetPlaylistResponseMessage>(retVal);

            return responseMessage;
        }
    }
}
