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

        public int x { get; }
        public int y { get; }

        public Square(int x, int y)
        {
            Status = SquareStatus.Empty;
            this.x = x;
            this.y = y;
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
            if (this.x == x && this.y == y)
            {
                return true;
            }
            return false;
        }
    }
}
