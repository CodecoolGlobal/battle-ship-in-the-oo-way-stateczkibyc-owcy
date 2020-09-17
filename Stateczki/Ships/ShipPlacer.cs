using Stateczki.Oceans;
using Stateczki.Ships;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki
{
    static class ShipPlacer
    {
        public static void PlaceTestShipsLayout1(Ocean ocean)
        {
            ocean.PlaceShip(ShipFactory.NewDestroyer(new Square[2] { ocean.Squares[1, 1], ocean.Squares[1, 2] }));
            ocean.PlaceShip(ShipFactory.NewSubmarine(new Square[3] { ocean.Squares[4, 2], ocean.Squares[5, 2], ocean.Squares[6, 2] }));
            ocean.PlaceShip(ShipFactory.NewCruiser(new Square[3] { ocean.Squares[3, 6], ocean.Squares[3, 7], ocean.Squares[3, 8] }));
            ocean.PlaceShip(ShipFactory.NewBattleship(new Square[4] { ocean.Squares[8, 1], ocean.Squares[8, 2], ocean.Squares[8, 3], ocean.Squares[8, 4] }));
            ocean.PlaceShip(ShipFactory.NewCarrier(new Square[5] { ocean.Squares[5, 8], ocean.Squares[6, 8], ocean.Squares[7, 8], ocean.Squares[8, 8], ocean.Squares[9, 8] }));
        }
        public static void PlaceTestShipsLayout2(Ocean ocean)
        {
            ocean.PlaceShip(ShipFactory.NewDestroyer(new Square[2] { ocean.Squares[4, 3], ocean.Squares[4, 4] }));
            ocean.PlaceShip(ShipFactory.NewSubmarine(new Square[3] { ocean.Squares[2, 4], ocean.Squares[2, 5], ocean.Squares[2, 6] }));
            ocean.PlaceShip(ShipFactory.NewCruiser(new Square[3] { ocean.Squares[2, 1], ocean.Squares[3, 1], ocean.Squares[4, 1] }));
            ocean.PlaceShip(ShipFactory.NewBattleship(new Square[4] { ocean.Squares[8, 3], ocean.Squares[8, 4], ocean.Squares[8, 5], ocean.Squares[8, 6] }));
            ocean.PlaceShip(ShipFactory.NewCarrier(new Square[5] { ocean.Squares[3, 9], ocean.Squares[4, 9], ocean.Squares[5, 9], ocean.Squares[6, 9], ocean.Squares[7, 9] }));
        }
    }
}
