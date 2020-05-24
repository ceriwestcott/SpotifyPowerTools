using SpotifyAPI.Web.Models;

namespace SpotifyWrapper.interfaces
{
    public interface IRequest
    {
        public Token Token { get; set; }
        public RequestType RequestType { get; set; }
        public string PlaylistUri { get; set; }
        string UserUri { get; set; }
    }
}