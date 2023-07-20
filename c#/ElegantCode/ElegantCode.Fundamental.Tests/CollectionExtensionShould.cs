using ElegantCode.Fundamental.Core.Utils;
using FluentAssertions;

namespace ElegantCode.Fundamental.Tests;

public class CollectionExtensionShould
{
    [Fact]
    public void IsAnyShould()
    {
        IEnumerable<string> li = null;
        li.IsAny(x => x == "a").Should().BeFalse();

        li = new List<string>() { "a", "b" };
        li.IsAny(x => x == "a").Should().BeTrue();
    }

    [Fact]
    public void ForeachShould()
    {
        IEnumerable<int> li = null;
        var expect = 0;
        li.Foreach(x => expect += x);
        expect.Should().Be(0);

        li = new int[0];
        expect = 0;
        li.Foreach(x => expect += x);
        expect.Should().Be(0);

        li = new[] { 1, 2, 3 };
        expect = 0;
        li.Foreach(x => expect += x);
        expect.Should().Be(6);
    }
}