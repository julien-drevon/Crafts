namespace ElegantCode.Fundamental.Core.Entities;

public interface IGotId<TId>
{
    TId Id { get; }
}