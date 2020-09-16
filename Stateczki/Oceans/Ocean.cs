using System;
using System.Collections.Generic;
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
        }

        internal ShootResult Shoot(int x, int y)
        {
            if (x < 0 || x > 9 || y < 0 || y > 9)
            {
                return ShootResult.WrongCoordinates;
            }

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

                }

            }


            return ShootResult.CorrectCoordinates;
            
        }

        public bool IsMoveCorrect(Move move)
        {
            return false;
        }

        public void MarkMove(Move move)
        {
        }
        
        public void PlaceShip(Move move, Ship ship)
        {
            Ships.Add(ship);
            // TODO Place ship on board (Squares)
        }
    }
}
