using System;

namespace NumberOfDigits
{
    public class Startup
    {
        private static int GetDigitsCount(int N)
        {
            if (N < 10)
            {
                return 1;
            }
            else if (N < 100)
            {
                return 2;
            }
            else if (N < 1000)
            {
                return 3;
            }
            else if (N < 10000)
            {
                return 4;
            }
            else if (N < 100000)
            {
                return 5;
            }

            return 6;
        }

        public static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            var numberOfDigits = 0;

            while (true)
            {
                if (N <= 0)
                {
                    break;
                }

                numberOfDigits += GetDigitsCount(N);

                N--;
            }

            Console.WriteLine(numberOfDigits);
        }
    }
}
