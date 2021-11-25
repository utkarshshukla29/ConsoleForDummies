using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Console.RabbitMQ.Recieve
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("Hello", false, false, false, null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    System.Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: "Hello",
                                 autoAck: true,
                                 consumer: consumer);

                System.Console.WriteLine(" Press [enter] to exit.");
                System.Console.ReadLine();
            }
        }
    }
}