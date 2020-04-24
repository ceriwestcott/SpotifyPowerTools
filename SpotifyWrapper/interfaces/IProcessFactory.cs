using SpotifyWrapper.interfaces;

namespace SpotifyWrapper.concrete
{
    public interface IProcessFactory
    {
        IProcess GetProcess(IRequest request);
    }
}