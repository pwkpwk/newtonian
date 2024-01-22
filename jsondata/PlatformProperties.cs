using System.Text.Json;
using System.Text.Json.Serialization;

namespace dev.newtonian.jsondata;

public class PlatformProperties
{
    public long Id { get; set; }
    public long[]? Dependencies { get; set; }
    public FoldType Type { get; set; }

    public static PlatformProperties Parse(string json) => JsonDocument.Parse(json).RootElement.Deserialize<PlatformProperties>();
    public override string ToString() => JsonSerializer.Serialize(this);

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FoldType
    {
        Hilbert,
        Gravitational
    }
}