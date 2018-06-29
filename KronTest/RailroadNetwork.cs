namespace KronTest
{
    class RailroadNetwork
    {
        //Representing the network as matrix for simplicity.
        private int[,] connectionMatrix;

        public RailroadNetwork(int stations)
        {
            connectionMatrix = new int[stations, stations];
        }

        public int GetLength(int first, int second)
        {
            return connectionMatrix[first, second];
        }

        public void SetLength(int first, int second, int length)
        {
            connectionMatrix[first, second] = length;
            connectionMatrix[second, first] = length;
        }
    }
}
