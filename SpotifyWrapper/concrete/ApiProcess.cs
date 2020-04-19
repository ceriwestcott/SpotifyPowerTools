using System;
using System.Collections.Generic;
using System.Text;
using SpotifyWrapper.interfaces;

namespace SpotifyWrapper.concrete
{
    public class ApiProcess : IAPIProcess
    {
        private IProcessFactory processFactory;
        public ApiProcess(IProcessFactory processFactory)
        {
            this.processFactory = processFactory;
        }
        public IResponseMessage RunCommand<T>(IRequest request)
        {
            IProcess process = processFactory.GetProcess(request);

            IResponseMessage validationResponseMessage = process.Validate(request);

            if (validationResponseMessage.StatusCode != Status.FAILURE)
            {
               return process.Process(request);
            }
            else
            {
                return validationResponseMessage;
            }
        }
    }
}
