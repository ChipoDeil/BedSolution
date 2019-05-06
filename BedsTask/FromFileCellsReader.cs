using System;
using System.IO;

namespace BedsTask
{
    internal class FromFileCellsReader
    {
        public string ReadCells(string fileName)
        {
            using (var streamReader = new StreamReader(fileName))
            {
                var table = "";

                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    table += line;
                    table += Environment.NewLine;
                }

                return table;
            }
        }
    }
}
