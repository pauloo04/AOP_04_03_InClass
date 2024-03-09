namespace GameOfLife
{
    public class Grid : IGrid
    {
        public int rows { get; set; }
        public int columns { get; set; }
        public List<List<Cell>> grid { get; set; }
        public void Print()
        {
            foreach (List<Cell> row in grid)
            {
                foreach (Cell cell in row)
                {
                    if (cell.aliveState)
                    {
                        Console.Write("O");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
        }
        public void Generate()
        {
            int maxSize = 100;
            int minSize = 4;
            int xAxis;
            int yAxis;
            grid = [];
            do
            {
                Console.WriteLine("Chose the value between 4 and 100 to randomly generate map X axis");
                xAxis = int.Parse(Console.ReadLine());

                if (xAxis > maxSize || xAxis < minSize)
                {
                    Console.WriteLine($"Value must be between {minSize} and {maxSize}");
                }
            } while (xAxis > maxSize || xAxis < minSize);

            do
            {
                Console.WriteLine("Chose the value between 4 and 100 to randomly generate map Y axis");
                yAxis = int.Parse(Console.ReadLine());

                if (yAxis > maxSize || yAxis < minSize)
                {
                    Console.WriteLine($"Value must be between {minSize} and {maxSize}");
                }
            } while (yAxis > maxSize || yAxis < minSize);

            List<bool> choices = [true, false];
            Random rnd = new();
            for (int i = 1; i <= yAxis; i++)
            {
                List<Cell> thisRow = [];
                for (int j = 1; j <= xAxis; j++)
                {
                    int ind = rnd.Next(0, 2);
                    bool val = choices[ind];
                    Cell newCell = new(val);
                    thisRow.Add(newCell);
                }
                grid.Add(thisRow);
            }

            AddNeighbors();
        }
        public void AddNeighbors()
        {
            for (int i=0; i<grid.Count; i++)
            {
                for (int j=0; j<grid[0].Count; j++)
                {
                    if (i!=0)
                    {
                        if (j!=0)
                            grid[i][j].neighbors.Add(grid[i-1][j-1]);
                        grid[i][j].neighbors.Add(grid[i-1][j]);
                        if (j!=grid[0].Count-1)
                            grid[i][j].neighbors.Add(grid[i-1][j+1]);
                    }
                    if (j!=0)
                        grid[i][j].neighbors.Add(grid[i][j-1]);
                    if (j!=grid[0].Count-1)
                        grid[i][j].neighbors.Add(grid[i][j+1]);
                    if (i!=grid.Count-1)
                    {
                        if (j!=0)
                            grid[i][j].neighbors.Add(grid[i+1][j-1]);
                        grid[i][j].neighbors.Add(grid[i+1][j]);
                        if (j!=grid[0].Count-1)
                            grid[i][j].neighbors.Add(grid[i+1][j+1]);
                    }
                }
            }
        }
    }
}