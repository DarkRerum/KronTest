using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronTest
{
    class RailroadNetwork
    {
        int[,] connectionMatrix;

        public RailroadNetwork()
        {
            connectionMatrix = new int[5, 5] { { 0, 0, 1, 0, 0 }, { 0, 0, 5, 4, 0 }, { 1, 5, 0, 3, 0 }, { 0, 4, 3, 0, 2 }, { 0, 0, 0, 2, 0 } };
        }

        public int GetLength(int first, int second)
        {
            return connectionMatrix[first, second];
        }
    }
}
