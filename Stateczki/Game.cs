using Stateczki.Ships;
using System;

namespace Stateczki
{
    class Game
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi, Bob!");
            Player bob = new Player("bob");
            Ship bobShip = ShipFactory.NewDestroyer(new Square[2] { bob.PlayerOcean.Squares[1, 1], bob.PlayerOcean.Squares[1, 2] });
            Player adam = new Player("adam");
            bob.PlayerOcean.Squares[1, 1].Status = SquareStatus.HitShip;
            OceanDisplayer.PrintOceanForCurrentPlayer(bob.PlayerOcean.Squares);
            OceanDisplayer.PrintOceanForPlay(bob.PlayerOcean.Squares);
        }

    }
}
