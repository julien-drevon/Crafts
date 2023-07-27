namespace Rpg.Core.Domain
{
    public class Sprite : ISprite
    {
        public Sprite(int x = 0, int y = 0)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; }

        public int Y { get; }
    }
}