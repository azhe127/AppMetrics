﻿// Copyright (c) Allan Hardy. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace App.Metrics.Formatters.Json
{
    public sealed class MetricData
    {
        [JsonProperty(Order = 3)]
        public IEnumerable<MetricsContext> Contexts { get; set; } = new MetricsContext[0];

        [JsonProperty(Order = 2)]

        public IDictionary<string, string> Environment { get; set; }

        [JsonProperty(Order = 1)]
        public DateTime Timestamp { get; set; }
    }
}