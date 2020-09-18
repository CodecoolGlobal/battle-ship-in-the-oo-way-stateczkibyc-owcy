using Stateczki.Oceans;
using Stateczki.Ships;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki
{
    public enum SquareStatus 
    {
        Empty,
        Ship,
        HitShip,
        SunkShip,
        Miss
    };

    public enum ShootResult
    {
        WrongCoordinates,
        AlreadyUsedCoordinates,
        CorrectCoordinates
    }

    class Square
    {
        public SquareStatus Status;

        public int X { get; }
        public int Y { get; }

        public Square(int x, int y)
        {
            Status = SquareStatus.Empty;
            this.X = x;
            this.Y = y;
        }

        public bool IsAlreadyHit()
        {
            if (this.Status == SquareStatus.HitShip || this.Status == SquareStatus.Miss || this.Status == SquareStatus.SunkShip)
            {
                return true;
            }

            return false;
        }

        public bool AreMyCoordinates(int x, int y)
        {
            if (this.X == x && this.Y == y)
            {
                return true;
            }
            return false;
        }

        public bool HasOccupiedNeighbours(Ocean ocean)
        {
            try
            {
                if (ocean.Squares[this.X - 1, this.Y].Status != SquareStatus.Empty)
                {
                    return true;
                }
            }
            catch (IndexOutOfRangeException)
            {
            }
            try
            {
                if (ocean.Squares[this.X + 1, this.Y].Status != SquareStatus.Empty)
                {
                    return true;
                }
            }
            catch (IndexOutOfRangeException)
            {
            }
            try
            {
                if (ocean.Squares[this.X, this.Y - 1].Status != SquareStatus.Empty)
                {
                    return true;
                }
            }
            catch (IndexOutOfRangeException)
            {
            }
            try
            {
                if (ocean.Squares[this.X, this.Y + 1].Status != SquareStatus.Empty)
                {
                    return true;
                }
            }
            catch (IndexOutOfRangeException)
            {
            }

            return false;
        }
    }
}
