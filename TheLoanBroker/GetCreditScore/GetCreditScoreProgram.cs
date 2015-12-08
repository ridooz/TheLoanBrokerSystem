using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetCreditScore
{
    class GetCreditScoreProgram
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
                channel.QueueDeclare(queue: "loanQuoteRequest_Queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
                channel.ExchangeDeclare("loanQuoteRequest_exhange", ExchangeType.Topic);
                channel.QueueBind("loanQuoteRequest_Queue", "loanQuoteRequest_exhange", "");

                Console.WriteLine("--GetCreditScore ready to receive Loan Request--");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    string[] messageArray = message.Split('#');
                    string ssn = messageArray[0];
                    double amount = Convert.ToDouble(messageArray[1]);
                    int duration = Convert.ToInt32(messageArray[2]);

                    Console.WriteLine(" [x] Received {0}", "SSN:"+ssn+" AMOUNT:"+amount+" DURATION:"+duration);

                    int creditScore = GetCreditScore(ssn);
                    sendMessage(creditScore, ssn, amount, duration);

                };
                channel.BasicConsume(queue: "loanQuoteRequest_Queue", noAck: true, consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }

        private static int GetCreditScore(string ssn)
        {
            int creditScore = 0;

            CreditScoreService.CreditScoreServiceClient creditBureau = new CreditScoreService.CreditScoreServiceClient();
            creditScore = creditBureau.creditScore(ssn);

            return creditScore;
        }


        private static void sendMessage(int creditScore, string ssn, double amount, int duration)
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

                string message = ssn + "#" + amount + "#" + duration + "#" + creditScore;
                var body = Encoding.UTF8.GetBytes(message);

                channel.ExchangeDeclare("getCreditScore_exhange", ExchangeType.Topic);
                channel.BasicPublish(exchange: "getCreditScore_exhange", routingKey: "", basicProperties: null, body: body);

                Console.WriteLine(" [x] Sent {0}", "SSN:" + ssn + " AMOUNT:" + amount + " DURATION:" + duration + " CREDITSCORE:" + creditScore);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();

        }

    }
}
