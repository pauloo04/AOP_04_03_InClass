using System.Data;
using System.Text.Json;

namespace GameOfLife
{
    public class Program
    {
        public static int RangeInput(string prompt, int start, int end)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                try
                {
                    string? choiceInput = Console.ReadLine();
                    int choice = int.Parse(choiceInput);
                    if (choice > start && choice <= end)
                    {
                        return choice;
                    }
                    else
                    {
                        Console.WriteLine("Please enter one of the provided choices!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Incorrect input! ({e.Message})");
                }
            }
        }
        public static char ChoiceInput(string prompt, List<char> acceptableValues)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                try
                {
                    string? choiceInput = Console.ReadLine();
                    char choice = char.ToUpper(choiceInput[0]);
                    if (acceptableValues.Contains(choice))
                    {
                        return choice;
                    }
                    else
                    {
                        Console.WriteLine("Please enter one of the provided choices!");
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
            int setupChoice = RangeInput("Choose a grid setup:\n1 - New randomized grid\n2 - Load grid from a file", 0, 2);
            Grid activeGrid = new();
            switch (setupChoice)
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
                    JsonStorage gridFile = new(path);
                    gridFile.LoadGrid(ref activeGrid);
                    break;
                }
                default:
                {
                    Console.WriteLine("Error!");
                    break;
                }
            }
            Console.WriteLine("\nCurrent grid (Generation 0):");
            activeGrid.Print();
            
            bool running = true;
            int generation = 0;
            while(running)
            {
                Console.WriteLine("\n\nWhat would you like to do?");
                char moveChoice = ChoiceInput("\n\tN - Advance to the next generation\n\tS - Save the current grid state\n\tX - Exit the simulation", ['N', 'S', 'X']);
                switch(moveChoice)
                {
                    case 'N':
                    {
                        AutomationSimulator.NextGeneration(activeGrid);
                        generation += 1;
                        Console.WriteLine($"\nCurrent grid (Generation {generation}):");
                        activeGrid.Print();
                        break;
                    }
                    case 'S':
                    {
                        break;
                    }
                    case 'X':
                    {
                        running = false;
                        break;
                    }
                }
            }
            
        }
    }
}