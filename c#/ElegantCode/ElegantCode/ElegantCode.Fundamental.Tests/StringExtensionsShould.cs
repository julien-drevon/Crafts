namespace ElegantCode.Fundamental.Tests;

public class StringExtensionsShould
{
    private static string GetExpectLine =>
        @"1," + Environment.NewLine + "2," + Environment.NewLine + "3," + Environment.NewLine + "4," + Environment.NewLine + "5," + Environment.NewLine + "6";

    [Fact]
    public void TestIsNotEmpty()
    {
        (null as string).IsNotNullOrEmpty().Should().BeFalse();
        ("a").IsNotNullOrEmpty().Should().BeTrue();
        ("").IsNotNullOrEmpty().Should().BeFalse();
    }

    [Fact]
    public void TestJoinString()
    {
        var myListOfString = new[] { "1", "2", "3", "4", "5", "6" };

        var noAddLineAssert = myListOfString.ToJoinString(isAddLine: false, concatString: "+");
        noAddLineAssert.Should().Be("1+2+3+4+5+6");

        noAddLineAssert = myListOfString.ToJoinString(isAddLine: false, concatString: "+-+");
        noAddLineAssert.Should().Be("1+-+2+-+3+-+4+-+5+-+6");

        var addLineAssert = myListOfString.ToJoinString(isAddLine: true, concatString: ",");
        addLineAssert.Should().Be(GetExpectLine);

        var joinIntByFactory = new[] { 0, 1, 2, 3, 4, 5 }.ToJoinString(isAddLine: true, concatString: ",", transformToStringFactory: x => (x + 1).ToString());
        joinIntByFactory.Should().Be(GetExpectLine);

        (new[] { string.Empty, null }).ToJoinString(isAddLine: false, concatString: ",")
                                      .Should().BeEmpty();
        (null as string).ToJoinString(isAddLine: false, concatString: "+")
                        .Should().BeEmpty();
    }
}