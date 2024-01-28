﻿using ElegantCode.Fundamental.Core.UsesCases;
using System;
using System.Collections.Generic;

namespace Trivia.Domaine.UseCases
{
    public class CreateGameQuery : UseCaseQueryBase
    {
        public CreateGameQuery(Guid correlationToken) : base(correlationToken)
        {
        }

        public Guid GameId { get; set; }

        public IEnumerable<string> PlayerNames { get; set; }
    }
}