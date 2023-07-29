using ElegantCode.Fundamental.Core.UsesCases;
using Rpg.Core.Domain;

namespace Rpg.Core.Dto
{
    public class WorldUseCaseResponse : UseCaseResponseBase
    {
        public WorldUseCaseResponse(Guid correlationId, World world)
            : base(correlationId)
        {
            Id = world.Id;
            Items = world.Elements;
        }

        public Guid Id { get; }

        public IEnumerable<ISprite> Items { get; }
    }
}