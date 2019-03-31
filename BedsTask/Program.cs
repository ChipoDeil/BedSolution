using System;
using System.Threading;

namespace BedsTask
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var table = "";

            var random = new Random();

            for (int i = 0; i < 190; i++)
            {
                for (int j = 0; j < 190; j++)
                {
                    var randomValue = random.Next(1, 100);

                    if (randomValue % 2 == 0)
                        table += '#';
                    else
                        table += '.';
                }

                table += Environment.NewLine;
            }

            /*var line = Console.ReadLine();

            while (line != string.Empty)
            {
                table += line + Environment.NewLine;
                line = Console.ReadLine();
            }*/
            Console.Write(table);
            Console.ReadLine();

            var cellResult = TextInterpreter.InterpretText(table);

            BedCounter.CellSelectedEvent += (location, type) =>
            {
                Console.SetCursorPosition(location.X, location.Y + cellResult.Count + 2);
                if (type == CellType.Bed)
                {
                    Thread.Sleep(1);
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine("{0}", type == CellType.Bed ? "#" : ".");
                Console.ForegroundColor = ConsoleColor.White;
            };

            var result = BedCounter.CalculateBeds(cellResult);

            Console.WriteLine(result);
            Console.ReadLine();
        }

    }
}
