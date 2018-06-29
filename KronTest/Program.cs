using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var trainSerializer = new TrainSerializer();
            var trains = trainSerializer.DeserializeTrains("trains.txt");
            var railroadNetworkSerializer = new RailroadNetworkSerializer();
            var network = railroadNetworkSerializer.DeserializeNetwork("stations.txt");
            var sim = new RailroadSimulator(trains, network);
            
            sim.Simulate();            

            Console.ReadKey();
        }
    }
}
