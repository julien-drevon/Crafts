using Rpg.Core.Domain;

namespace Rpg.Core.Dto
{
    public class WorldUseCaseResponse
    {
        public WorldUseCaseResponse(World world)
        {
            Id = world.Id;
            Items = world.Elements;
        }

        public Guid Id { get; }

        public IEnumerable<ISprite> Items { get; }
    }
}