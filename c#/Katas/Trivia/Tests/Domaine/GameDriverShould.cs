using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.Presenter;
using FluentAssertions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tests.Domaine.Dummy;
using Tests.Domaine.ServiceFacts;
using Tests.Stub;
using Trivia.Domaine.Drivers;
using Trivia.Domaine.Entities;
using Trivia.Domaine.Factories;
using Xunit;

namespace Tests.Domaine;

public class GameDriverShould
{
    string Chet_FirstPlayer { get; } = "Chet";
    string Pat_SecondPlayer { get; } = "Pat";
    string Sue_ThirdPlayer { get; } = "Sue";

    TriviaPlateau Plateau() => TriviaPlateauFactory.Create(
        new GenerateNumberForQuestions(),
        TriviaPlateauFactory.CreateTriviaCases(TriviaPlateauFactory.CreateDefaultCategories(), 4),
        TriviaQuestionsDummyFatory.Questions());

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
        gameResult.Status.Should().Be(TriviaGameStatus.NotStarted);
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
        GameDriverAdapter<TriviaGame> gameAdapter = CreateAdapter();
        _ = await gameAdapter.Create(new NewGameRequest(Guid.NewGuid(), gameId, playersName, Plateau));

        int desValueForDeplacement = 1;
        var (firstQuestionToChet, _) = await gameAdapter.LancerDes(new(Guid.NewGuid(), gameId, desValueForDeplacement));
        firstQuestionToChet.Status.Should().Be(TriviaGameStatus.InGame);
        firstQuestionToChet.CurrentRound.Player.Name.Should().Be(Chet_FirstPlayer);
        firstQuestionToChet.GameHistory.Should().HaveCount(0);
        firstQuestionToChet.NextPlayer.Name.Should().Be(Pat_SecondPlayer);
        firstQuestionToChet.Players.First().Position.Should().BeEquivalentTo(Plateau().Cases.First());
        firstQuestionToChet.Players.First().Score.Should().Be(0);
        firstQuestionToChet.CurrentRound.Question.QuestionText
            .Should()
            .Be("Quelle est la reponse à la question de toutes les questions?");
        firstQuestionToChet.CurrentRound.Response.Should().BeNull();

        var (firstResponseToChet, _) = await gameAdapter.Repondre(new(Guid.NewGuid(), gameId, "42"));
        firstQuestionToChet.CurrentRound.IsGoodResponse.Should().BeTrue();
        firstQuestionToChet.CurrentRound.Player.Score.Should().Be(1);
    }

    private static GameDriverAdapter<TriviaGame> CreateAdapter()
    {
        return new GameDriverAdapter<TriviaGame>(
            new SimplePresenter<TriviaGame>(),
            new UniqueGameRepositryStub());
    }
}
