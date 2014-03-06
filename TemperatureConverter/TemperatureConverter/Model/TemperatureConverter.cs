using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TemperatureConverter.Model
{
    public static class TemperatureConverter
    {
        public static int CelsiusToFahrenheit(int degreesC)
        {
            return (int)(degreesC * 1.8 + 32);      // Returnerar temperaturen konverterad från Celsius till Fahrenheit.
        }

        public static int FahrenheitToCelsius(int degreesF)
        {
            return (int)((degreesF - 32) * 5 / 9);  // Returnerar temperaturen konverterad från Fahrenheit till Celsius.
        }
    }
}