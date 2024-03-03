using Freightliner_challenge.Enums;

namespace Freightliner_challenge
{
    internal class Game
    {
        private bool quit = false;
        private bool robotIsPlaced = false;
        private readonly Board board;
        private readonly Robot robot;
        private readonly UserInterface userInterface;

        public Game(Board board, Robot robot, UserInterface userInterface)
        {
            this.board = board;
            this.robot = robot;
            this.userInterface = userInterface;
        }

        // Game loop
        public void Play()
        {
            userInterface.PromptUser();

            while (!quit)
            {
                // Get user input. The user interface can be mocked and user input simulated for testing
                string input = userInterface.GetUserInput();

                // Check that the place command has been run first
                if (!this.robotIsPlaced && !input.Split()[0].Equals("PLACE"))
                {
                    this.userInterface.RobotNotPlaced();
                    continue;
                }

                CarryOutInstruction(input);
            }
        }

        private void CarryOutInstruction(string instruction)
        {
            // Check if the first word of the user input matches any of the known commands
            switch (instruction.Split()[0])
            {
                case "PLACE":
                    Place(instruction);
                    break;
                case "TURN":
                    if (robotIsPlaced)
                        Turn(instruction);
                    break;
                case "MOVE":
                    Move(instruction);
                    break;
                case "PRINT":
                    Print();
                    break;
                case "QUIT":
                    Environment.Exit(0);
                    break;
                default:
                    this.userInterface.InvalidResponse();
                    break;
            }
        }

        private void Place(string instruction)
        {
            // Check that the command has the right number of components
            string[] instArr = instruction.Split(' ');

            if (instArr.Length != 4)
            {
                this.userInterface.InvalidResponse();
                return;
            }

            // Extract the direction
            CompassDirection direction = MatchCompassDirection(instArr[3], this.robot.GetCurrentDirection());

            int x;
            int y;

            // Extract the location
            // Check for non integer input
            try
            {
                x = Convert.ToInt32(instArr[1]);
                y = Convert.ToInt32(instArr[2]);
            }
            catch
            {
                this.userInterface.InvalidResponse();
                return;
            }

            // Check that the destination exists
            Cell cell = this.board.CheckCell(x, y);

            if (cell == null)
            {
                this.userInterface.InvalidResponse();
                return;
            }

            // Set new location and direction for robot
            this.robot.SetCurrentLocation(cell);
            this.robot.SetCurrentDirection(direction);
            this.robot.SetIsPlaced(true);
            this.robotIsPlaced = true;
        }

        private void Turn(string instruction)
        {
            string[] instArr = instruction.Split(' ');

            if (instArr.Length != 2)
            {
                this.userInterface.InvalidResponse();
                return;
            }

            this.robot.SetCurrentDirection(MatchCompassDirection(instArr[1], this.robot.GetCurrentDirection()));
        }

        private void Move(string instruction)
        {
            string[] instArr = instruction.Split(' ');

            if (instArr.Length != 1)
            {
                this.userInterface.InvalidResponse();
                return;
            }

            int robotX = this.robot.GetCurrentLocation().GetLocation().Item1;
            int robotY = this.robot.GetCurrentLocation().GetLocation().Item2;

            CompassDirection robotDir = this.robot.GetCurrentDirection();

            if (robotDir.Equals(CompassDirection.NORTH))
            {
                Cell destination = board.CheckCell(robotX + 1, robotY);

                if (destination != null)
                {
                    this.robot.SetCurrentLocation(destination);
                }
                else
                {
                    this.userInterface.EdgeWarning();
                }
            }

            if (robotDir.Equals(CompassDirection.EAST))
            {
                Cell destination = board.CheckCell(robotX, robotY + 1);

                if (destination != null)
                {
                    this.robot.SetCurrentLocation(destination);
                }
                else
                {
                    this.userInterface.EdgeWarning();
                }

            }

            if (robotDir.Equals(CompassDirection.SOUTH))
            {
                Cell destination = board.CheckCell(robotX - 1, robotY);

                if (destination != null)
                {
                    this.robot.SetCurrentLocation(destination);
                }
                else
                {
                    this.userInterface.EdgeWarning();
                }

            }

            if (robotDir.Equals(CompassDirection.WEST))
            {
                Cell destination = board.CheckCell(robotX, robotY - 1);

                if (destination != null)
                {
                    this.robot.SetCurrentLocation(destination);
                }
                else
                {
                    this.userInterface.EdgeWarning();
                }
            }
        }

        public void Print()
        {
            this.robot.PrintStatus();
        }

        private CompassDirection MatchCompassDirection(string input, CompassDirection previousDirection)
        {
            // Match the user input with a compass direction. If there isn't a match send back the existing direction
            if (Enum.TryParse(input, out CompassDirection compDir))
            {
                return compDir;
            }
            else
            {
                this.userInterface.InvalidResponse();
                return previousDirection;
            }

        }
    }
}
