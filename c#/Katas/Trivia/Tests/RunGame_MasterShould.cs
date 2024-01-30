using FluentAssertions;
using Trivia.Infra;
using Trivia.Master;
using Xunit;

namespace Tests;

public class RunGame_MasterShould
{
    private const int ROLL_TO_LOOSE = 7;
    private IGameRunner GameRunner = new GameRunner_Master();

    [Fact]
    public void RunbGameScenario()
    {
        var printer = new MyGameRunnerMasterPrinterSpy();
        var generator = new MyGameRunnerMasterDeterministeGenerator();
        generator.BeforeRoundStart += (o, e) =>
        {
            ValeuresAttenduePourLeScenario(e, printer, generator);
        };

        GameRunner.Run(printer, generator, 3);
    }

    private static void ValeuresAttenduePourLeScenario(
        (int Round, int Max) e,
        MyGameRunnerMasterPrinterSpy printer,
        MyGameRunnerMasterDeterministeGenerator generator)
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
    { return e.Max == MyGameRunnerMasterDeterministeGenerator.MAX_VALUE_FOR_START; }
}