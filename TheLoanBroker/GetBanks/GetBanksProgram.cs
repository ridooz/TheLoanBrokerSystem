using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.ServiceModel;
using RabbitMQ.Client.Events;
using TheLoanBroker;
using Newtonsoft.Json;

namespace GetBanks
{
    class GetBanksProgram
    {
        public static void Main(string[] args)
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
                channel.QueueDeclare(queue: "creditScore_Queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
                channel.ExchangeDeclare("creditScore_exhange", ExchangeType.Topic);
                channel.QueueBind("creditScore_Queue", "creditScore_exhange", "");

                Console.WriteLine("--GetBanks ready to receive credit score--");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);

                    string[] messageArray = message.Split('#');
                    string ssn = messageArray[0];
                    double amount = Convert.ToDouble(messageArray[1]);
                    int duration = Convert.ToInt32(messageArray[2]);
                    int creditScore = Convert.ToInt32(messageArray[3]);

                    List<Bank> listBanks = GetBanks(creditScore, amount, duration);
                    sendMessage(listBanks, creditScore, ssn, amount, duration);

                };
                channel.BasicConsume(queue: "creditScore_Queue", noAck: true, consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }

        private static List<Bank> GetBanks(int creditScore, double amount, int duration)
        {
            RuleBaseService.RuleBaseSoapClient ruleBaseClient = new RuleBaseService.RuleBaseSoapClient();

            List<Bank> listBanks = new List<Bank>();

            foreach (var bank in ruleBaseClient.GetBanks(creditScore, amount, duration))
            {
                listBanks.Add(new Bank(bank.Bankname, bank.Exchange, bank.TranslatorType));
            }

            return listBanks;
        }

        private static void sendMessage(List<Bank> listBanks, int creditScore, string ssn, double amount, int duration)
        {
            string EXCHANGE_NAME = "getBanks_exchange";

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

                string message = ssn + "#" + amount + "#" + duration + "#" + creditScore + "#" + JsonConvert.SerializeObject(listBanks);
                var body = Encoding.UTF8.GetBytes(message);

                channel.ExchangeDeclare(EXCHANGE_NAME, ExchangeType.Topic);
                channel.BasicPublish(exchange: EXCHANGE_NAME, routingKey: "", basicProperties: null, body: body);

                Console.WriteLine(" [x] Sent {0}", "SSN:" + ssn + " AMOUNT:" + amount + " DURATION:" + duration + " CREDITSCORE:" + creditScore + " BANKS:{"+BankNamesToString(listBanks)+"}");
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();

        }

        private static string BankNamesToString(List<Bank> listBanks)
        {
            string bankNames = "";
            foreach (Bank bank in listBanks) { 
                bankNames += bank.Bankname + ","; 
            }

            return bankNames.TrimEnd(',');
        }



    }
}
