﻿// Copyright (c) Allan Hardy. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using App.Metrics.Data;
using App.Metrics.Infrastructure;
using Newtonsoft.Json;

namespace App.Metrics.Formatters.Json.Converters
{
    public class EnvironmentInfoConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) { return typeof(EnvironmentInfo) == objectType; }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var source = serializer.Deserialize<Dictionary<string, string>>(reader);

            var target = new EnvironmentInfo(source);
            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var source = (EnvironmentInfo)value;

            var target = source.Entries.ToDictionary(entry => entry.Name, entry => entry.Value);

            serializer.Serialize(writer, target);
        }
    }
}