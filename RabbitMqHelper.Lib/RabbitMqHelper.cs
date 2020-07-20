using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMqHelper
{
    public class Client
    {
        public static void SendTextMessage(string hostName, 
            string queueName, 
            string routingKeyName, 
            string message)
        {
            var factory = new ConnectionFactory() { HostName = hostName };
            using(var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                    routingKey: routingKeyName,
                    basicProperties: null,
                    body: body
                );
            }
        }

        public static void ReceiveTextMessage(string hostName, 
            string queueName,
            Action<string> methodToExecute)
        {

            var factory = new ConnectionFactory() { HostName = hostName };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            
            channel.QueueDeclare(queue: queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                
                methodToExecute(message);
            };

            channel.BasicConsume(queue: queueName,
                autoAck: true,
                consumer: consumer);
        }
    }
}
