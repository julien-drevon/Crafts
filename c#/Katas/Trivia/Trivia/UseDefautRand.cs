using System;
using Trivia.Infra;

namespace Trivia
{
    public class UseDefautRand : IGenerateRand
    {
        Random _Rand = new Random();

        public int Next(int maxValue)
        {
            return _Rand.Next(maxValue);
        }
    }
}