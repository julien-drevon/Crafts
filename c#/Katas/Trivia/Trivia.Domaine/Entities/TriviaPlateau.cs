using Trivia.Domaine.Services;

namespace Trivia.Domaine.Entities
{
    public class TriviaPlateau
    {
        private IGenerateRand _CarSelector;
        private List<TriviaCase> _Cases;
        private List<TriviaQuestion> _Questions;

        public TriviaPlateau(IEnumerable<TriviaCase> cases, IEnumerable<TriviaQuestion> questions, IGenerateRand cardSelector)
        {
            _Cases = cases.ToList();
            _Questions = questions.ToList();
            _CarSelector = cardSelector;
        }

        public IEnumerable<TriviaCase> Cases { get => _Cases; }

        public IEnumerable<TriviaQuestion> Questions { get => _Questions; }

        public TriviaQuestion Move(Player nextPlayer, int desValue)
        {
            nextPlayer.Position = _Cases[desValue - 1];
            var questionsCategorie = this.Questions.Where(x => x.Categorie.Name == nextPlayer.Position.TriviaCategory.Name)
                                                   .ToList();
            return questionsCategorie[_CarSelector.GenerateNew(questionsCategorie.Count) - 1];
        }
    }
}