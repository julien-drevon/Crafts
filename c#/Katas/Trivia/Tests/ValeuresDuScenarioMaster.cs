using System;
using System.Linq;

namespace Tests
{
    public static class ValeuresDuScenarioMaster
    {
        public static string[] DebutDePartie()
        {
            return new[]
            {
            "Chet was added",
            "They are player number 1",
            "Pat was added",
            "They are player number 2",
            "Sue was added",
            "They are player number 3",
        };
        }

        public static string[] ValeuresFinDeRound1()
        {
            return new[]
            {
            "Chet is the current player",
            "They have rolled a 2",
            "Chet's new location is 2",
            "The category is Sports",
            "Sports Question 0",
            "Answer was corrent!!!!",
            "Chet now has 1 Gold Coins."
        };
        }
        public static string[] ValeuresFinDeRound2()
        {
            return new[]
            {
            "Pat is the current player",
            "They have rolled a 1",
            "Pat's new location is 1",
            "The category is Science",
            "Science Question 0",
            "Answer was corrent!!!!",
            "Pat now has 1 Gold Coins.",
        };
        }
        public static string[] ValeuresFinDeRound3()
        {
            return new[]
            {
            "Sue is the current player",
            "They have rolled a 4",
            "Sue's new location is 4",
            "The category is Pop",
            "Pop Question 0",
            "Question was incorrectly answered",
            "Sue was sent to the penalty box",
        };
        }
        public static string[] ValeuresFinDeRound4()
        {
            return new[]
            {
            "Chet is the current player",
            "They have rolled a 4",
            "Chet's new location is 6",
            "The category is Sports",
            "Sports Question 1",
            "Answer was corrent!!!!",
            "Chet now has 2 Gold Coins.",
        };
        }
        public static string[] ValeuresFinDeRound5()
        {
            return new[]
            {
            "Pat is the current player",
            "They have rolled a 5",
            "Pat's new location is 6",
            "The category is Sports",
            "Sports Question 2",
            "Question was incorrectly answered",
            "Pat was sent to the penalty box",
        };
        }
        public static string[] ValeuresFinDeRound6()
        {
            return new[]
            {
            "Sue is the current player",
            "They have rolled a 2",
            "Sue is not getting out of the penalty box",
            "Question was incorrectly answered",
            "Sue was sent to the penalty box",
        };
        }
    }
}

