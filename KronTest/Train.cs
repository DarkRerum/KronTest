using System.Collections.Generic;

namespace KronTest
{
    class Train
    {        
        //public TrainPosition Position { get; private set; }
        public List<int> Path { get; private set; }
        public int StationA { get; private set; }
        public int StationB { get; private set; }
        private int StationAPathIndex { get; set; }

        //Distance between each station in the path
        public List<int> StationDistances { get; set; }
        public int CurrentDistance { get; private set; }

        public Train(List<int> path)
        {            
            Path = path;            
            StationA = path[0];
            StationB = path[1];
            StationAPathIndex = 0;
        }        

        public void UpdatePosition()
        {            
            if (CurrentDistance < StationDistances[StationAPathIndex] - 1)
            {
                CurrentDistance++;
            }
            else
            {
                StationAPathIndex++;
                StationA = Path[StationAPathIndex];
                if (StationAPathIndex + 1 < Path.Count)
                {
                    StationB = Path[StationAPathIndex + 1];
                }
                else
                {
                    StationB = StationA;
                }
                CurrentDistance = 0;                
            }
        }
    }
}
