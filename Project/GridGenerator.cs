namespace GameOfLife
{
  public class GridGenerator
  {

    // List<List<bool>> Grid { get; set; }
    // int xAxis { get; set; }
    // int yAxis { get; set; }

    public static List<List<bool>> Generate()
    {

      int maxSize = 100;
      int minSize = 4;
      int xAxis = 0;
      int yAxis = 0;
      List<List<bool>> generatedGrid = new();

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
      Random rnd = new Random();
      for (int i = 1; i <= yAxis; i++)
      {
        List<bool> thisCol = new();
        for (int j = 1; j <= xAxis; j++)
        {
          int ind = rnd.Next(0, 2);
          bool val = choices[ind];
          thisCol.Add(val);
        }
        generatedGrid.Add(thisCol);
      }
      return generatedGrid;
    }

  }
}
