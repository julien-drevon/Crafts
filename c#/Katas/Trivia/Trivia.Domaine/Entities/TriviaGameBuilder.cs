namespace Trivia.Domaine.Entities;

public class TriviaGameBuilder
{
    private Guid _GameId;
    private List<Player> _Players;

    public TriviaGameBuilder(Guid gameId)
    {
        _GameId = gameId;
    }

    public TriviaGameBuilder AddPlayers(IEnumerable<string> players)
    {
        _Players = players.Select(x => new Player(x)).ToList();
        return this;
    }

    public TriviaGame Build()
    {
        return new TriviaGame(_GameId, _Players);
    }
}