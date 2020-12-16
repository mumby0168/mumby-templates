using ConsoleDi.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleDi
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = Startup.Build();
            var cleverService = serviceProvider.GetRequiredService<ICleverService>();
            cleverService.DoCleverWork();
        }
    }
}
