using System;
using System.Threading;
using System.Threading.Tasks;
using Trivia.Domaine.Entities;
using Trivia.Domaine.Services;

namespace Tests.Stub;

public class UniqueGameRepositryStub : IGameRepository
{

    TriviaGame _Game;

    public Task<TriviaGame> Create(TriviaGame game, CancellationToken cancellationToken = default)
    {
        _Game = game;
        return Task.FromResult(_Game);
    }

    public Task<TriviaGame> Get(Guid correlationToken, Guid idGame, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_Game);
    }

    public Task<TriviaGame> Save(TriviaGame query, CancellationToken cancellationToken = default)
    {
        _Game = query;
        return Task.FromResult(_Game);
    }
}