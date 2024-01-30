using ElegantCode.Fundamental.Core.UsesCases;

namespace Trivia.Domaine.UseCases
{
    public class RepondreGameQuery : UseCaseQueryBase
    {
        public RepondreGameQuery(Guid correlationToken, Guid gameId, string reponse)
            : base(correlationToken)
        {
            GameId = gameId;
            Reponse = reponse;
        }

        public Guid GameId { get; }

        public string Reponse { get; }
    }
}