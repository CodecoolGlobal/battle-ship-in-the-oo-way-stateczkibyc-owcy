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
            bob.PlayerOcean.Ships.Add(bobShip);
            Player adam = new Player("adam");
            bob.Shoot();
            OceanDisplayer.PrintOceanForCurrentPlayer(bob.PlayerOcean.Squares);
            OceanDisplayer.PrintOceanForPlay(bob.PlayerOcean.Squares);
        }

    }
}
