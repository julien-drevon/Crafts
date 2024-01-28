using System;
using System.Linq;
using Trivia.Infra;

namespace Tests
{
    public class MyDeterministeGenerator : IGenerateRand
    {
        public const int MAX_VALUE_FOR_START = 5;

        public int NumberToRandReturn { get; set; }

        public int Round { get; private set; }

        public EventHandler<(int Round, int Max)> BeforeRoundStart;

        public int GenerateNew(int maxValue)
        {
            if (maxValue == MAX_VALUE_FOR_START)
                Round++;
            BeforeRoundStart(this, new(Round, maxValue));
            return NumberToRandReturn;
        }
    }
}

