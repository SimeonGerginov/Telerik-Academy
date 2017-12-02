using System;

namespace SumOfOddDivisors
{
    public class Startup
    {
        private static int SumOfAllOddDivisors(int number)
        {
            var sum = 0;

            for (int i = 1; i <= number; i++)
            {
                if ((number % i == 0) && (i % 2 != 0))
                {
                    sum += i;
                }
            }

            return sum;
        }

        public static void Main()
        {
            var A = int.Parse(Console.ReadLine());
            var B = int.Parse(Console.ReadLine());

            var sum = 0;

            for (int i = A; i <= B; i++)
            {
                var sumOfDivisors = SumOfAllOddDivisors(i);
                sum += sumOfDivisors;
            }

            Console.WriteLine(sum);
        }
    }
}
