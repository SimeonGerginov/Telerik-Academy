using System;
using System.Collections.Generic;

namespace Batman
{
    public class Startup
    {
        public static void Main()
        {
            var dictionary = new Dictionary<int, int>
            {
                { 5, 1}, { 7, 2 }, { 9, 3 }, { 11, 4 }, { 13, 5 }, { 15, 6 }, { 17, 7 },
                { 19, 8 }, { 21, 9 }, { 23, 10 }, { 25, 11 }, { 27, 12 }, { 29, 13 },
                { 31, 14 }, { 33, 15 }, { 35, 16 }, { 37, 17 }, { 39, 18 }, { 41, 19 },
                { 43, 20 }, { 45, 21 }, { 47, 22 }, { 49, 23 }, { 51, 24 }
            };

            var S = int.Parse(Console.ReadLine());
            var C = Console.ReadLine()[0];

            var emptySpaces = 0;
            var symbolsCount = S;

            // for the wings of the bat logo
            for (int i = 0; i < dictionary[S]; i++)
            {
                string partOfWings = new string(C, symbolsCount);
                string emptyPartOfWings = new string(' ', symbolsCount);
                string emptySpacesPart = new string(' ', emptySpaces);

                Console.Write(emptySpacesPart + partOfWings + emptyPartOfWings + emptySpacesPart + partOfWings);
                Console.WriteLine();

                symbolsCount--;
                emptySpaces++;
            }

            // for the head of the bat logo
            string emptySpacesPartOfHead = new string(' ', dictionary[S]);
            var headHelper = 3;
            string partOfHead = new string(C, dictionary[S] + headHelper);

            Console.Write(emptySpacesPartOfHead + partOfHead + emptySpacesPartOfHead + C + ' ' + C + emptySpacesPartOfHead + partOfHead);
            Console.WriteLine();

            // for the body of the bat logo
            string emptySpacesPartOfBody = new string(' ', dictionary[S] + 1);
            string partOfBody = new string(C, (S * 2) + 1);

            for (int i = 0; i < S / 3; i++)
            {
                Console.Write(emptySpacesPartOfBody + partOfBody);
                Console.WriteLine();
            }

            var countOfSymbolsInLowerBody = S - 2;
            string emptyPartOfLowerBody = new string(' ', S + 1);
            var emptySpacesInLowerPart = 0;

            // for the lower part of bat logo 
            for (int i = 0; i < dictionary[S]; i++)
            {
                string symbolsInLowerBody = new string(C, countOfSymbolsInLowerBody);
                string emptySpacesPartInLowerBody = new string(' ', emptySpacesInLowerPart);

                Console.Write(emptyPartOfLowerBody + emptySpacesPartInLowerBody + symbolsInLowerBody + emptyPartOfLowerBody);
                Console.WriteLine();

                countOfSymbolsInLowerBody -= 2;
                emptySpacesInLowerPart++;
            }

            // final part of the bat logo
            string emptySpacesInFinalPart = new string(' ', S + 1 + emptySpacesInLowerPart);

            Console.Write(emptySpacesInFinalPart + C);
            Console.WriteLine();
        }
    }
}
