﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronTest
{
    class RailroadNetworkSerializer
    {        
        public RailroadNetwork DeserializeNetwork(string path)
        {
            var lines = System.IO.File.ReadAllLines(path);

            var stationsTotal = int.Parse(lines[0]);

            RailroadNetwork railroadNetwork = new RailroadNetwork(stationsTotal);

            for (int i = 0; i < stationsTotal; i++)
            {
                var splittedLine =lines[i + 1].Split();
                railroadNetwork.SetLength(int.Parse(splittedLine[0]), int.Parse(splittedLine[1]), int.Parse(splittedLine[2]));
            }

            return railroadNetwork;
        }
    }
}