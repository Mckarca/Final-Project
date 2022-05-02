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
            MainMenu(inventory);
        }

        public static void MainMenu(List<Potions> inventory)
        {
            int userInput;
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Main Menu:");
            Console.ResetColor();
            Console.WriteLine("\nEnter a number for one of the options below.\n");
            Console.WriteLine("(1) New Game");
            Console.WriteLine("(2) Load Game");
            Console.WriteLine("(3) Save and Exit Game\n");
            Console.WriteLine("-----------------------------------------------------------------");
            try
            {
                userInput = Convert.ToInt32(Console.ReadLine());
                if (userInput == 4)//For testing purposes
                {
                    Console.Clear();
                    GameMenu(inventory);
                }
                if (userInput == 1)
                {
                    if (File.Exists("GoldCount.txt"))
                    {
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine("\nAre you sure? You will be unable to recover any previously saved data.\n");
                        Console.WriteLine("(1) Yes, Restart Game");
                        Console.WriteLine("(2) No, Return to Main Menu\n");
                        Console.WriteLine("-----------------------------------------------------------------");
                        userInput = Convert.ToInt32(Console.ReadLine());
                        if (userInput == 1)
                        {
                            DefaultCharacterSettings.ResetCharacter(inventory);
                            Console.Clear();
                            GameMenu(inventory);
                        }
                        if (userInput == 2)
                        {
                            Console.Clear();
                            MainMenu(inventory);
                        }
                    }
                    else
                    {
                        Console.Clear();
                        DefaultCharacterSettings.ResetCharacter(inventory);
                        GameMenu(inventory);
                    }
                }
                if (userInput == 2)
                {
                    LoadGame.LoadUserInventory();
                    LoadGame.LoadUserGold();
                    LoadGame.LoadUserLevel();
                    LoadGame.LoadUserDefeats();
                    Console.Clear();
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("\nYour inventory has been loaded!");
                    Console.WriteLine($"You have {UserCharacter.userGoldCount} gold!");
                    Console.WriteLine($"You are level {UserCharacter.userLevel}!");
                    Console.WriteLine($"You have been defeated {UserCharacter.userDefeatedCount} times!\n");
                    GameMenu(LoadGame.LoadUserInventory());
                }
                if (userInput == 3)
                {
                    SaveGame.SaveUserInventory(inventory);
                    SaveGame.SaveUserGold();
                    SaveGame.SaveUserLevel();
                    SaveGame.SaveUserDefeats();
                    Console.Clear();
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("\nYour inventory has been saved!");
                    Console.WriteLine("Your gold has been saved!");
                    Console.WriteLine("Your level has been saved!");
                    Console.WriteLine("Your defeat count has been saved!\n");
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("\nGoodbye!\n");
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("\nI'm sorry, that command was not recognized. Please try again.\n");
                    MainMenu(inventory);
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------");
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
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("\nSorry, that's not an authorized command! Please try again.\n");
                GameMenu(inventory);
            }
        }

        public static void GameMenuSelection(int userInput, List<Potions> inventory)
        {
            if (userInput == 1)
            {
                Console.Clear();
                BattleUserInterface.GoIntoBattle(inventory);
            }
            if (userInput == 2)
            {
                Console.Clear();
                VisitStore(inventory);
            }
            if (userInput == 3)
            {
                Console.Clear();
                CharacterInformation(inventory);
            }
            if (userInput == 4)
            {
                Console.Clear();
                ReadInstructions(inventory);
            }
            if (userInput == 5)
            {
                MainMenu(inventory);
            }
            if (userInput != 1 & userInput != 2 & userInput != 3 & userInput != 4 & userInput != 5)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------");
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
            Console.WriteLine("\nBrief overview of game:\n");
            Console.WriteLine("You are a dragon and the evil Tyrant King has stolen your precious hoard of treasure. Fight to recover it!");
            Console.WriteLine("There are four levels of opponents: Lesser Knights, Regular Knights, Greater Knights, and the Tyrant King himself.");
            Console.WriteLine("You encounter harder opponents as your level increases.");
            Console.WriteLine("     Lesser Knight: Level 1-3");
            Console.WriteLine("     Regular Knight: Level 4-7");
            Console.WriteLine("     Greater Knight: Level 8-12");
            Console.WriteLine("     Tyrant King: Availible to challenge after you reach level 13");
            Console.WriteLine("To win the game, defeat the Tyrant King and reclaim your treasure!");
            Console.WriteLine("You lose the game if you are defeated 5 times over the course of the game.");
            Console.WriteLine("Keep an eye on your health and buy health potions when needed.\n");
            Console.WriteLine("\nBrief overview of the options on the Game Menu:\n");
            Console.WriteLine("Go Into Battle- Engage in battle with the enemy knights.");
            Console.WriteLine("Visit Store- Spend money on items to help you in battle!");
            Console.WriteLine("     There are three different levels of health potions. Prices and amount of health restored are listed in the store.");
            Console.WriteLine("     Level Up Potions are how you gain levels. With each level you gain, your attack damage and health increases.");
            Console.WriteLine("     The cost of Level Up Potions also increases with each level you gain, but the cost of health potions remains the same.");
            Console.WriteLine("     You earn gold from the knights that you defeat.");
            Console.WriteLine("View Character Information and Inventory- Look at your stats and inventory. You can also use potions from this screen.");
            Console.WriteLine("Read Instructions- You are here!");
            Console.WriteLine("Return to Main Menu- Return to the main menu. From there, you can save your game and quit, or load your last save. Saving will override your last save.\n");
            Console.WriteLine("\nBrief overview of battle system:\n");
            Console.WriteLine("When you go into battle, you will have three options: Attack, Use Item, and Flee.");
            Console.WriteLine("When you attack, you deal a certain amount of damage to your enemy, and your enemy deals damage to you.");
            Console.WriteLine("If you die, your health and your opponents health reset and your defeat counter goes up.");
            Console.WriteLine("If you and your opponent both reach 0 health on the same turn, you will win the round and earn the gold.");
            Console.WriteLine("However, you will need to regain some health, as the next time you are attacked you will be defeated.");
            Console.WriteLine("If you flee, your health stays the same, but your opponent's health resets. Your defeat counter remains the same.");
            Console.WriteLine("Use items to regain health and level up from the battle menu of the Character Information screen.");
            Console.WriteLine("\n Enter any button to go back to the Game Menu\n");
            Console.WriteLine("-----------------------------------------------------------------");
            string? userInput = Console.ReadLine();
            if (userInput != null)
            {
                Console.Clear();
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
                Console.WriteLine("Current inventory:");
                Console.WriteLine($"{DisplayInventory.DisplayLesserHealthPotions(inventory)} Lesser Health potions.");
                Console.WriteLine($"{DisplayInventory.DisplayGreaterHealthPotions(inventory)} Greater Health potions.");
                Console.WriteLine($"{DisplayInventory.DisplayGrandestHealthPotion(inventory)} Grandest Health potions.");
                Console.WriteLine($"{DisplayInventory.DisplayLevelUpPotions(inventory)} Level Up potions.\n");
                Console.WriteLine("\nWelcome to the store! Select one of the wares below to purchase.\n");
                Console.WriteLine("(1) Lesser Health Potion (regain 5 health)- 10 gold");
                Console.WriteLine("(2) Greater Health Potion (regain 10 health)- 20 gold");
                Console.WriteLine("(3) Grandest Health Potion (regain 20 health)- 30 gold");
                Console.WriteLine($"(4) Level Up Potion (gain a level)- {((UserCharacter.userLevel - 1) * 10) + 100} gold");
                Console.WriteLine("\n(5) Exit Store\n");
                Console.WriteLine("-----------------------------------------------------------------");
                userInput = Convert.ToInt32(Console.ReadLine());
                if (userInput == 1)
                {
                    if (UserCharacter.userGoldCount >= 10)
                    {
                        AddToInventory.AddLesserHealthPotion(inventory);
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine("\nYou don't have enough gold!\n");
                    }
                }
                if (userInput == 2)
                {
                    if (UserCharacter.userGoldCount >= 20)
                    {
                        AddToInventory.AddGreaterHealthPotion(inventory);
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine("\nYou don't have enough gold!\n");
                    }
                }
                if (userInput == 3)
                {
                    if (UserCharacter.userGoldCount >= 30)
                    {
                        AddToInventory.AddGrandestHealthPotion(inventory);
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine("\nYou don't have enough gold!\n");
                    }
                }
                if (userInput == 4)
                {
                    if (UserCharacter.userGoldCount >= (((UserCharacter.userLevel - 1) * 10) + 100))
                    {
                        AddToInventory.AddLevelUpPotion(inventory);
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine("\nYou don't have enough gold!\n");
                    }
                }
                if (userInput == 5)
                {
                    Console.Clear();
                    break;
                }
                if (userInput != 1 & userInput != 2 & userInput != 3 & userInput != 4 & userInput != 5)
                {
                    Console.Clear();
                    Console.WriteLine("-----------------------------------------------------------------");
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
            Console.WriteLine($"You have {DisplayInventory.DisplayGrandestHealthPotion(inventory)} Grandest Health potions.");
            Console.WriteLine($"You have {DisplayInventory.DisplayLevelUpPotions(inventory)} Level Up potions.");
            Console.WriteLine("\nWould you like to:\n");
            Console.WriteLine("(1) Use a Potion");
            Console.WriteLine("(2) Go Back to Game Menu\n");
            Console.WriteLine("-----------------------------------------------------------------");
            userInput = Convert.ToInt32(Console.ReadLine());
            if (userInput == 1)
            {
                Console.Clear();
                UsePotion(inventory);
            }
            if (userInput == 2)
            {
                Console.Clear();
                GameMenu(inventory);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("\nPlease try again with one of the availible commands.\n");
                CharacterInformation(inventory);
            }
        }

        public static void UsePotion(List<Potions> inventory)
        {
            int userInput;
            if (DisplayInventory.DisplayLesserHealthPotions(inventory) == 0 && DisplayInventory.DisplayGreaterHealthPotions(inventory) == 0 && DisplayInventory.DisplayGrandestHealthPotion(inventory) == 0 && DisplayInventory.DisplayLevelUpPotions(inventory) == 0)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("\nYou have no items to use!\n");
                CharacterInformation(inventory);
            }
            else
            {
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("\nWhich item in your inventory would you like to use?");
                Console.WriteLine("\n(1) Lesser Health Potion");
                Console.WriteLine("(2) Greater Health Potion");
                Console.WriteLine("(3) Grandest Health Potion");
                Console.WriteLine("(4) Level Up Potion");
                Console.WriteLine("\n(5) Exit without using item\n");
                Console.WriteLine("-----------------------------------------------------------------");
                userInput = Convert.ToInt32(Console.ReadLine());
                if (userInput == 1)
                {
                    if (DisplayInventory.DisplayLesserHealthPotions(inventory) != 0)
                    {
                        UsingPotions.UseLesserHealthPotion(inventory);
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine($"\nYour health is now {UserCharacter.userHealth}!\n");
                        CharacterInformation(inventory);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine("\nYou don't have any of that potion! Please select something else.\n");
                        UsePotion(inventory);
                    }
                }
                if (userInput == 2)
                {
                    if (DisplayInventory.DisplayGreaterHealthPotions(inventory) != 0)
                    {
                        UsingPotions.UseGreaterHealthPotion(inventory);
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine($"\nYour health is now {UserCharacter.userHealth}!\n");
                        CharacterInformation(inventory);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine("\nYou don't have any of that potion! Please select something else.\n");
                        UsePotion(inventory);
                    }
                }
                if (userInput == 3)
                {
                    if (DisplayInventory.DisplayGrandestHealthPotion(inventory) != 0)
                    {
                        UsingPotions.UseGrandestHealthPotion(inventory);
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine($"\nYour health is now {UserCharacter.userHealth}!\n");
                        CharacterInformation(inventory);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine("\nYou don't have any of that potion! Please select something else.\n");
                        UsePotion(inventory);
                    }
                }
                if (userInput == 4)
                {
                    if (DisplayInventory.DisplayLevelUpPotions(inventory) != 0)
                    {
                        UsingPotions.UseLevelUpPotion(inventory);
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine($"\nYour level is now {UserCharacter.userLevel}!");
                        Console.WriteLine($"Your health is now {UserCharacter.userHealth}!");
                        Console.WriteLine($"Your attack damage is now {UserCharacter.userAttackDamage}!\n");
                        CharacterInformation(inventory);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine("\nYou don't have any of that potion! Please select something else.\n");
                        UsePotion(inventory);
                    }
                }
                if (userInput == 5)
                {
                    Console.Clear();
                    CharacterInformation(inventory);
                }
            }
        }
    }
}