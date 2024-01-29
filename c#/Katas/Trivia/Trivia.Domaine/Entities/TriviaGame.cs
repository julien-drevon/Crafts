using ElegantCode.Fundamental.Core.UsesCases;

namespace Trivia.Domaine.Entities;

public class TriviaGame : UseCaseResponseBase
{
    private List<Player> _Players;

    public TriviaGame(Guid correlationToken, Guid gameId, IEnumerable<Player> players, TriviaPlateau plateau)
            : base(correlationToken)
    {
        this.Id = gameId;
        _Players = new(players);
        CurrentRound = new TriviaRound(null, 0, TriviaGameStatus.NotStarted);
        NextPlayer = players.First();
        Plateau = plateau;
    }


    public TriviaRound CurrentRound { get; internal set; }

    public IEnumerable<TriviaRound> GameHistory { get; set; } = new List<TriviaRound>();

    public Guid Id { get; internal set; }

    public Player NextPlayer { get; set; }

    public IEnumerable<Player> Players { get => _Players; }

    public TriviaPlateau Plateau { get; }

    public void Start(int desValue)
    {
        this.Plateau.Move(NextPlayer, desValue);
        this.CurrentRound = new TriviaRound(this.Players.First(), 1, TriviaGameStatus.InGame);
        this.NextPlayer = this._Players[1];
    }
}

public class TriviaPlateau
{
    List<TriviaCase> _Cases;
    public TriviaPlateau(IEnumerable<TriviaCase> cases)
    {
        _Cases = cases.ToList();
    }

    public IEnumerable<TriviaCase> Cases { get => _Cases; }

    public void Move(Player nextPlayer, int desValue)
    {
        nextPlayer.Position = _Cases[desValue - 1];
    }
}

public class TriviaCase
{


    public TriviaCase(TriviaCategory triviaCategory, int position)
    {
        TriviaCategory = triviaCategory;
        Position = position;
    }

    public TriviaCategory TriviaCategory { get; }

    public int Position { get; }
}

public class TriviaCategory
{
    private string Name;

    public TriviaCategory(string name)
    {
        this.Name = name;
    }
}

public class TriviaRound
{
    public TriviaRound(Player player, int number, TriviaGameStatus status)
    {
        Player = player;
        Number = number;
        Status = status;
    }



    public int Number { get; internal set; }

    public Player Player { get; internal set; }

    public TriviaGameStatus Status { get; internal set; }
}