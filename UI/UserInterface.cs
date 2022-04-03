using System;
using BattleCoding;
using BattleUI;
using CharacterCoding;
using ItemCoding;
namespace NormalUserInterface
{
    public class UserInterface
    {
        static public void Main()
        {
            List<Potions> inventory = new List<Potions>();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"\nHey there! This will be a game where you play as a dragon trying to rescue its precious gold from the corrupt king.");
            Console.WriteLine("You'll have to fight your way past his various knights while you gain enough levels that you can finally defeat the evil king himself.");
            Console.WriteLine($"For now though, I don't have a lot actually built, but you're welcome to explore what's here!\n");
            Console.WriteLine("-----------------------------------------------------------------");
            GameMenu(inventory);
        }

        public static void GameMenu(List<Potions> inventory)
        {
            Console.WriteLine("-----------------------------------------------------------------");
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
            Console.WriteLine("-----------------------------------------------------------------");
            int userInput;
            try
            {
                userInput = Convert.ToInt32(Console.ReadLine());
                GameMenuSelection(userInput, inventory);
            }
            catch
            {
                Console.WriteLine($"Sorry, that's not an authorized command! Please try again.\n");
                GameMenu(inventory);
            }
        }

        public static void GameMenuSelection(int userInput, List<Potions> inventory)
        {
            if (userInput == 1)
            {
                BattleUserInterface.GoIntoBattle(inventory);
            }
            if (userInput == 2)
            {
                VisitStore(inventory);
            }
            if (userInput == 4)
            {
                ReadInstructions(inventory);
            }
            if (userInput == 3 || userInput == 5)
            {
                Console.WriteLine($"\nSorry! That option is not availible at the moment. Please choose something else! :)\n");
                GameMenu(inventory);
            }

            if (userInput != 1 & userInput != 2 & userInput != 3 & userInput != 4 & userInput != 5)
            {
                Console.WriteLine($"Sorry, that option doesn't exist! Please try again.\n");
                GameMenu(inventory);
            }
        }

        public static void ReadInstructions(List<Potions> inventory)
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"\nInstructions:");
            Console.ResetColor();
            Console.WriteLine("Currently, you can only access this page and the battle page of the game. New features are in development.");
            Console.WriteLine("I am currently focused on making the battle function work. The Instructions page will be updated when there are actual functions that need instructions given.");
            Console.WriteLine("-----------------------------------------------------------------");
            ExitProgramOption(inventory);
        }

        public static void VisitStore(List<Potions> inventory)
        {
            //List<Potions> inventory = new List<Potions>();
            int userInput;
            while (true)
            {
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine($"Total Gold: {UserCharacter.userGoldCount}");
                Console.WriteLine("Welcome to the store! Select an one of the wares below to purchase.");
                Console.WriteLine("(1) Lesser Health Potion (adds 5 health)- 10 gold");
                Console.WriteLine("(2) Greater Health Potion (adds 10 health)- 20 gold");
                Console.WriteLine("(3) Attack Potion (adds 5 attack points for one turn)- 30 gold");
                Console.WriteLine("\n(4) Exit Store");
                Console.WriteLine("-----------------------------------------------------------------");
                userInput = Convert.ToInt32(Console.ReadLine());
                if (userInput == 1)
                {
                    UserCharacter.userGoldCount = UserCharacter.userGoldCount - 10;
                    inventory.Add(Potions.LesserHealthPotion);
                    inventory.Sort();
                    foreach(var item in inventory)
                    {
                        Console.WriteLine(item);
                    }
                }
                if (userInput == 2)
                {
                    UserCharacter.userGoldCount = UserCharacter.userGoldCount - 20;
                    inventory.Add(Potions.GreaterHealthPotion);
                    inventory.Sort();
                    foreach(var item in inventory)
                    {
                        Console.WriteLine(item);
                    }
                }
                if (userInput == 3)
                {
                    UserCharacter.userGoldCount = UserCharacter.userGoldCount - 30;
                    inventory.Add(Potions.AttackPotion);
                    inventory.Sort();
                    foreach(var item in inventory)
                    {
                        Console.WriteLine(item);
                    }
                }
                if (userInput == 4)
                {
                    break;
                   
                }
                
            }    
            GameMenu(inventory);
        }

        public static void ExitProgramOption(List<Potions> inventory)
        {
            int userInput = 0;
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"\n\nNow then, would you like to:");
            Console.WriteLine("(1) Go back to the game menu");
            Console.WriteLine("(2) Exit program");
            Console.WriteLine("-----------------------------------------------------------------");
            try
            {
                userInput = Convert.ToInt32(Console.ReadLine());
            }
            catch
            { }
            if (userInput == 1)
            {
                Console.WriteLine();
                GameMenu(inventory);
            }
            if (userInput == 2)
            {
                Console.WriteLine("Bye!");
            }
            if (userInput != 1 && userInput != 2)
            {
                Console.WriteLine("I'm sorry, that command was not recognized. Please try again.");
                ExitProgramOption(inventory);
            }
        }
    }
}
