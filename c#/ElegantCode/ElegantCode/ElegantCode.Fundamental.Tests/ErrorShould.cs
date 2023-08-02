namespace ElegantCode.Fundamental.Tests;

public class ErrorShould
{
    [Fact]
    public void TestErrorClass()
    {
        var token = Guid.NewGuid();
        var assert = new Error(token, message: "");

        assert.CorrelationToken.Should().Be(token);
        assert.Message.Should().BeEmpty();
        assert.IsError().Should().BeFalse();

        assert.AddError(message: "test1");
        assert.Message.Should().Be("test1");
        assert.AddError(null);
        assert.Message.Should().Be("test1");

        assert = new Error(token, errors: new[] { new Error(token, "test1"), new Error(token, "test2") });
        assert.Message.Should().BeEquivalentTo("test1" + Environment.NewLine + "test2");
    }
}