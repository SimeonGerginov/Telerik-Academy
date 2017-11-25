using System;

namespace MythicalNumbers
{
    public class Startup
    {
        public static void Main()
        {
            var numberAsString = Console.ReadLine();

            var firstDigit = int.Parse(numberAsString[0].ToString());
            var secondDigit = int.Parse(numberAsString[1].ToString());
            var thirdDigit = int.Parse(numberAsString[2].ToString());

            double result = 0;

            if (thirdDigit == 0)
            {
                result = firstDigit * secondDigit;
            }
            else if (thirdDigit > 0 && thirdDigit <= 5)
            {
                result = firstDigit * secondDigit;
                result = result / thirdDigit;
            }
            else // thirdDigit > 5
            {
                var sum = firstDigit + secondDigit;
                result = sum * thirdDigit;
            }

            Console.WriteLine("{0:F2}", result);
        }
    }
}
