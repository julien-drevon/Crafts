namespace ElegantCode.Fundamental.Core;

public interface IUseCaseAsync<TQuery, TPresentationData>
{
    Task<TPresentationData> Execute(TQuery request, CancellationToken cancelToken = default);
}