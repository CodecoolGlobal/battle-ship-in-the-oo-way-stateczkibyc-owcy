using Stateczki.Oceans;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki.Ships
{
    class Destroyer : Ship
    {
        public Destroyer(Ocean ocean, Square square, ShipOrientation orientation)
            : base(ocean, "Destroyer", square, orientation)
        {
        }
    }
}
