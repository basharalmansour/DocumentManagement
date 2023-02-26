using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Extension;

public class DictionaryJsonConverter : JsonConverter<Dictionary<string, string>>
{
    public override Dictionary<string, string> ReadJson(JsonReader reader, Type objectType, Dictionary<string, string> existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override void WriteJson(JsonWriter writer, Dictionary<string, string> value, JsonSerializer serializer)
    {
        var jo = new JObject();
        for (var i = 1; i <= value?.Count; i++)
        {
            jo.Add(value.ElementAt(i - 1).Key, JToken.FromObject(value.ElementAt(i - 1).Value));
        }

        jo.WriteTo(writer);
    }
}
