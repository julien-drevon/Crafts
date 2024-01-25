namespace Trivia.Infra
{
    public interface IGameRunner
    {
        void Run(IPrint print, IGenerateRand rand);
    }
}