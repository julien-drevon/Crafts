using System.Threading;
using System.Threading.Tasks;
using Trivia.Domaine.UseCases;

namespace Trivia.Domaine.Services;

public interface IGameRepository
{
    Task<GameResult> Create(CreateGameQuery query, CancellationToken cancellationToken = default);
}