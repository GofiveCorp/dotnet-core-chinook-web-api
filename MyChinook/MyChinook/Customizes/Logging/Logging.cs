namespace MyChinook.Customizes.Logging
{
    public class Logging : ILogging
    {
        public void Log(string message, string type)
        {
            if (type == "Error")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("ERROR - " + message);
            }
            else
            {
                if (type == "warning")
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("ERROR - " + message);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(message + " - SUCCESS");
                }

            }
        }
    }
}
