namespace KataExemples.TennisClass;

public class TennisGame
{
    private int[] _PlayersPoints = new int[2];

    public TennisGame()
    {
    }
    public object Points { get => ComputeScore(); }

    internal void SetPoint(JoueurNumber wichPlayer)
    {
        var increment = _PlayersPoints[(int)wichPlayer] < 30 ? 15 : 10;
        _PlayersPoints[(int)wichPlayer] += increment;
    }

    private string AffichageJ1OrJ2FunctionTheBest()
    {
        return $"{(_PlayersPoints[0] > _PlayersPoints[1] ? "J1" : "J2")}";
    }

    private string AfficheGagnantOuEgalite()
    {
        return $"{(Math.Abs(_PlayersPoints[0] - _PlayersPoints[1]) > 10 ? "GAGNANT " : "AVANTAGE ")}";
    }

    private string ComputeScore()
    {
        if (_PlayersPoints.All(x => x >= 40))
        {
            return ComputeScoreFinSet();

        }
        return ComputeScoreDebutGame();
    }

    private string ComputeScoreDebutGame()
    {
        return $"{_PlayersPoints[0]} {_PlayersPoints[1].ToString()}";
    }

    private string ComputeScoreFinSet()
    {
        if (_PlayersPoints[0] == _PlayersPoints[1])
            return "EGALITE";

        return AfficheGagnantOuEgalite() + AffichageJ1OrJ2FunctionTheBest();
    }
}

public enum JoueurNumber
{
    J1,
    J2
}
