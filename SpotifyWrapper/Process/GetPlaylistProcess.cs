using System;
using System.Collections.Generic;
using System.Text;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using SpotifyWrapper.interfaces;
using SpotifyWrapper.validation;

namespace SpotifyWrapper.concrete
{
    public class GetPlaylistProcess : IProcess
    {
        private readonly IValidator validator;
        private SpotifyWebAPI spotifyWebApi;
        public GetPlaylistProcess(IValidator validator, SpotifyWebAPI spotifyWebApi)
        {
            this.validator = validator;
            this.spotifyWebApi = spotifyWebApi;
        }

        public IResponseMessage Validate(IRequest request)
        {
            IResponseMessage responseMessage = new ReponseMessage();
            try
            {
                validator.AddRule(new NotNullRule());

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
            FullPlaylist retVal = spotifyWebApi.GetPlaylist(concreteRequest.PlaylistUri);

            return null;
        }
    }
}
