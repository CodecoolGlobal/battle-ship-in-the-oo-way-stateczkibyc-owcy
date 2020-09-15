using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki.Ships
{
    class Carrier : Ship
    {
        public Carrier(Square[] squares)
            :base("Carrier", squares)
        {
            if (squares.Length != 5)
            {
                throw new ShipFactoryException("A Carrier needs to occupy exactly 5 Squares");
            }
        }
    }
}
