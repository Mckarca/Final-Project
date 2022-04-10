using System;
using System.Text.Json;
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
            Console.WriteLine($"The game is still under heavy construction, but you're welcome to explore what's here!\n");
            Console.WriteLine("-----------------------------------------------------------------");
            MainMenu(inventory);

        }

        public static void MainMenu(List<Potions> inventory)
        {
            int userInput;
            //int userInput1;
            //PracticeInt money = new PracticeInt();
            //Console.WriteLine("Enter a money amount:");
            //userInput1 = Convert.ToInt32(Console.ReadLine());
            //money.practiceInt = userInput1;
            
            Console.WriteLine("(1) Enter Game");
            Console.WriteLine("(2) Save Inventory and Quit Game");
            Console.WriteLine("(3) Load inventory");
            userInput = Convert.ToInt32(Console.ReadLine());
            if (userInput == 1)
            {
                GameMenu(inventory);
            }

            if (userInput == 2)
            {
                var json = JsonSerializer.Serialize(inventory);
                File.WriteAllText("inventory.json", json);
                Console.WriteLine("You're inventory has been saved!");

                var json1 = JsonSerializer.Serialize(UserCharacter.userGoldCount);
                File.WriteAllText("userGoldCount.json", json1);
                Console.WriteLine("You're money has been saved!");

            }
            if (userInput == 3)
            {
                var json = File.ReadAllText("inventory.json");
                Console.WriteLine(json);
                var loadedInventory = JsonSerializer.Deserialize<List<Potions>>(json);
                Console.WriteLine(loadedInventory);
                //GameMenu(loadedInventory);

                //var json1 = File.ReadAllText("userGoldCount.json");
                //Console.WriteLine(json1);
                //var loadedUserGoldCount = JsonSerializer.Deserialize<UserCharacter>(json1);
                ///Console.WriteLine(loadedUserGoldCount);//need to pass loadedGoldCount in
                GameMenu(loadedInventory);
            }
        }

        public static void GameMenu(List<Potions> inventory)
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("~Dragon's Hoard~");
            Console.ResetColor();
            Console.WriteLine($"\nEnter a number for one of the options below (all but option 3 lead somewhere).");
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
            if (userInput == 5)
            {
                MainMenu(inventory);
            }
            if (userInput == 3)
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
            Console.WriteLine("Hi there! New features are in development.");
            Console.WriteLine("All option on the game menu except for (3) View Character Information lead somewhere. ");
            Console.WriteLine("Go Into Battle- Engage in battle with the enemy knights. So far, you can attack them, but are unable to leave any damage. Selecting 'Use Item' will print out your inventory, but items currently have no function.");
            Console.WriteLine("Visit Store- Spend money on items to help you in battle! (Currently, no items have any actual function).");
            Console.WriteLine("Read Instructions- You are here.");
            Console.WriteLine("Return to Main Menu- Return to the main menu. From there, you can save your inventory and quit the game, or load your last inventory. Saving will override your last save.");
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
                    foreach (var item in inventory)
                    {
                        Console.WriteLine(item);
                    }
                }
                if (userInput == 2)
                {
                    UserCharacter.userGoldCount = UserCharacter.userGoldCount - 20;
                    inventory.Add(Potions.GreaterHealthPotion);
                    inventory.Sort();
                    foreach (var item in inventory)
                    {
                        Console.WriteLine(item);
                    }
                }
                if (userInput == 3)
                {
                    UserCharacter.userGoldCount = UserCharacter.userGoldCount - 30;
                    inventory.Add(Potions.AttackPotion);
                    inventory.Sort();
                    foreach (var item in inventory)
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
