﻿// Copyright (c) Allan Hardy. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using App.Metrics.Configuration;
using App.Metrics.Extensions.Middleware.DependencyInjection.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace App.Metrics.Extensions.Middleware.Integration.Facts.Startup
{
    public class DisabledMetricsEndpointStartup : TestStartup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            SetupAppBuilder(app, env, loggerFactory);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var appMetricsOptions = new AppMetricsOptions
                                    {
                                        MetricsEnabled = true
                                    };

            var aspNetMetricsOptions = new AspNetMetricsOptions
                                       {
                                           MetricsEndpointEnabled = false
                                       };

            SetupServices(services, appMetricsOptions, aspNetMetricsOptions);
        }
    }
}