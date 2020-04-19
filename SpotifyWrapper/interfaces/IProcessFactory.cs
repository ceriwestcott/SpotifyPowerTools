using SpotifyWrapper.interfaces;

namespace SpotifyWrapper.concrete
{
    public interface IProcessFactory
    {
        public IProcess GetProcess(IRequest request)
        {
            switch (request.RequestType)
            {
                case RequestType.GET_PLAYLIST:
                    return null;
            }
            return null;
        }
    }
}