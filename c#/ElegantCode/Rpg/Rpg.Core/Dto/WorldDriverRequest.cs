using ElegantCode.Fundamental.Core.DriverAdapter;
using ElegantCode.Fundamental.Core.Errors;
using Rpg.Core.Domain;

namespace Rpg.Core.Dto;

public class WorldDriverRequest : IValidateRequest<CreateWorldUseCaseQuery>
{
    public WorldDriverRequest(Guid correlationToken, Guid id, IEnumerable<Sprite> itemsToAdd = null)
    {
        Id = id;
        this.Items = itemsToAdd == null ? new HashSet<Sprite>() : new HashSet<Sprite>(itemsToAdd);
    }

    public Guid CorrelationToken { get; }

    public Guid Id { get; internal set; }

    public IEnumerable<Sprite> Items { get; set; }

    public (CreateWorldUseCaseQuery UseCaseQuery, Error Error) ValidateRequest()
    { return (new CreateWorldUseCaseQuery(Id, CorrelationToken), null); }
}

