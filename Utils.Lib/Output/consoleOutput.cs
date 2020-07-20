using System;

namespace Utils
{
    public class ConsoleOutput : IOutput
    {
        public void Write(string output)
        {
            Console.WriteLine(output);
        }
    }
}
