using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace ElegantCode.Fundamental.Core.Errors;

[Serializable]
public class UseCaseExecption : Exception
{
    public UseCaseExecption(string message) : base(message)
    {
    }

    [ExcludeFromCodeCoverage]
    public UseCaseExecption(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    [ExcludeFromCodeCoverage]
    protected UseCaseExecption(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}