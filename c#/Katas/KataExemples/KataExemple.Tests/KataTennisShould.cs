using FluentAssertions;
using KataExemples.TennisClass;

namespace KataExemples;

public class KataTennisShould
{
    #region Baby steps regroupés

    [Fact]
    public void PlayAGame_Design()
    {
        var givenGame = new TennisGame();

        givenGame.ScoreString.Should().BeEquivalentTo("0 0");

        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.ScoreString.Should().BeEquivalentTo("15 0");

        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.ScoreString.Should().BeEquivalentTo("15 15");

        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.ScoreString.Should().BeEquivalentTo("30 15");

        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.ScoreString.Should().BeEquivalentTo("40 15");

        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.ScoreString.Should().BeEquivalentTo("40 30");

        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.ScoreString.Should().BeEquivalentTo("EGALITE");

        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.ScoreString.Should().BeEquivalentTo("AVANTAGE J2");

        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.ScoreString.Should().BeEquivalentTo("EGALITE");

        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.ScoreString.Should().BeEquivalentTo("AVANTAGE J1");

        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.ScoreString.Should().BeEquivalentTo("GAGNANT J1");
    }

    #endregion Baby steps regroupés

    #region Baby steps éclatés

    [Fact]
    public void StartGame_0_0()
    {
        var givenGame = new TennisGame();
        givenGame.ScoreString.Should().BeEquivalentTo("0 0");
    }

    [Fact]
    public void FirstPoint_15_0()
    {
        var givenGame = new TennisGame();
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.ScoreString.Should().BeEquivalentTo("15 0");
    }

    [Fact]
    public void SecondPoint_15_15()
    {
        var givenGame = new TennisGame();
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.ScoreString.Should().BeEquivalentTo("15 15");
    }

    [Fact]
    public void ThirdPoint_30_15()
    {
        var givenGame = new TennisGame();

        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J1);

        givenGame.ScoreString.Should().BeEquivalentTo("30 15");
    }

    [Fact]
    public void FourthPoint_40_15()
    {
        var givenGame = new TennisGame();

        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J1);

        givenGame.ScoreString.Should().Be("40 15");
    }

    [Fact]
    public void Players2_Egalizet_40_40_Egalité()
    {
        var givenGame = new TennisGame();

        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J2);

        givenGame.ScoreString.Should().BeEquivalentTo("EGALITE");
    }

    [Fact]
    public void Avantage_Joueur1()
    {
        var givenGame = new TennisGame();

        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J1);

        givenGame.ScoreString.Should().BeEquivalentTo("AVANTAGE J1");
    }

    [Fact]
    public void Avantage_Joueur2()
    {
        var givenGame = new TennisGame();

        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J2);

        givenGame.ScoreString.Should().BeEquivalentTo("AVANTAGE J2");
    }

    [Fact]
    public void DrawAgain2()
    {
        var givenGame = new TennisGame();

        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J1);

        givenGame.ScoreString.Should().BeEquivalentTo("EGALITE");
    }

    [Fact]
    public void Win_Joueur1()
    {
        var givenGame = new TennisGame();

        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J1);

        givenGame.ScoreString.Should().BeEquivalentTo("GAGNANT J1");
    }

    [Fact]
    public void Win_Joueur2()
    {
        var givenGame = new TennisGame();

        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J2);

        givenGame.ScoreString.Should().BeEquivalentTo("GAGNANT J2");
    }

    #endregion Baby steps éclatés
}