namespace Trivia.Domaine.Entities;

public class TriviaGameBuilder
{
    private Guid _CorrelationToken;
    private Guid _GameId;
    private TriviaPlateau _Plateau;
    private List<Player> _Players;

    public TriviaGameBuilder(Guid correlationToken, Guid gameId)
    {
        _GameId = gameId;
        _CorrelationToken = correlationToken;
    }

    public TriviaGameBuilder AddPlateau(TriviaPlateau plateau)
    {
        _Plateau = plateau;
        return this;
    }

    public TriviaGameBuilder AddPlayers(IEnumerable<string> players)
    {
        _Players = players.Select(x => new Player(x)).ToList();
        return this;
    }

    public TriviaGame Build()
    {
        return new TriviaGame(_CorrelationToken, _GameId, _Players, _Plateau);
    }
}