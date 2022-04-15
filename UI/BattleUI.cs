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
            //opponentStat lesserKnightAttack = new opponentStat(LesserKnight.attackDamage);//delegate
            //Console.WriteLine(lesserKnightHealth());
            LesserKnight lesserKnight = new LesserKnight();
            //opponentStat opponentHealth = new opponentStat(LesserKnight.health);//delegate
            RegularKnight regularKnight = new RegularKnight();
            GreaterKnight greaterKnight = new GreaterKnight();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"User's Health: {UserCharacter.userHealth}");
            Console.WriteLine($"Opponent's Health: {regularKnight.health}\n");//need a way to decide which opponent user faces, and a way to switch between them.
            Console.WriteLine($"Select an option to engage in battle! (Defend doesn't work, and items have no implementation)\n");
            Console.WriteLine("(1) Attack");
            Console.WriteLine("(2) Defend");
            Console.WriteLine("(3) Use Item");
            Console.WriteLine("(4) Flee");
            Console.WriteLine("-----------------------------------------------------------------");
            userInput = Convert.ToInt32(Console.ReadLine());
            if (userInput == 1)
            {
                //Attack.CharacterAttacksOpponent(LesserKnight.health);//polymorphism issue
                //Attack.OpponentAttacksCharacter(lesserKnight.attackDamage());//polymorphism issue
                Attack.CharacterAttacksOpponent(regularKnight.health);
                Attack.OpponentAttacksCharacter(regularKnight.attackDamage);
                Console.WriteLine($"\nYou have dealt {UserCharacter.userAttackDamage} damage!");
                Console.WriteLine($"You have received {regularKnight.attackDamage} damage!");
                //Console.WriteLine($"You have received {lesserKnight.attackDamage()} damage!");//polymorphism issue
                BattleUserSelection(inventory);
            }

            if (userInput == 3)
            {
                foreach (var item in inventory)
                {
                    Console.WriteLine(item);
                }
                BattleUserSelection(inventory);
            }

            if (userInput == 4)
            {

                Flee(inventory);
            }
            // Console.WriteLine($"Dragon's health is {Dragon.userHealth}");
            // Console.WriteLine($"Lesser Knight's health is {lesserKnight.health()}");
            // Console.WriteLine($"Regular Knight's health is {regularKnight.health()}");
            // Console.WriteLine($"Greater Knight's health is {greaterKnight.health()}");
            //UserInterface.ExitProgramOption();
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