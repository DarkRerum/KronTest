using System;
using System.Collections.Generic;

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
                try
                {
                    Update();
                }
                catch (CollisionException)
                {
                    throw;
                }
            }
        }

        private void Update()
        {            
            if (DetectCollisions())
            {
                throw new CollisionException();
            }            
            RemoveArrivedTrains();            
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

        private bool DetectCollisions()
        {
            for (int i = 0; i < trains.Count; i++)
            {
                for (int j = i + 1; j < trains.Count; j++)
                {
                    if (trains[i].Position.StationA == trains[j].Position.StationA && trains[i].Position.Distance == 0 && trains[j].Position.Distance == 0)
                    {
                        return true;
                    }

                    if (trains[i].Position.StationA == trains[j].Position.StationB && trains[i].Position.StationB == trains[j].Position.StationA)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //Train is considered to have arrived if its StationA is equal to its StationB
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
    }
}
