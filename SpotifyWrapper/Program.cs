using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using SpotifyWrapper.concrete;
using SpotifyWrapper.interfaces;
using SpotifyWrapper.Responses.Playlist;
using SpotifyWrapper.validation;

namespace SpotifyWrapper
{
    class Program
    {
        static void Main(string[] args)
        {

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IValidator, Validator>()
                .AddSingleton<IProcessFactory, ProcessFactory>()
                .AddSingleton<IAPIProcess, ApiProcess>()
                .AddSingleton<SpotifyWebAPI>()
                .AddTransient<IProcess, GetPlaylistProcess>()
                .AddTransient<IProcess, ClearPlaylistProcess>()
                .AddTransient<IServiceCollection, ServiceCollection>()
                    .BuildServiceProvider();


            var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<FullPlaylist, GetPlaylistResponseMessage>();
                });

            var apiProcess = serviceProvider.GetService<IAPIProcess>();

            GetPlaylistRequest request = new GetPlaylistRequest {PlaylistID = "test"};

            IResponseMessage responseMessage = apiProcess.RunCommand<GetPlaylistRequest>(request);
            
            Console.ReadLine();

        }
    }
}
