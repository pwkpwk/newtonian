// See https://aka.ms/new-console-template for more information

using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;

const string sObject = "{\"don\":\"Pedro\",\"Don\":\"Condon\"}";
const string sArray = "[{\"don\":\"Pedro\"},{\"don\":\"Omar\"}]";

var jObject = JToken.Parse(sObject);
var jArray = JToken.Parse(sArray);

var jeObject = JsonDocument.Parse(sObject).RootElement;
var jeArray = JsonDocument.Parse(sArray).RootElement;

DonContract? obj = jObject.ToObject<DonContract>();
DonContract[]? arr = jArray.ToObject<DonContract[]>();

DonContract? eObj = jeObject.Deserialize<DonContract>();
DonContract[]? eArr = jeArray.Deserialize<DonContract[]>();

Console.WriteLine(jObject);
Console.WriteLine(jArray);
Console.WriteLine(jeObject);
Console.WriteLine(jeArray);

var sVortex = JsonSerializer.Serialize(new Vortex
{
    Fold = FoldType.SimpleFold,
    Count = 10000
});

Console.WriteLine($"Serialized = \"{sVortex}\"");

[DataContract]
class DonContract
{
    [DataMember(Name = "don", IsRequired = true)]
    public string? Don { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter<FoldType>))]
enum FoldType
{
    Vortex,
    SimpleFold,
    Unbounded
}

[DataContract]
class Vortex
{
    [DataMember] public int Count { get; set; }
    [DataMember] public FoldType Fold { get; set; }
}