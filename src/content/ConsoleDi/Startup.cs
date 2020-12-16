using System;
using System.IO;
using ConsoleDi.Config;
using ConsoleDi.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ConsoleDi
{
    public class Startup
    {
        private static ServiceCollection _services;
        private static IConfigurationRoot _configuration;

        private Startup()
        {
            _services = new ServiceCollection();
        }

        private IServiceProvider BuildServiceProvider() => _services.BuildServiceProvider();
        
        public static IServiceProvider Build() => 
            new Startup()
                .ConfigureOptions(_services)
                .ConfigureServices(_services)
                .ConfigureLogging(_services)
                .BuildServiceProvider();

        
        private Startup ConfigureServices(IServiceCollection services)
        {
            //TODO: Register services here
            services.AddSingleton<ICleverService, CleverService>();
            return this;
        }
        
        private Startup ConfigureLogging(IServiceCollection services)
        {
            //TODO: Configure logging here
            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddConsole();
            });
            return this;
        }

        private Startup ConfigureOptions(IServiceCollection services)
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json",  true, true)
                .Build();
            
            var settings = new Settings();
            _configuration.GetSection("settings").Bind(settings);

            services.AddSingleton(settings);
            
            //TODO: Configure options here
            return this;
        }
    }
}