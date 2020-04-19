using SpotifyWrapper.interfaces;

namespace SpotifyWrapper.concrete
{
    internal class GetPlaylistRequest : IRequest
    {
        public RequestType RequestType { get; set; } = RequestType.GET_PLAYLIST;
    }
}