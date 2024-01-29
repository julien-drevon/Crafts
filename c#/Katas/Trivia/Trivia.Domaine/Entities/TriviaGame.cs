namespace Trivia.Domaine.Entities;

public class TriviaGame
{
    public TriviaGame(Guid gameId, IEnumerable<Player> players)
    {
        this.Id = gameId;
        Players = players;
    }

    public Guid Id { get; internal set; }

    public IEnumerable<Player> Players { get; internal set; }
}