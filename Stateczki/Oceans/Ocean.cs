using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stateczki.Oceans
{

    class Ocean
    {
        public Square[,] Squares { get; }
        public List<Ship> Ships { get; private set; }

        public Ocean(int size)
        {
            Squares = new Square[size, size];
            for (var i = 0; i < Squares.GetLength(0); i++)
            {
                for (var j = 0; j < Squares.GetLength(1); j++)
                {
                    Squares[i, j] = new Square(i, j);
                }
            }

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
                if(ship.CheckHit(x, y))
                {
                    ship.HandleShipSank();
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
        
        public void PlaceShip(Ship ship)
        {
            Ships.Add(ship);
            // TODO Place ship on board (Squares)
        }

        public bool CheckWin()
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
    }
}
