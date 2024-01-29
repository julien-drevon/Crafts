namespace Trivia.Domaine.Entities
{
    public class TriviaPlateau
    {
        private List<TriviaCase> _Cases;

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
}