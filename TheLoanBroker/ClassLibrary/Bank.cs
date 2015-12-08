using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheLoanBroker
{
    public class Bank
    {

        private string bankname;
        private string exchange;
        private string translatorType;

        public Bank(string bankname, string exchange, string translatorType)
        {
            this.bankname = bankname;
            this.exchange = exchange;
            this.translatorType = translatorType;
        }

        public Bank(string bankname, string exchange)
        {
            this.bankname = bankname;
            this.exchange = exchange;
        }

        public Bank()
        {

        }

        public string TranslatorType
        {
            get { return translatorType; }
            set { translatorType = value; }
        }

        public string Bankname
        {
            get { return bankname; }
            set { bankname = value; }
        }

        public string Exchange
        {
            get { return exchange; }
            set { exchange = value; }
        }

    }
}