using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Trivia;
using Trivia.Infra;
using Trivia.Master;
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
using ElegantCode.Fundamental.Core.Utils;

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

