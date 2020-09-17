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
            Console.ForegroundColor = ConsoleColor.DarkGray;
            OceanDisplayer.PrintOceanForCurrentPlayer(player1.PlayerOcean.Squares);
            Console.WriteLine(Environment.NewLine, Environment.NewLine);
            Console.ResetColor();
            Console.WriteLine("Enemy flotilla:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            OceanDisplayer.PrintOceanForPlay(player2.PlayerOcean.Squares);
            Console.ResetColor();
        }

        public static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
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

        private static void PrintGameRowsForPlay(Square[,] ocean, int rows, int cols, char[] alphabet)
        {
            for (int i = 0; i < rows; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\n" + alphabet[i]);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" | ");
                for (int j = 0; j < cols; j++)
                {
                    var currentSquare = ocean[i, j];
                    var stringToWrite = currentSquare.Status.ToSymbolForOpponent();
                    PrintInColor(stringToWrite);
                }
            }
        }

        private static void PrintGameRowsForCurrentPlayer(Square[,] ocean, int rows, int cols, char[] alphabet)
        {
            for (int i = 0; i < rows; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\n" + alphabet[i]);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" | ");

                for (int j = 0; j < cols; j++)
                {
                    var currentSquare = ocean[i, j];
                    var stringToWrite = currentSquare.Status.ToSymbolForCurrentPlayer();
                    PrintInColor(stringToWrite);
                }

            }
        }

        private static void PrintHeaders(int cols)
        {
            Console.Write("# | ");
            for (int counterRowsNumbers = 1; counterRowsNumbers <= cols; counterRowsNumbers++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (counterRowsNumbers < 9)
                {
                    Console.Write(counterRowsNumbers);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(" | ");
                }
                else
                {
                    Console.Write(counterRowsNumbers);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(" |");
                }
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
        }

        private static void PrintInColor(string output)
        {
            foreach (Char c in output)
            {
                Console.ForegroundColor = c switch
                {
                    '~' => ConsoleColor.Blue, // color of water
                    'X' => ConsoleColor.Red, // color of hit
                    'S' => ConsoleColor.DarkMagenta, // color of sunken ship
                    'M' => ConsoleColor.DarkGray, // color of miss
                    'V' => ConsoleColor.Yellow, // color of allied vessel
                    _ => ConsoleColor.DarkGray
                };
                PrintColoredCharInline(c);
            }
        }

        private static void PrintColoredCharInline(Char c)
        {
            Console.Write(c);
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }
    }
}
