using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SpotifyWrapper.interfaces
{
    interface IAPIProcess
    {
        IResponseMessage RunCommand<T>(IRequest request);
    }
}
