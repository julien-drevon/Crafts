using ElegantCode.Fundamental.Core.DriverAdapter;
using ElegantCode.Fundamental.Core.Errors;
using Rpg.Core.Domain;

namespace Rpg.Core.Dto
{
    public class AddItemsDriverRequest : IValidateRequest<AddItemsWorldUseCaseQuery>
    {
        public AddItemsDriverRequest(Guid correlationToken, Guid id, IEnumerable<Sprite> itemsToAdd = null)
        {
            Id = id;
            Items = itemsToAdd == null ? new HashSet<Sprite>() : new HashSet<Sprite>(itemsToAdd);
        }

        public Guid CorrelationToken { get; }

        public Guid Id { get; internal set; }

        public IEnumerable<Sprite> Items { get; set; }

        public (AddItemsWorldUseCaseQuery UseCaseQuery, Error Error) ValidateRequest()
        {
            throw new NotImplementedException();
        }
    }


}
