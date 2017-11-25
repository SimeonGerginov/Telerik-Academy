using System;

namespace MixingNumbers
{
    public class Startup
    {
        public static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            var firstNumberAsString = Console.ReadLine();

            var arrayIndexCounter = 0;

            var mixedNumbersArray = new int[N - 1];
            var substractedNumbersArray = new int[N - 1];

            for (int i = 1; i < N; i++)
            {
                var secondNumberAsString = Console.ReadLine();

                var secondDigitOfFirstNumber = int.Parse(firstNumberAsString[1].ToString());
                var firstDigitOfSecondNumber = int.Parse(secondNumberAsString[0].ToString());

                var resultOfDigits = secondDigitOfFirstNumber * firstDigitOfSecondNumber;

                mixedNumbersArray[arrayIndexCounter] = resultOfDigits;

                var firstNumber = int.Parse(firstNumberAsString);
                var secondNumber = int.Parse(secondNumberAsString);

                var resultOfSubstract = Math.Abs(firstNumber - secondNumber);

                substractedNumbersArray[arrayIndexCounter] = resultOfSubstract;

                arrayIndexCounter++;
                firstNumberAsString = secondNumberAsString;
            }

            Console.WriteLine(string.Join(" ", mixedNumbersArray));
            Console.WriteLine(string.Join(" ", substractedNumbersArray));
        }
    }
}
