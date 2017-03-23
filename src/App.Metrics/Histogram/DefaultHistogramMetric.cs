﻿// <copyright file="DefaultHistogramMetric.cs" company="Allan Hardy">
// Copyright (c) Allan Hardy. All rights reserved.
// </copyright>

using System;
using App.Metrics.Abstractions.MetricTypes;
using App.Metrics.Abstractions.ReservoirSampling;
using App.Metrics.Core;
using App.Metrics.Core.Internal;

namespace App.Metrics.Histogram
{
    public sealed class DefaultHistogramMetric : IHistogramMetric
    {
        private readonly Lazy<IReservoir> _reservoir;
        private bool _disposed;
        private UserValueWrapper _last;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DefaultHistogramMetric" /> class.
        /// </summary>
        /// <param name="reservoir">The reservoir to use for sampling.</param>
        public DefaultHistogramMetric(Lazy<IReservoir> reservoir)
        {
            _reservoir = reservoir ?? throw new ArgumentNullException(nameof(reservoir));
        }

        public HistogramValue Value => GetValue();

        [AppMetricsExcludeFromCodeCoverage]
        public void Dispose()
        {
            Dispose(true);
        }

        [AppMetricsExcludeFromCodeCoverage]
        // ReSharper disable MemberCanBePrivate.Global
        public void Dispose(bool disposing)
            // ReSharper restore MemberCanBePrivate.Global
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Free any other managed objects here.
                    if (_reservoir.IsValueCreated)
                    {
                        using (_reservoir.Value as IDisposable)
                        {
                        }
                    }
                }
            }

            _disposed = true;
        }

        /// <inheritdoc />
        public HistogramValue GetValue(bool resetMetric = false)
        {
            var value = new HistogramValue(_last.Value, _last.UserValue, _reservoir.Value.GetSnapshot(resetMetric));

            if (resetMetric)
            {
                _last = UserValueWrapper.Empty;
            }

            return value;
        }

        /// <inheritdoc />
        public void Reset()
        {
            _last = UserValueWrapper.Empty;
            _reservoir.Value.Reset();
        }

        /// <inheritdoc />
        public void Update(long value, string userValue)
        {
            _last = new UserValueWrapper(value, userValue);
            _reservoir.Value.Update(value, userValue);
        }

        /// <inheritdoc />
        public void Update(long value)
        {
            _last = new UserValueWrapper(value);
            _reservoir.Value.Update(value);
        }
    }
}