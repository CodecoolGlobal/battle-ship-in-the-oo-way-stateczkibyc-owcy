using Stateczki.Oceans;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki.Ships
{
    static class ShipFactory
    {
        public static Ship NewCarrier(Ocean ocean, Square square, ShipOrientation orientation)
        {
            return new Carrier(ocean, square, orientation);
        }
        public static Ship NewBattleship(Ocean ocean, Square square, ShipOrientation orientation)
        {
            return new Battleship(ocean, square, orientation);
        }
        public static Ship NewCruiser(Ocean ocean, Square square, ShipOrientation orientation)
        {
            return new Cruiser(ocean, square, orientation);
        }
        public static Ship NewSubmarine(Ocean ocean, Square square, ShipOrientation orientation)
        {
            return new Submarine(ocean, square, orientation);
        }
        public static Ship NewDestroyer(Ocean ocean, Square square, ShipOrientation orientation)
        {
            return new Destroyer(ocean, square, orientation);
        }

    }
}
