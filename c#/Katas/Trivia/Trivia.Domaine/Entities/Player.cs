namespace Trivia.Domaine.Entities;

public class Player
{
    public Player(string name)
    {
        Name = name;
    }

    public string Name { get; internal set; }
}
public enum TriviaGameStatus
{
    NotStarted,
    InGame
}