using System.Data;
using System.Text.Json;

namespace GameOfLife
{
    public class Program
    {
        public static int RangeInput(string prompt, int start, int end)
        {
            Console.WriteLine(prompt);
            while (true)
            {
                try
                {
                    string? choiceInput = Console.ReadLine();
                    int choice = int.Parse(choiceInput);
                    if (choice > start && choice <= end)
                    {
                        return choice;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Incorrect input! ({e.Message})");
                }
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Game of Life!\n");
            int choice = RangeInput("Choose a grid setup:\n1 - New randomized grid\n2 - Load grid from a file", 0, 2);
            Grid activeGrid = new();
            switch (choice)
            {
                case 1:
                {
                    activeGrid.Generate();
                    break;
                }
                case 2:
                {
                    Console.WriteLine("Enter path to the grid file: ");
                    string path = Console.ReadLine();
                    //Check if path exists
                    Storage gridFile = new(path);
                    gridFile.LoadGrid(ref activeGrid);
                    break;
                }
                default:
                {
                    Console.WriteLine("Error!");
                    break;
                }
            }
            Console.WriteLine("\nCurrent grid:");
            activeGrid.Print();
        }
    }
}