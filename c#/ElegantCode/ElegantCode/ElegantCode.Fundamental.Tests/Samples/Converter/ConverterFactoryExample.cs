namespace ElegantCode.Fundamental.Tests.Samples.Converter
{
    public class ConverterFactoryExample : GenericConverterWithFactory<ConvertFactModel, ConvertFactResult>
    {
        protected override ConvertFactResult ConvertData(ConvertFactModel data, ConvertFactResult retour)
        {
            retour = retour ?? new ConvertFactResult();

            retour.Id = retour.Id != 0 ? retour.Id : data.Id;
            retour.Label = data.Label;
            return retour;
        }
    }
}