﻿using ElegantCode.Fundamental.Core.UsesCases;
using Rpg.Core.Domain;
using Rpg.Core.Dto;
using Rpg.Core.Providers;
using Rpg.Core.UseCases.Query;

namespace Rpg.Core.UseCases;

public class CreateWorldUseCase : IUseCaseAsync<CreateWorldUseCaseQuery, WorldUseCaseResponse>
{
    private readonly IProvideTheWorld worldProvider;

    public CreateWorldUseCase(IProvideTheWorld worldProvider)
    {
        this.worldProvider = worldProvider;
    }

    public async Task<WorldUseCaseResponse> Execute(CreateWorldUseCaseQuery request, CancellationToken cancelToken = default)
    {
        var world = await worldProvider.CreateWorld(request);
        return new WorldUseCaseResponse(world.Id, request.CorrelationToken);
    }
}
