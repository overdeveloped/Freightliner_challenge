using System.Configuration;

namespace Freightliner_challenge
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(" ___       _          _          ___                     _         ___                   ");
            Console.WriteLine(@"| _ \ ___ | |__  ___ | |_       | _ ) ___  __ _  _ _  __| |       / __| __ _  _ __   ___ ");
            Console.WriteLine(@"|   // _ \|  _ \/ _ \|  _|      | _ \/ _ \/ _` || '_|/ _` |      | (_ |/ _` || '  \ / -_)");
            Console.WriteLine(@"|_|_\\___/|____/\___/ \__|      |___/\___/\__/_||_|  \__/_|       \___|\__/_||_|_|_|\___|");

            int boardWidth = 0;
            int boardHeight = 0;

            // Load the board dimetions from the config file
            try
            {
                boardWidth = Convert.ToInt32(ConfigurationManager.AppSettings["boardWidth"]);
                boardHeight = Convert.ToInt32(ConfigurationManager.AppSettings["boardHeight"]);
            }
            catch
            {
                Console.WriteLine("Problem with config. Setting default board size of 3 x 3");
                boardWidth = 3;
                boardHeight = 3;
            }

            // Instantiate the components of the game
            Board board = new Board(boardWidth, boardHeight);
            UserInterface userInterface = new UserInterface();
            Robot robot = new Robot(userInterface);
            Game game = new Game(board, robot, userInterface);
            game.Play();
        }
    }
}



