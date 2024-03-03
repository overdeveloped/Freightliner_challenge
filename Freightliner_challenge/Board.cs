
namespace Freightliner_challenge
{
    internal class Board
    {
        private int width;
        private int height;
        private List<Cell> cells = new List<Cell>();

        public Board(int width, int height)
        {
            this.width = width;
            this.height = height;
            InitialiseCells();
        }
        private void InitialiseCells()
        {
            for (int x = this.width - 1; x >= 0; x--)
            {
                for (int y = 0; y < this.height; y++)
                {
                    this.cells.Add(new Cell(x, y));
                }
            }
        }

        public void SetDimentions(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public int GetHeight()
        {
            return this.height;
        }

        public int getWidth()
        {
            return this.width;
        }

        public Cell CheckCell(int x, int y)
        {
            return this.cells.Find(c => c.GetLocation().Item1 == x && c.GetLocation().Item2 == y);
        }
    }
}
