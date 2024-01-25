using System;
using Trivia.Infra;

namespace Trivia
{
    public class ConsolePrinter : IPrint
    {
        public void WriteLine(string text) => Console.WriteLine(text);

    }
}
