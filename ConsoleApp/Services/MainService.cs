using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class MainService : IHostedService
    {
        private ILogger<MainService> _logger;
        IService<Models.Person> _service;

        public MainService(ILogger<MainService> logger, IService<Models.Person> service, IHostApplicationLifetime applicationLifetime)
        {
            _logger = logger;
            _service = service;

            applicationLifetime.ApplicationStarted.Register(OnStart);
            applicationLifetime.ApplicationStopped.Register(OnStop);
            applicationLifetime.ApplicationStopping.Register(OnStopping);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var task =  Task.Delay(3000);

            task.ContinueWith(x =>
            {
                var people = _service.Read();
                var text = string.Join("\n", people.Select(person => $"{person.LastName} {person.FirstName}!"));
            });

            return task;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.Delay(5000);
        }

        private void OnStop()
        {

            _logger.LogInformation("Main service stop");
        }
        private void OnStart()
        {

            _logger.LogInformation("Main service start");
        }
        private void OnStopping()
        {
            _logger.LogInformation("Main service stopping");

        }
    }
}
