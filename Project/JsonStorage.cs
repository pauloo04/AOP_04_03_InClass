using System.Text.Json;
using System.Xml;

namespace GameOfLife
{
    public class TempGrid
    {
        public int rows { get; set; }
        public int columns { get; set; }
        public List<List<bool>> grid { get; set; }
        public Grid ToGrid()
        {
            Grid newGrid = new()
            {
                rows = rows,
                columns = columns
            };
            List<List<Cell>> newGridgrid = [];
            foreach(List<bool> row in grid)
            {
                List<Cell> newRow = [];
                foreach(bool val in row)
                {
                    Cell newCell = new(val);
                    newRow.Add(newCell);
                }
                newGridgrid.Add(newRow);
            }
            newGrid.grid = newGridgrid;
            return newGrid;
        }
    }
    public class JsonStorage : IStorage
    {
        public string path { set; get; }
        public JsonStorage(string p)
        {
            path = p;
        }
        public TempGrid ToTempGrid(Grid grid)
        {
            TempGrid newTempGrid = new()
            {
                rows = grid.rows,
                columns = grid.columns
            };
            List<List<bool>> newGridBools = [];
            foreach(List<Cell> row in grid.grid)
            {
                List<bool> newRow = [];
                foreach(Cell val in row)
                {
                    newRow.Add(val.aliveState);
                }
                newGridBools.Add(newRow);
            }
            newTempGrid.grid = newGridBools;
            return newTempGrid;
        }
        public void LoadGrid(ref Grid grid)
        {
            string jsonString = File.ReadAllText(path);
            TempGrid tempGrid = JsonSerializer.Deserialize<TempGrid>(jsonString);
            grid = tempGrid.ToGrid();
            grid.AddNeighbors();
        }
        public void SaveGrid(Grid grid)
        {
            TempGrid tempGrid = ToTempGrid(grid);
            string jsonString = JsonSerializer.Serialize(tempGrid, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(path, jsonString);
        }
    }
}