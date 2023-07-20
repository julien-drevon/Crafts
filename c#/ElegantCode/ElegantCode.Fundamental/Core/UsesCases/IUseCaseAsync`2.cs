namespace ElegantCode.Fundamental.Core.UsesCases;

public interface IUseCaseAsync<TQuery, TPresentationData>
{
    Task<TPresentationData> Execute(TQuery request, CancellationToken cancelToken = default);
}