using System;
using System.Collections.Generic;
using System.Linq;
using Trivia.Infra;

namespace Tests
{
    public class MyDisplaySpy : IPrint
    {
        //public EventHandler<string> Printed;

        public void WriteLine(string text)
        {
            PrintHistory.Add(text);
            //Printed(this, text);
        }

        public IList<string> PrintHistory { get; } = new List<string>();
    }
}

