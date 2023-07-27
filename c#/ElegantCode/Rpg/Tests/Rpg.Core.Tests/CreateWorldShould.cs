using Rpg.Core.Tests.Fakes;

namespace Rpg.Core.Tests;

public class CreateWorldShould
{
    [Fact]
    public async Task GivenAUser_IWantCreateAWorld()
    {
        var worldId = Guid.NewGuid();
        var newWorld = await CreateNewWorldUseCase(worldId);

        newWorld.Entity.Id.Should().Be(worldId);
    }

    [Fact]
    public void NewWorld()
    {
        var meInTheWorld = new Sprite();
        var worldId = Guid.NewGuid();
        var firstWorld = new World(worldId);

        firstWorld.Id.Should().Be(worldId);
        firstWorld.Elements.Should().BeEmpty();

        firstWorld.AddElement(new[] { meInTheWorld });
        firstWorld.Elements.First().Should().Be(meInTheWorld);

        meInTheWorld.X.Should().Be(0);
        meInTheWorld.Y.Should().Be(0);

        var secondWorld = new World(worldId, new[] { meInTheWorld });
        secondWorld.Elements.First().Should().Be(meInTheWorld);
    }

    [Fact]
    public async Task GivenANewWorld_IWantToAddItems()
    {
        var worldId = Guid.NewGuid();
        await CreateNewWorldUseCase(worldId);
        var spritesToAdd = new Sprite[] { new(10, 10), new(0, 0) };
        var world = await WorldDriver.AddItems(new AddItemsDriverRequest(Guid.NewGuid(), worldId, spritesToAdd));

        world.Entity.Items.Should().BeEquivalentTo(spritesToAdd);
    }

    private WorldDriver<WorldUseCaseResponse> WorldDriver { get; } = new(CreateAWorldPresenter(), new ProvideWorldForCreateWorldFake());

    private static SimplePresenter<WorldUseCaseResponse> CreateAWorldPresenter() => new();

    private async Task<(WorldUseCaseResponse Entity, Error Error)> CreateNewWorldUseCase(Guid worldId)
        => await WorldDriver.CreateWorld(new CreateWorldDriverRequest(Guid.NewGuid(), worldId));
}