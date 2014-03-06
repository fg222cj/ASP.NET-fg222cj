using KassaKvitto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KassaKvitto
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var receipt = new Receipt(double.Parse(TextBoxTotal.Text));

                Subtotal.Text = String.Format(Subtotal.Text, receipt.Subtotal);
                DiscountRate.Text = String.Format(DiscountRate.Text, receipt.DiscountRate);
                MoneyOff.Text = String.Format(MoneyOff.Text, receipt.MoneyOff);
                Total.Text = String.Format(Total.Text, receipt.Total);

                PlaceHolderReceipt.Visible = true;
            }
        }
    }
}