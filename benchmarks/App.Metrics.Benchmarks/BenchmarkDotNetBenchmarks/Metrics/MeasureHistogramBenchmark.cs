﻿// Copyright (c) Allan Hardy. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using App.Metrics.Benchmarks.Support;
using BenchmarkDotNet.Attributes;

namespace App.Metrics.Benchmarks.BenchmarkDotNetBenchmarks.Metrics
{
    public class MeasureHistogramBenchmark : DefaultBenchmarkBase
    {
        [Benchmark]
        public void UpdateAlgorithmR()
        {
            Fixture.Metrics.Measure.Histogram.Update(
                MetricOptions.Histogram.OptionsAlgorithmR,
                Fixture.Rnd.Next(0, 1000),
                Fixture.RandomUserValue);
        }

        [Benchmark]
        public void UpdateForwardDecaying()
        {
            Fixture.Metrics.Measure.Histogram.Update(
                MetricOptions.Histogram.OptionsForwardDecaying,
                Fixture.Rnd.Next(0, 1000),
                Fixture.RandomUserValue);
        }

        [Benchmark]
        public void UpdateSlidingWindow()
        {
            Fixture.Metrics.Measure.Histogram.Update(
                MetricOptions.Histogram.OptionsSlidingWindow,
                Fixture.Rnd.Next(0, 1000),
                Fixture.RandomUserValue);
        }
    }
}