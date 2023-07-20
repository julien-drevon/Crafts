﻿using ElegantCode.Fundamental.Core;

namespace ElegantCode.Fundamental.Tests.Samples;

public class ExempleDriverAdapter<Tout> where Tout : class
{
    private readonly IPresenter<ExempleUseCaseResponse, Tout> _DoExemplePresenter;

    public ExempleDriverAdapter(IPresenter<ExempleUseCaseResponse, Tout> doExemplePresenter)
    {
        _DoExemplePresenter = doExemplePresenter;
    }

    public async Task<(Tout Entity, Error Error)> DoAnExemple(ExempleDriverAdapterRequest aRequestForDriverAdapter, CancellationToken cancellation = default)
    {
        var validation = aRequestForDriverAdapter.ValidateRequest();

        _DoExemplePresenter.PresentError(validation.Error);

        if (validation.Error.IsError() is false)
        {
            try
            {
                _DoExemplePresenter.PresentData(await new ExempleUseCase().Execute(validation.UseCaseQuery, cancellation));
            }
            catch (UseCaseExecption ex)
            {
                _DoExemplePresenter.PresentError(new(aRequestForDriverAdapter.CorrelationToken, ex.Message));
            }
        }


        return await _DoExemplePresenter.View();

    }
}

