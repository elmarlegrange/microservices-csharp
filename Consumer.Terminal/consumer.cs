using System;
using RabbitMqHelper;

namespace ServiceB.Terminal
{
    class Consumer
    {
        static void outputConsoleMessage(string message)
        {
            var messageParts = message.Split(new[] { ',' }, 2);

            string name = messageParts[1].Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine($"INVALID NAME INPUT DETECTED");
            }
            else
            {
                Console.WriteLine($"Hello {name}, I am your father!");
            }
        }

        static void Main(string[] args)
        {
            RabbitMqHelper.Client.ReceiveTextMessage("localhost", 
                "hello",
                outputConsoleMessage);
            Console.WriteLine("Consumer is running ...");
            Console.ReadLine();
        }
    }
}
