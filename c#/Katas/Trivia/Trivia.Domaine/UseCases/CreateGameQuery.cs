using ElegantCode.Fundamental.Core.UsesCases;
using Trivia.Domaine.Entities;

namespace Trivia.Domaine.UseCases;

public class CreateGameQuery : UseCaseQueryBase
{
    public CreateGameQuery(Guid correlationToken)
        : base(correlationToken)
    {
    }

    public Guid GameId { get; set; }

    public TriviaPlateau Plateau { get; internal set; }

    public IEnumerable<string> PlayerNames { get; set; }
}