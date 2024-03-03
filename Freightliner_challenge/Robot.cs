using Freightliner_challenge.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freightliner_challenge
{
    internal class Robot
    {
        private Cell currentCell;
        private CompassDirection currentDirection;

        public Robot()
        {
        }

        public Cell GetCurrentLocation()
        {
            return this.currentCell;
        }

        public void SetLocation(Cell currentCell)
        {
            this.currentCell = currentCell;
        }

        public CompassDirection GetCurrentDirection()
        {
            return this.currentDirection;
        }

        public void SetDirection(CompassDirection currentDirection)
        {
            this.currentDirection = currentDirection;
        }

        public void PrintStatus()
        {
            Console.WriteLine($"Location: {this.currentCell.GetLocation().Item1}, {this.currentCell.GetLocation().Item2} Direction: {this.currentDirection.ToString()}");
        }
    }
}
