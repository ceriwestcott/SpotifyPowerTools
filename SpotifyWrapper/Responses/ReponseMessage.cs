using System;
using System.Collections.Generic;
using System.Text;
using SpotifyWrapper.interfaces;

namespace SpotifyWrapper.concrete
{
    public class ReponseMessage : IResponseMessage
    {
        public Status StatusCode { get; set; } = Status.FAILURE;
    }
}
