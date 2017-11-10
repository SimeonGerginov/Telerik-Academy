using System;

namespace GoingToParty
{
    public class Startup
    {
        public static void Main()
        {
            var directions = Console.ReadLine();
            var index = 0;
            var position = 0;

            while (true)
            {
                var symbol = directions[index];

                if (symbol == '^')
                {
                    Console.WriteLine("Djor and Djano are at the party at {0}!", index);
                    break;
                }

                if (Char.IsLower(symbol))
                {
                    position = symbol - 'a' + 1;
                    index += position;

                    if (index >= directions.Length)
                    {
                        Console.WriteLine("Djor and Djano are lost at {0}!", index);
                        break;
                    }
                }

                if(Char.IsUpper(symbol))
                {
                    position = symbol - 'A' + 1;
                    index -= position;

                    if (index < 0)
                    {
                        Console.WriteLine("Djor and Djano are lost at {0}!", index);
                        break;
                    }
                }
            }
        }
    }
}
