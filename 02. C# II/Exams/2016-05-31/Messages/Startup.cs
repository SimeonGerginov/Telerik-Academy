using System;
using System.Numerics;

namespace Messages
{
    public class Startup
    {
        private static BigInteger ConvertToDecimalValue(string number)
        {
            var replacedNumber = number
                .Replace("cad", "0")
                .Replace("xoz", "1")
                .Replace("nop", "2")
                .Replace("cyk", "3")
                .Replace("min", "4")
                .Replace("mar", "5")
                .Replace("kon", "6")
                .Replace("iva", "7")
                .Replace("ogi", "8")
                .Replace("yan", "9");

            return BigInteger.Parse(replacedNumber);
        }

        private static string ConvertToNumeralSystem(string number)
        {
            var numberInNumeralSystem = number
                .Replace("0", "cad")
                .Replace("1", "xoz")
                .Replace("2", "nop")
                .Replace("3", "cyk")
                .Replace("4", "min")
                .Replace("5", "mar")
                .Replace("6", "kon")
                .Replace("7", "iva")
                .Replace("8", "ogi")
                .Replace("9", "yan");

            return numberInNumeralSystem;
        }

        private static BigInteger PerformOperation(BigInteger firstNumber, BigInteger secondNumber, string operation)
        {
            if (operation == "+")
            {
                return firstNumber + secondNumber;
            }
            else // operation == "-"
            {
                return firstNumber - secondNumber;
            }
        }

        public static void Main()
        {
            var firstNumberAsString = Console.ReadLine();
            var operation = Console.ReadLine();
            var secondNumberAsString = Console.ReadLine();

            var firstNumber = ConvertToDecimalValue(firstNumberAsString);
            var secondNumber = ConvertToDecimalValue(secondNumberAsString);

            var numberAfterOperation = PerformOperation(firstNumber, secondNumber, operation);
            var numberInNumeralSystem = ConvertToNumeralSystem(numberAfterOperation.ToString());

            Console.WriteLine(numberInNumeralSystem);
        }
    }
}
