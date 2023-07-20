using ElegantCode.Fundamental.Core.Utils;

namespace ElegantCode.Fundamental.Core.Errors;

public class Error
{
    private List<String> _Message = new();

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

    public string Message { get => _Message.JoinString(); }

    public void AddError(string message)
    {
        if (message.IsNullOrEmpty() is false)
        {
            _Message.Add(message);
        }
    }
}