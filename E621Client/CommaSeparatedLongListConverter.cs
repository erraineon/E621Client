using System;
using System.Linq;
using Newtonsoft.Json;

namespace E621
{
    internal class CommaSeparatedLongListConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var longs = ((string) reader.Value)
                .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();
            return longs;
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}