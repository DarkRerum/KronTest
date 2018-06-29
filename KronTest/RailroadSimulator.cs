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

        public RailroadSimulator(List<Train> trains, RailroadNetwork network)
        {
            this.trains = trains;

            railroadNetwork = network;            
        }

        public void Simulate()
        {
            while (trains.Count > 0)
            {
                Update();
            }
        }

        private void Update()
        {
            PrintTrainsPosition();
            if (DetectCollisions())
            {
                Console.WriteLine("Collision Detected");
            }            
            RemoveArrivedTrains();            
            UpdateTrainsPosition();
            Console.WriteLine();
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

        private TrainPosition NormalizePosition(TrainPosition position)
        {            
            if (position.StationA > position.StationB && position.Distance > 0)
            {
                TrainPosition newPosition = new TrainPosition(position.StationA, position.StationB, position.Distance);
                var temp = newPosition.StationA;
                newPosition.StationA = newPosition.StationB;
                newPosition.StationB = temp;

                newPosition.Distance = railroadNetwork.GetLength(newPosition.StationA, newPosition.StationB) - newPosition.Distance;

                return newPosition;
            }
                        
            return position;            
        }

        private bool ArePositionsSame(TrainPosition positionA, TrainPosition positionB)
        {
            if (positionA.StationA == positionB.StationA && positionA.Distance == 0 && positionB.Distance == 0)
            {
                return true;
            }

            var posA = NormalizePosition(positionA);
            var posB = NormalizePosition(positionB);

            if (posA.StationA == posB.StationA && posA.StationB == posB.StationB && posA.Distance == posB.Distance)
            {
                return true;
            }

            return false;
        }

        private bool DetectCollisions()
        {
            for (int i = 0; i < trains.Count; i++)
            {
                for (int j = i + 1; j < trains.Count; j++)
                {
                    if (ArePositionsSame(trains[i].Position, trains[j].Position))
                    {
                        return true;
                    }
                }
            }
            return false;
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
