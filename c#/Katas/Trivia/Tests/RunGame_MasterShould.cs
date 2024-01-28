using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Trivia;
using Trivia.Infra;
using Xunit;
using ElegantCode.Fundamental;
using Microsoft.Extensions.Hosting;
using ElegantCode.Fundamental.Core.Presenter;
using System.Threading.Tasks;
using ElegantCode.Fundamental.Core.DriverAdapter;
using ElegantCode.Fundamental.Core.Entities;
using ElegantCode.Fundamental.Core.UsesCases;
using System.Runtime.CompilerServices;
using ElegantCode.Fundamental.Core.Errors;
using System.Threading;

namespace Tests;

public class RunGame_MasterShould
{
    const int ROLL_TO_LOOSE = 7;
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
        GameRunner.Run(printer, generator, 3);
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
                generator.NumberToRandReturn = ROLL_TO_LOOSE;
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
                generator.NumberToRandReturn = 2;
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
                generator.NumberToRandReturn = ROLL_TO_LOOSE;
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
                generator.NumberToRandReturn = ROLL_TO_LOOSE;
            }
        }
        if (generator.Round == 7)
        {
            if (DebutDeRound(e))
            {
                generator.NumberToRandReturn = 2;
                printer.PrintHistory.Should().BeEquivalentTo(ValeuresDuScenarioMaster.ValeuresFinDeRound6());
                printer.PrintHistory.Clear();
            }
            else
            {
                generator.NumberToRandReturn = 2;
            }
        }

    }


    private static bool DebutDeRound((int Round, int Max) e)
    { return e.Max == MyDeterministeGenerator.MAX_VALUE_FOR_START; }
}



public class GameShould
{
    [Fact]
    public async Task WhenIStartAPartieIWantToAddAPlayers()
    {

        var gameId = Guid.NewGuid();
        var playersName = new[] { "", "", "" };
        var gameAdapter = new GameDriverAdapter(new SimplePresenter<GameResult>());
        var gameResult = await gameAdapter.CreateNew(new NewGameRequest(Guid.NewGuid(), gameId, playersName));
        gameResult.GameResult.GameId.Should().Be(gameId);
        gameResult.GameResult.Players.Select(x => x.Name).Should().BeEquivalentTo(playersName);
    }
}


public class NewGameRequest //: BaseDriverAdapterRequest<BaseDriverQuery>
{

    public NewGameRequest(Guid correlationToken, Guid gameId, string[] playersName)//:base(correlationToken)
    {
        Guid = correlationToken;
        GameId = gameId;
        PlayersName = playersName;
    }

    public Guid Guid { get; }
    public Guid GameId { get; }
    public string[] PlayersName { get; }


    //public override (BaseDriverQuery UseCaseQuery, Error Error) ValidateRequest()
    //{
    //    throw new NotImplementedException();
    //}
}



public class GameDriverAdapter
{
    private IInPresenter<GameResult> gamePresenter;

    public GameDriverAdapter(IInPresenter<GameResult> gamePresenter)
    {
        this.gamePresenter = gamePresenter;
    }

    public async Task<(GameResult GameResult, Error Error)> CreateNew(NewGameRequest gameRequest, CancellationToken cancellation = default)
    {
        var players = gameRequest.PlayersName.Select(x => new Player(x));
        return new(new(gameRequest.GameId, players.ToList()), null);
    }
}

public class GameResult
{
    public GameResult(Guid gameId, IEnumerable<Player> players)
    {
        GameId = gameId;
        Players = players;
    }

    public Guid GameId { get; internal set; }
    public IEnumerable<Player> Players { get; internal set; }
}

public class Player
{
    public Player(string name)
    {
        Name = name;
    }

    public string Name { get; internal set; }
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

