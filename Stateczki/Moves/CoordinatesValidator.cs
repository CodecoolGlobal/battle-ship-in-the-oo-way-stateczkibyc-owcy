using Stateczki.Oceans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Stateczki
{
    static class CoordinatesValidator
    {
        public static (int, int)? Validate(Square[,] Squares, string Input)
        {
                try
                {
                    char letterForRow = char.Parse(Regex.Match(Input, @"[a-zA-Z]").Groups[0].Value.ToUpper());
                    int rowIndex = Array.IndexOf(OceanDisplayer.InitAlphabet(Squares.GetLength(0)), letterForRow);
                    int colIndex = int.Parse(Regex.Match(Input, @"\d+").Groups[0].Value) - 1;
                    if (Squares[rowIndex, colIndex] is Square)
                    {
                        return (rowIndex, colIndex);
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
            return (null);
        }
    }
}
