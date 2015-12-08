using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.ServiceModel;
using RabbitMQ.Client.Events;
using TheLoanBroker;

namespace TranslatorMESSAGING
{
    class TranslatorMESSAGINGProgram
    {
        static void Main(string[] args)
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
                channel.QueueDeclare(queue: "translatorMESSAGING_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
                channel.ExchangeDeclare("recipientList_exchange", ExchangeType.Topic);
                channel.QueueBind("translatorMESSAGING_queue", "recipientList_exchange", "MESSAGING"); 
                
                Console.WriteLine("--MESSAGING TRANSLATOR ready to receive credit score--");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);

                    // start

                    Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: "translatorMESSAGING_queue", noAck: true, consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
