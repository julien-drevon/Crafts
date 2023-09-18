using System.Text;

namespace Rpg.Drivers.Wpf.Core.Tests;

public class RelayCommandShould
{
    [Fact]
    public void GivenARelayCommand_WhenCanExecuteIsTrue_ExecuteMyCommand()
    {
        var assert = new StringBuilder("42");
        bool isCanExecuteRaised = false;

        var myCommand = new BaseCommand<StringBuilder>(x =>
        {
            isCanExecuteRaised |= true;
            return x.ToString() == "42";
        }, x => x.Append("1"));

        myCommand.CanExecute(assert);
        myCommand.Execute(assert);

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