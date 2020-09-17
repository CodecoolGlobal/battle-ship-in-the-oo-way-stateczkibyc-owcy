using Stateczki.Ships;
using System;

namespace Stateczki
{
    class Game
    {
        static void Main(string[] args)
        {
            // Init players, boards, ships
            Player bob = new Player("bob");
            ShipPlacer.PlaceTestShipsLayout1(bob.PlayerOcean);
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

    }
}
