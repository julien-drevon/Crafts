using ElegantCode.Fundamental.Core.Entities;
using ElegantCode.Fundamental.Core.Utils;

namespace Rpg.Core.Domain
{
    public class World : IGotId<Guid>
    {
        private HashSet<ISprite> _Elements = new();

        public World(Guid guid)
        {
            Id = guid;
        }

        public World(Guid guid, IEnumerable<ISprite> sprites)
            : this(guid)
        {
            _Elements = new HashSet<ISprite>(sprites);
        }

        public IEnumerable<ISprite> Elements { get => _Elements; }

        public Guid Id { get; }

        public void AddElement(IEnumerable<ISprite> sprite)
        {
            sprite.Foreach(x => _Elements.Add(x));
        }
    }
}