using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SpotifyWrapper.interfaces
{
    public interface IAPIProcess
    {
        IResponseMessage RunCommand<T>(IRequest request);
    }
}
