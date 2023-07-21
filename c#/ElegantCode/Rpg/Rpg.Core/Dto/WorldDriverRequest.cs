using ElegantCode.Fundamental.Core.DriverAdapter;
using ElegantCode.Fundamental.Core.Errors;

namespace Rpg.Core.Dto;

public class WorldDriverRequest : IValidateRequest<CreateWorldUseCaseQuery>
{
    public WorldDriverRequest(Guid id, Guid correlationToken)
    {
        Id = id;
    }

    public Guid CorrelationToken { get; }

    public Guid Id { get; internal set; }

    public (CreateWorldUseCaseQuery UseCaseQuery, Error Error) ValidateRequest()
    {
        return (new CreateWorldUseCaseQuery(Id, CorrelationToken), null);
    }
}