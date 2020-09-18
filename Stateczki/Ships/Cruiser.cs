using Stateczki.Oceans;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki.Ships
{
    class Cruiser : Ship
    {
        public Cruiser(Ocean ocean, Square square, ShipOrientation orientation)
            : base(ocean, "Cruiser", square, orientation)
        {
        }
    }
}
