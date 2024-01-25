using System;

namespace Trivia
{
    public class ConsolePrinter : IPrint
    {
        public void WriteLine(string text) => Console.WriteLine(text);

    }
}
