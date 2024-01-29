using Trivia.Domaine.Entities;

namespace Trivia.Domaine.UseCases;

public class GameResult
{
    public GameResult(Guid correlationToken, TriviaGame game)
    {
        CorrelationToken=correlationToken;
        GameId=game.Id;
        Players=game.Players;
        RoundOf = game.RoundOf;
        GameStatus = game.Status;
    }

    public Guid GameId { get; internal set; }
    public Guid CorrelationToken { get; internal set; }
    public IEnumerable<Player> Players { get; internal set; }
    public TriviaGameStatus GameStatus { get; internal set; }
    public object RoundOf { get; set; }
}


public class GameToGameResultConverter : IGenericConverter<,>