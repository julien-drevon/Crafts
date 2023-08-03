using ElegantCode.Fundamental.Core.Entities;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace ElegantCode.Fundamental.Core.UsesCases;

[Serializable]
public class UseCaseException : Exception, IGotCorrelationToken
{
    public virtual Guid CorrelationToken { get; }

    public UseCaseException(Guid correlationToken, string message) : base(message)
    {
        CorrelationToken = correlationToken;
    }

    [ExcludeFromCodeCoverage]
    public UseCaseException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    [ExcludeFromCodeCoverage]
    protected UseCaseException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}