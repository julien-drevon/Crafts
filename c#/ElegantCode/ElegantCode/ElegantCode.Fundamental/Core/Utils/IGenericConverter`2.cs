namespace ElegantCode.Fundamental.Core.Utils
{
    /// <summary>
    /// <summary>
    /// Conversion d'un type vers un autre
    /// </summary>
    /// <typeparam name="Tin">The type of the in.</typeparam>
    /// <typeparam name="Tout">The type of the out.</typeparam>
    public interface IGenericConverter<in Tin, Tout>
    {
        #region Public Methods

        Tout Convert(Tin data, Func<Tout, Tout> afterConvert = null);

        #endregion Public Methods
    }
}