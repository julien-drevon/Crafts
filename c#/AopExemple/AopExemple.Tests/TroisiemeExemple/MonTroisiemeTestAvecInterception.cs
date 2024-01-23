using AopExemple.Tests.Loggers;
using FluentAssertions;

namespace AopExemple.Tests.TroisiemeExemple;

public class MonTroisiemeTestAvecInterception
{
    private MonSpyLogger leLogger;
    private IMUseCase<TroisiemeExempleQuery, string> useCase;

    public MonTroisiemeTestAvecInterception(MonSpyLogger leLogger, IMUseCase<TroisiemeExempleQuery, string> exemple)
    {
        this.leLogger = leLogger;
        useCase = exemple;
    }

    [Fact]
    public void EnTantQueDev_QuandOnAppelFaitUnTruc_JaimeraisLoggerParInterception()
    {
        useCase.Execute(new() { Value = "42" });
        leLogger.IsLog.Should().BeTrue();
    }
}