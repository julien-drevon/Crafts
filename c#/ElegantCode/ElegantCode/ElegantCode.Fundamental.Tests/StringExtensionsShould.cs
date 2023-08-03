namespace ElegantCode.Fundamental.Tests;

public class StringExtensionsShould
{
    [Fact]
    public void TestJoinString()
    {
        var myListOfString = new[] { "1", "2", "3", "4", "5", "6" };

        var noAddLineAssert = myListOfString.ToJoinString(addLine: false, concatString: "+");
        noAddLineAssert.Should().Be("1+2+3+4+5+6");

        noAddLineAssert = myListOfString.ToJoinString(addLine: false, concatString: "+-+");
        noAddLineAssert.Should().Be("1+-+2+-+3+-+4+-+5+-+6");

        var addLineAssert = myListOfString.ToJoinString(addLine: true, ",");
        var addLineWithFactoryAssert = new[] { 0, 1, 2, 3, 4, 5 }.ToJoinString(addLine: true, concatString: ",", transformToString: x => (x + 1).ToString());
        var expectAddLine = @"1," + Environment.NewLine + "2," + Environment.NewLine + "3," + Environment.NewLine + "4," + Environment.NewLine + "5," + Environment.NewLine + "6";

        addLineAssert.Should().Be(expectAddLine);
        addLineWithFactoryAssert.Should().Be(expectAddLine);

        (new[] { string.Empty, null }).ToJoinString(addLine: false, concatString: ",")
                                      .Should().BeEmpty();
        (null as string).ToJoinString(addLine: false, concatString: "+")
                        .Should().BeEmpty();
    }

    [Fact]
    public void TestIsNotNullOrEmpty()
    {
        (null as string).IsNotNullOrEmpty().Should().BeFalse();
        ("a").IsNotNullOrEmpty().Should().BeTrue();
        ("").IsNotNullOrEmpty().Should().BeFalse();
    }
}