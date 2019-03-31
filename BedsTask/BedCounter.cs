using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BedsTask
{
    internal static class BedCounter
    {
        private static List<List<Cell>> _table = null;
        private static Location _lastChecked = new Location(0, 0);

        public static int CalculateBeds(List<List<Cell>> table)
        {
            _table = table;

            if(_table == null)
                throw new ArgumentException();

            var unCheckedLocation = FindUncheckedLocation();

            var bedCount = 0;

            while (unCheckedLocation != null)
            {
                CheckCell(unCheckedLocation);

                unCheckedLocation = FindUncheckedLocation();

                bedCount++;
            }

            return bedCount;
        }

        private static Location FindUncheckedLocation()
        {
            for (var i = _lastChecked.Y; i < _table.Count; i++)
            {
                for (var j = 0; j < _table[i].Count; j++)
                {
                    if (_table[i][j].Type == CellType.Bed && !_table[i][j].Checked)
                    {
                        _lastChecked = _table[i][j].Location;
                        return _lastChecked;
                    }
                }
            }

            return null;
        }

        private static void CheckCell(Location location)
        {
            var currentCell = _table[location.Y][location.X];

            CellSelectedEvent?.Invoke(location, currentCell.Type);

            if (currentCell.Type != CellType.Bed || currentCell.Checked)
                return;

            _table[location.Y][location.X].Check();

            if (location.X != 0)
            {
                CheckCell(new Location(location.X - 1, location.Y));
            }

            if (location.Y != 0)
            {
                CheckCell(new Location(location.X, location.Y - 1));
            }

            if (location.Y < _table.Count - 1)
            {
                CheckCell(new Location(location.X, location.Y + 1));
            }

            if (location.X < _table.FirstOrDefault().Count - 1)
            {
                CheckCell(new Location(location.X + 1, location.Y));
            }
        }

        public delegate void SelectedCell(Location location, CellType type);

        public static event SelectedCell CellSelectedEvent;
    }
}
