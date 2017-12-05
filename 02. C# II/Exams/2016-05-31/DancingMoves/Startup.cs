using System;
using System.Linq;

namespace DancingMoves
{
    public class Startup
    {
        public static void Main()
        {
            var dancingMachine = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            double result = 0;
            var position = 0;
            var countOfRounds = 0;

            while (true)
            {
                var instructions = Console.ReadLine().Split(' ');

                if (instructions[0] == "stop")
                {
                    break;
                }

                var times = int.Parse(instructions[0]);
                var direction = instructions[1];
                var step = int.Parse(instructions[2]);

                var i = 0;

                while (i < times)
                {
                    if (direction == "right")
                    {
                        if (position + step >= dancingMachine.Length)
                        {
                            position += step;
                            while (position >= dancingMachine.Length)
                            {
                                position = position - dancingMachine.Length;
                            }
                            result += dancingMachine[position];
                        }
                        else
                        {
                            result += dancingMachine[position + step];
                            position = position + step;
                        }

                        i++;
                    }

                    if (direction == "left")
                    {
                        if (position - step < 0)
                        {
                            position -= step;
                            while (position < 0)
                            {
                                position = dancingMachine.Length + position;
                            }
                            result += dancingMachine[position];
                        }
                        else
                        {
                            result += dancingMachine[position - step];
                            position = position - step;
                        }

                        i++;
                    }
                }

                i = 0;
                countOfRounds++;
            }

            var averageResult = result / countOfRounds;

            Console.WriteLine("{0:F1}", averageResult);
        }
    }
}
