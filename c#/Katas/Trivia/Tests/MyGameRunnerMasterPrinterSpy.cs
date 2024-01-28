using System.Collections.Generic;
using Trivia.Infra;

namespace Tests
{
    public class MyGameRunnerMasterPrinterSpy : IPrint
    {

        public void WriteLine(string text)
        {
            PrintHistory.Add(text);
        }

        public IList<string> PrintHistory { get; } = new List<string>();
    }
}