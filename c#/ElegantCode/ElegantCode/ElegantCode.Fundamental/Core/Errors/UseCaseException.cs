using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace ElegantCode.Fundamental.Core.Errors;

[Serializable]
public class UseCaseException : Exception
{
    public Guid CorrelationToken { get;  }

    public UseCaseException(Guid correlationToken, string message) : base(message)
    {
        this.CorrelationToken = correlationToken;
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