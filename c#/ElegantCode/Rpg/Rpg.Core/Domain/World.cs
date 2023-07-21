namespace Rpg.Core.Domain
{
    public class World
    {
        private HashSet<Sprite> _Elements = new();

        public World(Guid guid)
        {
            Id = guid;
        }

        public World(Guid guid, IEnumerable<Sprite> sprites)
            : this(guid)
        {
            _Elements = new HashSet<Sprite>(sprites);
        }

        public IEnumerable<Sprite> Elements { get => _Elements; }

        public Guid Id { get; }

        public void AddElement(Sprite sprite)
        {
            _Elements.Add(sprite);
        }
    }
}