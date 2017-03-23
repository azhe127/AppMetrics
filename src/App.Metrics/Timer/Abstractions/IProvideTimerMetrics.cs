﻿// <copyright file="IProvideTimerMetrics.cs" company="Allan Hardy">
// Copyright (c) Allan Hardy. All rights reserved.
// </copyright>

using System;
using App.Metrics.Abstractions.MetricTypes;
using App.Metrics.Core.Options;
using App.Metrics.Tagging;

namespace App.Metrics.Timer.Abstractions
{
    public interface IProvideTimerMetrics
    {
        ITimer Instance(TimerOptions options);

        ITimer Instance(TimerOptions options, MetricTags tags);

        ITimer Instance<T>(TimerOptions options, Func<T> builder)
            where T : ITimerMetric;

        ITimer Instance<T>(TimerOptions options, MetricTags tags, Func<T> builder)
            where T : ITimerMetric;

        ITimer WithHistogram<T>(TimerOptions options, Func<T> histogramMetricBuilder)
            where T : IHistogramMetric;

        ITimer WithHistogram<T>(TimerOptions options, MetricTags tags, Func<T> histogramMetricBuilder)
            where T : IHistogramMetric;
    }
}