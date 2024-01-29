using System;
using System.Linq;
using Trivia.Domaine.Services;

namespace Tests.Domaine.ServiceFacts
{
    public class GenerateNumberForQuestions : IGenerateRand
    {
        public int GenerateNew(int maxValue) { return 1; }
    }
}