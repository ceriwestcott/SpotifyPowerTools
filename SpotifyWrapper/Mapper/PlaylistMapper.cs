using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SpotifyAPI.Web.Models;
using SpotifyWrapper.interfaces;
using SpotifyWrapper.Responses.Playlist;

namespace SpotifyWrapper.Mapper
{
    public class PlaylistMapper : Profile
    {
        public PlaylistMapper()
        {
            CreateMap<FullPlaylist, GetPlaylistResponseMessage>()
                .ForMember(to => to.PlaylistURI,
                    from =>
                        from.MapFrom(playlistResponse => playlistResponse.Uri))

                .ForMember(to => to.StatusCode,
                    from =>
                        from.MapFrom(
                            playlistResponse => (playlistResponse.HasError() ? Status.FAILURE : Status.SUCCESS)));
        }
    }
}
