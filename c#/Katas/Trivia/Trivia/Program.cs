using System;
using Trivia.Master;

namespace Trivia;

public class Program
{
    public static void Main(string[] args)
    {
       new GameRunner_Master().Run(new ConsolePrinter(), new UseDefautRand());
    }
}
