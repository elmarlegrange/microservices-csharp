using System;
using RabbitMqHelper;
using Utils;

namespace Consumer.Terminal
{
    class Consumer
    {
        static void WriteMessage(string message)
        {
            IValidator nameValidator = new NameValidator(message);
            IOutput consoleOutput = new ConsoleOutput();

            string output;

            if (nameValidator.Validate())
                output = $"Hello {nameValidator.validValue}, I am your father!";
            else
                output = "Invalid name input";

            consoleOutput.Write(output);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Consumer is running ...\nPress Enter or Ctrl+C to terminate.");

            Client.ReceiveTextMessage("localhost", 
                "hello",
                WriteMessage);
            
            Console.ReadLine();
        }
    }
}
