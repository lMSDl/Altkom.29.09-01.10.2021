using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi
{
    public class RandomHealth : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var sec = DateTime.Now.Second;

            if(sec % 2 == 0)
            {
                return Task.FromResult(HealthCheckResult.Healthy("Everything is O.K.!", new Dictionary<string, object> { { "key", "value1" }, { "Hi", 5 } }));
            }
            if (sec % 3 == 0)
            {
                return Task.FromResult(HealthCheckResult.Degraded());
            }

                return Task.FromResult(HealthCheckResult.Unhealthy("I am dead...."));
        }
    }
}
