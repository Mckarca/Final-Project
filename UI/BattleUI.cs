using BattleCoding;
using NormalUserInterface;
using CharacterCoding;
using ItemCoding;
namespace BattleUI
{
    public class BattleUserInterface
    {
        static bool ChallengingKing = false;
        static bool fightingGreaterKnight = false;
        public static void GoIntoBattle(List<Potions> inventory)
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("BATTLE!");
            Console.ResetColor();
            BattleMenu(inventory);
        }

        public static void BattleMenu(List<Potions> inventory)
        {
            int userInput;
            Console.WriteLine($"\nDefeated: {UserCharacter.userDefeatedCount}/5 times");
            Console.WriteLine($"Total Gold: {UserCharacter.userGoldCount}");
            Console.WriteLine($"User's Health: {UserCharacter.userHealth}");
            Console.WriteLine("\nSelect an option to engage in battle!\n");
            Console.WriteLine("(1) Attack");
            Console.WriteLine("(2) Use Item");
            Console.WriteLine("(3) Flee\n");
            Console.WriteLine("-----------------------------------------------------------------");
            try
            {
                userInput = Convert.ToInt32(Console.ReadLine());
                BattleUserSelection(userInput, inventory);
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("\nSorry, that's not an valid command! Please try again.\n");
                GoIntoBattle(inventory);
            }
        }

        public static void BattleUserSelection(int userInput, List<Potions> inventory)
        {
            if (userInput == 1)
            {
                Console.Clear();
                AttackOpponent(inventory);
            }
            if (userInput == 2)
            {
                Console.Clear();
                UseItem(inventory);
            }
            if (userInput == 3)
            {
                FleeFromBattle.ResetOpponentHealth();
                Flee(inventory);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("\nSorry, that's not an valid option! Please try again.\n");
                GoIntoBattle(inventory);
            }
        }

        public static void AttackOpponent(List<Potions> inventory)
        {
            if (UserCharacter.userLevel < 4)
            {
                ChallengeLesserKnight();
            }
            if (UserCharacter.userLevel >= 4 && UserCharacter.userLevel < 8)
            {
                ChallengeRegularKnight();
            }
            if (UserCharacter.userLevel >= 8 && UserCharacter.userLevel < 13)
            {
                ChallengeGreaterKnight();
            }
            if (UserCharacter.userLevel >= 13)
            {
                ChallengeTyrantKing();
            }
            if (DefeatInBattle.OpponentDefeatInBattle() is true)
            {
                fightingGreaterKnight = false;
                Console.WriteLine("Congratulations! You are victorious!\n");
                UserInterface.GameMenu(inventory);
            }
            else
            {
                if (DefeatInBattle.UserDefeatInBattle() is true)
                {
                    UserCharacter.userDefeatedCount++;
                    Console.Clear();
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("\nYou have been defeated!");
                    Console.WriteLine($"You have been defeated {UserCharacter.userDefeatedCount}/5 times.");
                    Console.WriteLine();
                    if (UserCharacter.userDefeatedCount < 5)
                    {
                        UserInterface.GameMenu(inventory);
                    }
                    if (UserCharacter.userDefeatedCount >= 5)
                    {
                        UserLosesGame();
                    }
                }
            }
            BattleMenu(inventory);
        }

        public static void ChallengeLesserKnight()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Time To fight!");
            Console.ResetColor();
            Console.WriteLine("\nYour opponent is the LESSER KNIGHT!");
            Console.WriteLine($"Opponent's Health: {LesserKnight.health}");
            Console.WriteLine($"User's Health: {UserCharacter.userHealth}");
            Attack.AttackLesserKnight();
            Console.WriteLine($"\nYou have dealt {UserCharacter.userAttackDamage} damage! Your opponent's health is now {LesserKnight.health}!");
            Console.WriteLine($"You have received {LesserKnight.attackDamage} damage! Your health is now {UserCharacter.userHealth}!\n");
            Console.WriteLine("-----------------------------------------------------------------");
        }

        public static void ChallengeRegularKnight()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Time To fight!");
            Console.ResetColor();
            Console.WriteLine("\nYour opponent is the REGULAR KNIGHT!");
            Console.WriteLine($"Opponent's Health: {RegularKnight.health}");
            Console.WriteLine($"User's Health: {UserCharacter.userHealth}");
            Attack.AttackRegularKnight();
            Console.WriteLine($"\nYou have dealt {UserCharacter.userAttackDamage} damage! Your opponent's health is now {RegularKnight.health}!");
            Console.WriteLine($"You have received {RegularKnight.attackDamage} damage! Your health is now {UserCharacter.userHealth}!\n");
            Console.WriteLine("-----------------------------------------------------------------");
        }

        public static void ChallengeGreaterKnight()
        {
            fightingGreaterKnight = true;
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Time To fight!");
            Console.ResetColor();
            Console.WriteLine("\nYour opponent is the GREATER KNIGHT!");
            Console.WriteLine($"Opponent's Health: {GreaterKnight.health}");
            Console.WriteLine($"User's Health: {UserCharacter.userHealth}");
            Attack.AttackGreaterKnight();
            Console.WriteLine($"\nYou have dealt {UserCharacter.userAttackDamage} damage! Your opponent's health is now {GreaterKnight.health}!");
            Console.WriteLine($"You have received {GreaterKnight.attackDamage} damage! Your health is now {UserCharacter.userHealth}!\n");
            Console.WriteLine("-----------------------------------------------------------------");
        }

        public static void ChallengeTyrantKing()
        {
            int userInput;
            if (fightingGreaterKnight == true)
            {
                Console.Clear();
                ChallengeGreaterKnight();
            }
            if (ChallengingKing == false && fightingGreaterKnight == false)
            {
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("\nWould you like to challenge the Tyrant King?");
                Console.WriteLine("\n(1) Yes");
                Console.WriteLine("(2) No\n");
                Console.WriteLine("-----------------------------------------------------------------");
                userInput = Convert.ToInt32(Console.ReadLine());
                if (userInput == 1)
                {
                    ChallengingKing = true;
                }
                if (userInput == 2)
                {
                    Console.Clear();
                    ChallengeGreaterKnight();
                }
                if (userInput != 1 && userInput != 2)
                {
                    Console.Clear();
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("\nPlease try again with some valid input.\n");
                    Console.WriteLine("-----------------------------------------------------------------");
                }
            }
            if (ChallengingKing == true)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Time To fight!");
                Console.ResetColor();
                Console.WriteLine("\nYou are fighting the TYRANT KING!");
                Console.WriteLine($"Opponent's Health: {TyrantKing.health}");
                Console.WriteLine($"User's Health: {UserCharacter.userHealth}");
                Attack.AttackTyrantKing();
                Console.WriteLine($"\nYou have dealt {UserCharacter.userAttackDamage} damage! Your opponent's health is now {TyrantKing.health}!");
                Console.WriteLine($"You have received {TyrantKing.attackDamage} damage! Your health is now {UserCharacter.userHealth}!\n");
                if (TyrantKing.health <= 0)
                {
                    ChallengingKing = false;
                    UserWins();
                }
                if (UserCharacter.userHealth <= 0)
                {
                    ChallengingKing = false;
                }
            }
        }

        public static void UseItem(List<Potions> inventory)
        {
            int userInput;
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Inventory:");
            Console.ResetColor();
            Console.WriteLine($"\nYou have {DisplayInventory.DisplayLesserHealthPotions(inventory)} Lesser Health potions.");
            Console.WriteLine($"You have {DisplayInventory.DisplayGreaterHealthPotions(inventory)} Greater Health potions.");
            Console.WriteLine($"You have {DisplayInventory.DisplayGrandestHealthPotion(inventory)} Grandest Health potions.");
            Console.WriteLine($"You have {DisplayInventory.DisplayLevelUpPotions(inventory)} Level Up potions.");
            if (DisplayInventory.DisplayLesserHealthPotions(inventory) == 0 && DisplayInventory.DisplayGreaterHealthPotions(inventory) == 0 && DisplayInventory.DisplayLevelUpPotions(inventory) == 0 && DisplayInventory.DisplayGrandestHealthPotion(inventory) == 0)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("\nYou have no items to use\n");
                GoIntoBattle(inventory);
            }
            else
            {
                Console.WriteLine("Which item in your inventory would you like to use?\n");
                Console.WriteLine("\n(1) Lesser Health Potion");
                Console.WriteLine("(2) Greater Health Potion");
                Console.WriteLine("(3) Grandest Health Potion");
                Console.WriteLine("(4) Level Up Potion");
                Console.WriteLine("\n(5) Return to battle without using item\n");
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
                        GoIntoBattle(inventory);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine("\nYou don't have any of that potion! Please select something else.");
                        UseItem(inventory);
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
                        GoIntoBattle(inventory);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine("\nYou don't have any of that potion! Please select something else.\n");
                        UseItem(inventory);
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
                        GoIntoBattle(inventory);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine("\nYou don't have any of that potion! Please select something else.\n");
                        UseItem(inventory);
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
                        GoIntoBattle(inventory);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine("\nYou don't have any of that potion! Please select something else.\n");
                        UseItem(inventory);
                    }
                }
                if (userInput == 5)
                {
                    Console.Clear();
                    GoIntoBattle(inventory);
                }
            }
        }

        public static void Flee(List<Potions> inventory)
        {
            int userInput;
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("\nAre you sure you wish to flee? Your health will not be reset.");
            Console.WriteLine("\n(1) Yes");
            Console.WriteLine("(2) No\n");
            Console.WriteLine("-----------------------------------------------------------------");
            userInput = Convert.ToInt32(Console.ReadLine());
            if (userInput == 1)
            {
                ChallengingKing = false;
                Console.Clear();
                UserInterface.GameMenu(inventory);
            }
            if (userInput == 2)
            {
                Console.Clear();
                GoIntoBattle(inventory);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("\nI'm sorry, please try entering a valid option.\n");
                Flee(inventory);
            }
        }

        public static void UserWins()
        {
            Console.Clear();
            Console.WriteLine("\nYou win!\n");
            Console.WriteLine("\nCongratualtions! You have defeated the dread Tyrant King and reclaimed your hoard of treasure!");
            Console.WriteLine("You are now free to retire peacefully back in your you cave, or continue terrorizing the kingdom, or whatever your little dragon heart desires.");
            Console.WriteLine("Thanks for playing!\n");
            Environment.Exit(0);
        }

        public static void UserLosesGame()
        {
            Console.Clear();
            Console.WriteLine("\nYou lost!\n");
            Console.WriteLine("You have been defeated five times in battle and must cut your losses. Your life is not worth your treasure.");
            Console.WriteLine("Better luck next time!\n");
            Environment.Exit(0);
        }
    }
}