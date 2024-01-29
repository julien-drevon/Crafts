using ElegantCode.Fundamental.Core.DriverAdapter;
using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.Utils;
using Trivia.Domaine.UseCases;

namespace Trivia.Domaine.Drivers;

public class StartGameRequest : BaseDriverAdapterRequest<StartGameQuery>
{
    public StartGameRequest(Guid correlationToken, Guid gameId, int desValues) : base(correlationToken)
    {
        GameId = gameId;
        DesValues = desValues;
    }

    public Guid GameId { get; }
    public int DesValues { get; }

    public override (StartGameQuery UseCaseQuery, Error Error) ValidateRequest()
    {
        return this.ValidationWorkflow(
             valueIfIsGood: new StartGameQuery(CorrelationToken, GameId, DesValues));
    }
}
