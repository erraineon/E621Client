using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace E621
{
    internal class RubyDateTimeConverter : JsonConverter
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var value = JObject.Load(reader);
            var datetime = Epoch.AddSeconds((int) value["s"]);
            return datetime;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }
    }
}