using System;

namespace Trivia.Infra;

public interface IGenerateRand
{
    int GenerateNew(int maxValue);
}
