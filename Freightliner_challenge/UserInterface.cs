using System.Text;

namespace Freightliner_challenge
{
    // This class takes care of input and output
    internal class UserInterface
    {
        public string GetUserInput()
        {
            return Console.ReadLine().ToUpper();
        }

        public void PromptUser()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter instruction:");
        }

        public void InvalidResponse()
        {
            Console.WriteLine();
            Console.WriteLine("invalid instruction");
        }

        public void RobotNotPlaced()
        {
            Console.WriteLine();
            Console.WriteLine("Error: First instruction must be PLACE");
        }

        public void EdgeWarning()
        {
            Console.WriteLine();
            Console.WriteLine("Stop! Going to fall!");
        }

        public void Print(string output)
        {
            Console.WriteLine();
            Console.WriteLine(output);
        }

        public void PrintStatus(List<string> status)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in status)
            {
                sb.Append(item + " ");
            }

            Console.WriteLine(sb.ToString());
        }

        public void PrintStatus(Dictionary<string, string> status)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in status)
            {
                sb.Append(item.Key + ": " + item.Value + "/n");
            }
        }
    }
}
