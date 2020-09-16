using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stateczki
{
    abstract class Ship
    {
        public string ShipType { get; }
        public int Life => OccupiedPlaces.Count(place => place.Status == SquareStatus.Ship);


        public List<Square> OccupiedPlaces { get; private set; }
        public Ship(string shipType, Square[] squares)
        {
            ShipType = shipType;
            OccupiedPlaces = new List<Square>(squares);
            foreach (var square in OccupiedPlaces)
            {
                square.Status = SquareStatus.Ship;
            }
        }


        public void CheckShipSank()
        {
            if (Life == 0)
            {
                foreach (var square in OccupiedPlaces)
                {
                    square.Status = SquareStatus.SunkShip;
                }
            }
        }

        public bool CheckHit(int x, int y)
        {
            foreach (var part in OccupiedPlaces)
            {
                if (part.AreMyCoordinates(x, y))
                {
                    // change status
                    part.Status = SquareStatus.HitShip;
                    return true;
                }
            }
            return false;
        }

    }
}
