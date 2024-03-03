using System.Net.Http.Headers;
using System.Xml.Resolvers;

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

            Board board = new Board();
            board.Setup();

            Robot robot = new Robot();

            Game game = new Game(board, robot);
            game.Play();


        }
    }
}



