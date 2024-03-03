using Freightliner_challenge.Enums;
using System.Text;

namespace Freightliner_challenge
{
    internal class Robot
    {
        private bool isPlaced = false;
        private Cell? currentCell;
        private CompassDirection currentDirection;
        private readonly UserInterface userInterface;

        public Robot(UserInterface userInterface)
        {
            this.userInterface = userInterface;
        }

        public bool GetIsPlaced()
        {
            return this.isPlaced;
        }

        public void SetIsPlaced(bool isPlaced)
        {
            this.isPlaced = isPlaced;
        }

        public Cell GetCurrentLocation()
        {
            return this.currentCell;
        }

        public void SetCurrentLocation(Cell currentCell)
        {
            this.currentCell = currentCell;
        }

        public CompassDirection GetCurrentDirection()
        {
            return this.currentDirection;
        }

        public void SetCurrentDirection(CompassDirection currentDirection)
        {
            this.currentDirection = currentDirection;
        }

        public void PrintStatus()
        {
            // Gather position and direction and pass to the user interface
            StringBuilder sb = new StringBuilder();

            if (this.isPlaced)
            {
                sb.Append(this.currentCell.GetLocation().Item1.ToString());
                sb.Append(" ");
                sb.Append(this.currentCell.GetLocation().Item2.ToString());
                sb.Append(" ");
                sb.Append(this.currentDirection.ToString());

                this.userInterface.Print(sb.ToString());
            }
            else
            {
                this.userInterface.Print("The robot has not been placed yet");
            }
        }
    }
}
