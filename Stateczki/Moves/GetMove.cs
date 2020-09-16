using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki.Moves
{
    static class GetMove
    {
        public static string GetMoveString()
        {
            Console.WriteLine("\r\n\r\nPlease enter coordinates");
            string coordinates = Console.ReadLine();

            if (coordinates == "quit")
            {
                Environment.Exit(0);
            }
            return coordinates;
        }
    }
}
