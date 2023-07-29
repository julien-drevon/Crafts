using ElegantCode.Fundamental.Core.UsesCases;
using Rpg.Core.Domain;

public class AddItemsWorldUseCaseQuery : UseCaseQueryBase
{
    public AddItemsWorldUseCaseQuery(Guid correlationToken, Guid id, IEnumerable<ISprite> sprites) : base(correlationToken)
    {
        this.Id = id;
        this.Items = sprites;
    }

    public Guid Id { get; }

    public IEnumerable<ISprite> Items { get; }
}