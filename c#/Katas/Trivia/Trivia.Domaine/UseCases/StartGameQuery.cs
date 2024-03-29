﻿using ElegantCode.Fundamental.Core.UsesCases;

namespace Trivia.Domaine.UseCases;

public class StartGameQuery : UseCaseQueryBase
{
    public StartGameQuery(Guid correlationToken, Guid gameId, int roll)
        : base(correlationToken)
    {
        this.GameId = gameId;
        this.DesValue = roll;
    }

    public int DesValue { get; private set; }

    public Guid GameId { get; private set; }
}