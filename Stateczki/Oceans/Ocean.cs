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
