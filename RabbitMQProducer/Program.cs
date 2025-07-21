using RabbitMQ.Client;
using System.Text;
using System;

namespace RabbitMQProducer
{
    public class Sender
    {
        public void SendMessage(string message)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "hello_queue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "",
                                 routingKey: "hello_queue",
                                 basicProperties: null,
                                 body: body);

            Console.WriteLine($" [x] Sent '{message}'");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sender = new Sender();
            string messageToSend = args.Length > 0 ? string.Join(" ", args) : "Hello World!";
            sender.SendMessage(messageToSend);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}