using ElegantCode.Fundamental.Core.UsesCases;

namespace Trivia.Domaine.UseCases;

public class StartGameQuery : UseCaseQueryBase
{
    public StartGameQuery(Guid correlationToken, Guid gameId) 
        : base(correlationToken)
    {
        this.GameId = gameId;
    }

    public Guid GameId { get; private set; }
}