using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronTest
{
    class TrainSerializer
    {
        public List<int> ParseTrainPath(string line)
        {
            string[] splittedLine = line.Split();
            List<int> path = new List<int>();
            foreach (var item in splittedLine)
            {
                path.Add(int.Parse(item));
            }

            return path;
        }

        public List<Train> DeserializeTrains(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);

            var trainsTotal = int.Parse(lines[0]);

            List<Train> trains = new List<Train>(trainsTotal);

            for (int i = 0; i < trainsTotal; i++)
            {
                trains.Add(new Train(i, ParseTrainPath(lines[i + 1])));
            }

            return trains;
        }
    }
}
