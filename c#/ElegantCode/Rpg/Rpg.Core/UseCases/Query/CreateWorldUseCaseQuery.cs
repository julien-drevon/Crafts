using ElegantCode.Fundamental.Core.Entities;
using ElegantCode.Fundamental.Core.UsesCases;

namespace Rpg.Core.UseCases.Query
{
    public class CreateWorldUseCaseQuery : UseCaseQueryBase, IGotId<Guid>
    {
        public CreateWorldUseCaseQuery(Guid correlationToken, Guid id)
            : base(correlationToken)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}