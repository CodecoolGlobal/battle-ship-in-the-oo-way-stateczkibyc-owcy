using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki
{
    static class OceanDisplayer
    {

        public static void PrintOceanForPlay(Square[,] ocean)
        {
            var rows = ocean.GetLength(0);
            var cols = ocean.GetLength(1);

            char[] alphabet = InitAlphabet(rows);
            PrintHeaders(cols);
            PrintGameRowsForPlay(ocean, rows, cols, alphabet);
            Console.WriteLine();
        }

        public static void PrintOceanForCurrentPlayer(Square[,] ocean)
        {
            var rows = ocean.GetLength(0);
            var cols = ocean.GetLength(1);

            char[] alphabet = InitAlphabet(rows);
            PrintHeaders(cols);
            PrintGameRowsForCurrentPlayer(ocean, rows, cols, alphabet);
            Console.WriteLine();
        }

        private static void PrintGameRowsForPlay(Square[,] ocean, int rows, int cols, char[] alphabet)
        {
            for (int i = 0; i < rows; i++)
            {
                Console.Write("\n" + alphabet[i] + " | ");
                for (int j = 0; j < cols; j++)
                {
                    var currentSquare = ocean[i, j];
                    Console.Write(currentSquare.Status.ToSymbolForOpponent());
                }
            }
        }

        private static void PrintGameRowsForCurrentPlayer(Square[,] ocean, int rows, int cols, char[] alphabet)
        {
            for (int i = 0; i < rows; i++)
            {
                Console.Write("\n" + alphabet[i] + " | ");
                for (int j = 0; j < cols; j++)
                {
                    var currentSquare = ocean[i, j];
                    Console.Write(currentSquare.Status.ToSymbolForCurrentPlayer());
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

        public static char[] InitAlphabet(int rows)
        {
            var alphabet = new char[rows];

            for (var i = 0; i < alphabet.Length; i++)
            {
                alphabet[i] = (char)(65 + i); // cast number to ASCII
            }

            return alphabet;
        }
    }
}
