using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var sim = new RailroadSimulator();

            for (int i = 0; i < 10; i++)
            {
                sim.Update();
            }

            Console.ReadKey();
        }
    }
}
