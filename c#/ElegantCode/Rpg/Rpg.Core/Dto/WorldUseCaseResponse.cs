using ElegantCode.Fundamental.Core.UsesCases;

namespace Rpg.Core.Dto
{
    public class WorldUseCaseResponse : UseCaseResponseBase
    {
        public WorldUseCaseResponse(Guid id, Guid correlationId)
            : base(correlationId)
        {
            Id = id;
        }

        public Guid Id { get; internal set; }
    }
}