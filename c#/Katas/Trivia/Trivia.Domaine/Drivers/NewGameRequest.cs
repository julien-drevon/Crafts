﻿using ElegantCode.Fundamental.Core.DriverAdapter;
using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.UsesCases;
using ElegantCode.Fundamental.Core.Utils;
using System.Runtime.CompilerServices;
using Trivia.Domaine.Entities;
using Trivia.Domaine.UseCases;

namespace Trivia.Domaine.Drivers;

public class NewGameRequest : BaseDriverAdapterRequest<CreateGameQuery>
{
    private const string GAME_ID_MUST_BE_DEFINE = "Game Id must be define";
    private const string MINIMUM_PLAYER_REQUIRED = "Minimum player is 2";

    public NewGameRequest(Guid correlationToken, Guid gameId, string[] playersName, Func<TriviaPlateau> plateau) : base(correlationToken)
    {
        GameId = gameId;
        PlayerNames = playersName;
        Plateau = plateau();
    }

    public Guid GameId { get; }

    public TriviaPlateau Plateau { get; set; }

    public string[] PlayerNames { get; }

    public override (CreateGameQuery UseCaseQuery, Error Error) ValidateRequest()
    {
        return this.ValidationWorkflow(
            valueIfIsGood: new CreateGameQuery(CorrelationToken) { GameId = GameId, PlayerNames = PlayerNames, Plateau = Plateau },
            PlayerNames.Where(x => x.IsNotNullOrEmpty()).CreateErrorRule(x => x.Count() < 2, MINIMUM_PLAYER_REQUIRED),
            GameId.CreateErrorRule(x => x.IsEmpty(), GAME_ID_MUST_BE_DEFINE));
    }
}
public class RepondreGameRequest: BaseDriverAdapterRequest<RepondreGameQuery>
{
    public RepondreGameRequest(Guid correlationToken, Guid gameId, string reponse) : base(correlationToken)
    {
        Guid = correlationToken;
        GameId = gameId;
        Reponse = reponse;
    }

    public Guid Guid { get; }
    public Guid GameId { get; }
    public string Reponse { get; }


    public override (RepondreGameQuery UseCaseQuery, Error Error) ValidateRequest()
    {
        return this.ValidationWorkflow(
            valueIfIsGood: new RepondreGameQuery(CorrelationToken, GameId, Reponse));
    }
}
