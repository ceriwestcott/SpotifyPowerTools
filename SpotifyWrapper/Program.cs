using System;
using SpotifyWrapper.interfaces;
using SpotifyWrapper.validation;

namespace SpotifyWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            IValidator validator = new Validator();
            IValidationRule rule = new NotNullRule();
            IRequest request = new PlaylistRequest();
            validator.AddRule(rule);
            Console.WriteLine(validator.ValidateRequest(request));
            Console.ReadLine();

        }
    }
}
