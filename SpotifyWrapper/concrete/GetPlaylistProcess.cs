using System;
using System.Collections.Generic;
using System.Text;
using SpotifyWrapper.interfaces;
using SpotifyWrapper.validation;

namespace SpotifyWrapper.concrete
{
    public class GetPlaylistProcess : IProcess
    {
        public IResponseMessage Validate(IRequest request)
        {
            IResponseMessage responseMessage = new ReponseMessage();
            try
            {
                IValidator validator = new Validator();
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
        }
    }
}
