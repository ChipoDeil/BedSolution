using System;

namespace BedsTask
{
    internal class RandomCellsReader
    {
        public string ReadCells(string fileName = "")
        {
            var table = "";

            var random = new Random();

            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    var randomValue = random.Next(1, 100);

                    if (randomValue % 2 == 0)
                        table += '#';
                    else
                        table += '.';
                }

                table += Environment.NewLine;
            }

            return table;
        }
    }
}
