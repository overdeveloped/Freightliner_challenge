using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freightliner_challenge
{
    internal class Board
    {
        private int width;
        private int height;
        private bool widthDefined = false;
        private bool heightDefined = false;
        private List<Cell> cells = new List<Cell>();

        public Board()
        {
        }

        //public Board(int width, int height)
        //{
        //    this.width = width;
        //    this.height = height;
        //    InitialiseCells();
        //}

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

        public void Setup()
        {
            while (!widthDefined)
            {
                Console.WriteLine("How wide do you want the board?");
                string input = Console.ReadLine();

                try
                {
                    width = Convert.ToInt32(input);
                    widthDefined = true;
                }
                catch
                {
                    Console.WriteLine("Please enter an integer");
                }

            }

            while (!heightDefined)
            {
                Console.WriteLine("How heigh do you want the board?");
                string input = Console.ReadLine();

                try
                {
                    height = Convert.ToInt32(input);
                    heightDefined = true;
                }
                catch
                {
                    Console.WriteLine("Please enter an integer");
                }

            }


            Console.WriteLine($"The board will be {width} wide and {height} high");

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

        public void Print()
        {
            int index = 0;
            for (int x = 0; x < this.width; x++)
            {
                for (int y = 0; y < this.height; y++)
                {
                    Console.Write(" ");
                    this.cells[index].Print();
                    index++;
                }
                Console.WriteLine();
            }
        }

        public Cell CheckCell(int x, int y)
        {
            return this.cells.Find(c => c.GetLocation().Item1 == x && c.GetLocation().Item2 == y);
        }
    }
}
