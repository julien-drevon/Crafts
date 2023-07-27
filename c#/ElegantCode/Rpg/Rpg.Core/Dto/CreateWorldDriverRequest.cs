using ElegantCode.Fundamental.Core.DriverAdapter;
using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.UsesCases;
using ElegantCode.Fundamental.Core.Utils;
using Rpg.Core.Domain;
using Rpg.Core.UseCases.Query;

namespace Rpg.Core.Dto;

public class CreateWorldDriverRequest : IValidateRequest<CreateWorldUseCaseQuery>
{
    public CreateWorldDriverRequest(Guid correlationToken, Guid id)
    {
        Id = id;
    }

    public Guid CorrelationToken { get; }

    public Guid Id { get; internal set; }


    public (CreateWorldUseCaseQuery UseCaseQuery, Error Error) ValidateRequest()
     => this.ValidationWorkflow(valueIfIsGood: new CreateWorldUseCaseQuery(CorrelationToken, Id));


}