using ElegantCode.Fundamental.Core.DriverAdapter;
using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.Presenter;
using ElegantCode.Fundamental.Core.UsesCases;

namespace Rpg.Core.Dto;

public class WorldDriverRequest : IValidateRequest<CreateWorldUseCaseQuery>
{

    public WorldDriverRequest(Guid id, Guid correlationToken)
    {
        Id = id;
    }

    public Guid Id { get; internal set; }

    public Guid CorrelationToken { get; }

    public (CreateWorldUseCaseQuery UseCaseQuery, Error Error) ValidateRequest()
    {
        return (new CreateWorldUseCaseQuery(Id, CorrelationToken), null);
    }

}
