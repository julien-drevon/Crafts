using System;

namespace Trivia.Infra;

public interface IGenerateRand
{
    int Next(int maxValue);
}
