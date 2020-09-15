using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki.Ships
{
    class Destroyer : Ship
    {
        public Destroyer(Square[] squares)
            : base("Destroyer", squares)
        {
            if (squares.Length != 2)
            {
                throw new ShipFactoryException("A Destroyer needs to occupy exactly 2 Squares");
            }
        }
    }
}
