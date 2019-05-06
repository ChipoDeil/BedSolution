using System;
using System.IO.Enumeration;
using System.Threading;

namespace BedsTask
{
    internal class Program
    {
        private const string fileName = "cells.txt";

        private static void Main(string[] args)
        {
            var reader = new FromFileCellsReader();

            var table = reader.ReadCells(fileName);

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
