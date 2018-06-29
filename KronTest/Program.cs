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
            var railroadNetworkSerializer = new RailroadNetworkSerializer();                        
            var files = System.IO.Directory.EnumerateFiles(args[0], "stations*.txt");

            foreach (var stationFilename in files)
            {
                var trainFilename = stationFilename.Replace("stations", "trains");
                var trains = trainSerializer.DeserializeTrains(trainFilename);
                var network = railroadNetworkSerializer.DeserializeNetwork(stationFilename);
                var sim = new RailroadSimulator(trains, network);

                Console.WriteLine($"Checking {stationFilename} and {trainFilename}");

                try
                {
                    sim.Simulate();
                }
                catch (CollisionException e)
                {
                    Console.WriteLine("Collision");
                    continue;
                }

                Console.WriteLine("No collision");
            }            
        }
    }
}
