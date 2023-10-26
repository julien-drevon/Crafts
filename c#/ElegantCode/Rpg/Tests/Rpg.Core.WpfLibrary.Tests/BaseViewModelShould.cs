using Rpg.Drivers.Wpf.Core.Tests.Dummy;

namespace Rpg.Drivers.Wpf.Core.Tests;

public class BaseViewModelShould
{
    [Fact]
    public void GivenABasicBaseViewModel_WhenIRisingOnePropertie_ThenShouldBeNotifing()
    {
        var isRising = false;
        var basicViewModel = new DummyViewModel();
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
        var basicViewModel = new DummyViewModel();
        basicViewModel.Name = "42";
        basicViewModel.Name.Should().Be("42");
    }

    [Fact]
    public void GivenABasicBaseViewModelPropertie_WhenIRisingOnePropertieWithNoActionInMethodToNotify_ThenShouldBeNotifingAndNotNullException()
    {
        var isRising = false;
        var basicViewModel = new DummyViewModel();
        basicViewModel.PropertyChanged += (o, e) =>
        {
            isRising = true;
            e.PropertyName.Should().Be(nameof(basicViewModel.TestNullAction));
        };

        basicViewModel.TestNullAction = "42";

        isRising.Should().BeTrue();
    }
}