using System.Text.Json;
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
            Console.WriteLine("(1) Enter Game");
            Console.WriteLine("(2) Save and Quit Game");
            Console.WriteLine("(3) Load Game");
            Console.WriteLine("(4) Exit Game");
            userInput = Convert.ToInt32(Console.ReadLine());
            if (userInput == 1)
            {
                GameMenu(inventory);
            }
            if (userInput == 2)
            {
                var json = JsonSerializer.Serialize(inventory);
                File.WriteAllText("inventory.json", json);
                Console.WriteLine("Your inventory has been saved!");

                var goldWriter = new StreamWriter("GoldCount.txt");
                goldWriter.WriteLine(UserCharacter.userGoldCount);
                goldWriter.Close();
                Console.WriteLine("Your gold has been saved!");

                var levelWriter = new StreamWriter("LevelCount.txt");
                levelWriter.WriteLine(UserCharacter.userLevel);
                levelWriter.Close();
                Console.WriteLine("Your level has been saved!");
            }
            if (userInput == 3)
            {
                var json = File.ReadAllText("inventory.json");
                var loadedInventory = JsonSerializer.Deserialize<List<Potions>>(json);
                Console.WriteLine("Your inventory has been loaded!");

                StreamReader goldReader = new StreamReader("GoldCount.txt");
                int loadedGoldCount = Int32.Parse(goldReader.ReadLine());
                UserCharacter.userGoldCount = loadedGoldCount;
                goldReader.Close();
                Console.WriteLine("Your gold has been loaded!");

                StreamReader levelReader = new StreamReader("LevelCount.txt");
                int loadedUserLevel = Int32.Parse(levelReader.ReadLine());
                UserCharacter.userLevel = loadedUserLevel;
                levelReader.Close();
                Console.WriteLine("Your level has been loaded!");

                UserCharacter.userHealth = ((UserCharacter.userLevel - 1) * 2) + 10;
                UserCharacter.userAttackDamage = UserCharacter.userLevel + 1;

                GameMenu(loadedInventory);
            }
            if (userInput == 4)
            {
                Console.WriteLine("Goodbye!");
                Environment.Exit(0);
            }
        }

        public static void GameMenu(List<Potions> inventory)
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("~Dragon's Hoard~");
            Console.ResetColor();
            Console.WriteLine($"\nEnter a number for one of the options below.");
            Console.WriteLine("(1) Go Into Battle");
            Console.WriteLine("(2) Visit Store");
            Console.WriteLine("(3) View Character Information and Inventory");
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
            Console.WriteLine("Go Into Battle- Engage in battle with the enemy knights.");
            Console.WriteLine("Visit Store- Spend money on items to help you in battle!");
            Console.WriteLine("Read Instructions- You are here.");
            Console.WriteLine("Return to Main Menu- Return to the main menu. From there, you can save your game and quit, or load your last save. Saving will override your last save.");
            Console.WriteLine("I am currently focused on developing the boss battle.");
            Console.WriteLine("-----------------------------------------------------------------");
            ExitProgramOption(inventory);
        }

        public static void VisitStore(List<Potions> inventory)
        {
            int userInput;
            while (true)
            {
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine($"Total Gold: {UserCharacter.userGoldCount}");
                Console.WriteLine("Welcome to the store! Select an one of the wares below to purchase.");
                Console.WriteLine("(1) Lesser Health Potion (adds 5 health)- 10 gold");
                Console.WriteLine("(2) Greater Health Potion (adds 10 health)- 20 gold");
                Console.WriteLine($"(3) Level Up Potion (gain a level)- {((UserCharacter.userLevel - 1) * 10) + 100} gold");
                //Console.WriteLine("(3) Attack Potion (adds 5 attack points for one turn)- 30 gold");
                Console.WriteLine("\n(4) Exit Store");
                Console.WriteLine("-----------------------------------------------------------------");
                userInput = Convert.ToInt32(Console.ReadLine());
                if (userInput == 1)
                {
                    if (UserCharacter.userGoldCount >= 10)
                    {
                        UserCharacter.userGoldCount = UserCharacter.userGoldCount - 10;
                        inventory.Add(Potions.LesserHealthPotion);
                        inventory.Sort();
                        foreach (var item in inventory)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough gold!");
                    }
                }
                if (userInput == 2)
                {
                    if (UserCharacter.userGoldCount >= 20)
                    {
                        UserCharacter.userGoldCount = UserCharacter.userGoldCount - 20;
                        inventory.Add(Potions.GreaterHealthPotion);
                        inventory.Sort();
                        foreach (var item in inventory)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough gold!");
                    }
                }
                // if (userInput == 3)
                // {
                //     UserCharacter.userGoldCount = UserCharacter.userGoldCount - 30;
                //     inventory.Add(Potions.AttackPotion);
                //     inventory.Sort();
                //     foreach (var item in inventory)
                //     {
                //         Console.WriteLine(item);
                //     }
                // }
                if (userInput == 3)
                {
                    if (UserCharacter.userGoldCount >= (((UserCharacter.userLevel - 1) *10) + 100))
                    {
                        UserCharacter.userGoldCount = UserCharacter.userGoldCount - (((UserCharacter.userLevel - 1) * 10) + 100);
                        inventory.Add(Potions.LevelUpPotion);
                        inventory.Sort();
                        foreach (var item in inventory)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough gold!");
                    }
                }
                if (userInput == 4)
                {
                    break;
                }
            }
            GameMenu(inventory);
        }

        public static void CharacterInformation(List<Potions> inventory)
        {
            int userInput;
            Console.WriteLine($"\nYou are a level {UserCharacter.userLevel} player.");
            Console.WriteLine($"You have {UserCharacter.userGoldCount} gold.");
            Console.WriteLine($"You have {UserCharacter.userHealth} health remaining");
            Console.WriteLine($"You currently deal {UserCharacter.userAttackDamage} damage.");
            Console.WriteLine($"You have {Inventory.DisplayLesserHealthPotions(inventory)} Lesser Health potions.");
            Console.WriteLine($"You have {Inventory.DisplayGreaterHealthPotions(inventory)} Greater Health potions.");
            Console.WriteLine($"You have {Inventory.DisplayLevelUpPotions(inventory)} Level Up potions.");
            Console.WriteLine($"\nWould you like to:");
            Console.WriteLine("(1) Use a Potion");
            Console.WriteLine("(2) Go Back to Game Menu");
            userInput = Convert.ToInt32(Console.ReadLine());
            if (userInput == 1)
            {
                if (Inventory.DisplayLesserHealthPotions(inventory) == 0 && Inventory.DisplayGreaterHealthPotions(inventory) == 0 && Inventory.DisplayLevelUpPotions(inventory) == 0)
                {
                    Console.WriteLine("You have no items to use");
                    CharacterInformation(inventory);
                }
                else
                {
                    Console.WriteLine("Which item in your inventory would you like to use?");
                    Console.WriteLine($"\n(1) Lesser Health Potion");
                    Console.WriteLine("(2) Greater Health Potion");
                    Console.WriteLine("(3) Level Up Potion");
                    Console.WriteLine("(4) Exit without using item");
                    userInput = Convert.ToInt32(Console.ReadLine());
                    if (userInput == 1)
                    {
                        UsingPotions.UseLesserHealthPotion(inventory);
                        Console.WriteLine($"Your health is now {UserCharacter.userHealth}!");
                        CharacterInformation(inventory);
                    }
                    if (userInput == 2)
                    {
                        UsingPotions.UseGreaterHealthPotion(inventory);
                        Console.WriteLine($"Your health is now {UserCharacter.userHealth}!");
                        CharacterInformation(inventory);
                    }
                    if (userInput == 3)
                    {
                        UsingPotions.UseLevelUpPotion(inventory);
                        Console.WriteLine($"Your level is now {UserCharacter.userLevel}!");
                        Console.WriteLine($"Your health is now {UserCharacter.userHealth}!");
                        Console.WriteLine($"Your attack damage is now {UserCharacter.userAttackDamage}!");
                        CharacterInformation(inventory);
                    }
                    if (userInput == 4)
                    {
                        CharacterInformation(inventory);
                    }
                }
            }
            if (userInput == 2)
            {
                GameMenu(inventory);
            }
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