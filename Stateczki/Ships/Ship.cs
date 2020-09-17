using Stateczki.Oceans;
using Stateczki.Ships;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Stateczki
{
    public enum ShipOrientation
    {
        Horizontal,
        Vertical
    }
    abstract class Ship
    {
        public string ShipType { get; } // TODO refactor to enum
        public int Life => OccupiedPlaces.Count(place => place.Status == SquareStatus.Ship);
        public int Size { get; }
        public ShipOrientation Orientation { get; }

        public List<Square> OccupiedPlaces { get; private set; }
        public Ship(Ocean ocean, string shipType, Square square, ShipOrientation orientation)
        {
            ShipType = shipType;
            Orientation = orientation;
            Size = shipType switch
            {
                "Destroyer" => 2,
                "Cruiser" => 3,
                "Submarine" => 3,
                "Battleship" => 4,
                "Carrier" => 5,
                _ => 0
            };

            OccupiedPlaces = GenerateOccupiedPlaces(square, ocean);
            ValidateOccupiedPlaces(OccupiedPlaces, ocean);
            foreach (var sq in OccupiedPlaces)
            {
                sq.Status = SquareStatus.Ship;
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

        private List<Square> GenerateOccupiedPlaces(Square square, Ocean ocean)
        {
            int x = square.X;
            int y = square.Y;
            var squares = new Square[Size];
            if (Orientation == ShipOrientation.Horizontal)
            {
                for (var i = 0; i < Size; i++)
                {
                    squares[i] = ocean.Squares[x, y + i];
                }
            }
            else
            {
                for (var i = 0; i < Size; i++)
                {
                    squares[i] = ocean.Squares[x + i, y];
                }
            }

            return squares.ToList<Square>();
        }

        private void ValidateOccupiedPlaces(List<Square> squares, Ocean ocean)
        {
            foreach (var sq in squares)
            {
                if (sq.HasOccupiedNeighbours(ocean))
                {
                    throw new ShipFactoryException("The neighbourhood is occupied!");
                }
            }
        }
    }
}
