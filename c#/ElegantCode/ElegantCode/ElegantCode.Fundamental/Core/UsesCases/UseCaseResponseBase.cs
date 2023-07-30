using ElegantCode.Fundamental.Core.Utils;

namespace ElegantCode.Fundamental.Core.UsesCases
{
    public class UseCaseResponseBase //: IGotCorrelationToken
    {
        public UseCaseResponseBase(Guid correlationToken)
        {
            //CorrelationToken = correlationToken;
        }

        //public virtual Guid CorrelationToken { get; }
    }
}