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
        CurrentRound = new TriviaRound(null, 0,  null);
        NextPlayer = players.First();
        Plateau = plateau;
        Status = TriviaGameStatus.NotStarted;
    }

    public TriviaRound CurrentRound { get; internal set; }

    public IEnumerable<TriviaRound> GameHistory { get; private set; } = new List<TriviaRound>();

    public Guid Id { get; internal set; }

    public TriviaGameStatus Status { get; internal set; }

    public Player NextPlayer { get; set; }

    public TriviaPlateau Plateau { get; }

    public IEnumerable<Player> Players { get => _Players; }
 

    public void Repondre(string reponse)
    {
       if( this.CurrentRound.SetReponseAndReturnIsGood( reponse))
        {
            this.CurrentRound.Player.Score++;
        }
       
    }

    public TriviaRound SeDeplacer(int desValue)
    {
        Status = TriviaGameStatus.InGame;
        var question = this.Plateau.Move(NextPlayer, desValue);
        this.CurrentRound = new TriviaRound(this.Players.First(), 1,  question);
        this.NextPlayer = this._Players[1];

        return this.CurrentRound;
    }
}