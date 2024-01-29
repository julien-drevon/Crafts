using System;
using System.Linq;
using System.Threading.Tasks;
using Trivia.Domaine.Entities;
using Trivia.Domaine.Services;
using Trivia.Domaine.UseCases;

namespace Tests.Stub;

public class GameRepositryStub : IGameRepository
{
    public Task<GameResult> Create(CreateGameQuery query)
    {
        return Task.FromResult(new GameResult(query.GameId, query.PlayerNames.Select(x => new Player(x))));
    }
}