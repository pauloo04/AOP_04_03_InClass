namespace GameOfLife
{
    public class GridOutput
    {
        public static void Print(List<List<bool>> printableGrid)
        {
            foreach(List<bool> row in printableGrid)
            {
                foreach(bool val in row)
                {
                    if(val)
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
    }
}