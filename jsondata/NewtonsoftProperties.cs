using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace dev.newtonian.jsondata;

[DataContract]
public class NewtonsoftProperties
{
    [DataMember] public long Id { get; set; }
    [DataMember] public long[]? Dependencies { get; set; } 

    [DataMember, JsonConverter(typeof(StringEnumConverter))]
    public FoldType Type { get; set; }

    public override string ToString() => JsonConvert.SerializeObject(this);
    public static NewtonsoftProperties Parse(string json) => JToken.Parse(json).ToObject<NewtonsoftProperties>();

    public enum FoldType
    {
        Hilbert,
        Gravitational
    }
}