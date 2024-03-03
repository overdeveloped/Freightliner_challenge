using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freightliner_challenge
{
    internal class Cell
    {
        private Tuple<int, int> location;

        public Cell(int x, int y)
        {
            this.location = new Tuple<int, int>(x, y);
        }

        public Tuple<int, int> GetLocation()
        {
            return this.location;
        }

        public void Print()
        {
            Console.Write($"({this.location.Item1}, {this.location.Item2})");
        }

    }
}
