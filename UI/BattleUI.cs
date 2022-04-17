using BattleCoding;
using NormalUserInterface;
using CharacterCoding;
using ItemCoding;
namespace BattleUI
{
    public class BattleUserInterface
    {
        public static void GoIntoBattle(List<Potions> inventory)
        {
            //opponentStat lesserKnightHealth = new opponentStat(LesserKnight.health);//delegate
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"BATTLE!");
            Console.ResetColor();
            Console.WriteLine($"Time to fight!\n");
            Console.WriteLine("-----------------------------------------------------------------");
            BattleUserSelection(inventory);
        }

        public static void BattleUserSelection(List<Potions> inventory)
        {
            int userInput;
            LesserKnight lesserKnight = new LesserKnight();
            GreaterKnight greaterKnight = new GreaterKnight();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"Select an option to engage in battle!\n");
            Console.WriteLine("(1) Attack");
            Console.WriteLine("(2) Use Item");
            Console.WriteLine("(3) Flee");
            Console.WriteLine("-----------------------------------------------------------------");
            userInput = Convert.ToInt32(Console.ReadLine());
            if (userInput == 1)
            {
                {
                    if (UserCharacter.userLevel < 5)
                    {
                        Console.WriteLine("Your opponent is the Lesser Knight!");
                        Console.WriteLine($"Opponent's Health: {LesserKnight.health}");
                        Console.WriteLine($"User's Health: {UserCharacter.userHealth}");
                        Attack.AttackLesserKnight();
                        Console.WriteLine($"\nYou have dealt {UserCharacter.userAttackDamage} damage! Your opponent's health is now {LesserKnight.health}!");
                        Console.WriteLine($"You have received {LesserKnight.attackDamage} damage! Your health is now {UserCharacter.userHealth}!");
                    }
                    if (UserCharacter.userLevel >= 5 && UserCharacter.userLevel < 10)
                    {
                        Console.WriteLine("Your opponent is the Regular Knight!");
                        Console.WriteLine($"Opponent's Health: {RegularKnight.health}");
                        Console.WriteLine($"User's Health: {UserCharacter.userHealth}");
                        Attack.AttackRegularKnight();
                        Console.WriteLine($"\nYou have dealt {UserCharacter.userAttackDamage} damage! Your opponent's health is now {RegularKnight.health}!");
                        Console.WriteLine($"You have received {RegularKnight.attackDamage} damage! Your health is now {UserCharacter.userHealth}!");
                    }
                    if (UserCharacter.userLevel >= 10 && UserCharacter.userLevel < 15)
                    {
                        Console.WriteLine("Your opponent is the Greater Knight!");
                        Console.WriteLine($"Opponent's Health: {GreaterKnight.health}");
                        Console.WriteLine($"User's Health: {UserCharacter.userHealth}");
                        Attack.AttackGreaterKnight();
                        Console.WriteLine($"\nYou have dealt {UserCharacter.userAttackDamage} damage! Your opponent's health is now {GreaterKnight.health}!");
                        Console.WriteLine($"You have received {GreaterKnight.attackDamage} damage! Your health is now {UserCharacter.userHealth}!");
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

                }
                BattleUserSelection(inventory);
            }

            if (userInput == 2)
            {
                Console.WriteLine($"You have {Inventory.DisplayLesserHealthPotions(inventory)} Lesser Health potions.");
                Console.WriteLine($"You have {Inventory.DisplayGreaterHealthPotions(inventory)} Greater Health potions.");
                Console.WriteLine($"You have {Inventory.DisplayLevelUpPotions(inventory)} Level Up potions.");
                if (Inventory.DisplayLesserHealthPotions(inventory) == 0 && Inventory.DisplayGreaterHealthPotions(inventory) == 0 && Inventory.DisplayLevelUpPotions(inventory) == 0)
                {

                    Console.WriteLine("You have no items to use");
                    BattleUserSelection(inventory);
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
                        BattleUserSelection(inventory);
                    }
                    if (userInput == 2)
                    {
                        UsingPotions.UseGreaterHealthPotion(inventory);
                        Console.WriteLine($"Your health is now {UserCharacter.userHealth}!");
                        BattleUserSelection(inventory);
                    }
                    if (userInput == 3)
                    {
                        UsingPotions.UseLevelUpPotion(inventory);
                        Console.WriteLine($"Your level is now {UserCharacter.userLevel}!");
                        Console.WriteLine($"Your health is now {UserCharacter.userHealth}!");
                        Console.WriteLine($"Your attack damage is now {UserCharacter.userAttackDamage}!");
                        BattleUserSelection(inventory);
                    }
                    if (userInput == 4)
                    {
                        BattleUserSelection(inventory);
                    }
                }
            }

            if (userInput == 3)
            {

                Flee(inventory);
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
    }
}

