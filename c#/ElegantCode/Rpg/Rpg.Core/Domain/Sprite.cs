using ElegantCode.Fundamental.Core.Utils;

namespace Rpg.Core.Domain
{
    public class Sprite : ISprite
    {
        public int Width { get; set; }

        public Sprite(int x = 0, int y = 0, int width = 0, int height = 0, Guid id = default)
        {
            id = id.IsEmpty() ? Guid.NewGuid() : id;
            Id = id;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Height { get; set; }

        public Guid Id { get; }
    }
}