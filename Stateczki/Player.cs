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
    }
}
