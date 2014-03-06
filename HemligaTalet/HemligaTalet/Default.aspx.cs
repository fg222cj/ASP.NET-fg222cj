using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HemligaTalet.Model;

namespace HemligaTalet
{
    public partial class Default : System.Web.UI.Page
    {
        private SecretNumber SecretNumber
        {
            get { return Session["secretNumber"] as SecretNumber; }
            set { Session["secretNumber"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Om ingen instans av affärslogiken finns så skapas den här.
            if (SecretNumber == null)
            {
                SecretNumber = new SecretNumber();
            }


            if (SecretNumber.Outcome == Outcome.Correct || SecretNumber.Outcome == Outcome.NoMoreGuesses)
            {
                TextBoxGuess.Enabled = false;
                ButtonNewGame.Visible = true;
            }
        }

        protected void ButtonSubmitGuess_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                SecretNumber.Outcome = SecretNumber.MakeGuess(int.Parse(TextBoxGuess.Text));

                switch (SecretNumber.Outcome)
                {
                    case Outcome.NoMoreGuesses:
                        LabelResult.Text = String.Format("Slut på gissningar, rätt svar var {0}.", SecretNumber.Number);
                        goto default;
                        /*
                         * Ja, goto är ett väldigt fult ord. Min motivering av användandet är som följer:
                         * Förutom meddelandet till användaren så ska samma saker ske om antalet gissningar är slut
                         * som om användaren har gissat rätt. C# tillåter bara fallthrough från ett case till ett
                         * annat om det tidigare caset är tomt. Det kan det inte vara i det här fallet och alternativet
                         * för att följa DRY hade varit att ersätta denna switch-sats med en serie if-satser eller att
                         * följa upp denna switch med en if. Jag anser att användandet av en goto-sats här är att föredra.
                         * Se: http://www.ecma-international.org/publications/files/ECMA-ST/Ecma-334.pdf  Kapitel 15.7.2
                         */
                    case Outcome.PreviousGuess:
                        LabelResult.Text = String.Format("Du har redan gissat på {0}!", TextBoxGuess.Text);
                        break;
                    case Outcome.High:
                        LabelResult.Text = String.Format("{0} är för högt.", TextBoxGuess.Text);
                        break;
                    case Outcome.Low:
                        LabelResult.Text = String.Format("{0} är för lågt.", TextBoxGuess.Text);
                        break;
                    case Outcome.Correct:
                        LabelResult.Text = String.Format("JA! {0} är rätt svar! Du klarade det på {1} försök! Bra jobbat!", TextBoxGuess.Text, SecretNumber.Count);
                        goto default; // Se ovan.
                    case Outcome.Indefinite:
                        break;
                    default:
                        TextBoxGuess.Enabled = false;
                        ButtonNewGame.Visible = true;
                        break;

                }
                LabelResult.Visible = true;

                LabelPreviousGuesses.Text = "";
                foreach(int guess in SecretNumber.PreviousGuesses)
                {
                    LabelPreviousGuesses.Text += String.Format("{0} ", guess);
                }
                
                LabelPreviousGuesses.Visible = true;

            }
        }
        
        protected void ButtonNewGame_Click(object sender, EventArgs e)
        {
            SecretNumber.Initialize();
            TextBoxGuess.Enabled = true;
            ButtonNewGame.Visible = false;
        }
        
    }
}