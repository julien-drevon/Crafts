using Trivia.Infra;

namespace Trivia.Master;

public class GameRunner_Master : IGameRunner
{
    private static bool _notAWinner;

    public void Run(IPrint print, IGenerateRand rand, int pointsToWin = 2)
    {
        var aGame = new Game_Master(print, pointsToWin);

        aGame.Add("Chet");
        aGame.Add("Pat");
        aGame.Add("Sue");

        do
        {
            aGame.Roll(rand.GenerateNew(5) + 1);

            if (rand.GenerateNew(9) == 7)
            {
                _notAWinner = aGame.WrongAnswer();
            }
            else
            {
                _notAWinner = aGame.WasCorrectlyAnswered();
            }
        } while (_notAWinner);
    }
}