namespace Trivia.Domaine.Entities
{
    public class TriviaRound
    {
        public TriviaRound(Player player, int number, TriviaGameStatus status, TriviaQuestion question)
        {
            Player = player;
            Number = number;
            Status = status;
            Question = question;
        }

        public int Number { get; internal set; }

        public Player Player { get; internal set; }

        public TriviaQuestion Question { get; }

        public string Response { get; set; }

        public TriviaGameStatus Status { get; internal set; }
    }
}