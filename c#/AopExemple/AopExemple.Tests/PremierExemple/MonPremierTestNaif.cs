using AopExemple.Tests.Loggers;
using FluentAssertions;

namespace AopExemple.Tests.PremierExemple;

public class MonPremierTestNaif
{
    [Fact]
    public void EnTantQueDev_JaimeraisLoggerDansMaFonction()
    {
        var leLogger = new MonSpyLogger();
        var useCase = new MonPremierExemple(leLogger);

        useCase.Execute("42");

        leLogger.IsLog.Should().BeTrue();
    }
}