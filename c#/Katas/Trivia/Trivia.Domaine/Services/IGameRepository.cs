using Trivia.Domaine.Entities;

namespace Trivia.Domaine.Services;

public interface IGameRepository
{
    Task<TriviaGame> Create(TriviaGame query, CancellationToken cancellationToken = default);

    Task<TriviaGame> Get(Guid correlationToken, Guid idGame, CancellationToken cancellationToken = default);

    Task<TriviaGame> Save(TriviaGame query, CancellationToken cancellationToken = default);

}