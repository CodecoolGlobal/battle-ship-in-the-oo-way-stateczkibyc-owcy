using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki
{
    static class OceanDisplayer
    {
        private static Dictionary<string, string> symbols = new Dictionary<string, string>
        {
            {"ship", "S" },
            {"shoot", "X" },
            {"empty", "O" }
        };

        public static void PrintOceanForPlay(Square[,] ocean)
        {
            var rows = ocean.GetLength(0);
            var cols = ocean.GetLength(1);

            char[] alphabet = InitAlphabet(rows);
            PrintHeaders(cols);
            PrintGameRowsForPlay(ocean, rows, cols, alphabet);
        }

        public static void PrintOceanForPlacementPhase(Square[,] ocean)
        {
            var rows = ocean.GetLength(0);
            var cols = ocean.GetLength(1);

            char[] alphabet = InitAlphabet(rows);
            PrintHeaders(cols);
            PrintGameRowsForPlacement(ocean, rows, cols, alphabet);
        }

        private static void PrintGameRowsForPlay(Square[,] ocean, int rows, int cols, char[] alphabet)
        {
            for (int i = 0; i < rows; i++)
            {
                Console.Write("\n" + alphabet[i] + " | ");
                for (int j = 0; j < cols; j++)
                {
                    var currentSquare = ocean[i, j];
                    if (currentSquare.IsHit)
                    {
                        Console.Write(symbols["shoot"] + " | ");
                    }
                    else
                    {
                        Console.Write(symbols["empty"] + " | ");
                    }
                }
            }
        }

        private static void PrintGameRowsForPlacement(Square[,] ocean, int rows, int cols, char[] alphabet)
        {
            for (int i = 0; i < rows; i++)
            {
                Console.Write("\n" + alphabet[i] + " | ");
                for (int j = 0; j < cols; j++)
                {
                    var currentSquare = ocean[i, j];
                    if (currentSquare.IsOccupied)
                    {
                        Console.Write(symbols["ship"] + " | ");
                    }
                    else
                    {
                        Console.Write(symbols["empty"] + " | ");
                    }
                }
            }
        }

        private static void PrintHeaders(int cols)
        {
            Console.Write("# | ");
            for (int counterRowsNumbers = 1; counterRowsNumbers <= cols; counterRowsNumbers++)
            {
                if (counterRowsNumbers < 9)
                {
                    Console.Write(counterRowsNumbers + " | ");
                }
                else
                {
                    Console.Write(counterRowsNumbers + " |");
                }
            }
        }

        private static char[] InitAlphabet(int rows)
        {
            var alphabet = new char[rows];

            for (var i = 0; i < alphabet.Length; i++)
            {
                alphabet[i] = (char)(65 + i);
            }

            return alphabet;
        }
    }
}
