using Stateczki.Oceans;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki.Ships
{
    class Carrier : Ship
    {
        public Carrier(Ocean ocean, Square[] squares, ShipOrientation orientation)
            :base(ocean, "Carrier", squares, orientation)
        {
            if (squares.Length != 5)
            {
                throw new ShipFactoryException("A Carrier needs to occupy exactly 5 Squares");
            }
        }
    }
}
