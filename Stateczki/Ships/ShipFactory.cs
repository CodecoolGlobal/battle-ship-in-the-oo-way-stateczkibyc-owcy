using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki.Ships
{
    static class ShipFactory
    {
        public static Ship NewCarrier(Square[] squares)
        {
            return new Carrier(squares);
        }
        public static Ship NewBattleship(Square[] squares)
        {
            return new Battleship(squares);
        }
        public static Ship NewCruiser(Square[] squares)
        {
            return new Cruiser(squares);
        }
        public static Ship NewSubmarine(Square[] squares)
        {
            return new Submarine(squares);
        }
        public static Ship NewDestroyer(Square[] squares)
        {
            return new Destroyer(squares);
        }

    }
}
