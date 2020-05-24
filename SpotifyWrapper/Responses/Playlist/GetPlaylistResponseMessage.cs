using System;
using System.Collections.Generic;
using System.Text;
using SpotifyAPI.Web.Models;
using SpotifyWrapper.interfaces;

namespace SpotifyWrapper.Responses.Playlist
{
    public class GetPlaylistResponseMessage : IResponseMessage
    {
        public Status StatusCode { get; set; }
        public string PlaylistURI { get; set; }
        public FullPlaylist Playlist { get; set; }
    }
}
