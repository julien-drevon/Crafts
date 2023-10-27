using ElegantCode.Fundamental.Core.Entities;

namespace Rpg.Core.Domain
{
    public interface ISprite : IGotId<Guid>
    {
        int X { get; }

        int Y { get; }
    }
}