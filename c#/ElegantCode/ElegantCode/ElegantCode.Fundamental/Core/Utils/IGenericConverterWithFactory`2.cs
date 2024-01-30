namespace ElegantCode.Fundamental.Core.Utils;

/// Conversion d'un type par un autre en utilisant une factory pour créer la référence passée en Tout
/// </summary>
/// <typeparam name="Tin">The type of the in.</typeparam>
/// <typeparam name="Tout">The type of the out.</typeparam>
public interface IGenericConverterWithFactory<in Tin, Tout> : IGenericConverter<Tin, Tout>
{
    #region Public Methods

    Tout Convert(Tin data, Func<Tout> factory = null, Func<Tout, Tout> afterConvert = null);

    #endregion Public Methods
}