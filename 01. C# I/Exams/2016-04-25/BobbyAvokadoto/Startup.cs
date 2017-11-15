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

        private static bool IsOverlaping(uint head, uint comb)
        {
            bool isOverlaping = false;
            uint hc = head ^ comb;

            for (int i = 0; i < 32; i++)
            {
                if (GetBitValue(head, i) == 1 && GetBitValue(hc, i) == 0)
                {
                    isOverlaping = true;
                }
            }

            return isOverlaping;
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
            var head = uint.Parse(Console.ReadLine());
            var C = uint.Parse(Console.ReadLine());

            uint bestComb = uint.MinValue;
            var maxTeeths = 0;

            for (int i = 0; i < C; i++)
            {
                var currentComb = uint.Parse(Console.ReadLine());

                if (IsOverlaping(head, currentComb))
                {
                    continue;
                }

                var teeths = GetCountOfOneBits(currentComb);

                if (teeths > maxTeeths)
                {
                    maxTeeths = teeths;
                    bestComb = currentComb;
                }
            }

            Console.WriteLine(bestComb);
        }
    }
}
