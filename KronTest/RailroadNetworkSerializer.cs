namespace KronTest
{
    class RailroadNetworkSerializer
    {        
        public static RailroadNetwork DeserializeNetwork(string path)
        {
            var lines = System.IO.File.ReadAllLines(path);

            var stationsTotal = int.Parse(lines[0]);

            RailroadNetwork railroadNetwork = new RailroadNetwork(stationsTotal);

            for (int i = 0; i < lines.Length - 1; i++)
            {
                var splittedLine = lines[i + 1].Split();
                railroadNetwork.SetLength(int.Parse(splittedLine[0]), int.Parse(splittedLine[1]), int.Parse(splittedLine[2]));
            }

            return railroadNetwork;
        }
    }
}
