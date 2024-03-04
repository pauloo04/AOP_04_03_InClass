namespace GameOfLife
{
    public interface IGrid
    {
        public int rows { get; set; }
        public int columns { get; set; }
        public List<List<Cell>> grid { get; set; }
        public void Print();
        public void Generate();
    }
}