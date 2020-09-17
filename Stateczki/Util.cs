using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki
{
    public static class Util
    {
        public static string ToSymbolForOpponent(this SquareStatus status) => status switch
        {
            SquareStatus.Empty => "~ | ",
            SquareStatus.HitShip => "X | ",
            SquareStatus.Ship => "0 | ",  // TODO Change to Tilda
            SquareStatus.SunkShip => "S | ",
            SquareStatus.Miss => "M | ",
            _ => throw new ArgumentOutOfRangeException(),
        };

        public static string ToSymbolForCurrentPlayer(this SquareStatus status) => status switch
        {
            SquareStatus.Empty => "~ | ",
            SquareStatus.HitShip => "X | ",
            SquareStatus.Ship => "V | ",
            SquareStatus.SunkShip => "S | ",
            SquareStatus.Miss => "M | ",
            _ => throw new ArgumentOutOfRangeException(),
        };
    }
}
