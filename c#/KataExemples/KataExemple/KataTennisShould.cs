﻿using FluentAssertions;

namespace KataExemples;

public class KataTennisShould
{
    [Fact]
    public void Avantage_Joueur1()
    {
        var givenGame = new Game();

        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J1);

        givenGame.Points.Should().BeEquivalentTo("AVANTAGE J1");
    }

    [Fact]
    public void Avantage_Joueur2()
    {
        var givenGame = new Game();

        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J2);

        givenGame.Points.Should().BeEquivalentTo("AVANTAGE J2");
    }

    [Fact]
    public void DrawAgain2()
    {
        var givenGame = new Game();

        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J1);

        givenGame.Points.Should().BeEquivalentTo("EGALITE");
    }

    [Fact]
    public void FirstPoint_15_0()
    {
        var givenGame = new Game();
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.Points.Should().BeEquivalentTo("15 0");
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
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J2);


        givenGame.Points.Should().BeEquivalentTo("EGALITE");
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
    public void StartGame_0_0()
    {
        var givenGame = new Game();
        givenGame.Points.Should().BeEquivalentTo("0 0");
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
    public void Win_Joueur1()
    {
        var givenGame = new Game();

        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J1);

        givenGame.Points.Should().BeEquivalentTo("GAGNANT J1");
    }

    [Fact]
    public void Win_Joueur2()
    {
        var givenGame = new Game();

        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J1);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J2);
        givenGame.SetPoint(JoueurNumber.J2);

        givenGame.Points.Should().BeEquivalentTo("GAGNANT J2");
    }
}
