using System.Text.Json;

namespace GameOfLife
{
    public class Storage : IStorage
    {
        public string path { set; get; }
        public Storage(string p)
        {
            path = p;
        }
        public void LoadGrid(ref Grid grid)
        {
            string jsonString = File.ReadAllText(path);
            grid = JsonSerializer.Deserialize<Grid>(jsonString);
        }
        public void SaveGrid(Grid grid)
        {
            
        }
    }
}