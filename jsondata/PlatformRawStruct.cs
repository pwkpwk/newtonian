using System.Text.Json;
using System.Text.Json.Serialization;

namespace dev.newtonian.jsondata;

public struct PlatformRawStruct
{
    private static readonly JsonSerializerOptions _options = new() { IncludeFields = true };
    
    public long Id;
    public long[]? Dependencies;
    public FoldType Type;

    public static PlatformRawStruct Parse(string json) => JsonDocument.Parse(json).RootElement.Deserialize<PlatformRawStruct>(_options);
    public override string ToString() => JsonSerializer.Serialize(this, _options);

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FoldType
    {
        Hilbert,
        Gravitational
    }
}