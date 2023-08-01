using ElegantCode.Fundamental.Core.Utils;
using Rpg.Core.Domain;
using Rpg.Core.Providers;
using Rpg.Core.UseCases.Query;

namespace Rpg.Providers;

public class SimpleWorldProvider : IProvideTheWorld
{
    private HashSet<World> _world = new();

    public Task<World> CreateWorld(CreateWorldUseCaseQuery createWorldQuery)
    {
        if (_world.IsAny(x => x.Id == createWorldQuery.Id))
            throw new WorldProviderException(createWorldQuery.CorrelationToken, $"Id {createWorldQuery.Id} already exist");

        var world = new World(createWorldQuery.Id);
        _world.Add(world);
        return Task.FromResult(world);
    }

    public async Task<World> GetWorld(Guid correlationToken, Guid worldId)
    {
        return await Task.FromResult(_world.SingleOrDefault(x => x.Id == worldId));
    }
}