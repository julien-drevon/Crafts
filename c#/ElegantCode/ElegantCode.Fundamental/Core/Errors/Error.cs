using ElegantCode.Fundamental.Core.Utils;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace ElegantCode.Fundamental.Core.Errors;

public class Error
{
    public string Message { get => _Message.JoinString(); }
    private List<String> _Message = new();

    public Guid CorrelationToken { get; }

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

    public void AddError(string message)
    {
        if (message.IsNullOrEmpty() is false)
        {
            _Message.Add(message);
        }
    }
}
