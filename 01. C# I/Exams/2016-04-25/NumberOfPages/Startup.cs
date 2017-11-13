using System;

namespace NumberOfPages
{
    public class Startup
    {
        private const int DigitsCountOfOneDigitNumbers = 9;
        private const int DigitsCountOfTwoDigitNumbers = 90;
        private const int DigitsCountOfThreeDigitNumbers = 900;
        private const int DigitsCountOfFourDigitNumbers = 9000;
        private const int DigitsCountOfFiveDigitNumbers = 90000;

        private static int GetPagesCount(int D)
        {
            if (D < 10)
            {
                return DigitsCountOfOneDigitNumbers;
            }
            else if (D < 100)
            {
                D -= DigitsCountOfOneDigitNumbers;

                return DigitsCountOfOneDigitNumbers + (D / 2);
            }
            else if (D < 1000)
            {
                D -= DigitsCountOfOneDigitNumbers;
                D -= DigitsCountOfTwoDigitNumbers * 2;

                return DigitsCountOfOneDigitNumbers + DigitsCountOfTwoDigitNumbers + (D / 3);
            }
            else if(D < 10000)
            {
                D -= DigitsCountOfOneDigitNumbers;
                D -= DigitsCountOfTwoDigitNumbers * 2;
                D -= DigitsCountOfThreeDigitNumbers * 3;

                return DigitsCountOfOneDigitNumbers + DigitsCountOfTwoDigitNumbers + DigitsCountOfThreeDigitNumbers + 
                    (D / 4);
            }
            else if (D < 100000)
            {
                D -= DigitsCountOfOneDigitNumbers;
                D -= DigitsCountOfTwoDigitNumbers * 2;
                D -= DigitsCountOfThreeDigitNumbers * 3;
                D -= DigitsCountOfFourDigitNumbers * 4;

                return DigitsCountOfOneDigitNumbers + DigitsCountOfTwoDigitNumbers + DigitsCountOfThreeDigitNumbers +
                    DigitsCountOfFourDigitNumbers + (D / 5);
            }

            D -= DigitsCountOfOneDigitNumbers;
            D -= DigitsCountOfTwoDigitNumbers * 2;
            D -= DigitsCountOfThreeDigitNumbers * 3;
            D -= DigitsCountOfFourDigitNumbers * 4;
            D -= DigitsCountOfFiveDigitNumbers * 5;

            return DigitsCountOfOneDigitNumbers + DigitsCountOfTwoDigitNumbers + DigitsCountOfThreeDigitNumbers +
                    DigitsCountOfFourDigitNumbers + DigitsCountOfFiveDigitNumbers + (D / 6);
        }

        public static void Main()
        {
            var D = int.Parse(Console.ReadLine());
            var numberOfPages = GetPagesCount(D);

            Console.WriteLine(numberOfPages);
        }
    }
}
