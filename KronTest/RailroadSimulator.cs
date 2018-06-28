using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronTest
{
    class RailroadSimulator
    {
        private List<Train> trains;
        private RailroadNetwork railroadNetwork;

        public RailroadSimulator()
        {
            trains = new List<Train>();

            trains.Add(new Train(0, new List<int>() { 1, 2, 0 }));
            trains.Add(new Train(1, new List<int>() { 4, 3, 2, 0 }));

            railroadNetwork = new RailroadNetwork();
        }

        public void Update()
        {
            PrintTrainsPosition();
            RemoveArrivedTrains();
            Console.WriteLine();
            UpdateTrainsPosition();
        }

        private void UpdateTrainsPosition()
        {
            foreach (Train train in trains)
            {
                var pos = train.Position;
                if (pos.Distance != railroadNetwork.GetLength(pos.StationA, pos.StationB) - 1)
                {
                    train.Position.Distance++;
                }
                else
                {
                    var currentStationIndex = train.Position.StationAPathIndex + 1;
                    train.Position.StationA = train.Path[currentStationIndex];
                    try
                    {
                        train.Position.StationB = train.Path[currentStationIndex + 1];
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        train.Position.StationB = train.Position.StationA;
                    }
                    train.Position.Distance = 0;
                    train.Position.StationAPathIndex++;
                }
            }
        }

        private void RemoveArrivedTrains()
        {
            for (int i = trains.Count - 1; i >= 0; i--)
            {
                if (trains[i].Position.StationA == trains[i].Position.StationB)
                {
                    trains.RemoveAt(i);
                }
            }
        }

        private void PrintTrainsPosition()
        {
            foreach (Train train in trains)
            {
                var pos = train.Position;
                Console.WriteLine($"{train.Id}: {pos.StationA}   {pos.StationB}   {pos.Distance}");
            }
        }
    }
}
