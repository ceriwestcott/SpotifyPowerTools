using System;
using System.Collections.Generic;
using System.Text;
using SpotifyAPI.Web.Models;
using SpotifyWrapper.interfaces;
using SpotifyWrapper.Interfaces.Validation;

namespace SpotifyWrapper.Requests
{
    public class ClearPlaylistRequest : IRequest, IPlaylistID
    {
        public Status StatusCode { get; set; }
        public List<PlaylistTrack> PlaylistTracks { get; set; }
        public RequestType RequestType { get; set; } = RequestType.CLEAR_PLAYLIST;
        public string PlaylistUri { get; set; }
        public string UserUri { get; set; }
        public Token Token { get; set; }
    }
}
