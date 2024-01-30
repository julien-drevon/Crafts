using Trivia.Domaine.Services;

namespace Trivia.Infra
{
    public interface IGameRunner
    {
        void Run(IPrint print, IGenerateRand rand, int pointsToWin);
    }
}