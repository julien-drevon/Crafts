using ElegantCode.Fundamental.Core.DriverAdapter;
using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.Utils;
using System;
using System.Linq;
using Trivia.Domaine.UseCases;

namespace Trivia.Domaine.Drivers;

public class NewGameRequest : BaseDriverAdapterRequest<CreateGameQuery>
{
    const string MINIMUM_PLAYER_REQUIRED = "Minimum player is 2";
    public NewGameRequest(Guid correlationToken, Guid gameId, string[] playersName)
        : base(correlationToken)
    {
        Guid = correlationToken;
        GameId = gameId;
        PlayerNames = playersName;
    }

    public Guid Guid { get; }

    public Guid GameId { get; }

    public string[] PlayerNames { get; }

    public override (CreateGameQuery UseCaseQuery, Error Error) ValidateRequest()
    {
        return this.ValidationWorkflow(
            valueIfIsGood: new CreateGameQuery(CorrelationToken)
            {
                GameId = GameId,
                PlayerNames = PlayerNames
            },
            prediacateErrors: PlayerNames.Where(x=> x.IsNotNullOrEmpty())
                                         .CreateErrorRule(x => x.Count() < 2, MINIMUM_PLAYER_REQUIRED));
    }
}