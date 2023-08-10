namespace ElegantCode.Fundamental.Tests;

public class ErrorShould
{
    [Fact]
    public void Error_steps()
    {
        var token = Guid.NewGuid();
        var assert = new Error(token, message: "");

        assert.CorrelationToken.Should().Be(token);
        assert.Message.Should().BeEmpty();
        assert.IsOnError().Should().BeFalse();
        assert.IsNotOnError().Should().BeTrue();

        assert.AddError(message: "test1");
        assert.Message.Should().Be("test1");
        assert.AddError(null);
        assert.Message.Should().Be("test1");
        assert.IsOnError().Should().BeTrue();
        assert.IsNotOnError().Should().BeFalse();

        assert = new Error(token, errors: new[] { new Error(token, "test1"), new Error(token, "test2") });
        assert.Message.Should().BeEquivalentTo("test1" + Environment.NewLine + "test2");
        assert.IsOnError().Should().BeTrue();
        assert.IsNotOnError().Should().BeFalse();

        /***************** Validation Workflow ***************************/
        (object UseCaseQuery, Error Error) assert2 = new(null, null);
        assert2.IsNotOnError().Should().BeTrue();
        assert2 = new(null, new Error(Guid.NewGuid(), "Erreur"));
        assert2.IsOnError().Should().BeTrue();
    }
}