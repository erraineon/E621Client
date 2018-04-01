using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace E621
{
    internal class TagsLookupConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var isCategoryTags = reader.TokenType == JsonToken.StartObject;
            var lookup = isCategoryTags
                ? serializer.Deserialize<IDictionary<string, string[]>>(reader)
                    .SelectMany(pair => pair.Value, (pair, tag) => (category: pair.Key, tag))
                    .ToLookup(tuple => tuple.category, tuple => tuple.tag)
                : ((string) reader.Value).Split(' ').ToLookup(_ => default(string));
            return lookup;
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}