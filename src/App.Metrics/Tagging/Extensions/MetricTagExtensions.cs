﻿// <copyright file="MetricTagExtensions.cs" company="Allan Hardy">
// Copyright (c) Allan Hardy. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;

// ReSharper disable CheckNamespace
namespace App.Metrics.Tagging
    // ReSharper restore CheckNamespace
{
    public static class MetricTagExtensions
    {
        public static MetricTags FromDictionary(this Dictionary<string, string> source)
        {
            if (source == null)
            {
                return MetricTags.Empty;
            }

            var tags = source.Keys.ToArray();
            var values = source.Values.ToArray();
            return new MetricTags(tags, values);
        }

        public static Dictionary<string, string> ToDictionary(this MetricTags source)
        {
            if (source.Count == 0)
            {
                return new Dictionary<string, string>();
            }

            var keys = source.Keys;
            var values = source.Values;

            var target = new Dictionary<string, string>();

            for (var i = 0; i < keys.Length; i++)
            {
                target.Add(keys[i], values[i]);
            }

            return target;
        }
    }
}