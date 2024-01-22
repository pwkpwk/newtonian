using BenchmarkDotNet.Attributes;
using benchmarks;
using dev.newtonian.jsondata;

namespace dev.newtonian.benchmarks;

public class JsonParseBenchmarks
{
    private string? _jsonData;

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
        var sPlatform = PlatformRaw.Parse(_jsonData).ToString();
        Console.WriteLine($"Serialized by Platform: {sPlatform}");
    }

    [Benchmark]
    public void NewtonsoftRawParse()
    {
        var restored = NewtonsoftRaw.Parse(_jsonData);
    }

    [Benchmark]
    public void PlatformRawParse()
    {
        var restored = PlatformRaw.Parse(_jsonData);
    }

    [Benchmark]
    public void NewtonsoftPropertiesParse()
    {
        var restored = NewtonsoftProperties.Parse(_jsonData);
    }

    [Benchmark]
    public void PlatformPropertiesParse()
    {
        var restored = PlatformProperties.Parse(_jsonData);
    }
}