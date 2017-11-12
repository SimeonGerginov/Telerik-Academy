using System;

namespace Busses
{
    public class Startup
    {
        public static void Main()
        {
            var C = int.Parse(Console.ReadLine());
            var firstSpeed = int.Parse(Console.ReadLine());
            var numberOfGroups = 1;

            for (int i = 1; i < C; i++)
            {
                var secondSpeed = int.Parse(Console.ReadLine());

                if (firstSpeed == secondSpeed)
                {
                    numberOfGroups++;
                    firstSpeed = secondSpeed;
                }

                if (firstSpeed > secondSpeed)
                {
                    numberOfGroups++;
                    firstSpeed = secondSpeed;
                }
            }

            Console.WriteLine(numberOfGroups);
        }
    }
}
