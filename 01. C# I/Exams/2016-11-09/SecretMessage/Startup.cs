using System;
using System.Text;

namespace SecretMessage
{
    public class Startup
    {
        public static void Main()
        {
            var sb = new StringBuilder();
            var numberOfLines = 1;

            while (true)
            {
                var str = Console.ReadLine();

                if (str == "end")
                {
                    Console.WriteLine(sb.ToString());
                    break;
                }

                var start = int.Parse(str);
                var end = int.Parse(Console.ReadLine());
                var line = Console.ReadLine();

                if (start < 0)
                {
                    start = line.Length + start;
                }

                if (end < 0)
                {
                    end = line.Length + end;
                }

                if (numberOfLines % 2 == 0)
                {
                    while (start <= end)
                    {
                        sb.Append(line[start]);
                        start += 4;
                    }
                }
                else
                {
                    while (start <= end)
                    {
                        sb.Append(line[start]);
                        start += 3;
                    }
                }

                numberOfLines++;
            }
        }
    }
}
