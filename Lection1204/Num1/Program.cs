namespace Num1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                var fileIndex = args.ToList().IndexOf("-filename");
                if (fileIndex > -1)
                {
                    var filename = args[fileIndex + 1];
                    Console.WriteLine(File.ReadAllText(filename));
                }
                var showHelp = args.ToList().Any(arg => arg == "-h" || arg == "-help");
                if (showHelp)
                    Console.WriteLine("help ... me ... ");
            }
        }
    }
}
