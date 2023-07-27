using ElegantCode.Fundamental.Core.UsesCases;

namespace Rpg.Core.UseCases.Query;

public class AddItemsUseCaseQuery : UseCaseQueryBase
{
    public AddItemsUseCaseQuery(Guid correlationToken)
        : base(correlationToken)
    {
    }
}