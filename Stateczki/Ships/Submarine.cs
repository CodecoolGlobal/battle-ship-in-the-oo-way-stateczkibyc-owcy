using Stateczki.Oceans;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki.Ships
{
    class Submarine : Ship
    {
        public Submarine(Ocean ocean, Square[] squares, ShipOrientation orientation)
            : base(ocean, "Submarine", squares, orientation)
        {
            if (squares.Length != 3)
            {
                throw new ShipFactoryException("A submarine needs to occupy exactly 3 Squares");
            }
        }
    }
}
