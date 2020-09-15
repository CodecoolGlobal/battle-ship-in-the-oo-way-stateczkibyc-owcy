using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki.Ships
{
    class Battleship : Ship
    {
        public Battleship(Square[] squares)
            :base("Battleship", squares)
        {
            if (squares.Length != 4)
            {
                throw new ShipFactoryException("A Battleship needs to occupy exactly 4 Squares");
            }
        }
    }
}
