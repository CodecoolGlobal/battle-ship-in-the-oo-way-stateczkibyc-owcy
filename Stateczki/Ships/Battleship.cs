using System;
using System.Collections.Generic;
using System.Text;
using Stateczki.Oceans;

namespace Stateczki.Ships
{
    class Battleship : Ship
    {
        public Battleship(Ocean ocean, Square[] squares, ShipOrientation orientation)
            :base(ocean, "Battleship", squares, orientation)
        {
            if (squares.Length != 4)
            {
                throw new ShipFactoryException("A Battleship needs to occupy exactly 4 Squares");
            }
        }
    }
}
