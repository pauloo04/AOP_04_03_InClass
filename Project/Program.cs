﻿using System.Data;
using System.Text.Json;

namespace GameOfLife
{
    public class Grid
    {
        public int rows { get; set; }
        public int columns { get; set; }
        public List<List<bool>> grid { get; set; }
    }
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
                    Console.WriteLine("Incorrect input!");
                }
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Game of Life!\n");
            int choice = RangeInput("Choose a grid setup:\n1 - New randomized grid\n2 - Load grid from a file", 0, 2);
            List<List<bool>> activeGrid;
            activeGrid = GridReader.Read();
            // switch (choice)
            // {
            //     case 1:
            //     {
            //         //Generate random grid
            //         break;
            //     }
            //     case 2:
            //     {
            //         break;
            //     }
            //     default:
            //     {
            //         Console.WriteLine("Error!");
            //         ;
            //     }
            // }
            Console.WriteLine("\nCurrent grid:");
            GridOutput.Print(activeGrid);
        }
    }
}