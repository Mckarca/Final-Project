using BattleUI;
using CharacterCoding;
using ItemCoding;
using SaveAndLoadCoding;
namespace NormalUserInterface
{
    public class UserInterface
    {
        static public void Main()
        {
            List<Potions> inventory = new List<Potions>();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("\nHey there! This will be a game where you play as a dragon trying to rescue its precious gold from the corrupt king.");
            Console.WriteLine("You'll have to fight your way past his various knights while you gain enough levels that you can finally defeat the evil king himself.");
            Console.WriteLine("The game is still under heavy construction, but you're welcome to explore what's here!\n");
            MainMenu(inventory);
        }

        public static void MainMenu(List<Potions> inventory)
        {
            int userInput;
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Main Menu:");
            Console.ResetColor();
            Console.WriteLine("\nEnter a number for one of the options below.\n");
            Console.WriteLine("(1) Enter Game");
            Console.WriteLine("(2) Save and Quit Game");
            Console.WriteLine("(3) Load Game");
            Console.WriteLine("(4) Exit Game\n");
            Console.WriteLine("-----------------------------------------------------------------");
            try
            {
                userInput = Convert.ToInt32(Console.ReadLine());
                if (userInput == 1)
                {
                    GameMenu(inventory);
                }
                if (userInput == 2)
                {
                    SaveGame.SaveUserInventory(inventory);
                    SaveGame.SaveUserGold();
                    SaveGame.SaveUserLevel();
                    SaveGame.SaveUserDefeats();
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("\nYour inventory has been saved!");
                    Console.WriteLine("Your gold has been saved!");
                    Console.WriteLine("Your level has been saved!");
                    Console.WriteLine("Your defeat count has been saved!\n");
                    Console.WriteLine("-----------------------------------------------------------------");
                    Environment.Exit(0);
                }
                if (userInput == 3)
                {
                    LoadGame.LoadUserInventory();
                    LoadGame.LoadUserGold();
                    LoadGame.LoadUserLevel();
                    LoadGame.LoadUserDefeats();
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("\nYour inventory has been loaded!");
                    Console.WriteLine("Your gold has been loaded!");
                    Console.WriteLine("Your level has been loaded!");
                    Console.WriteLine("Your defeat count has been loaded!\n");
                    GameMenu(LoadGame.LoadUserInventory());
                }
                if (userInput == 4)
                {
                    Console.WriteLine("\nGoodbye!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("\nI'm sorry, that command was not recognized. Please try again.\n");
                    MainMenu(inventory);
                }
            }
            catch
            {
                Console.WriteLine("\nI'm sorry, that's not a proper command. Please try again.\n");
                MainMenu(inventory);
            }
        }

        public static void GameMenu(List<Potions> inventory)
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("~Dragon's Hoard~");
            Console.ResetColor();
            Console.WriteLine("\n(1) Go Into Battle");
            Console.WriteLine("(2) Visit Store");
            Console.WriteLine("(3) View Character Information and Inventory");
            Console.WriteLine("(4) Read Instructions");
            Console.WriteLine("(5) Return to Main Menu\n");
            Console.WriteLine("-----------------------------------------------------------------");
            int userInput;
            try
            {
                userInput = Convert.ToInt32(Console.ReadLine());
                GameMenuSelection(userInput, inventory);
            }
            catch
            {
                Console.WriteLine("\nSorry, that's not an authorized command! Please try again.\n");
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
            if (userInput == 3)
            {
                CharacterInformation(inventory);
            }
            if (userInput == 4)
            {
                ReadInstructions(inventory);
            }
            if (userInput == 5)
            {
                MainMenu(inventory);
            }
            if (userInput != 1 & userInput != 2 & userInput != 3 & userInput != 4 & userInput != 5)
            {
                Console.WriteLine("\nSorry, that option doesn't exist! Please try again.\n");
                GameMenu(inventory);
            }
        }

        public static void ReadInstructions(List<Potions> inventory)
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Instructions:");
            Console.ResetColor();
            Console.WriteLine("\nHi there! New features are in development.");
            Console.WriteLine("Go Into Battle- Engage in battle with the enemy knights.");
            Console.WriteLine("Visit Store- Spend money on items to help you in battle!");
            Console.WriteLine("Read Instructions- You are here.");
            Console.WriteLine("Return to Main Menu- Return to the main menu. From there, you can save your game and quit, or load your last save. Saving will override your last save.");
            Console.WriteLine("I am currently focused on developing the boss battle.");
            Console.WriteLine("\n Enter any button to go back to the Game Menu\n");
            Console.WriteLine("-----------------------------------------------------------------");
            string? userInput = Console.ReadLine();
            if (userInput != null)
            {
                GameMenu(inventory);
            }
        }

        public static void VisitStore(List<Potions> inventory)
        {
            int userInput;
            while (true)
            {
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Store:");
                Console.ResetColor();
                Console.WriteLine($"\nTotal Gold: {UserCharacter.userGoldCount}\n");
                Console.WriteLine("Welcome to the store! Select one of the wares below to purchase.\n");
                Console.WriteLine("(1) Lesser Health Potion (regain 5 health)- 10 gold");
                Console.WriteLine("(2) Greater Health Potion (regain 10 health)- 20 gold");
                Console.WriteLine($"(3) Level Up Potion (gain a level)- {((UserCharacter.userLevel - 1) * 10) + 100} gold");
                Console.WriteLine("\n(4) Exit Store\n");
                Console.WriteLine("-----------------------------------------------------------------");
                userInput = Convert.ToInt32(Console.ReadLine());
                if (userInput == 1)
                {
                    if (UserCharacter.userGoldCount >= 10)
                    {
                        AddToInventory.AddLesserHealthPotion(inventory);
                        Console.WriteLine("\nInventory List:\n");
                        foreach (var item in inventory)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("\nYou don't have enough gold!\n");
                    }
                }
                if (userInput == 2)
                {
                    if (UserCharacter.userGoldCount >= 20)
                    {
                        AddToInventory.AddGreaterHealthPotion(inventory);
                        Console.WriteLine("\nInventory List:\n");
                        foreach (var item in inventory)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("\nYou don't have enough gold!\n");
                    }
                }
                if (userInput == 3)
                {
                    if (UserCharacter.userGoldCount >= (((UserCharacter.userLevel - 1) * 10) + 100))
                    {
                        AddToInventory.AddLevelUpPotion(inventory);
                        Console.WriteLine("\nInventory List:\n");
                        foreach (var item in inventory)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("\nYou don't have enough gold!\n");
                    }
                }
                if (userInput == 4)
                {
                    break;
                }
                if (userInput != 1 & userInput != 2 & userInput != 3 & userInput != 4)
                {
                    Console.WriteLine("\nI'm sorry, please try again with a valid option.\n");
                }
            }
            GameMenu(inventory);
        }

        public static void CharacterInformation(List<Potions> inventory)
        {
            int userInput;
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Character Information and Inventory:");
            Console.ResetColor();
            Console.WriteLine($"\nYou are a level {UserCharacter.userLevel} player.");
            Console.WriteLine($"You have {UserCharacter.userGoldCount} gold.");
            Console.WriteLine($"You have {UserCharacter.userHealth} health remaining.");
            Console.WriteLine($"You currently deal {UserCharacter.userAttackDamage} damage.");
            Console.WriteLine($"You have been defeated {UserCharacter.userDefeatedCount}/5 times.\n");
            Console.WriteLine($"You have {DisplayInventory.DisplayLesserHealthPotions(inventory)} Lesser Health potions.");
            Console.WriteLine($"You have {DisplayInventory.DisplayGreaterHealthPotions(inventory)} Greater Health potions.");
            Console.WriteLine($"You have {DisplayInventory.DisplayLevelUpPotions(inventory)} Level Up potions.");
            Console.WriteLine("\nWould you like to:\n");
            Console.WriteLine("(1) Use a Potion");
            Console.WriteLine("(2) Go Back to Game Menu\n");
            Console.WriteLine("-----------------------------------------------------------------");
            userInput = Convert.ToInt32(Console.ReadLine());
            if (userInput == 1)
            {
                UsePotion(inventory);
            }
            if (userInput == 2)
            {
                GameMenu(inventory);
            }
            else
            {
                Console.WriteLine("\nPlease try again with one of the availible commands.\n");
                CharacterInformation(inventory);
            }
        }

        public static void UsePotion(List<Potions> inventory)
        {
            int userInput;
            if (DisplayInventory.DisplayLesserHealthPotions(inventory) == 0 && DisplayInventory.DisplayGreaterHealthPotions(inventory) == 0 && DisplayInventory.DisplayLevelUpPotions(inventory) == 0)
            {
                Console.WriteLine("\nYou have no items to use!\n");
                CharacterInformation(inventory);
            }
            else
            {
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("\nWhich item in your inventory would you like to use?");
                Console.WriteLine("\n(1) Lesser Health Potion");
                Console.WriteLine("(2) Greater Health Potion");
                Console.WriteLine("(3) Level Up Potion");
                Console.WriteLine("(4) Exit without using item\n");
                Console.WriteLine("-----------------------------------------------------------------");
                userInput = Convert.ToInt32(Console.ReadLine());
                if (userInput == 1)
                {
                    if (DisplayInventory.DisplayLesserHealthPotions(inventory) != 0)
                    {
                        UsingPotions.UseLesserHealthPotion(inventory);
                        Console.WriteLine($"\nYour health is now {UserCharacter.userHealth}!\n");
                        CharacterInformation(inventory);
                    }
                    else
                    {
                        Console.WriteLine("\nYou don't have any of that potion! Please select something else.\n");
                        UsePotion(inventory);
                    }
                }
                if (userInput == 2)
                {
                    if (DisplayInventory.DisplayGreaterHealthPotions(inventory) != 0)
                    {
                        UsingPotions.UseGreaterHealthPotion(inventory);
                        Console.WriteLine($"\nYour health is now {UserCharacter.userHealth}!\n");
                        CharacterInformation(inventory);
                    }
                    else
                    {
                        Console.WriteLine("\nYou don't have any of that potion! Please select something else.\n");
                        UsePotion(inventory);
                    }
                }
                if (userInput == 3)
                {
                    if (DisplayInventory.DisplayLevelUpPotions(inventory) != 0)
                    {
                        UsingPotions.UseLevelUpPotion(inventory);
                        Console.WriteLine($"\nYour level is now {UserCharacter.userLevel}!");
                        Console.WriteLine($"Your health is now {UserCharacter.userHealth}!");
                        Console.WriteLine($"Your attack damage is now {UserCharacter.userAttackDamage}!\n");
                        CharacterInformation(inventory);
                    }
                    else
                    {
                        Console.WriteLine("\nYou don't have any of that potion! Please select something else.\n");
                        UsePotion(inventory);
                    }
                }
                if (userInput == 4)
                {
                    CharacterInformation(inventory);
                }
            }
        }
    }
}