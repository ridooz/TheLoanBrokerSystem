using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheLoanBroker
{
    public partial class CustomerLoanRequest : System.Web.UI.Page
    {
     LoanBrokerService.LoanBrokerSoapClient loanBroker = new LoanBrokerService.LoanBrokerSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLoanRequest_Click(object sender, EventArgs e)
        {
            string ssn = TextBoxSSN.Text;
            double amount = Convert.ToDouble(TextBoxAmount.Text);
            int duration = Convert.ToInt32(TextBoxDuration.Text);

            loanBroker.LoanQuoteRequest(ssn, amount, duration);

        }

    }
}