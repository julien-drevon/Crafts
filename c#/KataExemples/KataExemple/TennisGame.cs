namespace KataExemples.TennisClass;

public class TennisGame
{
    private int[] _PlayersPoints = new int[2];

    public string ScoreString { get => ComputeScore(); }

    public void SetPoint(JoueurNumber whichPlayer)
    {
        var increment = _PlayersPoints[(int)whichPlayer] < 30 ? 15 : 10;
        _PlayersPoints[(int)whichPlayer] += increment;
    }

    private static string AffichageEgalite()
    {
        return "EGALITE";
    }

    private static string AffichageSeparator()
    {
        return " ";
    }

    private string AffichageJ1OrJ2FunctionTheBest()
    {
        return _PlayersPoints[0] > _PlayersPoints[1] ? "J1" : "J2";
    }

    private string AfficheGagnantOuAvantage()
    {
        return Math.Abs(_PlayersPoints[0] - _PlayersPoints[1]) > 10 ? "GAGNANT" : "AVANTAGE";
    }

    private string ComputeScore()
    {
        if (_PlayersPoints.All(point => point >= 40))
        {
            return ComputeScoreFinSet();
        }
        return ComputeScoreDebutGame();
    }

    private string ComputeScoreDebutGame()
    {
        return _PlayersPoints[0] + AffichageSeparator() + _PlayersPoints[1];
    }

    private string ComputeScoreFinSet()
    {
        if (IsEgalite())
            return AffichageEgalite();

        return AfficheGagnantOuAvantage() + AffichageSeparator() + AffichageJ1OrJ2FunctionTheBest();
    }

    private bool IsEgalite()
    {
        return _PlayersPoints[0] == _PlayersPoints[1];
    }
}

public enum JoueurNumber
{
    J1,
    J2
}