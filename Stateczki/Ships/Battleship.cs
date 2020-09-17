using System;
using System.Collections.Generic;
using System.Text;
using Stateczki.Oceans;

namespace Stateczki.Ships
{
    class Battleship : Ship
    {
        public Battleship(Ocean ocean, Square square, ShipOrientation orientation)
            :base(ocean, "Battleship", square, orientation)
        {
        }
    }
}
