using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Sol_Demo.HealthChecker
{
    public class GoogleWebSiteHealthCheckerHandler : IHealthCheck
    {
        async Task<HealthCheckResult> IHealthCheck.CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken)
        {
            using (var httpClient=new HttpClient())
            {
                var response = await httpClient.GetAsync("https://www.google.com");

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(HealthCheckResult.Healthy());
                }
                else
                {
                    return await Task.FromResult(HealthCheckResult.Unhealthy());
                }
            }
        }
    }
}
