using Trivia.Domaine.Entities;

namespace Trivia.Domaine.UseCases;

public class GameResult
{
    public GameResult(Guid gameId, IEnumerable<Player> players)
    {
        GameId = gameId;
        Players = players;
    }

    public Guid GameId { get; internal set; }

    public IEnumerable<Player> Players { get; internal set; }
}