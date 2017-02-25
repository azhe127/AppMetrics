﻿// Copyright (c) Allan Hardy. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using App.Metrics.Meter;
using App.Metrics.Meter.Abstractions;
using App.Metrics.Meter.Extensions;
using App.Metrics.Timer;
using App.Metrics.Timer.Abstractions;

namespace App.Metrics.Gauge
{
    public class HitPercentageGauge : PercentageGauge
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="HitPercentageGauge" /> class.
        /// </summary>
        /// <param name="hitMeter">The hit meter.</param>
        /// <param name="totalMeter">The total meter.</param>
        /// <remarks>
        ///     Creates a new HitPercentageGauge with externally tracked Meters, and uses the OneMinuteRate from the MeterValue of
        ///     the meters.
        /// </remarks>
        public HitPercentageGauge(IMeter hitMeter, IMeter totalMeter)
            : this(hitMeter, totalMeter, value => value.OneMinuteRate) { }

        /// <summary>
        ///     Initializes a new instance of the <see cref="HitPercentageGauge" /> class.
        /// </summary>
        /// <param name="hitMeter">The numerator meter to use.</param>
        /// <param name="totalMeter">The denominator meter to use.</param>
        /// <param name="meterRateFunc">
        ///     The function to extract a value from the MeterValue. Will be applied to both the numerator
        ///     and denominator meters.
        /// </param>
        /// <remarks>
        ///     Creates a new HitPercentageGauge with externally tracked Meters, and uses the provided meter rate function to
        ///     extract the value for the percentage.
        /// </remarks>
        public HitPercentageGauge(IMeter hitMeter, IMeter totalMeter, Func<MeterValue, double> meterRateFunc)
            : base(() => meterRateFunc(hitMeter.GetValueOrDefault()), () => meterRateFunc(totalMeter.GetValueOrDefault())) { }

        /// <summary>
        ///     Initializes a new instance of the <see cref="HitPercentageGauge" /> class.
        /// </summary>
        /// <param name="hitMeter">The numerator meter to use.</param>
        /// <param name="totalTimer">The denominator meter to use.</param>
        /// <remarks>
        ///     Creates a new HitPercentageGauge with externally tracked Meter and Timer, and uses the OneMinuteRate from the
        ///     MeterValue of the meters.
        /// </remarks>
        public HitPercentageGauge(IMeter hitMeter, ITimer totalTimer)
            : this(hitMeter, totalTimer, value => value.OneMinuteRate) { }

        /// <summary>
        ///     Initializes a new instance of the <see cref="HitPercentageGauge" /> class.
        /// </summary>
        /// <param name="hitMeter">The numerator meter to use.</param>
        /// <param name="totalTimer">The denominator timer to use.</param>
        /// <param name="meterRateFunc">
        ///     The function to extract a value from the MeterValue. Will be applied to both the numerator
        ///     and denominator meters.
        /// </param>
        /// <remarks>
        ///     Creates a new HitPercentageGauge with externally tracked Meter and Timer, and uses the provided meter rate function
        ///     to extract the value for the percentage.
        /// </remarks>
        public HitPercentageGauge(IMeter hitMeter, ITimer totalTimer, Func<MeterValue, double> meterRateFunc)
            : base(() => meterRateFunc(hitMeter.GetValueOrDefault()), () => meterRateFunc(totalTimer.GetValueOrDefault().Rate)) { }
    }
}