﻿using Stateczki.Oceans;
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
            ocean.PlaceShip(ShipFactory.NewDestroyer(ocean, ocean.Squares[1, 1], ShipOrientation.Horizontal));
            ocean.PlaceShip(ShipFactory.NewSubmarine(ocean, ocean.Squares[4, 2], ShipOrientation.Vertical));
            ocean.PlaceShip(ShipFactory.NewCruiser(ocean, ocean.Squares[3, 6], ShipOrientation.Horizontal));
            ocean.PlaceShip(ShipFactory.NewBattleship(ocean, ocean.Squares[8, 1], ShipOrientation.Horizontal));
            ocean.PlaceShip(ShipFactory.NewCarrier(ocean, ocean.Squares[5, 8], ShipOrientation.Vertical));
        }
        public static void PlaceTestShipsLayout2(Ocean ocean)
        {
            ocean.PlaceShip(ShipFactory.NewDestroyer(ocean, ocean.Squares[4, 3], ShipOrientation.Horizontal));
            ocean.PlaceShip(ShipFactory.NewSubmarine(ocean, ocean.Squares[2, 4], ShipOrientation.Horizontal));
            ocean.PlaceShip(ShipFactory.NewCruiser(ocean, ocean.Squares[2, 1], ShipOrientation.Vertical));
            ocean.PlaceShip(ShipFactory.NewBattleship(ocean, ocean.Squares[8, 3], ShipOrientation.Horizontal));
            ocean.PlaceShip(ShipFactory.NewCarrier(ocean, ocean.Squares[3, 9], ShipOrientation.Vertical));
        }
    }
}
