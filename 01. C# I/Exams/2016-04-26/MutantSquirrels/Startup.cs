using System;

namespace MutantSquirrels
{
    public class Startup
    {
        private const double DivideValue = 7;
        private const double MultiplyValue = 376439;

        public static void Main()
        {
            var trees = double.Parse(Console.ReadLine());
            var branches = double.Parse(Console.ReadLine());
            var squirrels = double.Parse(Console.ReadLine());
            var averageNumberOfTails = double.Parse(Console.ReadLine());

            double result = 0;

            double product = trees * branches * squirrels * averageNumberOfTails;

            if (product % 2 != 0)
            {
                result = product / DivideValue;
            }
            else // product is an even number
            {
                result = product * MultiplyValue;
            }

            Console.WriteLine("{0:F3}", result);
        }
    }
}
