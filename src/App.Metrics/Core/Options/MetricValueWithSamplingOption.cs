﻿// <copyright file="MetricValueWithSamplingOption.cs" company="Allan Hardy">
// Copyright (c) Allan Hardy. All rights reserved.
// </copyright>

using System;
using App.Metrics.Abstractions.ReservoirSampling;

// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace App.Metrics.Core.Options
{
    /// <summary>
    ///     Configuration of a Metric that will be measured using a reservoir sampling type
    /// </summary>
    public abstract class MetricValueWithSamplingOption : MetricValueOptionsBase
    {
        /// <summary>
        ///     Gets or sets an <see cref="IReservoir" /> implementation for sampling.
        /// </summary>
        /// <value>
        ///     The reservoir instance to use for sampling.
        /// </value>
        /// <remarks>
        ///     Reservoir sampling avoids unbound memory usage, allows metrics to be generated from a reservoir of values.
        /// </remarks>
        public Lazy<IReservoir> Reservoir { get; set; }
    }

    // ReSharper restore UnusedAutoPropertyAccessor.Global
}