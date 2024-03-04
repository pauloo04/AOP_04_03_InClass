namespace GameOfLife
{
    public interface IStorage
    {
        public string path { set; get; }
        public void LoadGrid(ref Grid grid);
        public void SaveGrid(Grid grid);
    }
}