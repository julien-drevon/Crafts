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

    [Fact]
    public void Bool_IsTrue()
    {
        true.IsTrue().Should().BeTrue();
        false.IsTrue().Should().BeFalse();
        false.IsFalse().Should().BeTrue();
        true.IsFalse().Should().BeFalse();

        new Nullable<bool>(true).IsTrue().Should().BeTrue();
        new Nullable<bool>().IsTrue().Should().BeFalse();
        new Nullable<bool>(false).IsTrue().Should().BeFalse();

        new Nullable<bool>(true).IsFalse().Should().BeFalse();
        new Nullable<bool>().IsFalse().Should().BeTrue();
        new Nullable<bool>(false).IsFalse().Should().BeTrue();
    }
}