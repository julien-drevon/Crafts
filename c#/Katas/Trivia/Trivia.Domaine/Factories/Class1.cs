using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Domaine.Entities;

namespace Trivia.Domaine.Factories;

public class TriviaPlateauFactory
{
    public static TriviaPlateau Create()
    {
        return new TriviaPlateau(new[] { new TriviaCase(new TriviaCategory("Sports"), 1), new TriviaCase(new TriviaCategory("Histoire"), 2) });
    }
}
