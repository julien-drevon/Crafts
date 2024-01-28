using System;
using Trivia.Infra;

namespace Trivia
{
    public class UseDefautRand : IGenerateRand
    {
        private Random _Rand = new Random();

        public int GenerateNew(int maxValue)
        {
            return _Rand.Next(maxValue);
        }
    }
}