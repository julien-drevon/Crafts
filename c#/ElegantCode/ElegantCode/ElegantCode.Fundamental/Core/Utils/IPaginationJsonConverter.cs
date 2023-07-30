using System.Text.Json;
using System.Text.Json.Serialization;

namespace ElegantCode.Fundamental.Core.Utils
{
    public class IPaginationJsonConverter : JsonConverter<IPagination>
    {
        public override IPagination Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<Pagination>(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, IPagination value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}