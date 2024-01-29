namespace Trivia.Domaine.Entities
{
    public class TriviaCase
    {
        public TriviaCase(TriviaCategory triviaCategory, int position)
        {
            TriviaCategory = triviaCategory;
            Position = position;
        }

        public int Position { get; }

        public TriviaCategory TriviaCategory { get; }
    }
}