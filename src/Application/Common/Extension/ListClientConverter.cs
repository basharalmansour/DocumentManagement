using CleanArchitecture.Application.Common.Dtos.POI.Cart.RequestDtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class ListClientConverter : JsonConverter<IList<PaxDto>>
{
    public override void WriteJson(JsonWriter writer, IList<PaxDto>? value, JsonSerializer serializer)
    {
        var jo = new JObject();
        for (var i = 1; i <= value?.Count; i++)
        {
            jo.Add(i.ToString(), JToken.FromObject(value[i - 1]));
        }

        jo.WriteTo(writer);
    }

    public override IList<PaxDto>? ReadJson(JsonReader reader, Type objectType, IList<PaxDto>? existingValue,
        bool hasExistingValue,
        JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}