namespace Trivia.Domaine.Entities
{
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
}