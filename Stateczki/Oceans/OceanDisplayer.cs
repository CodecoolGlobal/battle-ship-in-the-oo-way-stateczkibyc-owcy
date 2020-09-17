using System;
using System.Collections.Generic;
using System.Drawing;
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

        public static void PrintGreeting(Player player1)
        {
            Console.WriteLine($"{player1.Name}'s turn!");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
        }

        public static void PrintBothOceans(Player player1, Player player2)
        {
            Console.WriteLine("Your flotilla:");
            OceanDisplayer.PrintOceanForCurrentPlayer(player1.PlayerOcean.Squares);
            Console.WriteLine(Environment.NewLine, Environment.NewLine);
            Console.WriteLine("Enemy flotilla:");
            OceanDisplayer.PrintOceanForPlay(player2.PlayerOcean.Squares);
        }

        public static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void PrintGameRowsForPlay(Square[,] ocean, int rows, int cols, char[] alphabet)
        {
            for (int i = 0; i < rows; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n" + alphabet[i]);
                Console.ResetColor();
                Console.Write(" | ");
                for (int j = 0; j < cols; j++)
                {
                    var currentSquare = ocean[i, j];

                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Write(currentSquare.Status.ToSymbolForOpponent());
                    Console.ResetColor();
                }
            }
        }

        private static void PrintGameRowsForCurrentPlayer(Square[,] ocean, int rows, int cols, char[] alphabet)
        {
            for (int i = 0; i < rows; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n" + alphabet[i]);
                Console.ResetColor();
                Console.Write(" | ");

                for (int j = 0; j < cols; j++)
                {
                    var currentSquare = ocean[i, j];
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Write(currentSquare.Status.ToSymbolForCurrentPlayer());
                    Console.ResetColor();
                }

            }
        }

        private static void PrintHeaders(int cols)
        {
            Console.Write("# | ");
            for (int counterRowsNumbers = 1; counterRowsNumbers <= cols; counterRowsNumbers++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (counterRowsNumbers < 9)
                {
                    Console.Write(counterRowsNumbers);
                    Console.ResetColor();
                    Console.Write(" | ");
                }
                else
                {
                    Console.Write(counterRowsNumbers);
                    Console.ResetColor();
                    Console.Write(" |");
                }
                Console.ResetColor();
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
