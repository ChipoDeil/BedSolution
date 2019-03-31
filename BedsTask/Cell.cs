namespace BedsTask
{
    public class Cell
    {
        public Location Location { get; }
        public CellType Type { get; }
        public bool Checked { get; private set; }

        public Cell(Location location, CellType type, bool @checked)
        {
            Location = location;
            Type = type;
            Checked = @checked;
        }

        internal void Check()
        {
            Checked = true;
        }
    }
}
