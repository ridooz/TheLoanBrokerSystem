using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.ServiceModel;
using RabbitMQ.Client.Events;

namespace ClassLibrary
{
    public class Control
    {
        public Control()
        {

        }

        public  void sendMessage(string EXCHANGE_NAME, string message, string println)
        {

            ConnectionFactory factory = new ConnectionFactory()
            {
                HostName = "datdb.cphbusiness.dk",
                Port = 5672,
                UserName = "student",
                Password = "cph"
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {

                var body = Encoding.UTF8.GetBytes(message);

                channel.ExchangeDeclare(EXCHANGE_NAME, ExchangeType.Topic);
                channel.BasicPublish(exchange: EXCHANGE_NAME, routingKey: "", basicProperties: null, body: body);

                Console.WriteLine(" [x] Sent {0}", println);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();

        }



        public void sendMessage(string EXCHANGE_NAME, string message, string println, string routingkey)
        {

            ConnectionFactory factory = new ConnectionFactory()
            {
                HostName = "datdb.cphbusiness.dk",
                Port = 5672,
                UserName = "student",
                Password = "cph"
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {

                var body = Encoding.UTF8.GetBytes(message);

                channel.ExchangeDeclare(EXCHANGE_NAME, ExchangeType.Topic);
                channel.BasicPublish(exchange: EXCHANGE_NAME, routingKey: routingkey, basicProperties: null, body: body);

                Console.WriteLine(" [x] Sent {0}", println);
            }

            Console.WriteLine(" Press [enter] to exit.");
            return;

        }

    }
}
