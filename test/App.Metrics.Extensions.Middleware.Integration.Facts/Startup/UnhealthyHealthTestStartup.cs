using App.Metrics.Configuration;
using App.Metrics.Extensions.Middleware.DependencyInjection.Options;
using App.Metrics.Health;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace App.Metrics.Extensions.Middleware.Integration.Facts.Startup
{
    public class UnhealthyHealthTestStartup : TestStartup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            SetupAppBuilder(app, env, loggerFactory);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var appMetricsOptions = new AppMetricsOptions
                                    {
                                        DefaultContextLabel = "testing",
                                        MetricsEnabled = true
                                    };

            var aspNetMetricsOptions = new AspNetMetricsOptions
                                       {
                                           MetricsTextEndpointEnabled = true,
                                           HealthEndpointEnabled = true,
                                           MetricsEndpointEnabled = true,
                                           PingEndpointEnabled = true
                                       };

            SetupServices(
                services,
                appMetricsOptions,
                aspNetMetricsOptions,
                healthChecks: new[] { HealthCheckResult.Healthy(), HealthCheckResult.Degraded(), HealthCheckResult.Unhealthy() });
        }
    }
}