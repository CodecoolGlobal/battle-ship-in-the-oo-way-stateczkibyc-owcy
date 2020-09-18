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
            Player bob = new Player("bob", false);  // false for human, true for AI
            PlaceShipsForPlayers(bob);
            Player adam = new Player("adam", true);
            ShipPlacer.PlaceTestShipsLayout2(adam.PlayerOcean);

            // Start game
            var noWinner = true;
            var currentPlayer = bob;
            var nextPlayer = adam;
            while(noWinner) // TODO use do while (check win condition)
            {
                Console.Clear();
                OceanDisplayer.PrintGreeting(currentPlayer);
                if (!currentPlayer.IsAi)
                {
                    OceanDisplayer.PrintBothOceans(currentPlayer, nextPlayer);
                    nextPlayer.ReceiveShot();
                    Console.Clear();
                    OceanDisplayer.PrintBothOceans(currentPlayer, nextPlayer);
                    OceanDisplayer.PressAnyKey();
                }
                else
                {
                    OceanDisplayer.PrintOceanForCurrentPlayer(nextPlayer.PlayerOcean.Squares);
                    System.Threading.Thread.Sleep(500);
                    nextPlayer.ReceiveShot();
                    Console.Clear();
                    OceanDisplayer.PrintOceanForCurrentPlayer(nextPlayer.PlayerOcean.Squares);
                    System.Threading.Thread.Sleep(1000);
                }
                if (nextPlayer.PlayerOcean.CheckLoose())
                {
                    Console.WriteLine($"{currentPlayer.Name} won!");
                    Environment.Exit(1);
                }
                
                var SwitchedPlayers = SwitchPlayers(currentPlayer, nextPlayer); // REFACTOR PLEASE
                currentPlayer = SwitchedPlayers.Item1;
                nextPlayer = SwitchedPlayers.Item2;
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

        static internal void PlaceShipsForPlayers(Player player) // TODO przenieść do klasy Player
        {
            player.PlaceShip("Carrier");
            player.PlaceShip("Battleship");
            player.PlaceShip("Cruiser");
            player.PlaceShip("Sumbarine");
            player.PlaceShip("Destroyer");
        }

    }
}
