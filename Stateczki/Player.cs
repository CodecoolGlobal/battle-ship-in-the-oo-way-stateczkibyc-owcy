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
        public bool IsAi { get; }

        private (int, int)? lastHit { get; set; }

        public Ocean PlayerOcean { get; }

        public Player(string name, bool isAi)
        {
            Name = name;
            PlayerOcean = new Ocean(10); // fixed 10x10 board size.
            IsAi = isAi;
            lastHit = null;
        }

        public void ReceiveShot()
        {
            // ask for coordinates in while loop
            var areCoordinatesCorrect = false;
            while (!areCoordinatesCorrect)
            {
                (int, int)? coordinates = null;
                if (!IsAi)
                {
                    // TODO add better AI
                    if (lastHit != null)
                    {
                        coordinates = GetAiMove() ?? (new Random().Next(0, PlayerOcean.Squares.GetLength(0)), new Random().Next(0, PlayerOcean.Squares.GetLength(1)));
                    }
                    else
                    {
                    coordinates = (new Random().Next(0, PlayerOcean.Squares.GetLength(0)), new Random().Next(0, PlayerOcean.Squares.GetLength(1)));
                    }
                }
                else
                {
                coordinates = CoordinatesValidator.Validate(PlayerOcean.Squares, GetMove.GetMoveString());
                }

                if (coordinates == null)
                {
                    continue;
                }

                int x = coordinates.Value.Item1;
                int y = coordinates.Value.Item2;
                var shootResult = PlayerOcean.CheckShot(x, y);

                if (shootResult == ShootResult.CorrectCoordinates)
                {
                    if (PlayerOcean.Squares[x, y].Status == SquareStatus.HitShip)
                    {
                        lastHit = coordinates;
                    }
                    areCoordinatesCorrect = true;
                }
                else if (shootResult == ShootResult.AlreadyUsedCoordinates)
                {
                    if (IsAi)
                    {
                    Console.WriteLine("Coordinates already used!");
                    }
                }
                else
                {
                    if (IsAi)
                    {
                    Console.WriteLine("Coordinates are wrong!");
                    }
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

        private (int, int)? GetAiMove()
        {
            (int, int)? coordinates = null;
            if (lastHit != null)
            {
                int x = lastHit.Value.Item1;
                int y = lastHit.Value.Item2;
                coordinates = PlayerOcean.Squares[x, y].CheckNeighbours(PlayerOcean);
            }

            return coordinates;
        }
    }
}
