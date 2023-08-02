using FluentAssertions;
using KataExemples.TennisClass;
using System.Text;

namespace KataExemples;

public class PolynomeShould
{
    [Fact]
    public void TransformMyPolynome()
    {
        Transform.ToPolynome(0).Should().Be("0");
        Transform.ToPolynome(1).Should().Be("1");
        Transform.ToPolynome(1, 0).Should().Be("x");
        Transform.ToPolynome(1, 1).Should().Be("x + 1");
        Transform.ToPolynome(1, -1).Should().Be("x - 1");
        Transform.ToPolynome(-2, -1, -1).Should().Be("-2x^2 - x - 1");
        Transform.ToPolynome(-4, 2, -1, -1).Should().Be("-4x^3 + 2x^2 - x - 1");
        Transform.ToPolynome().Should().BeEmpty();
        Transform.ToPolynome(null).Should().BeEmpty();
    }
}
