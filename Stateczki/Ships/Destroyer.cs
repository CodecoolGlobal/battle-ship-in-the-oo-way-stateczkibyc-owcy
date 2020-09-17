using Stateczki.Oceans;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki.Ships
{
    class Destroyer : Ship
    {
        public Destroyer(Ocean ocean, Square[] squares, ShipOrientation orientation)
            : base(ocean, "Destroyer", squares, orientation)
        {
            if (squares.Length != 2)
            {
                throw new ShipFactoryException("A Destroyer needs to occupy exactly 2 Squares");
            }
        }
    }
}
