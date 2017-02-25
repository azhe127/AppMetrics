﻿// Copyright (c) Allan Hardy. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using App.Metrics.Abstractions.Reporting;
using App.Metrics.Configuration;
using App.Metrics.Reporting.Abstractions;
using App.Metrics.Reporting.Internal;
using App.Metrics.Scheduling;
using App.Metrics.Scheduling.Abstractions;
using Microsoft.Extensions.Logging;

namespace App.Metrics.Reporting
{
    public sealed class ReportFactory : IReportFactory
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly IMetrics _metrics;
        private readonly AppMetricsOptions _options;
        private readonly Dictionary<Type, IReporterProvider> _providers = new Dictionary<Type, IReporterProvider>();
        private readonly object _syncLock = new object();

        public ReportFactory(AppMetricsOptions options, IMetrics metrics, ILoggerFactory loggerFactory)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (metrics == null)
            {
                throw new ArgumentNullException(nameof(metrics));
            }

            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            _options = options;
            _metrics = metrics;
            _loggerFactory = loggerFactory;
        }

        public void AddProvider(IReporterProvider provider)
        {
            lock (_syncLock)
            {
                _providers.Add(provider.GetType(), provider);
            }
        }

        public IReporter CreateReporter(IScheduler scheduler) { return new Reporter(_options, this, _metrics, scheduler, _loggerFactory); }

        public IReporter CreateReporter() { return CreateReporter(new DefaultTaskScheduler()); }

        internal Dictionary<Type, IReporterProvider> GetProviders() { return _providers; }
    }
}