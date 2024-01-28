using ElegantCode.Fundamental.Core.Presenter;
using FluentAssertions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Trivia.Domaine.Drivers;
using Trivia.Domaine.UseCases;
using Xunit;

namespace Tests
{
    public class GameShould
    {
        [Fact]
        public async Task WhenIStartAPartieIWantToAddAPlayers()
        {
            var gameId = Guid.NewGuid();
            var playersName = new[] { "", "", "" };
            var gameAdapter = new GameDriverAdapter<GameResult>(new SimplePresenter<GameResult>());
            var gameResult = await gameAdapter.CreateNew(new NewGameRequest(Guid.NewGuid(), gameId, playersName));
            gameResult.GameResult.GameId.Should().Be(gameId);
            gameResult.GameResult.Players.Select(x => x.Name).Should().BeEquivalentTo(playersName);
        }
    }
}