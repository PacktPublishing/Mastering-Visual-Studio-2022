using System;

namespace MyFirstPackage.lib
{
    public static class TemperatureConverter
    {
        public static double ConvertCelsiusToFahrenheit(double celsius)
        {
            return celsius * 9 / 5 + 32;
        }

        public static double ConvertFahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
    }
}
