using ElegantCode.Fundamental.Core.Presenter;
using FluentAssertions;
using Rpg.Core.Domain;
using Rpg.Core.Drivers;
using Rpg.Core.Dto;

namespace Rpg.Core.Tests;

public class CreateWorldShould
{
    [Fact]
    public void NewWorld()
    {
        var me = new Sprite();
        var worldId = Guid.NewGuid();
        var world = new World(worldId);

        world.Id.Should().Be(worldId);
        world.Elements.Should().BeEmpty();

        world.AddElement(me);
        world.Elements.Should().HaveCount(1);
        world.Elements.First().Should().Be(me);

        me.X.Should().Be(0);
        me.Y.Should().Be(0);

        var secondWorld = new World(worldId, new[] { me });

        secondWorld.Elements.First().Should().Be(me);
    }

    [Fact]
    public async Task GivenAUser_IWantCreateAWorld()
    {
        var worldDriver = new WorldDriver<WorldUseCaseResponse>(CreateAPresenter());
        var worldDriverRequest = new WorldDriverRequest(Guid.NewGuid(), Guid.NewGuid());
        var expect = await worldDriver.CreateWorld(worldDriverRequest);
        expect.Entity.Id.Should().Be(worldDriverRequest.Id);
    }

    private static SimplePresenter<WorldUseCaseResponse> CreateAPresenter() => new();

}