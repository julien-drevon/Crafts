using FluentAssertions;

namespace KataExemples;

public class KataTennisShould
{
    [Fact]
    public void StartGame_0_0()
    {
        var givenGame = new Game();
        givenGame.Points.Should().BeEquivalentTo("0 0");
    }

    [Fact]
    public void FirstPoint_15_0()
    {
        var givenGame = new Game();
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.Points.Should().BeEquivalentTo("15 0");
    }

    [Fact]
    public void SecondPoint_15_15()
    {
        var givenGame = new Game();
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.Points.Should().BeEquivalentTo("15 15");
    }

    [Fact]
    public void ThirdPoint_30_15()
    {
        var givenGame = new Game();

        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J1);

        givenGame.Points.Should().BeEquivalentTo("30 15");
    }

    [Fact]
    public void FourthPoint_40_15()
    {
        var givenGame = new Game();

        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J1);

        givenGame.Points.Should().Be("40 15");
    }

    [Fact]
    public void Players2_Egalizet_40_40_Egalité()
    {
        var givenGame = new Game();

        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J1);

        givenGame.Points.Should().BeEquivalentTo("40 15");
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

    public object Points { get => $"{_PlayersPoints[0].ToString()} {_PlayersPoints[1].ToString()}"; }

    internal void SetPoint(JoueurNumber wichPlayer)
    {
        var increment = _PlayersPoints[(int)wichPlayer] < 30 ? 15 : 10;
        _PlayersPoints[(int)wichPlayer] += increment;
    }
}