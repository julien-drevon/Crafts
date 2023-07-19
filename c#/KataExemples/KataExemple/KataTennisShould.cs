using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;

namespace KataExemples;

public class KataTennisShould
{
    [Fact]
    public void StartGame_0_0()
    {
        var givenGame = new Game();
        givenGame.Points.Should().BeEquivalentTo(new[]
        {
            "0","0"
        });
    }

    [Fact]
    public void FirstPoint_15_0()
    {
        var givenGame = new Game();
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.Points.Should().BeEquivalentTo(new[]
        {
            "15","0"
        });
    }


    [Fact]
    public void SecondPoint_15_15()
    {
        var givenGame = new Game();
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.Points.Should().BeEquivalentTo(new[]
        {
            "0","15"
        });
    }
}

public enum JoueurNumber
{
    J1,
    J2
}

public class Game
{
    public Game()
    {
    }

    private int[] _PlayersPoints = new int[2];

    public object Points { get =>new []{ _PlayersPoints[0].ToString(), _PlayersPoints[1].ToString() }; }

    internal void SetPoint(JoueurNumber wichPlayer)
    {
        _PlayersPoints[(int)wichPlayer] = 15;
    }
}