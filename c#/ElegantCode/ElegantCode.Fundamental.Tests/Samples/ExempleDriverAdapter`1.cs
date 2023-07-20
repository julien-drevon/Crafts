﻿using ElegantCode.Fundamental.Core.DriverAdapter;
using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.Presenter;
using System.Threading.Tasks;

namespace ElegantCode.Fundamental.Tests.Samples;

public class ExempleDriverAdapter<Tout> where Tout : class
{
    private readonly IPresenter<ExempleUseCaseResponse, Tout> _DoExemplePresenter;

    public ExempleDriverAdapter(IPresenter<ExempleUseCaseResponse, Tout> doExemplePresenter)
    { _DoExemplePresenter = doExemplePresenter; }

    public async Task<(Tout Entity, Error Error)> DoAnExemple(
        ExempleDriverAdapterRequest aRequestForDriverAdapter,
        CancellationToken cancellation = default)
    {
        return await DriverAdapter.CreateUseCaseWorflow(aRequestForDriverAdapter, new ExempleUseCase(), _DoExemplePresenter, cancellation);
    }
}


