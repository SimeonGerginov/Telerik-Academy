using System;
using System.Collections.Generic;

namespace MalkoKote
{
    public class Startup
    {
        public static void Main()
        {
            var dictionary = new Dictionary<int, int>
            {
                { 10, 3}, { 12, 3 }, { 14, 4 }, { 16, 4 }, { 18, 5 }, { 20, 5 }, { 22, 6 },
                { 24, 6 }, { 26, 7 }, { 28, 7 }, { 30, 8 }, { 32, 8 }, { 34, 9 },
                { 36, 9 }, { 38, 10 }, { 40, 10 }, { 42, 11 }, { 44, 11 }, { 46, 12 },
                { 48, 12 }, { 50, 13 }, { 52, 13 }, { 54, 14 }, { 56, 14 }, { 58, 15 },
                { 60, 15 }, { 62, 16 }, { 64, 16 }, { 66, 17 }, { 68, 17 }, { 70, 18 },
                { 72, 18 }, { 74, 19 }, { 76, 19 }, { 78, 20 }, { 80, 20 }, { 82, 21 },
                { 84, 21 }, { 86, 22}
            };

            var sizeOfCat = int.Parse(Console.ReadLine());
            var characterToPrint = Console.ReadLine()[0];

            // head of cat
            var emptySpaces = new string(' ', dictionary[sizeOfCat] - 2);
            Console.WriteLine(emptySpaces + characterToPrint + emptySpaces + characterToPrint);

            var headString = new string(characterToPrint, dictionary[sizeOfCat]);

            for (int i = 0; i < dictionary[sizeOfCat] - 2; i++)
            {
                Console.WriteLine(emptySpaces + headString);
            }

            var lowerPartOfHeadString = new string(characterToPrint, dictionary[sizeOfCat] - 2);

            for (int i = 0; i < dictionary[sizeOfCat] - 2; i++)
            {
                Console.WriteLine(emptySpaces + " " + lowerPartOfHeadString);
            }

            for (int i = 0; i < dictionary[sizeOfCat] - 2; i++)
            {
                Console.WriteLine(emptySpaces + headString);
            }

            // upper body part
            var emptySpacesInUpperBodyString = new string(' ', 3);
            var characterToPrintInUpperBody = new string(characterToPrint, dictionary[sizeOfCat] - 1);
            Console.WriteLine(emptySpaces + headString + emptySpacesInUpperBodyString + 
                characterToPrintInUpperBody);

            // body
            var bodyString = new string(characterToPrint, dictionary[sizeOfCat] + 2);
            for (int i = 0; i < dictionary[sizeOfCat]; i++)
            {
                Console.WriteLine(bodyString + "  " + characterToPrint);
            }

            // lower body part
            Console.WriteLine(bodyString + " " + characterToPrint + characterToPrint);

            // lowest part of cat
            var lowestPartString = new string(characterToPrint, dictionary[sizeOfCat] + 3);
            Console.WriteLine(" " + lowestPartString);
        }
    }
}
