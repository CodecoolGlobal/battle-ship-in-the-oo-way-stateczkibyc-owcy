using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki
{
    class Square
    {
        public bool IsOccupied { get; set; }
        public bool IsHit { get; set; }

        public Square()
        {
            IsOccupied = false;
            IsHit = false;
        }

    }
}
