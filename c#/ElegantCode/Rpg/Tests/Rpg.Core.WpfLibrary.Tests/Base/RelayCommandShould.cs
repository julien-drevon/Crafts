using Rpg.Core.WpfLibrary.Base;
using System.Text;

namespace Rpg.Core.WpfLibrary.Tests.Base;

public class RelayCommandShould
{
    [Fact]
    public void GivenARelayCommand_WhenCanExecuteIsTrue_ExecuteMyCommand()
    {
        var assert = new StringBuilder("42");
        bool isCanExecuteRaised = false;

        var myCommand = new BaseCommand<StringBuilder>(x =>
        {
            isCanExecuteRaised = true;
            return x.ToString() == "42";
        }, x => x.Append("1"));

        myCommand.CanExecute(assert);
        myCommand.Execute(assert);

        isCanExecuteRaised.Should().BeTrue();
        assert.ToString().Should().Be("421");
    }

    [Fact]
    public void GivenARelayCommand_WhenCanExecuteAnjdExecuteAreNull_NotRaisedException()
    {
        var myCommand = new BaseCommand<string>(null, null);
        myCommand.CanExecute("42");
        myCommand.Execute("42");
    }
}