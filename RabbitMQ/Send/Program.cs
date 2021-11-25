using System;
using RabbitMQ.Client;
using System.Text;

namespace Console.RabbitMQ.Send
{
    public class Send
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("Hello",false,false,false,null);

                string message = "Hello World";

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(string.Empty,"Hello",false,null,body);

                System.Console.WriteLine($"Sent Message : {message}");
            }
        }
    }
}