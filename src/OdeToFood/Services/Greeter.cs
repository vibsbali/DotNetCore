using Microsoft.Extensions.Configuration;

namespace OdeToFood.Services
{
    public class Greeter : IGreeter
    {
        public readonly string Greeting;

        public Greeter(IConfiguration configuration)
        {
            Greeting = configuration["greeting"];
        }

        public string GetGreeting()
        {
            return Greeting;
        }
    }
}
