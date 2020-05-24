using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using SpotifyWrapper.concrete;
using SpotifyWrapper.interfaces;
using SpotifyWrapper.Mapper;
using SpotifyWrapper.Process;
using SpotifyWrapper.Requests;
using SpotifyWrapper.Responses.Playlist;
using SpotifyWrapper.validation;

namespace SpotifyWrapper
{
    class Program
    {
        static void Main(string[] args)
        {

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PlaylistMapper());
            });

            var serviceProvider = new ServiceCollection()
                .AddAutoMapper(typeof(Program))
                .AddSingleton<IValidator, Validator>()
                .AddSingleton<IProcessFactory, ProcessFactory>()
                .AddSingleton<IAPIProcess, ApiProcess>()
                .AddSingleton<SpotifyWebAPI>()
                .AddTransient<IProcess, GetPlaylistProcess>()
                .AddTransient<IProcess, ClearPlaylistProcess>()
                .AddTransient<IProcess, ReorderProcess>()
                .AddTransient<IServiceCollection, ServiceCollection>()
                    .BuildServiceProvider();

            string _clientId = "eca82f597115423cac9d1125e0fb97c4";
            string _secretId = "17a6e5916bb3424eb50f29e4816521a4";

            AuthorizationCodeAuth auth = new AuthorizationCodeAuth(
                _clientId,
                _secretId,
                "http://localhost:4200",
                "http://localhost:4200",
                Scope.PlaylistReadPrivate | Scope.PlaylistReadCollaborative | Scope.PlaylistModifyPrivate | Scope.PlaylistModifyPublic
            );


            auth.AuthReceived += async (sender, payload) =>
            {
                auth.Stop();
                Token token = await auth.ExchangeCode(payload.Code);

                var apiProcess = serviceProvider.GetService<IAPIProcess>();

                ClearPlaylistRequest request = new ClearPlaylistRequest { PlaylistUri = "6KPMCEavSTefLEx5JH3edt", Token = token};

                IResponseMessage responseMessage = apiProcess.RunCommand<ClearPlaylistRequest>(request);
            };
            auth.Start(); // Starts an internal HTTP Server
            auth.OpenBrowser();

            Console.ReadLine();

        }
    }
}
