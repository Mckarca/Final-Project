using System;
using Backend;

public class UserInterface
{
    static public void Main()
    {
        GameMenu();
    }

    public static void GameMenu()
        {
            
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("~Dragon's Hoard~");
            Console.ResetColor();
            Console.WriteLine($"\nEnter a number for one of the options below (only 1 and 4 currently lead anywhere).");
            Console.WriteLine("(1) Go Into Battle");
            Console.WriteLine("(2) Visit Store");
            Console.WriteLine("(3) View Character Information");
            Console.WriteLine("(4) Read Instructions");
            Console.WriteLine("(5) Return to Main Menu");
            int userInput = Convert.ToInt32(Console.ReadLine());
            GameMenuSelection(userInput);
        }

    public static void GameMenuSelection(int userInput)
    {
        if (userInput == 1)
        {
            GoIntoBattle();
        }
        if (userInput == 4)
        {
            ReadInstructions();
        }
        if (userInput != 1 && userInput != 4)
        {
            Console.WriteLine($"Sorry! That option is not availible at the moment. Please choose something else! :)\n");
            GameMenu();
        }
    }

    public static void GoIntoBattle()
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("BATTLE!");
        Console.ResetColor();
        Console.WriteLine("Time to fight!");
    }

    public static void ReadInstructions()
    {
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("Instructions:");
        Console.ResetColor();
        Console.WriteLine("Currently, you can only access this page of the game. New features are in development. I am currently focused on making the battle function work.");
    }

}

