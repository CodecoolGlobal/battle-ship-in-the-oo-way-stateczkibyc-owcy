using System;

namespace Stateczki
{
    class Game
    {
        static void Main(string[] args)
        {
            Square[,] exampleOcean = new Square[3,3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    exampleOcean[i, j] = new Square();
                }
            }
            exampleOcean[0, 0].IsOccupied = true;
            OceanDisplayer.PrintOceanForPlacementPhase(exampleOcean);
        }
    }
}
