using System;

namespace MagicalNumbers
{
    public class Startup
    {
        public static void Main()
        {
            var number = Console.ReadLine();

            var firstDigit = int.Parse(number[0].ToString());
            var secondDigit = int.Parse(number[1].ToString());
            var thirdDigit = int.Parse(number[2].ToString());

            double result = 0;

            if (secondDigit % 2 == 0)
            {
                result += (firstDigit + secondDigit) * thirdDigit;
            }
            else
            {
                result += (double)(firstDigit * secondDigit) / thirdDigit;
            }

            Console.WriteLine("{0:F2}", result);
        }
    }
}
