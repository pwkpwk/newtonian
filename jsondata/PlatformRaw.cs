using System.Text.Json;
using System.Text.Json.Serialization;

namespace benchmarks;

public class PlatformRaw
{
    private static readonly JsonSerializerOptions _options = new() { IncludeFields = true };
    
    public long Id;
    public long[]? Dependencies;
    public FoldType Type;

    public static PlatformRaw Parse(string json) => JsonDocument.Parse(json).RootElement.Deserialize<PlatformRaw>(_options);
    public override string ToString() => JsonSerializer.Serialize(this, _options);

    [JsonConverter(typeof(JsonStringEnumConverter<FoldType>))]
    public enum FoldType
    {
        Hilbert,
        Gravitational
    }
}