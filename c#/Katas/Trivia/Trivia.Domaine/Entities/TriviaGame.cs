using ElegantCode.Fundamental.Core.UsesCases;

namespace Trivia.Domaine.Entities;

public class TriviaGame : UseCaseResponseBase
{
    public TriviaGame(Guid correlationToken, Guid gameId, IEnumerable<Player> players)
        : base(correlationToken)
    {
        this.Id = gameId;
        Players = players;
    }

    public Guid Id { get; internal set; }

    public IEnumerable<Player> Players { get; internal set; }
    public TriviaGameStatus Status { get; internal set; }
    public object RoundOf { get; internal set; }
}