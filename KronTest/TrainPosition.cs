namespace KronTest
{
    class TrainPosition
    {
        public TrainPosition(int stationA, int stationB, int distance)
        {
            StationA = stationA;
            StationB = stationB;
            Distance = distance;
            StationAPathIndex = 0;
        }

        public int StationA { get; set; }
        public int StationB { get; set; }
        public int Distance { get; set; }
        public int StationAPathIndex { get; set; }
    }
}
