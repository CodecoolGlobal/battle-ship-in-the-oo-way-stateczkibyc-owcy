using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki.Ships
{
    class Cruiser : Ship
    {
        public Cruiser(Square[] squares)
            : base("Cruiser", squares)
        {
            if (squares.Length != 3)
            {
                throw new ShipFactoryException("A Cruiser needs to occupy exactly 3 Squares");
            }
        }
    }
}
