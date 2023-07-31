namespace ElegantCode.Fundamental.Core.DriverAdapter.Responses;

/// <summary>
/// Reponse de base sans entite avec un error message et un bool IsOk
/// </summary>
public interface IBaseResponse
{
    bool IsOk { get; set; }

    string Message { get; set; }
}