namespace GameOfLife
{
  public class GridGenerator
  {

    List<list<bool>> Grid { get; set; }
    int xAxis { get; set; }
    int yAxis { get; set; }

    public void Grid( List<list<bool>> Grid, int xAxis, int yAxis)
    {

      int maxSize = 100;
      int minSize = 4;

      List<List<bool>> Grid;

      do
      {
        Console.WriteLine("Chose the value between 4 and 100 to randomly generate map X axis");
        int xAxis = int.Parse(Console.ReadLine());

        if (xAxis > maxSize || xAxis < minSize)
        {
          Console.WriteLine($"Value must bve between {minSize} and {maxSize}");
        }
      } while (xAxis > maxSize || xAxis < minSize);

      do
      {
        Console.WriteLine("Chose the value between 4 and 100 to randomly generate map Y axis");
        int yAxis = int.Parse(Console.ReadLine());

        if (yAxis > maxSize || yAxis < minSize)
        {
          Console.WriteLine($"Value must bve between {minSize} and {maxSize}");
        }
      } while (yAxis > maxSize || yAxis < minSize)


       List<bool> choices = [true, false];°
       Random rnd = new Random();

       

        
        while(i=1; i<=yAxis; i++)
        {
            List<bool> thisCol;
            while(j=1; j<=xAxis; j++)
            {
                int i = rnd.Next(0, 2);
                bool val = choices[i];
                thisCol.Add(val);
            }
            grid.Add(thisCol);
        }


    }

  }


}
