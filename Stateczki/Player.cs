using Stateczki.Oceans;
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

        public void Shoot()
        {
            // ask for coordinates in while loop
            var areCoordinatesCorrect = false;
            while (!areCoordinatesCorrect)
            {
                int x = 1;
                int y = 1;
                var shootResult = PlayerOcean.Shoot(x, y);

                if (shootResult == ShootResult.CorrectCoordinates)
                {
                    areCoordinatesCorrect = true;
                }

                if (shootResult == ShootResult.AlreadyUsedCoordinates)
                {
                    Console.WriteLine("Coordinates already used!");
                }
                else
                {
                    Console.WriteLine("Coordinates are wrong!");
                }

            }



        }
    }
}
