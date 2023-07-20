using ElegantCode.Fundamental.Core.Utils;
using FluentAssertions;

namespace ElegantCode.Fundamental.Tests;

public class StringExtensionsShoul
{

    [Fact]
    public void TestJoinString()
    {
        var myListOfString = new[] { "1", "2", "3", "4", "5", "6" };

        var noAddLineAssert = myListOfString.JoinString(false, "+");
        noAddLineAssert.Should().Be("1+2+3+4+5+6");
        noAddLineAssert = myListOfString.JoinString(false, "+-+");
        noAddLineAssert.Should().Be("1+-+2+-+3+-+4+-+5+-+6");

        var addLineAssert = myListOfString.JoinString(true, ",");
        var addLineWithFactoryAssert = new[] { 0, 1, 2, 3, 4, 5 }.JoinString(true, ",", x => (x + 1).ToString());
        var expectAddLine = @"1," + Environment.NewLine + "2," + Environment.NewLine + "3," + Environment.NewLine + "4," + Environment.NewLine + "5," + Environment.NewLine + "6";
        addLineAssert.Should().Be(expectAddLine);
        addLineWithFactoryAssert.Should().Be(expectAddLine);

        var testWithNullAndEmptyValue = (new[] { string.Empty, null }).JoinString(false, ",");
        testWithNullAndEmptyValue.Should().BeEmpty();
        string[] myNullList = null;
        testWithNullAndEmptyValue = myNullList.JoinString(false, "+");
        testWithNullAndEmptyValue.Should().BeEmpty();
    }
}