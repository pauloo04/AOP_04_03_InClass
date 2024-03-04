using System.Data;
using System.Text.Json;

namespace GameOfLife
{
    public class GridReader
    {
        public static List<List<bool>> Read()
        {
            Console.WriteLine("Enter path to the grid file: ");
            string path = Console.ReadLine();
            //Check if path exists
            string jsonString = File.ReadAllText(path);
            Grid readGrid = JsonSerializer.Deserialize<Grid>(jsonString);

            return readGrid.grid;
        }
    }
}