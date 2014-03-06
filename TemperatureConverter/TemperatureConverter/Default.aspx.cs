using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TemperatureConverter.Model;

namespace TemperatureConverter
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                int tempStart = int.Parse(TextBoxStart.Text);       // Starttemperatur
                int tempFinal = int.Parse(TextBoxFinal.Text);       // Sluttemperatur
                int tempInterval = int.Parse(TextBoxInterval.Text); // intervallet med vilket temperaturen kommer öka tills den når sluttemperaturen.


                // Kollar vilken radioknapp som bockats i, sätter rätt headers på tabellen.
                if (RadioButton2.Checked)
                {
                    TableHeaderLeft.Text = "&deg;F";
                    TableHeaderRight.Text = "&deg;C";
                }

                // Börjar på starttemperaturen. För varje iteration ökar denna med intervallet tills den når sluttemperaturen.
                for (int temp = tempStart; temp <= tempFinal; temp += tempInterval)
                {
                    TableRow row = new TableRow();  // Ny rad
                    Table1.Rows.Add(row);       // Raden läggs till på tabellen.

                    TableCell[] cells = { new TableCell(), new TableCell() }; // Array om två dataceller (td)
                    row.Cells.AddRange(cells);  // Cellerna läggs till på raden.

                    cells[0].Text = temp.ToString();    // Aktuell temperatur läggs in i den första cellen.

                    // Beroende på vilken konvertering som har valts så läggs antingen Celsius eller Fahrenheit in i den andra cellen.
                    if(RadioButton1.Checked)
                    {
                        cells[1].Text = Model.TemperatureConverter.CelsiusToFahrenheit(temp).ToString();
                    }
                    else
                    {
                        cells[1].Text = Model.TemperatureConverter.FahrenheitToCelsius(temp).ToString();
                    }
                }

                Table1.Visible = true;  // Tabellen görs synlig.
            }
        }

        // CustomValidator för att se till att någon av radioknapparna är ifylld.
        // Källa: http://forums.asp.net/t/1199803.aspx?how+to+validate+a+group+of+radio+buttons+
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = RadioButton1.Checked || RadioButton2.Checked;
        }
    }
}