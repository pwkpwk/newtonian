using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using dev.newtonian.jsondata;

namespace dev.newtonian.benchmarks;

[SimpleJob(RuntimeMoniker.Net60, baseline: true), SimpleJob(RuntimeMoniker.Net80)]
[MemoryDiagnoser]
public class JsonParseBenchmarks
{
    private string _jsonData = string.Empty;

    [Params(10, 250)] public int DependenciesLength = 0;

    [GlobalSetup]
    public void SetUpBenchmarks()
    {
        NewtonsoftRaw source = new()
        {
            Id = 1010,
            Dependencies = new long[DependenciesLength],
            Type = NewtonsoftRaw.FoldType.Gravitational
        };

        for (int n = 0; n < DependenciesLength; ++n)
        {
            source.Dependencies[n] = n;
        }

        _jsonData = source.ToString();
        Console.WriteLine($"Serialized by Newtonsoft: {_jsonData}");
        var platform = PlatformRaw.Parse(_jsonData);
        var sPlatform = platform.ToString();
        Console.WriteLine($"Serialized by Platform: {sPlatform}");
        if (platform.Type != PlatformRaw.FoldType.Gravitational)
        {
            Console.Error.WriteLine("Cannot load JSON data with the .Net serialization API");
            throw new InvalidOperationException();
        }
    }

    [Benchmark]
    public NewtonsoftRaw NewtonsoftRawParse() => NewtonsoftRaw.Parse(_jsonData);

    [Benchmark]
    public PlatformRaw PlatformRawParse() => PlatformRaw.Parse(_jsonData);

    [Benchmark]
    public NewtonsoftRawStruct NewtonsoftRawStructParse() => NewtonsoftRawStruct.Parse(_jsonData);
    
    [Benchmark]
    public PlatformRawStruct PlatformRawStructParse() => PlatformRawStruct.Parse(_jsonData);

    [Benchmark]
    public NewtonsoftProperties NewtonsoftPropertiesParse() => NewtonsoftProperties.Parse(_jsonData);

    [Benchmark]
    public PlatformProperties PlatformPropertiesParse() => PlatformProperties.Parse(_jsonData);
}