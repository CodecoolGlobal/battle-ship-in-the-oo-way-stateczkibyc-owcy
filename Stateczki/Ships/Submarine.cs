using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki.Ships
{
    class Submarine : Ship
    {
        public Submarine(Square[] squares)
            : base("Submarine", squares)
        {
            if (squares.Length != 3)
            {
                throw new ShipFactoryException("A submarine needs to occupy exactly 3 Squares");
            }
        }
    }
}
