namespace Trivia.Domaine.Entities
{
    public class TriviaQuestion
    {
        public TriviaQuestion(TriviaCategory categorie, string question, string reponse)
        {
            QuestionText = question;
            Response = reponse;
            Categorie = categorie;
        }

        public TriviaCategory Categorie { get; internal set; }

        public string QuestionText { get; }

        public string Response { get; }
    }
}