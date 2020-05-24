using System;
using System.Collections.Generic;
using System.Text;
using SpotifyWrapper.interfaces;

namespace SpotifyWrapper.validation
{
    public interface IValidator
    {
        IValidator AddRule(IValidationRule rule);
        bool ValidateRequest(IRequest request);
    }
}
