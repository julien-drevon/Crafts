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
        false.IsFalse().Should().BeTrue();
        true.IsFalse().Should().BeFalse();

        new Nullable<bool>(true).IsTrue().Should().BeTrue();
        new Nullable<bool>().IsTrue().Should().BeFalse();
        new Nullable<bool>(false).IsTrue().Should().BeFalse();

        new Nullable<bool>(true).IsFalseOrNull().Should().BeFalse();
        new Nullable<bool>().IsFalseOrNull().Should().BeTrue();
        new Nullable<bool>(false).IsFalseOrNull().Should().BeTrue();
    }

    [Fact]
    public void GuidIsEmpty()
    {
        (Guid.Empty).IsEmpty().Should().BeTrue();
        Guid.NewGuid().IsEmpty().Should().BeFalse();

        (Guid.Empty).IsNotEmpty().Should().BeFalse();
        Guid.NewGuid().IsNotEmpty().Should().BeTrue();
    }
}