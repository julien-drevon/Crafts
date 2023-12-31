namespace Rpg.Providers.Tests;

public class SimpleProvideTheWorldShould
{
    private Guid Token { get; } = Guid.NewGuid();

    [Fact]
    public async Task CreateWorldScenarioForProvider()
    {
        var worldProvider = new SimpleWorldProvider();
        var world = await worldProvider.CreateWorld(new(Token, Guid.NewGuid()));
        world.Should().NotBeNull();
        (await worldProvider.GetWorld(Token, world.Id)).Should().Be(world);

        var world2 = await worldProvider.CreateWorld(new(Token, Guid.NewGuid()));
        world2.Should().NotBe(world);
        world2.Should().NotBeNull();

        var notsameWorlds = (await worldProvider.GetWorld(Token, world2.Id));
        notsameWorlds.Should().Be(world2);

        notsameWorlds = (await worldProvider.GetWorld(Token, world.Id));
        notsameWorlds.Should().NotBe(world2);

        await Assert.ThrowsAnyAsync<WorldProviderException>(() => worldProvider.CreateWorld(new(Token, world.Id)));

        try
        {
            await worldProvider.CreateWorld(new(Token, world.Id));
        }
        catch (WorldProviderException ex)
        {
            ex.CorrelationToken.Should().Be(Token);
            ex.Message.Should().BeEquivalentTo($"Id: {world.Id} already exist");
        }

        (await worldProvider.GetWorld(Token, Guid.NewGuid())).Should().BeNull();
    }
}