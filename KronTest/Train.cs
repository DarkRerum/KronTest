using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronTest
{
    class Train
    {
        public int Id { get; set; }
        public TrainPosition Position { get; set; }
        public List<int> Path { get; set; }

        public Train(int id, List<int> path)
        {
            Id = id;
            Path = path;

            Position = new TrainPosition(path[0], path[1], 0);
        }
    }
}
