using SpotifyAPI.Web.Models;
using SpotifyWrapper.interfaces;
using SpotifyWrapper.Interfaces.Validation;

namespace SpotifyWrapper.concrete
{
    internal class GetPlaylistRequest : IRequest, IPlaylistID
    {
        public Token Token { get; set; }
        public RequestType RequestType { get; set; } = RequestType.GET_PLAYLIST;
        public string PlaylistUri { get; set; }
        public string UserUri { get; set; }
    }
}