using Stateczki.Oceans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Stateczki
{
    class CoordinatesValidator
    {
        public (int, int) Validate(Square[,] Squares)
        {

            int rowIndex = 0;
            int colIndex = 0;

            bool noCoordinatesExist = true;
            while (noCoordinatesExist)
            {
                Console.WriteLine("\r\n\r\nPlease enter coordinates");
                string coordinates = Console.ReadLine();

                if (coordinates == "quit")
                {
                    Environment.Exit(0);
                }

                try
                {
                    char letterForRow = char.Parse(Regex.Match(coordinates, @"[a-zA-Z]").Groups[0].Value.ToUpper());
                    rowIndex = Array.IndexOf(OceanDisplayer.InitAlphabet(Squares.GetLength(0)), letterForRow);
                    colIndex = int.Parse(Regex.Match(coordinates, @"\d+").Groups[0].Value) - 1;
                    if (Squares[rowIndex, colIndex].IsOccupied)
                    {
                        noCoordinatesExist = false;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Wrong Coordinates! Try again.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return (rowIndex, colIndex);
        }
    }
}
