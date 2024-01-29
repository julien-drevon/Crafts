using Trivia.Domaine.Entities;

namespace Trivia.Domaine.Services;

public interface IGameRepository
{
    Task<TriviaGame> Create(TriviaGame query, CancellationToken cancellationToken = default);
}