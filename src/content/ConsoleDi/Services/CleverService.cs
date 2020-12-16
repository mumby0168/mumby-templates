using System.Threading;
using ConsoleDi.Config;
using Microsoft.Extensions.Logging;

namespace ConsoleDi.Services
{
    public class CleverService : ICleverService
    {
        private readonly ILogger<CleverService> _logger;
        private readonly Settings _settings;

        public CleverService(ILogger<CleverService> logger, Settings settings)
        {
            _logger = logger;
            _settings = settings;
        }
        
        
        public void DoCleverWork()
        {
            _logger.LogInformation("Starting clever work");
            Thread.Sleep(_settings.CleverWorkTimeInSeconds * 1000);
            _logger.LogInformation($"Finished clever work took {_settings.CleverWorkTimeInSeconds} seconds");
        }
    }
}