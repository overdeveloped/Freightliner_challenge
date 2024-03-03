
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
    }
}
