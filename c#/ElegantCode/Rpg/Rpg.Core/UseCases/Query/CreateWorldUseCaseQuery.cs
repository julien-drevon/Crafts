using ElegantCode.Fundamental.Core.UsesCases;

namespace Rpg.Core.UseCases.Query
{
    public class CreateWorldUseCaseQuery : UseCaseQueryBase
    {
        public CreateWorldUseCaseQuery(Guid correlationToken, Guid id)
            : base(correlationToken)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}