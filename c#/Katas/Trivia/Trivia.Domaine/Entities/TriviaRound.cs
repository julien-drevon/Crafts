using System.Globalization;

namespace Trivia.Domaine.Entities
{
    public class TriviaRound
    {
        public TriviaRound(Player player, int number, TriviaQuestion question)
        {
            Player = player;
            Number = number;
            Question = question;
        }

        public int Number { get; }

        public Player Player { get; }

        public TriviaQuestion Question { get; }

        public string Response { get; private set; } = null;

        public bool IsGoodResponse { get; private set; }

        public bool SetReponseAndReturnIsGood(string response)
        {
            this.Response = response;
            IsGoodResponse = this.Response.ToLower(CultureInfo.InvariantCulture) == Question.Response.ToLower(CultureInfo.InvariantCulture);
            return IsGoodResponse;
        }
    }
}