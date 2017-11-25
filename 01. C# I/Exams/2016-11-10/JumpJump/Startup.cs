using System;

namespace JumpJump
{
    public class Startup
    {
        public static void Main()
        {
            var instructions = Console.ReadLine();
            var position = 0;

            while (true)
            {
                if (position < 0 || position >= instructions.Length)
                {
                    Console.WriteLine("Fell off the dancefloor at {0}!", position);
                    break;
                }

                if (Char.IsDigit(instructions[position]))
                {
                    var digit = int.Parse(instructions[position].ToString());

                    if (digit == 0)
                    {
                        Console.WriteLine("Too drunk to go on after {0}!", position);
                        break;
                    }

                    if (digit % 2 == 0)
                    {
                        position += digit;
                    }
                    else // digit % 2 != 0
                    {
                        position -= digit;
                    }
                }
                else if (instructions[position] == '^')
                {
                    Console.WriteLine("Jump, Jump, DJ Tomekk kommt at {0}!", position);
                    break;
                }
            }
        }
    }
}
