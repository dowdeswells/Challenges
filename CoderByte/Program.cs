using System;
using System.Globalization;
using CoderByte.CorrectPath;
using System.Linq;
using System.Threading;

namespace CoderByte
{
    class Program
    {


        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
            const string input = "interesting";
        
            bool comparison = input.ToUpper() == "INTERESTING";
            bool comparison2 = input.Equals("INTERESTING", StringComparison.OrdinalIgnoreCase);

            Console.WriteLine("These things are equal: " + comparison);
            Console.WriteLine("These other things are equal: " + comparison2);
            Console.ReadLine();




//            while (true)
//            {
//                Console.WriteLine("Type in a command string");
//                Console.WriteLine(FindPath(Console.ReadLine()));                
//            }
        }

        private static string FindPath(string stringOfMovementCommands)
        {
            var stringCommandSource = new StringPathElementSource(stringOfMovementCommands);
            var board = new SquareBoard(5);
            var pathFinder = new PathFinder(board);
            var result = pathFinder.Solve(stringCommandSource);
            var commandReporter = new StringCommandReporter();
            var report = commandReporter.ReportOn(result);
            return report;
        }
        
   
    }
}