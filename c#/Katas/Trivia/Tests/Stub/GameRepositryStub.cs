using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Trivia.Domaine.Entities;
using Trivia.Domaine.Services;
using Trivia.Domaine.UseCases;
using Trivia.OriginalCode;

namespace Tests.Stub;

public class GameRepositryStub : IGameRepository
{
    public Task<TriviaGame> Create(TriviaGame game, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(game);
    }
}