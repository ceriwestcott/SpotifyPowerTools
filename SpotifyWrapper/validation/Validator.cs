using System;
using System.Collections.Generic;
using System.Text;
using SpotifyWrapper.interfaces;

namespace SpotifyWrapper.validation
{
    public class Validator : IValidator
    {
        private List<IValidationRule> validationRules = new List<IValidationRule>();
        public IValidationRule AddRule(IValidationRule rule)
        {
            validationRules.Add(rule);
            return rule;
        }

        public bool ValidateRequest(IRequest request)
        {
            foreach (IValidationRule validationRule in validationRules)
            {
                if (!validationRule.Validate(request))
                    return false;
            }
            validationRules.Clear();
            return true;
        }
    }
}
