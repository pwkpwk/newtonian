using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace dev.newtonian.jsondata;

[DataContract]
public struct NewtonsoftRawStruct
{
    [DataMember] public long Id;
    [DataMember] public long[]? Dependencies;

    [DataMember, JsonConverter(typeof(StringEnumConverter))]
    public FoldType Type;

    public override string ToString() => JsonConvert.SerializeObject(this);
    public static NewtonsoftRawStruct Parse(string json) => JToken.Parse(json).ToObject<NewtonsoftRawStruct>();

    public enum FoldType
    {
        Hilbert,
        Gravitational
    }
}