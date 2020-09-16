using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki
{
    public enum SquareStatus 
    {
        Empty,
        Ship,
        HitShip,
        SunkShip,
        Miss
    };
    class Square
    {
        public SquareStatus Status;

        public Square()
        {
            Status = SquareStatus.Empty;
        }

    }
}
