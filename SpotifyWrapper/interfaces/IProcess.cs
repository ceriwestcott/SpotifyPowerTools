using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyWrapper.interfaces
{
    public interface IProcess
    {
        public IResponseMessage Validate(IRequest request);
        public IResponseMessage Process(IRequest request);
    }
}
