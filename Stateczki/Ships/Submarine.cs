using Stateczki.Oceans;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki.Ships
{
    class Submarine : Ship
    {
        public Submarine(Ocean ocean, Square square, ShipOrientation orientation)
            : base(ocean, "Submarine", square, orientation)
        {
        }
    }
}
