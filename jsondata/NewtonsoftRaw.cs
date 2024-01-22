using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace dev.newtonian.jsondata;

[DataContract]
public class NewtonsoftRaw
{
    [DataMember] public long Id;
    [DataMember] public long[]? Dependencies;

    [DataMember, System.Text.Json.Serialization.JsonConverter(typeof(StringEnumConverter))]
    public FoldType Type;

    public override string ToString() => JsonConvert.SerializeObject(this);
    public static NewtonsoftRaw Parse(string json) => JToken.Parse(json).ToObject<NewtonsoftRaw>();

    public enum FoldType
    {
        Hilbert,
        Gravitational
    }
}