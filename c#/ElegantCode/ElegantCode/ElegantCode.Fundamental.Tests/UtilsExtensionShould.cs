namespace ElegantCode.Fundamental.Tests;

public class UtilsExtensionShould
{
    [Fact]
    public void Object_IsNull()
    {
        (null as object).IsNull().Should().BeTrue();
        new object().IsNull().Should().BeFalse();
    }

    [Fact]
    public void Object_IsNotNull()
    {
        (null as object).IsNotNull().Should().BeFalse();
        new object().IsNotNull().Should().BeTrue();
    }
}