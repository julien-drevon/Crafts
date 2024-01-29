using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.Presenter;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.Stub;
using Trivia.Domaine.Drivers;
using Trivia.Domaine.Entities;
using Trivia.Domaine.Factories;
using Trivia.Domaine.Services;
using Xunit;

namespace Tests.Domaine;

public class GenerateNumberForQuestions : IGenerateRand
{
    public int GenerateNew(int maxValue) { return 1; }
}

public class GameDriverShould
{
    static IEnumerable<TriviaQuestion> Questions = new[]
    {
        new TriviaQuestion(
        TriviaPlateauFactory.CreateDefaultCategories().ToList()[0],
        "Quelle est la reponse à la question de toutes les questions?",
        "42")
    };

    string Chet_FirstPlayer { get; } = "Chet";

    string Pat_SecondPlayer { get; } = "Pat";

    string Sue_ThirdPlayer { get; } = "Sue";

    Func<TriviaPlateau> Plateau = () => TriviaPlateauFactory.Create(
        new GenerateNumberForQuestions(),
        () => TriviaPlateauFactory.CreateTriviaCases(TriviaPlateauFactory.CreateDefaultCategories(), 4),
        Questions);

    [Fact]
    public async Task WhenIStartAPartieIWantToAddAPlayers()
    {
        var gameId = Guid.NewGuid();
        var playersName = new[] { Chet_FirstPlayer, Pat_SecondPlayer };
        var gameAdapter = new GameDriverAdapter<TriviaGame>(
            new SimplePresenter<TriviaGame>(),
            new UniqueGameRepositryStub());
        var (gameResult, _) = await gameAdapter.Create(new NewGameRequest(Guid.NewGuid(), gameId, playersName, Plateau));

        gameResult.Id.Should().Be(gameId);
        gameResult.Players.Select(x => x.Name).Should().BeEquivalentTo(playersName);
        gameResult.CurrentRound.Status.Should().Be(TriviaGameStatus.NotStarted);
        gameResult.NextPlayer.Name.Should().Be(Chet_FirstPlayer);
        gameResult.Plateau.Cases.Should().BeEquivalentTo(Plateau().Cases);
    }

    [Fact]
    public async Task DefineQueryError()
    {
        var gameId = Guid.NewGuid();

        var gameAdapter = new GameDriverAdapter<TriviaGame>(
            new SimplePresenter<TriviaGame>(),
            new UniqueGameRepositryStub());

        var gameResult = await gameAdapter.Create(
            new NewGameRequest(Guid.NewGuid(), gameId, new[] { Chet_FirstPlayer }, Plateau));
        gameResult.Error.IsOnError().Should().BeTrue();
        gameResult.Error.Message.Should().Be("Minimum player is 2");

        gameResult = await gameAdapter.Create(
            new NewGameRequest(Guid.NewGuid(), gameId, new[] { Chet_FirstPlayer, string.Empty }, Plateau));
        gameResult.Error.IsOnError().Should().BeTrue();
        gameResult.Error.Message.Should().Be("Minimum player is 2");

        gameResult = await gameAdapter.Create(
            new NewGameRequest(Guid.NewGuid(), Guid.Empty, new[] { Chet_FirstPlayer, Pat_SecondPlayer }, Plateau));
        gameResult.Error.IsOnError().Should().BeTrue();
        gameResult.Error.Message.Should().Be("Game Id must be define");
    }

    [Fact]
    public async Task GameStartDesign()
    {
        var gameId = Guid.NewGuid();
        var playersName = new[] { Chet_FirstPlayer, Pat_SecondPlayer, Sue_ThirdPlayer };
        var gameAdapter = new GameDriverAdapter<TriviaGame>(
            new SimplePresenter<TriviaGame>(),
            new UniqueGameRepositryStub());
        _ = await gameAdapter.Create(new NewGameRequest(Guid.NewGuid(), gameId, playersName, Plateau));

        int desValue = 1;
        var (gameResult, _) = await gameAdapter.LancerDes(new(Guid.NewGuid(), gameId, desValue));
        gameResult.CurrentRound.Status.Should().Be(TriviaGameStatus.InGame);
        gameResult.CurrentRound.Player.Name.Should().Be(Chet_FirstPlayer);
        gameResult.GameHistory.Should().HaveCount(0);
        gameResult.NextPlayer.Name.Should().Be(Pat_SecondPlayer);
        gameResult.Players.First().Position.Should().BeEquivalentTo(Plateau().Cases.First());
        gameResult.CurrentRound.Question.QuestionText
            .Should()
            .Be("Quelle est la reponse à la question de toutes les questions?");
    }
}