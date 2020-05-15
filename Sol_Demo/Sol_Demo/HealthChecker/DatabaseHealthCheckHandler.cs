using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sol_Demo.HealthChecker
{
    public class DatabaseHealthCheckHandler : IHealthCheck
    {
        Task<HealthCheckResult> IHealthCheck.CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken)
        {
            string _connectionString = @"Data Source=DESKTOP-MOL1H66\IDEATORS;Initial Catalog=Db;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException)
                {
                    return Task.FromResult(HealthCheckResult.Unhealthy());
                }
            }

            return Task.FromResult(HealthCheckResult.Healthy());
        }
    }
}
