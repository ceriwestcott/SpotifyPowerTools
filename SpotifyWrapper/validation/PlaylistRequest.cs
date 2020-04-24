using System;
using System.Collections.Generic;
using System.Text;
using SpotifyWrapper.interfaces;

namespace SpotifyWrapper.validation
{
    public class PlaylistRequest : IRequest
    {
        public RequestType RequestType { get; set; }
        public string PlaylistUri { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string UserUri { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
