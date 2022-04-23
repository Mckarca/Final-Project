using BattleCoding;
using NormalUserInterface;
using CharacterCoding;
using ItemCoding;
namespace BattleUI
{
    public class BattleUserInterface
    {
        static bool ChallengingKing = false;
        public static void GoIntoBattle(List<Potions> inventory)
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("BATTLE! Time To fight!");
            Console.ResetColor();
            BattleMenu(inventory);
        }

        public static void BattleMenu(List<Potions> inventory)
        {
            int userInput;
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

                Console.WriteLine("\nSorry, that's not an valid command! Please try again.\n");
                GoIntoBattle(inventory);
            }
        }

        public static void BattleUserSelection(int userInput, List<Potions> inventory)
        {
            if (userInput == 1)
            {
                AttackOpponent(inventory);
            }
            if (userInput == 2)
            {
                UseItem(inventory);
            }
            if (userInput == 3)
            {
                FleeFromBattle.ResetOpponentHealth();
                Flee(inventory);
            }
            else
            {
                Console.WriteLine("\nSorry, that's not an valid option! Please try again.\n");
                GoIntoBattle(inventory);
            }
        }

        public static void AttackOpponent(List<Potions> inventory)
        {
            if (UserCharacter.userLevel < 5)
            {
                ChallengeLesserKnight();
            }
            if (UserCharacter.userLevel >= 5 && UserCharacter.userLevel < 10)
            {
                ChallengeRegularKnight();
            }
            if (UserCharacter.userLevel >= 10 && UserCharacter.userLevel < 25)
            {
                ChallengeGreaterKnight();
            }
            if (UserCharacter.userLevel >= 25)
            {
                ChallengeTyrantKing();
            }
            if (DefeatInBattle.OpponentDefeatInBattle() is true)
            {
                Console.WriteLine("Congratulations! You are victorious!\n");
                UserInterface.GameMenu(inventory);
            }
            else
            {
                if (DefeatInBattle.UserDefeatInBattle() is true)
                {
                    Console.WriteLine("You have been defeated!");
                    Console.WriteLine();
                    UserInterface.GameMenu(inventory);
                }
            }
            BattleMenu(inventory);
        }

        public static void ChallengeLesserKnight()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("\nYour opponent is the Lesser Knight!");
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
            Console.WriteLine("\nYour opponent is the Regular Knight!");
            Console.WriteLine($"Opponent's Health: {RegularKnight.health}");
            Console.WriteLine($"User's Health: {UserCharacter.userHealth}");
            Attack.AttackRegularKnight();
            Console.WriteLine($"\nYou have dealt {UserCharacter.userAttackDamage} damage! Your opponent's health is now {RegularKnight.health}!");
            Console.WriteLine($"You have received {RegularKnight.attackDamage} damage! Your health is now {UserCharacter.userHealth}!\n");
            Console.WriteLine("-----------------------------------------------------------------");
        }

        public static void ChallengeGreaterKnight()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("\nYour opponent is the Greater Knight!");
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
            if (ChallengingKing == false)
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
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("\nYou have challenged the Tyrant King!");
                    Console.WriteLine($"Opponent's Health: {TyrantKing.health}");
                    Console.WriteLine($"User's Health: {UserCharacter.userHealth}\n");
                    Attack.AttackTyrantKing();
                    Console.WriteLine($"You have dealt {UserCharacter.userAttackDamage} damage! Your opponent's health is now {TyrantKing.health}!");
                    Console.WriteLine($"You have received {TyrantKing.attackDamage} damage! Your health is now {UserCharacter.userHealth}!\n");
                    Console.WriteLine("-----------------------------------------------------------------");
                }
                if (userInput == 2)
                {
                    ChallengeGreaterKnight();
                }
                else
                {
                    Console.WriteLine("\nPlease try again with some valid input.\n");
                }
            }
            if (ChallengingKing == true)
            {
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("\nYou are fighting the Tyrant King!");
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
            Console.WriteLine($"You have {DisplayInventory.DisplayLevelUpPotions(inventory)} Level Up potions.");
            if (DisplayInventory.DisplayLesserHealthPotions(inventory) == 0 && DisplayInventory.DisplayGreaterHealthPotions(inventory) == 0 && DisplayInventory.DisplayLevelUpPotions(inventory) == 0)
            {
                Console.WriteLine("\nYou have no items to use\n");
                GoIntoBattle(inventory);
            }
            else
            {
                Console.WriteLine("Which item in your inventory would you like to use?\n");
                Console.WriteLine("\n(1) Lesser Health Potion");
                Console.WriteLine("(2) Greater Health Potion");
                //Console.WriteLine("(3) Attack Potion");
                Console.WriteLine("(3) Level Up Potion");
                Console.WriteLine("\n(4) Return to battle without using item\n");
                Console.WriteLine("-----------------------------------------------------------------");
                userInput = Convert.ToInt32(Console.ReadLine());
                if (userInput == 1)
                {
                    if (DisplayInventory.DisplayLesserHealthPotions(inventory) != 0)
                    {
                        UsingPotions.UseLesserHealthPotion(inventory);
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine($"\nYour health is now {UserCharacter.userHealth}!\n");
                        GoIntoBattle(inventory);
                    }
                    else
                    {
                        Console.WriteLine("\nYou don't have any of that potion! Please select something else.");
                        UseItem(inventory);
                    }
                }
                if (userInput == 2)
                {
                    if (DisplayInventory.DisplayGreaterHealthPotions(inventory) != 0)
                    {
                        UsingPotions.UseGreaterHealthPotion(inventory);
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine($"\nYour health is now {UserCharacter.userHealth}!\n");
                        GoIntoBattle(inventory);
                    }
                    else
                    {
                        Console.WriteLine("\nYou don't have any of that potion! Please select something else.\n");
                        UseItem(inventory);
                    }
                }
                if (userInput == 3)
                {
                    if (DisplayInventory.DisplayLevelUpPotions(inventory) != 0)
                    {
                        UsingPotions.UseLevelUpPotion(inventory);
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine($"\nYour level is now {UserCharacter.userLevel}!");
                        Console.WriteLine($"Your health is now {UserCharacter.userHealth}!");
                        Console.WriteLine($"Your attack damage is now {UserCharacter.userAttackDamage}!\n");
                        GoIntoBattle(inventory);
                    }
                    else
                    {
                        Console.WriteLine("\nYou don't have any of that potion! Please select something else.\n");
                        UseItem(inventory);
                    }
                }
                if (userInput == 4)
                {
                    GoIntoBattle(inventory);
                }
            }
        }

        public static void Flee(List<Potions> inventory)
        {
            int userInput;
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("\nAre you sure you wish to flee? Your health will not be reset.");
            Console.WriteLine("\n(1) Yes");
            Console.WriteLine("(2) No\n");
            Console.WriteLine("-----------------------------------------------------------------");
            userInput = Convert.ToInt32(Console.ReadLine());
            if (userInput == 1)
            {
                UserInterface.GameMenu(inventory);
            }
            if (userInput == 2)
            {
                GoIntoBattle(inventory);
            }
            else
            {
                Console.WriteLine("\nI'm sorry, please try entering a valid option.\n");
                Flee(inventory);
            }
        }

        public static void UserWins()
        {
            Console.Clear();
            Console.WriteLine("\nCongratualtions! You have defeated the dread Tyrant King and reclaimed your hoard of treasure!");
            Console.WriteLine("You are now free to retire peacefully back in your you cave, or continue terrorizing the kingdom, or whatever your little dragon heart desires.");
            Console.WriteLine("Thanks for playing!\n");
            Environment.Exit(0);
        }
    }
}