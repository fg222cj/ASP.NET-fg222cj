using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KassaKvitto.Model
{
    public class Receipt
    {
        private double _subtotal;   // Innehåller den av användaren angivna summan. Måste vara större än 0.

        public double DiscountRate  // Returnerar rabattsatsen i "procent".
        {
            get
            {
                if (Subtotal < 500)
                {
                    return 0;
                }
                else if (Subtotal < 1000)
                {
                    return 0.05;
                }
                else if (Subtotal < 5000)
                {
                    return 0.1;
                }
                else
                {
                    return 0.15;
                }
            }
        }

        public double MoneyOff  // Returnerar den avdragna rabatten.
        {
            get
            {
                return Subtotal * DiscountRate;
            }
        }

        public double Subtotal  // Se _subtotal.
        {
            get
            {
                return _subtotal;
            }

            private set
            {
                if (value > 0)
                {
                    _subtotal = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public double Total // Returnerar slutsumman efter avdragen rabatt.
        {
            get
            {
                return Subtotal - MoneyOff;
            }
        }

        public Receipt(double subtotal) // Konstruktor.
        {
            Subtotal = subtotal;
        }
    }
}