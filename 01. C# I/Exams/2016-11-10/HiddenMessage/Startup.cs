using System;
using System.Text;

namespace HiddenMessage
{
    public class Startup
    {
        private static bool CheckIfFirstLineIsEnd(string line)
        {
            if (line == "end")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Main()
        {
            var sb = new StringBuilder();
            var startIndex = 0;
            var indexOfSymbolToDecode = 0;

            while (true)
            {
                var firstLine = Console.ReadLine();
                var isEndLine = CheckIfFirstLineIsEnd(firstLine);

                if (isEndLine)
                {
                    Console.WriteLine(sb.ToString());
                    break;
                }
                else
                {
                    indexOfSymbolToDecode = int.Parse(firstLine);
                }


                var numberOfSymbolsToDecode = int.Parse(Console.ReadLine());
                var textLine = Console.ReadLine();
                

                if (indexOfSymbolToDecode < 0)
                {
                    indexOfSymbolToDecode = textLine.Length + indexOfSymbolToDecode;
                }

                if (indexOfSymbolToDecode >= textLine.Length)
                {
                    continue;
                }

                startIndex = indexOfSymbolToDecode;
                sb.Append(textLine[startIndex]);

                while (true)
                {
                    if (startIndex + numberOfSymbolsToDecode >= textLine.Length || 
                        startIndex + numberOfSymbolsToDecode < 0)
                    {
                        break;
                    }

                    startIndex += numberOfSymbolsToDecode;
                    sb.Append(textLine[startIndex]);
                }
            }
        }
    }
}
