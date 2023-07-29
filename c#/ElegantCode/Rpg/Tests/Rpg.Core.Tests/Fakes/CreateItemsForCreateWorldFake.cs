using Rpg.Core.Providers;

namespace Rpg.Core.Tests.Fakes
{
    public class CreateItemsForCreateWorldFake : ICreateItems
    {
        public IEnumerable<ISprite> Do(IEnumerable<ISprite> items)
        {
            return items;
        }
    }
}