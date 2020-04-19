using System;
using System.Collections.Generic;
using System.Text;
using SpotifyWrapper.interfaces;

namespace SpotifyWrapper.validation
{
    public interface IValidationRule
    {
        bool Validate(IRequest request);
    }
}
