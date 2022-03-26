using System;
using Battle;

public class UserInterface
{
    static public void Main()
    {
        Console.WriteLine($"\nHey there! This will be a game where you play as a dragon trying to rescue its precious gold from the corrupt king.");
        Console.WriteLine("You'll have to fight your way past his various knights while you gain enough levels that you can finally defeat the evil king himself.");
        Console.WriteLine($"For now though, I don't have a lot actually built, but you're welcome to explore what's here!\n");
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
            int userInput;
            try
           {
                userInput = Convert.ToInt32(Console.ReadLine());
                GameMenuSelection(userInput);
            }
            catch
            {
                Console.WriteLine($"Sorry, that's not an authorized command! Please try again.\n");
                GameMenu();
            }
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
        if (userInput == 2 || userInput == 3 || userInput == 5)
        {
            Console.WriteLine($"\nSorry! That option is not availible at the moment. Please choose something else! :)\n");
            GameMenu();
        }
    
        if (userInput != 1 & userInput != 2 & userInput != 3 & userInput != 4 & userInput != 5)
        {
            Console.WriteLine($"Sorry, that option doesn't exist! Please try again.\n");
            GameMenu();
        }
    }

    public static void GoIntoBattle()
    {
        LesserKnight lesserKnight = new LesserKnight();
        RegularKnight regularKnight = new RegularKnight();
        GreaterKnight greaterKnight = new GreaterKnight();
        UserCharacter Dragon = new UserCharacter(10, 2);
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($"/nBATTLE!");
        Console.ResetColor();
        Console.WriteLine("Time to fight!");
        Console.WriteLine($"Dragon's health is {Dragon.userHealth}");
        Console.WriteLine($"Lesser Knight's health is {lesserKnight.health()}");
        Console.WriteLine($"Regular Knight's health is {regularKnight.health()}");
        Console.WriteLine($"Greater Knight's health is {greaterKnight.health()}");
        ExitProgramOption();
    }
    public static void ReadInstructions()
    {
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($"\nInstructions:");
        Console.ResetColor();
        Console.WriteLine("Currently, you can only access this page and the battle page of the game. New features are in development.");
        Console.WriteLine("I am currently focused on making the battle function work. The Instructions page will be updated when there are actual functions that need instructions given.");
        ExitProgramOption();
    }

    public static void ExitProgramOption()
    {
        int userInput = 0;
        Console.WriteLine($"\n\nNow then, would you like to:");
        Console.WriteLine("(1) Go back to the game menu");
        Console.WriteLine("(2) Exit program");
        try
        {
            userInput = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {}
        if (userInput == 1)
        {
            Console.WriteLine();
            GameMenu();
        }
        if (userInput == 2)
        {
            Console.WriteLine("Bye!");
        }
        if (userInput != 1 && userInput != 2)
        {
            Console.WriteLine("I'm sorry, that command was not recognized. Please try again.");
            ExitProgramOption();
        }
    }

}

