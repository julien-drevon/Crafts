namespace ElegantCode.Fundamental.Tests.Samples.Converter
{
    public class ConverterExample : GenericConverter<ConvertFactModel, ConvertFactResult>
    {
        #region Public Methods

        protected override ConvertFactResult ConvertData(ConvertFactModel data)
        {
            var retour = new ConvertFactResult();
            retour.Id = data.Id;
            retour.Label = data.Label;
            return retour;
        }

        #endregion Public Methods
    }
}