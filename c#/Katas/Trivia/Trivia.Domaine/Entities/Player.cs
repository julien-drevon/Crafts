namespace Trivia.Domaine.Entities;

public class Player
{
    public Player(string name)
    {
        Name = name;
    }

    public string Name { get; internal set; }

    public TriviaCase Position { get; set; }
    public PlayerReponse Reponse { get; set; }
}

public class PlayerReponse
{
    public bool IsGood()
    {
        return false;
    }


}