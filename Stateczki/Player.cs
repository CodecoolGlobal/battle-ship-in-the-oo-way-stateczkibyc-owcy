using Stateczki.Moves;
using Stateczki.Oceans;
using Stateczki.Ships;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki
{
    class Player
    {
        public string Name { get;}

        public Ocean PlayerOcean { get; }

        public Player(string name)
        {
            Name = name;
            PlayerOcean = new Ocean(10); // fixed 10x10 board size.
        }

        public void ReceiveShot()
        {
            // ask for coordinates in while loop
            var areCoordinatesCorrect = false;
            while (!areCoordinatesCorrect)
            {
                (int, int)? coordinates = CoordinatesValidator.Validate(PlayerOcean.Squares, GetMove.GetMoveString());

                if (coordinates == null)
                {
                    continue;
                }

                int x = coordinates.Value.Item1;
                int y = coordinates.Value.Item2;
                var shootResult = PlayerOcean.CheckShot(x, y);

                if (shootResult == ShootResult.CorrectCoordinates)
                {
                    areCoordinatesCorrect = true;
                }
                else if (shootResult == ShootResult.AlreadyUsedCoordinates)
                {
                    Console.WriteLine("Coordinates already used!");
                }
                else
                {
                    Console.WriteLine("Coordinates are wrong!");
                }

            }
        }

        public void PlaceShip(string shipType)
        {
            var areCoordinatesCorrect = false;
            while (!areCoordinatesCorrect)
            {
                Console.Clear();
                OceanDisplayer.PrintOceanForCurrentPlayer(PlayerOcean.Squares);
                (int, int)? coordinates = CoordinatesValidator.Validate(PlayerOcean.Squares, GetMove.GetMoveString());
                if (!coordinates.HasValue)
                {
                    System.Threading.Thread.Sleep(1000);
                    continue;
                }
                Console.WriteLine("Enter V for vertical or H for horizontal");
                char orientation = Char.ToUpper(Console.ReadKey().KeyChar);
                if (orientation != 'V' && orientation != 'H')
                {
                    Console.Clear();
                    Console.WriteLine("Please press valid key!");
                    System.Threading.Thread.Sleep(1000);
                    continue;
                }
                try
                {
                    PlayerOcean.PlaceShip(coordinates, orientation, shipType);
                }
                catch (ShipFactoryException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    System.Threading.Thread.Sleep(1000);
                    continue;
                }
                areCoordinatesCorrect = true;
            }

        }
    }
}
