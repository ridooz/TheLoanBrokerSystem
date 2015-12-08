using ClassLibrary;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;

namespace ServiceLibrary
{
    /// <summary>
    /// Summary description for LoanBroker
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LoanBroker : System.Web.Services.WebService
    {
        private const string QUEUE_NAME = "loanQuoteRequest_Queue";

        [WebMethod]
        public void LoanQuoteRequest(string ssn, double amount, int duration)
        {
            Control control = new Control();
            string message = ssn + "#" + amount + "#" + duration;
            string println =  "SSN:" + ssn + " AMOUNT:" + amount + " DURATION:" + duration;
            control.sendMessage("loanQuoteRequest_exhange", message, println);
        }

    }
}