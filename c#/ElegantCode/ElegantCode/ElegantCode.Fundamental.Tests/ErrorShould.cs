namespace ElegantCode.Fundamental.Tests;

public class ErrorShould
{
    private const string MessageDeTest1 = "test1";
    private const string MessageDeTest2 = "test2";

    [Fact]
    public void Error_steps()
    {
        var token = Guid.NewGuid();
        var assert = new Error(token, message: "");

        assert.CorrelationToken.Should().Be(token);
        assert.Message.Should().BeEmpty();
        assert.IsOnError().Should().BeFalse();
        assert.IsNotOnError().Should().BeTrue();

        assert.AddError(message: MessageDeTest1);
        assert.Message.Should().Be(MessageDeTest1);
        assert.AddError(null);
        assert.Message.Should().Be(MessageDeTest1);
        assert.IsOnError().Should().BeTrue();
        assert.IsNotOnError().Should().BeFalse();

        assert = new Error(token, errors: new[] { new Error(token, MessageDeTest1), new Error(token, MessageDeTest2) });
        assert.Message.Should().BeEquivalentTo(MessageDeTest1 + Environment.NewLine + MessageDeTest2);
        assert.IsOnError().Should().BeTrue();
        assert.IsNotOnError().Should().BeFalse();

        /***************** Validation Workflow ***************************/
        (object UseCaseQuery, Error Error) assert2 = new(null, null);
        assert2.IsNotOnError().Should().BeTrue();
        assert2 = new(null, new Error(Guid.NewGuid(), "Erreur"));
        assert2.IsOnError().Should().BeTrue();
    }
}