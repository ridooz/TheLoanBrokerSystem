using ClassLibrary;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLoanBroker;

namespace RecipientList
{
    class RecipientListProgram
    {

        static void Main(string[] args)
        {

            Control control = new Control();

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
                channel.QueueDeclare(queue: "getBanks_Queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
                Console.WriteLine("--RecipientList ready to receive banks--");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);

                    string[] messageArray = message.Split('#');
                    string ssn = messageArray[0];
                    double amount = Convert.ToDouble(messageArray[1]);
                    int duration = Convert.ToInt32(messageArray[2]);
                    int creditScore = Convert.ToInt32(messageArray[3]);
                    List<Bank> listBanks = JsonConvert.DeserializeObject<List<Bank>>(messageArray[4]);

                    foreach (Bank bank in listBanks)
                    {
                        string messageSend = ssn + "#" + amount + "#" + duration + "#" + creditScore + "#" + JsonConvert.SerializeObject(bank); 
                        string println = bank.Bankname;
                        string routingKey = bank.TranslatorType;

                        control.sendMessage("recipientList_exchange", messageSend, println, routingKey);

                    }

                    Console.WriteLine(" [x] Received {0}", "SSN:" + ssn + " AMOUNT:" + amount + " DURATION:" + duration + " CREDITSCORE:" + creditScore + " BANKS:{" + BankNamesToString(listBanks) + "}");
                };
                channel.BasicConsume(queue: "getBanks_Queue", noAck: true, consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }

        private static string BankNamesToString(List<Bank> listBanks)
        {
            string bankNames = "";
            foreach (Bank bank in listBanks)
            {
                bankNames += bank.Bankname + ",";
            }
            
            return bankNames.TrimEnd(',');
        }

    }
}
