using ElegantCode.Fundamental.Core.UsesCases;
using Rpg.Core.Domain;

namespace Rpg.Core.Dto
{
    public class WorldUseCaseResponse : UseCaseResponseBase
    {
        public WorldUseCaseResponse(Guid id, Guid correlationId)
            : base(correlationId)
        {
            Id = id;
        }

        public Guid Id { get;  set; }
        public IEnumerable<Sprite> Items { get; set; }
    }
}