namespace ElegantCode.Fundamental.Core.Utils
{
    /// <summary>
    /// Converter générique
    /// </summary>
    /// <typeparam name="Tin">The type of the in.</typeparam>
    /// <typeparam name="Tout">The type of the out.</typeparam>
    /// <seealso cref="Agaetis.Core.IGenericConverter&lt;Tin, Tout&gt;" />
    public abstract class GenericConverter<Tin, Tout> : IGenericConverter<Tin, Tout>
    {
        #region Public Methods

        /// <summary>
        /// Applique une conversion
        /// </summary>
        /// <param name="data">une donnée a convertir</param>
        /// <param name="afterConvert">un ensemble d'action a faire sur l'objet avant de le retourner</param>
        /// <returns></returns>
        public virtual Tout Convert(Tin data, Func<Tout, Tout> afterConvert = null)
        {
            Tout retour = default;

            if (data.IsNotNull())
                retour = ConvertData(data);

            if (afterConvert.IsNotNull())
                retour = afterConvert.Invoke(retour);

            return retour;
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Applique une conversion
        /// </summary>
        /// <param name="datas">une donnée a convertir</param>
        /// <returns></returns>
        protected abstract Tout ConvertData(Tin data);

        #endregion Protected Methods
    }
}