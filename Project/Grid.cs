namespace GameOfLife
{
    public class Grid : IGrid
    {
        public int rows { get; set; }
        public int columns { get; set; }
        public List<List<bool>> grid { get; set; }
        public void Print()
        {
            foreach (List<bool> row in grid)
            {
                foreach (bool val in row)
                {
                    if (val)
                    {
                        Console.Write("0");
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
                List<bool> thisCol = [];
                for (int j = 1; j <= xAxis; j++)
                {
                    int ind = rnd.Next(0, 2);
                    bool val = choices[ind];
                    thisCol.Add(val);
                }
                grid.Add(thisCol);
            }
        }
    }
}