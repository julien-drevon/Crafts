namespace ElegantCode.Fundamental.Core.Entities;

/// <summary>
/// Reponse de base sans entite avec un error message et un bool IsOk
/// </summary>
public interface IBaseResponse
{
    bool IsOk { get; set; }

    string Message { get; set; }
}