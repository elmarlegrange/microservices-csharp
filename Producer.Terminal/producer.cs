using System;
using RabbitMqHelper;

namespace Producer.Terminal
{
    class Producer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();

            Client.SendTextMessage(
                "localhost", 
                "hello", 
                "hello",
                $"Hello my name is, {name}"
            );

            Console.WriteLine("Posted message to queue.\nPress Enter or Ctrl+C to terminate.");

            Console.ReadLine();
        }
    }
}
