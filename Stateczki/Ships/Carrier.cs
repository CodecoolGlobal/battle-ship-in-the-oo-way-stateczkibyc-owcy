using Stateczki.Oceans;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki.Ships
{
    class Carrier : Ship
    {
        public Carrier(Ocean ocean, Square square, ShipOrientation orientation)
            :base(ocean, "Carrier", square, orientation)
        {
        }
    }
}
