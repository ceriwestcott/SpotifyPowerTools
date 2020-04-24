using SpotifyWrapper.interfaces;

namespace SpotifyWrapper.concrete
{
    internal class GetPlaylistRequest : IRequest
    {
        public RequestType RequestType { get; set; } = RequestType.GET_PLAYLIST;
        public string PlaylistUri { get; set; }
        public string UserUri { get; set; }

        public string PlaylistID { get; set; }
    }
}