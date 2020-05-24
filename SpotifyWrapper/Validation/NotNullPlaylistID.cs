using System;
using System.Collections.Generic;
using System.Text;
using SpotifyWrapper.interfaces;
using SpotifyWrapper.Interfaces.Validation;
using SpotifyWrapper.validation;

namespace SpotifyWrapper.Validation
{
    public class NotNullPlaylistID : IValidationRule
    {
        public bool Validate(IRequest request)
        {
            IPlaylistID playlistIDRequest = request as IPlaylistID;

            return (playlistIDRequest != null && playlistIDRequest.PlaylistUri != null);
        }
    }
}
