using System;

namespace Feathers
{
    public class Startup
    {
        private const long magicNumberForMultiply = 123123123123;
        private const int magicNumberForDivide = 317;

        public static void Main()
        {
            var B = int.Parse(Console.ReadLine());
            var F = int.Parse(Console.ReadLine());

            double result = (double)F / (double)B;

            if (B % 2 == 0)
            {
                result *= (double)magicNumberForMultiply;
            }
            else
            {
                result /= (double)magicNumberForDivide;
            }

            Console.WriteLine("{0:F4}", result);
        }
    }
}
