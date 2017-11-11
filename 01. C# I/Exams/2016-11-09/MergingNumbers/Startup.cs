using System;

namespace MergingNumbers
{
    public class Startup
    {
        public static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            var mergedArray = new int[N - 1];
            var sumArray = new int[N - 1];

            var firstNumberAsString = Console.ReadLine();

            for (int i = 1; i < N; i++)
            {
                var secondNumberAsString = Console.ReadLine();

                var digitOfFirstNumber = firstNumberAsString[1];
                var digitOfSecondNumber = secondNumberAsString[0];
                var mergedNumberAsString = digitOfFirstNumber.ToString() + digitOfSecondNumber.ToString();

                var mergedNumber = int.Parse(mergedNumberAsString.ToString());
                mergedArray[i - 1] = mergedNumber;

                var sumNumber = int.Parse(firstNumberAsString.ToString()) +
                    int.Parse(secondNumberAsString.ToString());
                sumArray[i - 1] = sumNumber;
                
                firstNumberAsString = secondNumberAsString;
            }

            Console.WriteLine(string.Join(" ", mergedArray));
            Console.WriteLine(string.Join(" ", sumArray));
        }
    }
}
