using dev.newtonian.jsondata;

namespace dev.newtonian.test;

[TestFixture]
public class SerializationTests
{
    [Test]
    public void NewtonsoftRaw_ToStringAndLoad_SameValues()
    {
        var source = new NewtonsoftRaw
        {
            Type = NewtonsoftRaw.FoldType.Gravitational,
            Id = 102,
            Dependencies = [1, 2, 3, 4, 5]
        };

        var loaded = NewtonsoftRaw.Parse(source.ToString());
        
        Assert.That(loaded.Id, Is.EqualTo(source.Id));
        Assert.That(loaded.Dependencies, Is.EquivalentTo(source.Dependencies));
        Assert.That(loaded.Type, Is.EqualTo(source.Type));
    }

    [Test]
    public void NewtonsoftProperties_ToStringAndLoad_SameValues()
    {
        var source = new NewtonsoftProperties
        {
            Type = NewtonsoftProperties.FoldType.Gravitational,
            Id = 102,
            Dependencies = [1, 2, 3, 4, 5]
        };

        var loaded = NewtonsoftProperties.Parse(source.ToString());
        
        Assert.That(loaded.Id, Is.EqualTo(source.Id));
        Assert.That(loaded.Dependencies, Is.EquivalentTo(source.Dependencies));
        Assert.That(loaded.Type, Is.EqualTo(source.Type));
    }

    [Test]
    public void PlatformRaw_ToStringAndLoad_SameValues()
    {
        var source = new PlatformRaw
        {
            Type = PlatformRaw.FoldType.Gravitational,
            Id = 102,
            Dependencies = [1, 2, 3, 4, 5]
        };

        var loaded = PlatformRaw.Parse(source.ToString());
        
        Assert.That(loaded.Id, Is.EqualTo(source.Id));
        Assert.That(loaded.Dependencies, Is.EquivalentTo(source.Dependencies));
        Assert.That(loaded.Type, Is.EqualTo(source.Type));
    }

    [Test]
    public void PlatformProperties_ToStringAndLoad_SameValues()
    {
        var source = new PlatformProperties
        {
            Type = PlatformProperties.FoldType.Gravitational,
            Id = 102,
            Dependencies = [1, 2, 3, 4, 5]
        };

        var loaded = PlatformProperties.Parse(source.ToString());
        
        Assert.That(loaded.Id, Is.EqualTo(source.Id));
        Assert.That(loaded.Dependencies, Is.EquivalentTo(source.Dependencies));
        Assert.That(loaded.Type, Is.EqualTo(source.Type));
    }

    [Test]
    public void NewtonsoftSerialize_PlatformRawLoad_SameValues()
    {
        var source = new NewtonsoftRaw
        {
            Type = NewtonsoftRaw.FoldType.Gravitational,
            Id = 102,
            Dependencies = [1, 2, 3, 4, 5]
        };

        var loaded = PlatformRaw.Parse(source.ToString());
        
        Assert.That(loaded.Id, Is.EqualTo(source.Id));
        Assert.That(loaded.Dependencies, Is.EquivalentTo(source.Dependencies));
        Assert.That(loaded.Type, Is.EqualTo(PlatformRaw.FoldType.Gravitational));
    }

    [Test]
    public void NewtonsoftSerialize_PlatformPropertiesLoad_SameValues()
    {
        var source = new NewtonsoftRaw
        {
            Type = NewtonsoftRaw.FoldType.Gravitational,
            Id = 102,
            Dependencies = [1, 2, 3, 4, 5]
        };

        var loaded = PlatformProperties.Parse(source.ToString());
        
        Assert.That(loaded.Id, Is.EqualTo(source.Id));
        Assert.That(loaded.Dependencies, Is.EquivalentTo(source.Dependencies));
        Assert.That(loaded.Type, Is.EqualTo(PlatformProperties.FoldType.Gravitational));
    }

    [Test]
    public void PlatformRawSerialize_NewtonsoftPropertiesLoad_SameValues()
    {
        var source = new PlatformRaw
        {
            Type = PlatformRaw.FoldType.Gravitational,
            Id = 102,
            Dependencies = [1, 2, 3, 4, 5]
        };

        var loaded = NewtonsoftProperties.Parse(source.ToString());
        
        Assert.That(loaded.Id, Is.EqualTo(source.Id));
        Assert.That(loaded.Dependencies, Is.EquivalentTo(source.Dependencies));
        Assert.That(loaded.Type, Is.EqualTo(NewtonsoftProperties.FoldType.Gravitational));
    }
}