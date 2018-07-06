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
            
            foreach (var item in this.trains)
            {
                List<int> stationDistances = new List<int>();
                for (int i = 0; i < item.Path.Count - 1; i++)
                {
                    stationDistances.Add(railroadNetwork.GetLength(item.Path[i], item.Path[i+1]));
                }

                item.StationDistances = stationDistances;
            }
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
            DetectCollisions();            
            RemoveArrivedTrains();            
            UpdateTrainsPosition();            
        }

        private void UpdateTrainsPosition()
        {
            foreach (Train train in trains)
            {
                train.UpdatePosition();
            }
        }

        private void DetectCollisions()
        {
            for (int i = 0; i < trains.Count; i++)
            {
                for (int j = i + 1; j < trains.Count; j++)
                {
                    if (trains[i].StationA == trains[j].StationA && trains[i].CurrentDistance == 0 && trains[j].CurrentDistance == 0)
                    {
                        throw new CollisionException();
                    }

                    if (trains[i].StationA == trains[j].StationB && trains[i].StationB == trains[j].StationA)
                    {
                        throw new CollisionException();
                    }
                }
            }            
        }

        //Train is considered to have arrived if its StationA is equal to its StationB
        private void RemoveArrivedTrains()
        {
            for (int i = trains.Count - 1; i >= 0; i--)
            {
                if (trains[i].StationA == trains[i].StationB)
                {
                    trains.RemoveAt(i);
                }
            }
        }
    }
}
