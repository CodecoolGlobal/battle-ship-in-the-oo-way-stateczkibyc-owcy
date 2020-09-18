using Stateczki.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stateczki.Oceans
{

    class Ocean
    {
        public Square[,] Squares { get; private set; }
        public List<Ship> Ships { get; private set; }

        public Ocean(int size)
        {
            InitBoard(size);
            Ships = new List<Ship>();
        }

        internal ShootResult CheckShot(int x, int y)
        {
            // if (Squares[x, y].Status == SquareStatus.HitShip)
            if (Squares[x, y].IsAlreadyHit())
            {
                return ShootResult.AlreadyUsedCoordinates;
            }

            // mark shoot and update status
            foreach (var ship in Ships)
            {
                if (ship.CheckHit(x, y))
                {
                    ship.CheckShipSank();
                    return ShootResult.CorrectCoordinates;
                }

            }

            Squares[x, y].Status = SquareStatus.Miss;
            return ShootResult.CorrectCoordinates;

        }

        public bool IsMoveCorrect(Move move)
        {
            return false;
        }

        public void MarkMove(Move move)
        {
        }

        public void PlaceTemplateShip(Ship ship)
        {
            Ships.Add(ship);
        }
        
        public void PlaceShip((int, int)? coordinates, char orientation, string shipType)
        {
            ShipOrientation orientationEnum;
            if (orientation == 'V')
            {
                orientationEnum = ShipOrientation.Vertical;
            }
            else
            {
                orientationEnum = ShipOrientation.Horizontal;
            }
            switch (shipType)
            {
                case "Battleship":
                    Ships.Add(ShipFactory.NewBattleship(this, Squares[coordinates.Value.Item1, coordinates.Value.Item2], orientationEnum));
                    break;
                case "Cruiser":
                    Ships.Add(ShipFactory.NewCruiser(this, Squares[coordinates.Value.Item1, coordinates.Value.Item2], orientationEnum));
                    break;
                case "Carrier":
                    Ships.Add(ShipFactory.NewCarrier(this, Squares[coordinates.Value.Item1, coordinates.Value.Item2], orientationEnum));
                    break;
                case "Destroyer":
                    Ships.Add(ShipFactory.NewDestroyer(this, Squares[coordinates.Value.Item1, coordinates.Value.Item2], orientationEnum));
                    break;
                case "Sumbarine":
                    Ships.Add(ShipFactory.NewSubmarine(this, Squares[coordinates.Value.Item1, coordinates.Value.Item2], orientationEnum));
                    break;
            }
        }

        public bool CheckLoose()
        {
            foreach (var ship in Ships)
            {
                if (!ship.IsShipSank())
                {
                    return false;
                }
            }
            return true;
        }

        private void InitBoard(int size)
        {
            Squares = new Square[size, size];
            for (var i = 0; i < Squares.GetLength(0); i++)
            {
                for (var j = 0; j < Squares.GetLength(1); j++)
                {
                    Squares[i, j] = new Square(i, j);
                }
            }
        }
    }
}
