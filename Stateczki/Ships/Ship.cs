using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki
{
    abstract class Ship
    {
        public string ShipType { get; }
        public int Life => OccupiedPlaces.Count;
        public List<Square> OccupiedPlaces { get; private set; }

        public Ship(string shipType, Square[] squares)
        {
            ShipType = shipType;
            OccupiedPlaces = new List<Square>(squares);
        }
    }
}
