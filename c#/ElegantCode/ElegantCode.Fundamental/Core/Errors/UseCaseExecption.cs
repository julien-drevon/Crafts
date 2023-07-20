using System.Runtime.Serialization;

namespace ElegantCode.Fundamental.Core.Errors;

[Serializable]
public class UseCaseExecption : Exception
{
    public UseCaseExecption()
    {
    }

    public UseCaseExecption(string message) : base(message)
    {
    }

    public UseCaseExecption(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected UseCaseExecption(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
