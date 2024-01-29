using Trivia.Domaine.Entities;
using Trivia.Domaine.Services;

namespace Trivia.Domaine.Factories;

public class TriviaPlateauFactory
{
    public static TriviaPlateau Create(IGenerateRand carSelector, IEnumerable<TriviaCase> createCases, IEnumerable<TriviaQuestion> questions)
    {
        return new TriviaPlateau(
            createCases,
            questions,
            carSelector);
    }

    public static IEnumerable<TriviaCategory> CreateDefaultCategories()
    {
        return new[] {
             new TriviaCategory("Pop"),
             new TriviaCategory("Science"),
             new TriviaCategory("Sports"),
             new TriviaCategory("Rock")
        };
    }

    public static IEnumerable<TriviaCase> CreateTriviaCases(IEnumerable<TriviaCategory> categories, int nbOfCase = 4)
    {
        var nombresDeCategories = categories.Count();
        for (int i = 0, j = 0; i < nbOfCase; i++, j++)
        {
            if (j >= nombresDeCategories) j = 0;
            yield return new TriviaCase(categories.Skip(j).First(), i + 1);
        }
    }
}