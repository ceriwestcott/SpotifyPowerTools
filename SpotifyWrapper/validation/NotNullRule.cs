using System;
using System.Collections.Generic;
using System.Text;
using SpotifyWrapper.interfaces;

namespace SpotifyWrapper.validation
{
    public class NotNullRule : IValidationRule
    {
        public bool Validate(IRequest request)
        {
            return request != null && request.RequestType != null;
        }
    }
}
