namespace Rpg.Core.Domain
{
    public class World
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

        public void AddElement(ISprite sprite)
        {
            _Elements.Add(sprite);
        }
    }
}