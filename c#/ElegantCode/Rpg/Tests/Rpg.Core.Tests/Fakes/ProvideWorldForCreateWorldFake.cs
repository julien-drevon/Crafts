using Rpg.Core.Providers;
using Rpg.Core.UseCases.Query;

namespace Rpg.Core.Tests.Fakes;

public class ProvideWorldForCreateWorldFake : IProvideTheWorld
{
    private World _world;

    public Task<World> CreateWorld(CreateWorldUseCaseQuery createWorldQuery)
    {
        _world = new World(createWorldQuery.Id);
        return Task.FromResult(_world);
    }

    public Task<World> GetWorld(Guid correlationToken, Guid worldId)
    {
        return Task.FromResult(_world);
    }
}
