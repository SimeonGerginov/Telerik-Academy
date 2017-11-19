using System;
using System.Collections.Generic;

namespace Cards
{
    public class Startup
    {
        private static long GetBitValue(long hand, int position)
        {
            var mask = (long)1 << position;
            var maskedHand = hand & mask;

            return maskedHand >> position;
        }

        private static bool IsFullDeck(bool[] fullDeck)
        {
            for (int i = 0; i < 52; i++)
            {
                if (!fullDeck[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static List<string> GetCardsFoundEvenTimes(string[] allCards, int[] cards)
        {
            var cardsFoundEvenTimes = new List<string>(52);

            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] % 2 == 0)
                {
                    cardsFoundEvenTimes.Add(allCards[i]);
                }
            }

            return cardsFoundEvenTimes;
        }

        public static void Main()
        {
            var fullDeck = new bool[52];
            var cards = new int[52];

            var allCards = new string[]
            {
                "2c", "3c", "4c", "5c", "6c", "7c", "8c", "9c", "Tc", "Jc", "Qc", "Kc", "Ac",
                "2d", "3d", "4d", "5d", "6d", "7d", "8d", "9d", "Td", "Jd", "Qd", "Kd", "Ad",
                "2h", "3h", "4h", "5h", "6h", "7h", "8h", "9h", "Th", "Jh", "Qh", "Kh", "Ah",
                "2s", "3s", "4s", "5s", "6s", "7s", "8s", "9s", "Ts", "Js", "Qs", "Ks", "As"
            };

            var N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                var hand = long.Parse(Console.ReadLine());

                for (int k = 0; k < 52; k++)
                {
                    var bitOfHand = GetBitValue(hand, k);

                    if (bitOfHand == 1)
                    {
                        cards[k]++;
                        if (!fullDeck[k])
                        {
                            fullDeck[k] = true;
                        }
                    }
                }
            }

            var message = !IsFullDeck(fullDeck) ? "Wa wa!" : "Full deck";
            Console.WriteLine(message);

            var cardsFoundEvenTimes = GetCardsFoundEvenTimes(allCards, cards);
            Console.WriteLine(string.Join(" ", cardsFoundEvenTimes));
        }
    }
}
