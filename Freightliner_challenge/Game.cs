using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Freightliner_challenge.Enums;

namespace Freightliner_challenge
{
    internal class Game
    {
        private bool quit = false;
        private bool startingLocationIsSet = false;
        private readonly Board board;
        private readonly Robot robot;

        public Game(Board board, Robot robot)
        {
            this.board = board;
            this.robot = robot;
        }

        public void Play()
        {
            while (!quit)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter instruction");

                string input = Console.ReadLine().ToUpper();
                bool success = false;

                //foreach (var item in Enum.GetNames(typeof(Instruction)))
                //{
                //    if (input.Split(' ')[0].Equals(item))
                //    {
                //        //CarryOutInstruction((int)Enum.Parse(typeof(Instruction), item));
                //        success = true;
                //        CarryOutInstruction(input);
                //    }
                //}

                //if (!success)
                //{
                //}
                CarryOutInstruction(input);

            }
        }

        private void CarryOutInstruction(string instruction)
        {
            //PLACE,
            //TURN,
            //MOVE,
            //PRINT,
            //MAP,
            //QUIT

            //if (!this.startingLocationIsSet && !instruction.Contains("PLACE"))
            //{
            //    Console.WriteLine("Error: First instruction must be PLACE");
            //    return;
            //}

            //Console.Clear();

            switch (instruction.Split()[0])
            {
                case "PLACE":
                    Place(instruction);
                    break;
                case "TURN":
                    Turn(instruction);
                    break;
                case "MOVE":
                    Move(instruction);
                    break;
                case "PRINT":
                    Print();
                    break;
                case "MAP":
                    board.Print();
                    break;
                case "QUIT":
                    Environment.Exit(0);
                    break;
                default:
                    InvalidResponse();
                    break;
            }
        }

        private void Place(string instruction)
        {
            // Check that the command has the right number of components
            string[] instArr = instruction.Split(' ');

            if (instArr.Length != 4)
            {
                InvalidResponse();
                return;
            }

            // Extract the direction
            CompassDirection direction = MatchCompassDirection(instArr[3], this.robot.GetCurrentDirection());
            bool directionIsValid = false;

            //foreach (var item in Enum.GetNames(typeof(CompassDirection)))
            //{
            //    if (instArr[3].Equals(item))
            //    {
            //        if (Enum.TryParse(item, out CompassDirection compDir))
            //        {
            //            direction = compDir;
            //        }
            //        else
            //        {
            //            InvalidResponse();
            //            return;
            //        }

            //        directionIsValid = true;
            //    }
            //}

            //if (!directionIsValid)
            //{
            //    InvalidResponse();
            //    return;
            //}

            // Extract the location
            int x;
            int y;

            // Check for non integer input
            try
            {
                x = Convert.ToInt32(instArr[1]);
                y = Convert.ToInt32(instArr[2]);
            }
            catch
            {
                InvalidResponse();
                return;
            }

            // Check that destination exists
            Cell cell = this.board.CheckCell(x, y);

            if (cell != null)
            {
                cell.Print();
            }
            else
            {
                InvalidResponse();
                return;
            }

            // Set location and direction for robot
            this.robot.SetLocation(cell);

            this.robot.SetDirection(direction);

            this.startingLocationIsSet = true;
        }

        private void Turn(string instruction)
        {
            string[] instArr = instruction.Split(' ');

            if (instArr.Length != 2)
            {
                InvalidResponse();
                return;
            }

            this.robot.SetDirection(MatchCompassDirection(instArr[1], this.robot.GetCurrentDirection()));


        }

        private void Move(string instruction)
        {
            string[] instArr = instruction.Split(' ');

            if (instArr.Length != 1)
            {
                InvalidResponse();
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
                    this.robot.SetLocation(destination);
                }
                else
                {
                    Console.WriteLine("Stop! Going to fall!");
                }
                //if (robotX + 1 >= this.board.GetHeight())
                //{
                //    Console.WriteLine("NO");
                //}
                //else
                //{
                //    this.robot.SetLocation()
                //}
            }

            if (robotDir.Equals(CompassDirection.EAST))
            {
                Cell destination = board.CheckCell(robotX, robotY + 1);

                if (destination != null)
                {
                    this.robot.SetLocation(destination);
                }
                else
                {
                    Console.WriteLine("Stop! Going to fall!");
                }

            }

            if (robotDir.Equals(CompassDirection.SOUTH))
            {
                Cell destination = board.CheckCell(robotX - 1, robotY);

                if (destination != null)
                {
                    this.robot.SetLocation(destination);
                }
                else
                {
                    Console.WriteLine("Stop! Going to fall!");
                }

            }

            if (robotDir.Equals(CompassDirection.WEST))
            {
                Cell destination = board.CheckCell(robotX, robotY - 1);

                if (destination != null)
                {
                    this.robot.SetLocation(destination);
                }
                else
                {
                    Console.WriteLine("Stop! Going to fall!");
                }

            }



        }

        public void Print()
        {
            this.robot.PrintStatus();
        }

        private void InvalidResponse()
        {
            Console.WriteLine("invalid instruction");
        }

        private CompassDirection MatchCompassDirection(string input, CompassDirection previousDirection)
        {
            // TODO: Revisit
            if (Enum.TryParse(input, out CompassDirection compDir))
            {
                return compDir;
            }
            else
            {
                return previousDirection;
            }

        }
    }
}
