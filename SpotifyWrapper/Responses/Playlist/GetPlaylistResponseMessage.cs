using System;
using System.Collections.Generic;
using System.Text;
using SpotifyWrapper.interfaces;

namespace SpotifyWrapper.Responses.Playlist
{
    public class GetPlaylistResponseMessage : IResponseMessage
    {
        public Status StatusCode { get; set; }
        public string PlaylistURI { get; set; }
    }
}
