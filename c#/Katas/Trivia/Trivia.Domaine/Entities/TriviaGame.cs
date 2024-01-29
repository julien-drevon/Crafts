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
        CurrentRound = new TriviaRound(null, 0, TriviaGameStatus.NotStarted, null);
        NextPlayer = players.First();
        Plateau = plateau;
    }

    public TriviaRound CurrentRound { get; internal set; }

    public IEnumerable<TriviaRound> GameHistory { get; set; } = new List<TriviaRound>();

    public Guid Id { get; internal set; }

    public Player NextPlayer { get; set; }

    public TriviaPlateau Plateau { get; }

    public IEnumerable<Player> Players { get => _Players; }

    public void Repondre(string reponse)
    {
        //this.CurrentRound.Player.Reponse = new PlayerReponse()
    }

    public TriviaRound SeDeplacer(int desValue)
    {
        var question = this.Plateau.Move(NextPlayer, desValue);
        this.CurrentRound = new TriviaRound(this.Players.First(), 1, TriviaGameStatus.InGame, question);
        this.NextPlayer = this._Players[1];

        return this.CurrentRound;
    }
}