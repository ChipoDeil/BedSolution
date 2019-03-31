using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BedsTask
{
    internal static class TextInterpreter
    {
        public static List<List<Cell>> InterpretText(string text)
        {
            var container = new List<List<Cell>>();

            var reader = new StringReader(text);

            var currentLine = reader.ReadLine();

            int y = 0;

            while (currentLine != null)
            {
                var width = new List<Cell>();

                for (var i = 0; i < currentLine.Length; i++)
                {
                    width.Add(
                        new Cell(
                            new Location(i, y),
                            currentLine[i].Equals('#') ? CellType.Bed : CellType.Empty,
                            false));
                }

                container.Add(width);

                y++;

                currentLine = reader.ReadLine();
            }

            return container;
        }
    }
}
