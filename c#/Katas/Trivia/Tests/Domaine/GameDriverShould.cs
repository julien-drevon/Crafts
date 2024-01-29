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
using Trivia.Domaine.UseCases;
using Xunit;

namespace Tests.Domaine;

public class GameDriverShould
{
    [Fact]
    public async Task WhenIStartAPartieIWantToAddAPlayers()
    {
        var gameId = Guid.NewGuid();
        var playersName = new[] { "Chet", "Pat" };
        var gameAdapter = new GameDriverAdapter<TriviaGame>(new SimplePresenter<TriviaGame>(), new GameRepositryStub());
        var gameResult = await gameAdapter.Create(new NewGameRequest(Guid.NewGuid(), gameId, playersName));
        gameResult.TriviaGame.Id.Should().Be(gameId);
        gameResult.TriviaGame.Players.Select(x => x.Name).Should().BeEquivalentTo(playersName);
        gameResult.TriviaGame.Status.Should().Be(TriviaGameStatus.NotStarted);
    }

    [Fact]
    public async Task DefineQueryError()
    {
        var gameId = Guid.NewGuid();

        var gameAdapter = new GameDriverAdapter<TriviaGame>(new SimplePresenter<TriviaGame>(), new GameRepositryStub());

        var gameResult = await gameAdapter.Create(new NewGameRequest(Guid.NewGuid(), gameId, new[] { "Chet" }));
        gameResult.Error.IsOnError().Should().BeTrue();
        gameResult.Error.Message.Should().Be("Minimum player is 2");

        gameResult = await gameAdapter.Create(new NewGameRequest(Guid.NewGuid(), gameId, new[] { "Chet", string.Empty }));
        gameResult.Error.IsOnError().Should().BeTrue();
        gameResult.Error.Message.Should().Be("Minimum player is 2");

        gameResult = await gameAdapter.Create(new NewGameRequest(Guid.NewGuid(), Guid.Empty, new[] { "Chet", "Pat" }));
        gameResult.Error.IsOnError().Should().BeTrue();
        gameResult.Error.Message.Should().Be("Game Id must be define");
    }

    [Fact]
    public async Task GameStartDesign()
    {
        var gameId = Guid.NewGuid();
        var playersName = new[] { "Chet", "Pat", "Sue" };
        var gameAdapter = new GameDriverAdapter<TriviaGame>(new SimplePresenter<TriviaGame>(), new GameRepositryStub());
        _ = await gameAdapter.Create(new NewGameRequest(Guid.NewGuid(), gameId, playersName));

        var gameResult = await gameAdapter.Start(new(Guid.NewGuid(), gameId));
        gameResult.GameResult.Status.Should().Be(TriviaGameStatus.InGame);
    }
}



//public class GameShould
//{
//    [Fact]
//    public void GameDesignsShould()
//    {
//        var GameId = Guid.NewGuid();
//        var players =new[] { "Chet", "Pat", "Sue" };

//        var game = new TriviaGameBuilder(GameId).AddPlayers(players).Build();
//        game.Id.Should().Be(GameId);
//        game.Players.Select(x=> x.Name).Should().BeEquivalentTo(players);

//    }
//}



