using Stateczki.Ships;
using System;
using System.Net;

namespace Stateczki
{
    class Game
    {
        static void Main(string[] args)
        {
            // Init players, boards, ships
            Player bob = new Player("bob");
            PlaceShipsForPlayers(bob);
            Player adam = new Player("adam");
            ShipPlacer.PlaceTestShipsLayout2(adam.PlayerOcean);

            // Start game
            var noWinner = true;
            var player1 = bob;
            var player2 = adam;
            while(noWinner)
            {
                OceanDisplayer.PrintGreeting(player1);
                OceanDisplayer.PrintBothOceans(player1, player2);
                player2.ReceiveShot();
                Console.Clear();
                OceanDisplayer.PrintBothOceans(player1, player2);
                OceanDisplayer.PressAnyKey();
                if (player2.PlayerOcean.CheckWin())
                {
                    Console.WriteLine($"{player1.Name} won!");
                    Environment.Exit(1);
                }
                
                var SwitchedPlayers = SwitchPlayers(player1, player2); // REFACTOR PLEASE
                player1 = SwitchedPlayers.Item1;
                player2 = SwitchedPlayers.Item2;
            }





            OceanDisplayer.PrintOceanForCurrentPlayer(bob.PlayerOcean.Squares);
            Console.WriteLine();
            Console.WriteLine();
            OceanDisplayer.PrintOceanForPlay(bob.PlayerOcean.Squares);
            bob.ReceiveShot();
            OceanDisplayer.PrintOceanForCurrentPlayer(bob.PlayerOcean.Squares);
           
        }

        static internal (Player, Player) SwitchPlayers(Player player1, Player player2)
        {
            var temp = player1;
            player1 = player2;
            player2 = temp;
            return (player1, player2);
        }

        static internal void PlaceShipsForPlayers(Player player)
        {
            player.PlaceShip("Carrier");
            player.PlaceShip("Battleship");
            player.PlaceShip("Cruiser");
            player.PlaceShip("Sumbarine");
            player.PlaceShip("Destroyer");
        }

    }
}
