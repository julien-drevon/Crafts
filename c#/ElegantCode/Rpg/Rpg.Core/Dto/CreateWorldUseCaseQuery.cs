using ElegantCode.Fundamental.Core.UsesCases;

namespace Rpg.Core.Dto
{
    public class CreateWorldUseCaseQuery : UseCaseQueryBase
    {
        public CreateWorldUseCaseQuery(Guid id, Guid correlationToken)
            : base(correlationToken)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}