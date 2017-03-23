﻿// <copyright file="DefaultHistogramMetricProvider.cs" company="Allan Hardy">
// Copyright (c) Allan Hardy. All rights reserved.
// </copyright>

using System;
using App.Metrics.Abstractions.MetricTypes;
using App.Metrics.Core.Options;
using App.Metrics.Histogram.Abstractions;
using App.Metrics.Registry.Abstractions;
using App.Metrics.Tagging;

namespace App.Metrics.Histogram
{
    public class DefaultHistogramMetricProvider : IProvideHistogramMetrics
    {
        private readonly IBuildHistogramMetrics _histogramBuilder;
        private readonly IMetricsRegistry _registry;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DefaultHistogramMetricProvider" /> class.
        /// </summary>
        /// <param name="histogramBuilder">The histogram builder.</param>
        /// <param name="registry">The registry.</param>
        public DefaultHistogramMetricProvider(IBuildHistogramMetrics histogramBuilder, IMetricsRegistry registry)
        {
            _registry = registry;
            _histogramBuilder = histogramBuilder;
        }

        /// <inheritdoc />
        public IHistogram Instance(HistogramOptions options)
        {
            return Instance(options, () => _histogramBuilder.Build(options.Reservoir));
        }

        /// <inheritdoc />
        public IHistogram Instance<T>(HistogramOptions options, Func<T> builder)
            where T : IHistogramMetric
        {
            return _registry.Histogram(options, builder);
        }

        /// <inheritdoc />
        public IHistogram Instance(HistogramOptions options, MetricTags tags)
        {
            return Instance(options, tags, () => _histogramBuilder.Build(options.Reservoir));
        }

        /// <inheritdoc />
        public IHistogram Instance<T>(HistogramOptions options, MetricTags tags, Func<T> builder)
            where T : IHistogramMetric
        {
            return _registry.Histogram(options, tags, builder);
        }
    }
}