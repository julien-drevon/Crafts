using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Trivia;
using Trivia.Infra;
using Xunit;

namespace Tests;

public class RunGame_MasterShould
{
    IGameRunner GameRunner = new GameRunner_Master();


    [Fact]
    public void RunbGameScenario()
    {
        var printer = new MyDisplaySpy();
        var generator = new MyDeterministeGenerator();
        generator.BeforeRoundStart += (o, e) =>
        {
            ValeuresAttenduePourLeScenario(e, printer, generator);
        };

        // printer.Printed += (o, e) => whenIPrint(o, e, printer, generator);
        GameRunner.Run(printer, generator, 2);
    }

    private static void ValeuresAttenduePourLeScenario(
        (int Round, int Max) e,
        MyDisplaySpy printer,
        MyDeterministeGenerator generator)
    {
        if (generator.Round == 1)
        {
            generator.NumberToRandReturn = 1;
            if (DebutDeRound(e))
            {
                printer.PrintHistory.Should().BeEquivalentTo(ValeuresDuScenarioMaster.DebutDePartie());
                printer.PrintHistory.Clear();
            }
        }
        if (generator.Round == 2)
        {
            generator.NumberToRandReturn = 0;
            if (DebutDeRound(e))
            {
                printer.PrintHistory.Should().BeEquivalentTo(ValeuresDuScenarioMaster.ValeuresFinDeRound1());
                printer.PrintHistory.Clear();
            }
        }
        if (generator.Round == 3)
        {
            if (DebutDeRound(e))
            {
                generator.NumberToRandReturn = 3;
                printer.PrintHistory.Should().BeEquivalentTo(ValeuresDuScenarioMaster.ValeuresFinDeRound2());
                printer.PrintHistory.Clear();
            }
            else
            {
                generator.NumberToRandReturn = 7;
            }
        }
        if (generator.Round == 4)
        {
            if (DebutDeRound(e))
            {
                generator.NumberToRandReturn = 3;
                printer.PrintHistory.Should().BeEquivalentTo(ValeuresDuScenarioMaster.ValeuresFinDeRound3());
                printer.PrintHistory.Clear();
            }
            else
            {
                generator.NumberToRandReturn = 7;
            }
        }
        if (generator.Round == 5)
        {
            if (DebutDeRound(e))
            {
                generator.NumberToRandReturn = 4;
                printer.PrintHistory.Should().BeEquivalentTo(ValeuresDuScenarioMaster.ValeuresFinDeRound4());
                printer.PrintHistory.Clear();
            }
            else
            {
                generator.NumberToRandReturn = 7;
            }
        }
        if (generator.Round == 6)
        {
            if (DebutDeRound(e))
            {
                generator.NumberToRandReturn = 1;
                printer.PrintHistory.Should().BeEquivalentTo(ValeuresDuScenarioMaster.ValeuresFinDeRound5());
                printer.PrintHistory.Clear();
            }
            else
            {
                generator.NumberToRandReturn = 1;
            }
        }
    }


    private static bool DebutDeRound((int Round, int Max) e)
    { return e.Max == MyDeterministeGenerator.MAX_VALUE_FOR_START; }
}

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
            "",

        };
    }    
    public static string[] ValeuresFinDeRound5()
    {
        return new[]
        {
            "",

        };
    }
    public static string[] ValeuresFinDeRound6()
    {
        return new[]
        {
            "",

        };
    }
    public static string[] ValeuresFinDeRound7()
    {
        return new[]
        {
            "",

        };
    }
    public static string[] ValeuresFinDeRound8()
    {
        return new[]
        {
            "",

        };
    }
}

public class MyDisplaySpy : IPrint
{
    //public EventHandler<string> Printed;

    public void WriteLine(string text)
    {
        PrintHistory.Add(text);
        //Printed(this, text);
    }

    public IList<string> PrintHistory { get; } = new List<string>();
}

public class MyDeterministeGenerator : IGenerateRand
{
    public const int MAX_VALUE_FOR_START = 5;

    public int NumberToRandReturn { get; set; }

    public int Round { get; private set; }

    public EventHandler<(int Round, int Max)> BeforeRoundStart;

    public int GenerateNew(int maxValue)
    {
        if (maxValue == MAX_VALUE_FOR_START)
            Round++;
        BeforeRoundStart(this, new(Round, maxValue));
        return this.NumberToRandReturn;
    }
}

