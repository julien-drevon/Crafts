using Rpg.Core.Domain;

namespace Rpg.Core.Providers;

public interface ICreateItems
{
    public IEnumerable<ISprite> Do(IEnumerable<ISprite> items);
}