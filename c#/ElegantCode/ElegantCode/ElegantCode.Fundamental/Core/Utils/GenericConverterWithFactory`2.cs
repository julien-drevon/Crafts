namespace ElegantCode.Fundamental.Core.Utils
{
    /// <summary>
    /// The  return is initialyze by the factory and convert data
    /// </summary>
    /// <typeparam name="Tin">The type of the in.</typeparam>
    /// <typeparam name="Tout">The type of the out.</typeparam>
    /// <seealso cref="Core.GenericConverter&lt;Tin, Tout&gt;" />
    /// <seealso cref="Core.IGenericConverterWithFactory&lt;Tin, Tout&gt;" />
    public abstract class GenericConverterWithFactory<Tin, Tout> : GenericConverter<Tin, Tout>, IGenericConverterWithFactory<Tin, Tout>
    {
        #region Public Methods

        public virtual Tout Convert(Tin data, Func<Tout> factory = null, Func<Tout, Tout> afterConvert = null)
        {
            Tout retour = default;
            if (data.IsNotNull())
            {
                retour = factory != null ? factory() : retour;
                retour = ConvertData(data, retour);
            }

            if (afterConvert.IsNotNull())
                retour = afterConvert.Invoke(retour);

            return retour;
        }

        #endregion Public Methods

        #region Protected Methods

        protected override Tout ConvertData(Tin data)
        {
            return Convert(data, null, null);
        }

        /// <summary>
        /// Converts the data. retour is initilyze by the factory before passed in arguments
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="retour">The retour.</param>
        /// <returns></returns>
        protected abstract Tout ConvertData(Tin data, Tout retour);

        #endregion Protected Methods
    }
}