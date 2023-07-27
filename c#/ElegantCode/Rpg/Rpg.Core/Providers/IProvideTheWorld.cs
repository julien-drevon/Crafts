using Rpg.Core.Domain;
using Rpg.Core.UseCases.Query;

namespace Rpg.Core.Providers
{
    public interface IProvideTheWorld
    {
        Task<World> CreateWorld(CreateWorldUseCaseQuery createWorldQuery);

        Task<World> GetWorld(Guid correlationToken, Guid worldId);
    }
}