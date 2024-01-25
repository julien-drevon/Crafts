﻿using System;
using Trivia.Infra;

namespace Trivia;

public class GameRunner_Master : IGameRunner
{
    private static bool _notAWinner;



    public void Run(IPrint print, IGenerateRand rand)
    {
        var aGame = new Game_Master(print);

        aGame.Add("Chet");
        aGame.Add("Pat");
        aGame.Add("Sue");       

        do
        {
            aGame.Roll(rand.Next(5) + 1);

            if (rand.Next(9) == 7)
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
