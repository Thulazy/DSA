using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System;
using System.Threading.Tasks;

namespace RabbitMQConsumer
{
    public class Receiver
    {
        public void ReceiveMessages()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "hello_queue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            Console.WriteLine(" [*] Waiting for messages. To exit press CTRL+C");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [x] Received '{message}'");
            };

            channel.BasicConsume(queue: "hello_queue",
                                 autoAck: true, 
                                 consumer: consumer);

            Console.ReadLine(); 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var receiver = new Receiver();
            receiver.ReceiveMessages();
        }
    }
}