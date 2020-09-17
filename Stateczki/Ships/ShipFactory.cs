using Stateczki.Oceans;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki.Ships
{
    static class ShipFactory
    {
        public static Ship NewCarrier(Ocean ocean, Square[] squares, ShipOrientation orientation)
        {
            return new Carrier(ocean, squares, orientation);
        }
        public static Ship NewBattleship(Ocean ocean, Square[] squares, ShipOrientation orientation)
        {
            return new Battleship(ocean, squares, orientation);
        }
        public static Ship NewCruiser(Ocean ocean, Square[] squares, ShipOrientation orientation)
        {
            return new Cruiser(ocean, squares, orientation);
        }
        public static Ship NewSubmarine(Ocean ocean, Square[] squares, ShipOrientation orientation)
        {
            return new Submarine(ocean, squares, orientation);
        }
        public static Ship NewDestroyer(Ocean ocean, Square[] squares, ShipOrientation orientation)
        {
            return new Destroyer(ocean, squares, orientation);
        }

    }
}
