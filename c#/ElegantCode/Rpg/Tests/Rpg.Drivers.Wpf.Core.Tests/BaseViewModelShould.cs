namespace Rpg.Drivers.Wpf.Core.Tests;

public class BaseViewModelShould
{
    [Fact]
    public void GivenABasicBaseViewModel_WhenIRisingOnePropertie_ThenShouldBeNotifing()
    {
        var isRising = false;
        var basicViewModel = new BasicViewModel();
        basicViewModel.PropertyChanged += (o, e) =>
        {
            isRising = true;
            e.PropertyName.Should().Be(nameof(basicViewModel.Name));
        };

        basicViewModel.Name = "42";

        isRising.Should().BeTrue();
    }

    [Fact]
    public void GivenABasicBaseViewModel_WhenIChangedValueWithoutHandling_ThenShouldNotRaiseException()
    {
        var basicViewModel = new BasicViewModel();
        basicViewModel.Name = "42";
        basicViewModel.Name.Should().Be("42");
    }
}

public class BasicViewModel : BaseViewModel
{
    private string name;

    public string Name
    {
        get => name; set

        {
            name = value;
            this.OnPropertyChanged();
        }
    }
}