using System.ComponentModel;

namespace Rpg.Core.WpfLibrary.Tests.Base;

public class SpriteViewModelShould
{
    [Fact]
    public void SpriteMovingNotify()
    {
        var viewModel = new SpriteViewModel();

        var isMovingX = false;
        PropertyChangedEventHandler verifyMoveXFunction = (object o, PropertyChangedEventArgs e) =>
        {
            isMovingX = true;
            e.PropertyName.Should().Be(nameof(viewModel.X));
        };
        viewModel.PropertyChanged += verifyMoveXFunction;

        viewModel.X = 1;
        isMovingX.Should().BeTrue();
        viewModel.X.Should().Be(1);
        viewModel.PropertyChanged -= verifyMoveXFunction;

        var isMovingY = false;
        PropertyChangedEventHandler verifyMoveYFunction = (object o, PropertyChangedEventArgs e) =>
        {
            isMovingY = true;
            e.PropertyName.Should().Be(nameof(viewModel.Y));
        };
        viewModel.PropertyChanged += verifyMoveYFunction;

        viewModel.Y = 1;
        isMovingY.Should().BeTrue();
        viewModel.Y.Should().Be(1);
        viewModel.PropertyChanged -= verifyMoveYFunction;

        viewModel = new SpriteViewModel(5, 4);
        viewModel.X.Should().Be(5);
        viewModel.Y.Should().Be(4);
    }

    [Fact]
    public void SpriteHadBox()
    {
        var viewModel = new SpriteViewModel(width: 5, height: 6);

        viewModel.Width.Should().Be(5);
        viewModel.Height.Should().Be(6);

        var isChangingWidth = false;
        PropertyChangedEventHandler verifyChangingWidthFunction = (object o, PropertyChangedEventArgs e) =>
        {
            isChangingWidth = true;
            e.PropertyName.Should().Be(nameof(viewModel.Width));
        };
        viewModel.PropertyChanged += verifyChangingWidthFunction;

        viewModel.Width = 6;
        isChangingWidth.Should().BeTrue();
        viewModel.Width.Should().Be(6);
        viewModel.PropertyChanged -= verifyChangingWidthFunction;

        var isChangingHeight = false;
        PropertyChangedEventHandler verifyChangingHeightFunction = (object o, PropertyChangedEventArgs e) =>
        {
            isChangingHeight = true;
            e.PropertyName.Should().Be(nameof(viewModel.Height));
        };
        viewModel.PropertyChanged += verifyChangingHeightFunction;

        viewModel.Height = 5;
        isChangingHeight.Should().BeTrue();
        viewModel.Height.Should().Be(5);
        viewModel.PropertyChanged -= verifyChangingHeightFunction;
    }
}

public class WorldPresenterShould
{
    [Fact]
    public void ConvertWorld()
    {
    }
}