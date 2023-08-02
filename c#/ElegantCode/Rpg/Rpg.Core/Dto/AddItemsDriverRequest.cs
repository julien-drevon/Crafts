using ElegantCode.Fundamental.Core.DriverAdapter;
using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.Utils;
using Rpg.Core.Domain;

namespace Rpg.Core.Dto
{
    public class AddItemsDriverRequest : IValidateRequest<AddItemsWorldUseCaseQuery>
    {
        public AddItemsDriverRequest(Guid correlationToken, Guid id, IEnumerable<ISprite> itemsToAdd = null)
        {
            Id = id;
            Items = itemsToAdd.IsNull()
                    ? new HashSet<ISprite>(itemsToAdd)
                    : itemsToAdd;
        }

        public Guid CorrelationToken { get; }

        public Guid Id { get; internal set; }

        public IEnumerable<ISprite> Items { get; set; }

        public (AddItemsWorldUseCaseQuery UseCaseQuery, Error Error) ValidateRequest()
            => this.ValidationWorkflow(valueIfIsGood: new AddItemsWorldUseCaseQuery(CorrelationToken, Id, Items));
    }
}