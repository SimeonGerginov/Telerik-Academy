using System;

namespace BobbyAvokadoto
{
    public class Startup
    {
        private static uint GetBitValue(uint comb, int position)
        {
            var mask = (uint)1 << position;
            var maskedComb = comb & mask;

            return maskedComb >> position;
        }

        private static int GetMinLength(int firstLength, int secondLength)
        {
            if (firstLength < secondLength)
            {
                return firstLength;
            }

            return secondLength;
        }

        private static int GetCountOfOneBits(uint comb)
        {
            var counterOfOneBits = 0;

            for (int k = 0; k < 32; k++)
            {
                var bitOfComb = GetBitValue(comb, k);

                if (bitOfComb == 1)
                {
                    counterOfOneBits++;
                }
            }

            return counterOfOneBits;
        }

        public static void Main()
        {
            var N = uint.Parse(Console.ReadLine());
            var C = uint.Parse(Console.ReadLine());

            var lengthOfNInBits = Convert.ToString(N, 2).Length;
            uint bestComb = uint.MinValue;
            var countOfOneBitsInComb = int.MinValue;

            for (int i = 0; i < C; i++)
            {
                var currentComb = uint.Parse(Console.ReadLine());
                var lengthOfCombInBits = Convert.ToString(currentComb, 2).Length;

                var minLengthOfBits = GetMinLength(lengthOfNInBits, lengthOfCombInBits);
                var counterForCurrentComb = 0;

                for (int k = 0; k < minLengthOfBits; k++)
                {
                    var bitOfN = GetBitValue(N, k);
                    var bitOfComb = GetBitValue(currentComb, k);

                    if (bitOfN == bitOfComb)
                    {
                        break;
                    }

                    counterForCurrentComb++;
                }

                if (counterForCurrentComb == minLengthOfBits)
                {
                    var currentCountOfOneBitsInComb = GetCountOfOneBits(currentComb);

                    if (countOfOneBitsInComb < currentCountOfOneBitsInComb)
                    {
                        countOfOneBitsInComb = currentCountOfOneBitsInComb;
                        bestComb = currentComb;
                    }
                }
            }

            Console.WriteLine(bestComb);
        }
    }
}
