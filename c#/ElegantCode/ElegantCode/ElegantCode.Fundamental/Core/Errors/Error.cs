using ElegantCode.Fundamental.Core.Utils;

namespace ElegantCode.Fundamental.Core.Errors;

public class Error
{
    private readonly List<String> _Messages = new();

    public Error(Guid correlationToken, string message = "")
    {
        this.AddError(message);
        CorrelationToken = correlationToken;
    }

    public Error(Guid correlationToken, IEnumerable<Error> errors)
        : this(correlationToken, "")
    {
        errors.Foreach(x => this.AddError(x.Message));
    }

    public Guid CorrelationToken { get; }

    public string Message { get => _Messages.ToJoinString(); }

    public void AddError(string message)
    {
        if (message.IsNotNullOrEmpty())
        {
            _Messages.Add(message);
        }
    }
}