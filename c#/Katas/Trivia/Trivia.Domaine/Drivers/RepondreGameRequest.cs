using ElegantCode.Fundamental.Core.DriverAdapter;
using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.Utils;
using Trivia.Domaine.UseCases;

namespace Trivia.Domaine.Drivers
{
    public class RepondreGameRequest : BaseDriverAdapterRequest<RepondreGameQuery>
    {
        public RepondreGameRequest(Guid correlationToken, Guid gameId, string reponse) : base(correlationToken)
        {
            Guid = correlationToken;
            GameId = gameId;
            Reponse = reponse;
        }

        public Guid GameId { get; }

        public Guid Guid { get; }

        public string Reponse { get; }

        public override (RepondreGameQuery UseCaseQuery, Error Error) ValidateRequest()
        {
            return this.ValidationWorkflow(
                valueIfIsGood: new RepondreGameQuery(CorrelationToken, GameId, Reponse));
        }
    }
}