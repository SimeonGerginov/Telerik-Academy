using System;

namespace SnackyTheSnake
{
    public class Startup
    {
        private static int ChangeRowInDen(string direction)
        {
            if (direction == "d")
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        private static int ChangeColInDen(string direction)
        {
            if (direction == "r")
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public static void Main()
        {
            var rowsAndColsString = Console.ReadLine().Split('x');

            var rows = int.Parse(rowsAndColsString[0]);
            var cols = int.Parse(rowsAndColsString[1]);

            int startRow = 0;
            int startCol = 0;
            var lengthOfSnake = 3;

            var den = new char[rows, cols];

            for (int i = 0; i < den.GetLength(0); i++)
            {
                var currentRow = Console.ReadLine();
                for (int j = 0; j < den.GetLength(1); j++)
                {
                    if (i == 0 && currentRow[j] == 's')
                    {
                        startCol = j;
                    }

                    den[i, j] = currentRow[j];
                }
            }

            var directions = Console.ReadLine().Split(',');
            var movesMade = 0;

            var currentRowInDen = startRow;
            var currentColInDen = startCol;

            foreach (var direction in directions)
            {
                // check for length of snake
                if (lengthOfSnake <= 0)
                {
                    Console.WriteLine("Snacky will starve at [{0},{1}]", currentRowInDen, currentColInDen);
                    return;
                }

                // change current row or col
                if (direction == "d" || direction == "u")
                {
                    currentRowInDen += ChangeRowInDen(direction);
                }
                else
                {
                    currentColInDen += ChangeColInDen(direction);
                }

                // check if lost in den
                if (currentRowInDen >= rows)
                {
                    Console.WriteLine("Snacky will be lost into the depths with length {0}", lengthOfSnake);
                    return;
                }

                // check if col goes outside of the den
                if (currentColInDen < 0)
                {
                    currentColInDen = cols - 1;
                }

                if (currentColInDen > cols - 1)
                {
                    currentColInDen = 0;
                }

                // check if cell in den contains food or trap
                if (den[currentRowInDen, currentColInDen] == '*')
                {
                    lengthOfSnake++;
                    den[currentRowInDen, currentColInDen] = ' ';
                }
                else if (den[currentRowInDen, currentColInDen] == '#')
                {
                    Console.WriteLine("Snacky will hit a rock at [{0},{1}]", currentRowInDen, currentColInDen);
                    return;
                }

                // check if moves count is equal to five
                movesMade++;
                if (movesMade == 5)
                {
                    movesMade = 0;
                    lengthOfSnake--;
                }

                // check if current row and col are equal to start row and col
                if (currentRowInDen == startRow && currentColInDen == startCol)
                {
                    Console.WriteLine("Snacky will get out with length {0}", lengthOfSnake);
                    return;
                }
            }

            // the snake is stuck in the den
            Console.WriteLine("Snacky will be stuck in the den at [{0},{1}]", currentRowInDen, currentColInDen);
        }
    }
}
