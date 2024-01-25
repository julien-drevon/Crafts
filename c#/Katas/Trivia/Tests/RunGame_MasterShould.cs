using System;
using System.Collections.Generic;
using System.Linq;
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
            if(generator.Round == 1)
            {
                generator.NumberToRandReturn = 1;
            }
        };

        printer.Printed += (o, e) => scenarioOfPrinting(o, e, printer, generator);
        GameRunner.Run(printer, generator);

    }
    void scenarioOfPrinting(object o, string text, IPrint printer, IGenerateRand generator)
    {
        text.Should().Be("a");
    }

    public class MyDisplaySpy : IPrint
    {
        public EventHandler<string> Printed;
        public void WriteLine(string text)
        {
            PrintHistory.Add(text);
            Printed(this, text);
        }

        public IList<string> PrintHistory { get; } = new List<string>();
    }

    public class MyDeterministeGenerator : IGenerateRand
    {
        public int NumberToRandReturn { get; set; }

        public int Round { get; private set; }

        public EventHandler<int> BeforeRoundStart;
        public int GenerateNew(int maxValue)
        {
            Round++;
            BeforeRoundStart(this, Round);
            return this.NumberToRandReturn;
        }
    }
}
