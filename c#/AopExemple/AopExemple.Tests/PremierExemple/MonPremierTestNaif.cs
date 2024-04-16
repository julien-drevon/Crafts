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

    [Fact]
    public void UnTest()
    {

        var converter = new MonConverterInToString();

        converter.Convert(1).Should().Be("1");

    }
}

internal class MonConverterInToString : IConvert<int, string>
{
    public MonConverterInToString()
    {
    }

    public string Convert(int v)
    {
        return v.ToString();
    }
}

internal interface IConvert<Tin, Tout>
{
    Tout Convert(Tin v);
}