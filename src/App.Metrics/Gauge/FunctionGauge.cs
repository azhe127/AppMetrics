﻿// <copyright file="FunctionGauge.cs" company="Allan Hardy">
// Copyright (c) Allan Hardy. All rights reserved.
// </copyright>

using System;
using App.Metrics.Abstractions.MetricTypes;

namespace App.Metrics.Gauge
{
    /// <summary>
    ///     A Gauge metric using a function to provide the instantaneous value to record
    /// </summary>
    /// <seealso cref="IGaugeMetric" />
    public class FunctionGauge : IGaugeMetric
    {
        private readonly Func<double> _valueProvider;

        public FunctionGauge(Func<double> valueProvider) { _valueProvider = valueProvider; }

        /// <inheritdoc />
        public double Value
        {
            get
            {
                try
                {
                    return _valueProvider();
                }
                catch (Exception)
                {
                    return double.NaN;
                }
            }
        }

        /// <inheritdoc />
        public double GetValue(bool resetMetric = false)
        {
            return Value;
        }

        /// <inheritdoc />
        public void Reset()
        {
            throw new InvalidOperationException("Unable to reset a Function Gauge");
        }

        /// <inheritdoc />
        public void SetValue(double value)
        {
            throw new InvalidOperationException("Unable to set the value of a Function Gauge");
        }
    }
}