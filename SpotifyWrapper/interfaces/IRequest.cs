namespace SpotifyWrapper.interfaces
{
    public interface IRequest
    {
        public RequestType RequestType { get; set; }
        public string PlaylistUri { get; set; }
        string UserUri { get; set; }
    }
}