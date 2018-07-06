using System;

namespace KronTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = System.IO.Directory.EnumerateFiles(args[0], "stations*.txt");

            foreach (var stationFilename in files)
            {
                var trainFilename = stationFilename.Replace("stations", "trains");
                var trains = TrainSerializer.DeserializeTrains(trainFilename);
                var network = RailroadNetworkSerializer.DeserializeNetwork(stationFilename);
                var sim = new RailroadSimulator(trains, network);

                Console.WriteLine($"Checking {stationFilename} and {trainFilename}");

                try
                {
                    sim.Simulate();
                }
                catch (CollisionException)
                {
                    Console.WriteLine("Collision");
                    continue;
                }

                Console.WriteLine("No collision");
            }            
        }
    }
}
