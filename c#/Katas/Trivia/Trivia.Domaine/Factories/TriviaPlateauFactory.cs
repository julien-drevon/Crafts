using System;
using System.Linq;
using Trivia.Domaine.Entities;

namespace Trivia.Domaine.Factories;

public class TriviaPlateauFactory
{
    public static TriviaPlateau Create()
    {
        return new TriviaPlateau(
            new[] { new TriviaCase(new TriviaCategory("Pop"), 1)
            , new TriviaCase(new TriviaCategory("Science"), 2)
            , new TriviaCase(new TriviaCategory("Sports"), 3)
            , new TriviaCase(new TriviaCategory("Rock"), 4)}
            );
    }
}
