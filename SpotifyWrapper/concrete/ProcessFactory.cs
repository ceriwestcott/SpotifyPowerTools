using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SpotifyWrapper.interfaces;
using SpotifyWrapper.Process;

namespace SpotifyWrapper.concrete
{
    public class ProcessFactory : IProcessFactory
    {
        private IServiceProvider provider;
        public ProcessFactory(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public IProcess GetProcess(IRequest request)
        {

            var services = provider.GetServices<IProcess>();
            switch (request.RequestType)
            {
                case RequestType.GET_PLAYLIST:
                    return services.First(x => x.GetType() == typeof(GetPlaylistProcess));
                case RequestType.CLEAR_PLAYLIST:
                    return services.First(x => x.GetType() == typeof(ClearPlaylistProcess));
                case RequestType.REORDER:
                    return services.First(x => x.GetType() == typeof(ReorderProcess))
                    break;
            }
            return null;
        }
    }
}