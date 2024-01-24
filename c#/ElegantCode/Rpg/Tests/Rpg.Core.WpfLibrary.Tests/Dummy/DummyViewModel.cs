using Rpg.Core.WpfLibrary.Base;

namespace Rpg.Drivers.Wpf.Core.Tests.Dummy;

public class DummyViewModel : BaseViewModel
{
    private string name;
    private string testNullAction;

    public string Name
    {
        get => name;

        set { OnPropertyChanged(() => name = value); }
    }

    public string TestNullAction
    {
        get => testNullAction;

        set
        {
            testNullAction = value;
            OnPropertyChanged();
        }
    }
}