using ElegantCode.Fundamental.Core.Errors;
using System.Runtime.Serialization;

namespace Rpg.Providers;

[Serializable]
public class WorldProviderException : UseCaseException
{

    public WorldProviderException(Guid correlationToken, string message) : base(correlationToken, message)
    {
    }

    public WorldProviderException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected WorldProviderException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}