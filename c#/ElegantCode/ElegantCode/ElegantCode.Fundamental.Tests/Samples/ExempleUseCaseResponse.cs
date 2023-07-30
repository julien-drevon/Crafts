﻿using ElegantCode.Fundamental.Core.UsesCases;

namespace ElegantCode.Fundamental.Tests.Samples;

public class ExempleUseCaseResponse : UseCaseResponseBase
{
    public ExempleUseCaseResponse(Guid correlationToken, string theResponse)
        : base(correlationToken)
    {
        TheResponse = theResponse;
    }

    public string TheResponse { get; }
}