using AopExemple.Tests.Loggers;
using FluentAssertions;

namespace AopExemple.Tests.DeuxiemeExemple;

public class MonDeuxiemeTestAvecDecorator
{
    private MonSpyLogger leLogger;
    private IMUseCase<DeuxiemeExempleQuery, string> useCase;

    public MonDeuxiemeTestAvecDecorator(MonSpyLogger leLogger, IMUseCase<DeuxiemeExempleQuery, string> exemple)
    {
        this.leLogger = leLogger;
        this.useCase = exemple;
    }

    [Fact]
    public void EnTantQueDev_QuandOnAppelFaitUnTruc_JaimeraisLeDecorerPourLeLogger()
    {
        useCase.Execute(new() { Value = "42" });
        leLogger.IsLog.Should().BeTrue();
    }
}