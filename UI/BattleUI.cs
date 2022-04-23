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
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"BATTLE!");
            Console.ResetColor();
            Console.WriteLine($"Time to fight!\n");
            Console.WriteLine("-----------------------------------------------------------------");
            BattleMenu(inventory);
        }

        public static void BattleMenu(List<Potions> inventory)
        {
            int userInput;
            //LesserKnight lesserKnight = new LesserKnight();
            //GreaterKnight greaterKnight = new GreaterKnight();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"Select an option to engage in battle!\n");
            Console.WriteLine("(1) Attack");
            Console.WriteLine("(2) Use Item");
            Console.WriteLine("(3) Flee");
            Console.WriteLine("-----------------------------------------------------------------");
            try
            {
                userInput = Convert.ToInt32(Console.ReadLine());
                BattleUserSelection(userInput, inventory);
            }
            catch
            {

                Console.WriteLine($"Sorry, that's not an valid command! Please try again.\n");
                BattleMenu(inventory);
            }
            // try
            // {

            // }
            // catch
            // {
            //     Console.WriteLine($"Sorry, that's not an valid command! Please try again.\n");
            //     BattleMenu(inventory);
            // }
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
                Console.WriteLine($"Sorry, that's not an valid option! Please try again.\n");
                BattleMenu(inventory);
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
                Console.WriteLine("Congratulations! You are victorious!");
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
            Console.WriteLine("Your opponent is the Lesser Knight!");
            Console.WriteLine($"Opponent's Health: {LesserKnight.health}");
            Console.WriteLine($"User's Health: {UserCharacter.userHealth}");
            Attack.AttackLesserKnight();
            Console.WriteLine($"\nYou have dealt {UserCharacter.userAttackDamage} damage! Your opponent's health is now {LesserKnight.health}!");
            Console.WriteLine($"You have received {LesserKnight.attackDamage} damage! Your health is now {UserCharacter.userHealth}!");
        }

        public static void ChallengeRegularKnight()
        {
            Console.WriteLine("Your opponent is the Regular Knight!");
            Console.WriteLine($"Opponent's Health: {RegularKnight.health}");
            Console.WriteLine($"User's Health: {UserCharacter.userHealth}");
            Attack.AttackRegularKnight();
            Console.WriteLine($"\nYou have dealt {UserCharacter.userAttackDamage} damage! Your opponent's health is now {RegularKnight.health}!");
            Console.WriteLine($"You have received {RegularKnight.attackDamage} damage! Your health is now {UserCharacter.userHealth}!");
        }

        public static void ChallengeGreaterKnight()
        {
            Console.WriteLine("Your opponent is the Greater Knight!");
            Console.WriteLine($"Opponent's Health: {GreaterKnight.health}");
            Console.WriteLine($"User's Health: {UserCharacter.userHealth}");
            Attack.AttackGreaterKnight();
            Console.WriteLine($"\nYou have dealt {UserCharacter.userAttackDamage} damage! Your opponent's health is now {GreaterKnight.health}!");
            Console.WriteLine($"You have received {GreaterKnight.attackDamage} damage! Your health is now {UserCharacter.userHealth}!");
        }

        public static void ChallengeTyrantKing()
        {
            int userInput;
            if (ChallengingKing == false)
            {
                Console.WriteLine("Would you like to challenge the Tyrant King?");
                Console.WriteLine($"\n(1) Yes");
                Console.WriteLine($"(2) No");
                userInput = Convert.ToInt32(Console.ReadLine());
                if (userInput == 1)
                {
                    ChallengingKing = true;
                    Console.WriteLine("You have challenged the Tyrant King!");
                    Console.WriteLine($"Opponent's Health: {TyrantKing.health}");
                    Console.WriteLine($"User's Health: {UserCharacter.userHealth}");
                    Attack.AttackTyrantKing();
                    Console.WriteLine($"\nYou have dealt {UserCharacter.userAttackDamage} damage! Your opponent's health is now {TyrantKing.health}!");
                    Console.WriteLine($"You have received {TyrantKing.attackDamage} damage! Your health is now {UserCharacter.userHealth}!");
                }
                if (userInput == 2)
                {
                    ChallengeGreaterKnight();
                }
            }
            if (ChallengingKing == true)
            {
                Console.WriteLine("You are fighting the Tyrant King!");
                Console.WriteLine($"Opponent's Health: {TyrantKing.health}");
                Console.WriteLine($"User's Health: {UserCharacter.userHealth}");
                Attack.AttackTyrantKing();
                Console.WriteLine($"\nYou have dealt {UserCharacter.userAttackDamage} damage! Your opponent's health is now {TyrantKing.health}!");
                Console.WriteLine($"You have received {TyrantKing.attackDamage} damage! Your health is now {UserCharacter.userHealth}!");
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
            Console.WriteLine($"\nYou have {DisplayInventory.DisplayLesserHealthPotions(inventory)} Lesser Health potions.");
            Console.WriteLine($"You have {DisplayInventory.DisplayGreaterHealthPotions(inventory)} Greater Health potions.");
            Console.WriteLine($"You have {DisplayInventory.DisplayLevelUpPotions(inventory)} Level Up potions.");
            if (DisplayInventory.DisplayLesserHealthPotions(inventory) == 0 && DisplayInventory.DisplayGreaterHealthPotions(inventory) == 0 && DisplayInventory.DisplayLevelUpPotions(inventory) == 0)
            {
                Console.WriteLine("You have no items to use");
                BattleMenu(inventory);
            }
            else
            {
                Console.WriteLine($"Which item in your inventory would you like to use?\n");
                Console.WriteLine($"\n(1) Lesser Health Potion");
                Console.WriteLine("(2) Greater Health Potion");
                //Console.WriteLine("(3) Attack Potion");
                Console.WriteLine("(3) Level Up Potion");
                Console.WriteLine($"\n(4) Return to battle without using item\n");
                userInput = Convert.ToInt32(Console.ReadLine());
                if (userInput == 1)
                {
                    if (DisplayInventory.DisplayLesserHealthPotions(inventory) != 0)
                    {
                        UsingPotions.UseLesserHealthPotion(inventory);
                        Console.WriteLine($"Your health is now {UserCharacter.userHealth}!");
                        BattleMenu(inventory);
                    }
                    else
                    {
                        Console.WriteLine($"\nYou don't have any of that potion! Please select something else.");
                        UseItem(inventory);
                    }
                }
                if (userInput == 2)
                {
                    if (DisplayInventory.DisplayGreaterHealthPotions(inventory) != 0)
                    {
                        UsingPotions.UseGreaterHealthPotion(inventory);
                        Console.WriteLine($"Your health is now {UserCharacter.userHealth}!");
                        BattleMenu(inventory);
                    }
                    else
                    {
                        Console.WriteLine($"\nYou don't have any of that potion! Please select something else.");
                        UseItem(inventory);
                    }
                }
                // if (userInput == 3)
                // {
                //     UsingPotions.RemoveAttackPotionFromInventory(inventory);
                //     UsingPotions.attackPotionInUse = true;
                // }
                if (userInput == 3)
                {
                    if (DisplayInventory.DisplayLevelUpPotions(inventory) != 0)
                    {
                        UsingPotions.UseLevelUpPotion(inventory);
                        Console.WriteLine($"Your level is now {UserCharacter.userLevel}!");
                        Console.WriteLine($"Your health is now {UserCharacter.userHealth}!");
                        Console.WriteLine($"Your attack damage is now {UserCharacter.userAttackDamage}!");
                        BattleMenu(inventory);
                    }
                    else
                    {
                        Console.WriteLine($"\nYou don't have any of that potion! Please select something else.");
                        UseItem(inventory);
                    }
                }
                if (userInput == 4)
                {
                    BattleMenu(inventory);
                }
            }
        }

        public static void Flee(List<Potions> inventory)
        {
            int userInput;
            Console.WriteLine($"\nAre you sure?");
            Console.WriteLine("(1) Yes");
            Console.WriteLine("(2) No");
            userInput = Convert.ToInt32(Console.ReadLine());
            if (userInput == 1)
            {
                Console.WriteLine();
                UserInterface.GameMenu(inventory);
            }
            if (userInput == 2)
            {
                Console.WriteLine();
                GoIntoBattle(inventory);
            }
        }

        public static void UserWins()
        {
            Console.Clear();
            Console.WriteLine("Congratualtions! You have defeated the dread Tyrant King and reclaimed your hoard of treasure!");
            Console.WriteLine("You are now free to retire peacefully back in your you cave, or continue terrorizing the kingdom, or whatever your little dragon heart desires.");
            Console.WriteLine("Thanks for playing!");
            Environment.Exit(0);
        }
    }
}