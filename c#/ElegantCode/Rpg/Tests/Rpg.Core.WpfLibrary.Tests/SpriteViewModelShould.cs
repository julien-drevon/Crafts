using Rpg.Core.Domain;
using Rpg.Core.WpfLibrary.Base;
using Rpg.Drivers.Wpf.Core.Tests.Dummy;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;

namespace Rpg.Core.WpfLibrary.Tests.Base;

public class SpriteViewModelShould
{
    [Fact]
    public void SpriteMovingNotify()
    {
        var viewModel = new SpriteViewModel();

        var isMovingX = false;
        PropertyChangedEventHandler verifyMoveX = (object o, PropertyChangedEventArgs e) =>
        {
            isMovingX = true;
            e.PropertyName.Should().Be(nameof(viewModel.X));
        };
        viewModel.PropertyChanged += verifyMoveX;

        viewModel.X = 1;
        isMovingX.Should().BeTrue();
        viewModel.X.Should().Be(1);
        viewModel.PropertyChanged -= verifyMoveX;

        var isMovingY = false;
        PropertyChangedEventHandler verifyMoveY = (object o, PropertyChangedEventArgs e) =>
        {
            isMovingY = true;
            e.PropertyName.Should().Be(nameof(viewModel.Y));
        };
        viewModel.PropertyChanged += verifyMoveY;

        viewModel.Y = 1;
        isMovingY.Should().BeTrue();
        viewModel.Y.Should().Be(1);
        viewModel.PropertyChanged -= verifyMoveY;


        viewModel = new SpriteViewModel(5, 4);
        viewModel.X.Should().Be(5);
        viewModel.Y.Should().Be(4);

    }
}

