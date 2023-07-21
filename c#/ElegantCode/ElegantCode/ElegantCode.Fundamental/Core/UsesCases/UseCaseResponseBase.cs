namespace ElegantCode.Fundamental.Core.UsesCases
{
    public class UseCaseResponseBase
    {
        public UseCaseResponseBase(Guid correlationToken)
        {
            CorrelationToken = correlationToken;
        }
        public virtual Guid CorrelationToken { get; }

    }
}