using FluentAssertions;
using System.Linq;
using Trivia.Domaine.Entities;
using Trivia.Domaine.Factories;
using Xunit;

namespace Tests.Domaine;

public class TriviaPlateauFactoryShould
{
    [Fact]
    public void CreateDefaultPlateau()
    {
        var defaultCategories = TriviaPlateauFactory.CreateDefaultCategories().ToList();
        TriviaPlateauFactory.CreateTriviaCases(defaultCategories, 1)
            .Should()
            .BeEquivalentTo(new[] { new TriviaCase(defaultCategories[0], 1) });
        TriviaPlateauFactory.CreateTriviaCases(defaultCategories, 2)
            .Should()
            .BeEquivalentTo(new[] { new TriviaCase(defaultCategories[0], 1), new TriviaCase(defaultCategories[1], 2) });

        TriviaPlateauFactory.CreateTriviaCases(defaultCategories, 5)
            .Should()
            .BeEquivalentTo(
                new[]
                {
                new TriviaCase(defaultCategories[0], 1),
                new TriviaCase(defaultCategories[1], 2),
                new TriviaCase(defaultCategories[2], 3),
                new TriviaCase(defaultCategories[3], 4),
                new TriviaCase(defaultCategories[0], 5),
                });
    }
}