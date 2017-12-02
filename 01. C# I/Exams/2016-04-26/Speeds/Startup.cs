using System;

namespace Speeds
{
    public class Startup
    {
        public static void Main()
        {
            var numberOfCars = int.Parse(Console.ReadLine());
            var firstSpeed = int.Parse(Console.ReadLine());

            var groupCount = 1;
            var maxGroupCount = 0;
            var theFirstSpeed = firstSpeed;

            var currentSumOfSpeeds = firstSpeed;
            var maxSumOfSpeeds = 0;

            for (int i = 1; i < numberOfCars; i++)
            {
                var secondSpeed = int.Parse(Console.ReadLine());

                if (secondSpeed < firstSpeed)
                {
                    groupCount = 1;
                    currentSumOfSpeeds = secondSpeed;
                    firstSpeed = secondSpeed;
                }
                else if (secondSpeed == firstSpeed)
                {
                    groupCount = 1;
                    currentSumOfSpeeds = firstSpeed;
                    firstSpeed = secondSpeed;
                }
                else // firstSpeed < secondSpeed
                {
                    groupCount++;
                    currentSumOfSpeeds += secondSpeed;
                }

                if (groupCount > maxGroupCount)
                {
                    maxGroupCount = groupCount;
                    maxSumOfSpeeds = currentSumOfSpeeds;
                }

                if (groupCount == maxGroupCount && currentSumOfSpeeds > maxSumOfSpeeds)
                {
                    maxSumOfSpeeds = currentSumOfSpeeds;
                }
            }

            if (maxGroupCount == 1)
            {
                maxSumOfSpeeds = theFirstSpeed;
            }

            Console.WriteLine(maxSumOfSpeeds);
        }
    }
}
