using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using TheLoanBroker;

namespace ServiceLibrary
{
    /// <summary>
    /// Summary description for RuleBase
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RuleBase : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Bank> GetBanks(int creditScore, double amount, int duration)
        {
            Bank bank1 = new Bank("SAXO Bank", "cphbusiness.bankXML", "XML");
            Bank bank2 = new Bank("Santader Bank", "cphbusiness.bankJSON", "JSON");
            Bank bank3 = new Bank("Nordea Bank", "Nordea_exchange", "MESSAGING");
            Bank bank4 = new Bank("DER", "DER_exchange", "WS");

            List<Bank> banks = new List<Bank>();

            if ((amount >= (double)200000) && (creditScore >= 650) && (duration <= 144))
            {
                banks.Add(bank1);
                banks.Add(bank2);
                banks.Add(bank3);
            }

            if ((amount >= (double)50000) && (amount <= (double)100000) && (creditScore >= 550) && (duration <= 60))
            {
                banks.Add(bank3);
                banks.Add(bank4);
            }

            if ((amount <= (double)20000) && (creditScore >= 500) && (duration <= 12))
            {
                banks.Add(bank4);
                banks.Add(bank1);

            }
            else
            {
                banks.Add(bank4);
                banks.Add(bank3);
                banks.Add(bank1);


            }

            return banks;
        }

    }
}
