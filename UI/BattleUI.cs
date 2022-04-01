using Battle;
using NormalUserInterface;
using Character;
namespace BattleUI
{
    public class BattleUserInterface
    {
        public static void GoIntoBattle()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"BATTLE!");
            Console.ResetColor();
            Console.WriteLine($"Time to fight!\n");
            Console.WriteLine("-----------------------------------------------------------------");
            BattleUserSelection();

        }

        public static void BattleUserSelection()
        {
            int userInput;
            LesserKnight lesserKnight = new LesserKnight();
            //RegularKnight regularKnight = new RegularKnight();
            //GreaterKnight greaterKnight = new GreaterKnight();
            //UserCharacter Dragon = new UserCharacter();//Need a way to adjust character stats when level increases
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"User's Health: {UserCharacter.userHealth}");
            Console.WriteLine($"Opponent's Health: {lesserKnight.health()}\n");//need a way to decide which opponent user faces, and a way to switch between them.
            Console.WriteLine($"Select an option to engage in battle! (So far only option 1 and 4 work)\n");
            Console.WriteLine("(1) Attack");
            Console.WriteLine("(2) Defend");
            Console.WriteLine("(3) Use Item");
            Console.WriteLine("(4) Flee");
            Console.WriteLine("-----------------------------------------------------------------");
            userInput = Convert.ToInt32(Console.ReadLine());
            if (userInput == 1)
            {
                
                Attack.CharacterAttacksOpponent(lesserKnight.health());
                Attack.OpponentAttacksCharacter(lesserKnight.attackDamage());
                Console.WriteLine($"\nYou have dealt {UserCharacter.userAttackDamage} damage!");
                Console.WriteLine($"You have received {lesserKnight.attackDamage()} damage!");
                BattleUserSelection();

            }

            if (userInput == 4)
            {
                Flee();
            }
            // Console.WriteLine($"Dragon's health is {Dragon.userHealth}");
            // Console.WriteLine($"Lesser Knight's health is {lesserKnight.health()}");
            // Console.WriteLine($"Regular Knight's health is {regularKnight.health()}");
            // Console.WriteLine($"Greater Knight's health is {greaterKnight.health()}");
            //UserInterface.ExitProgramOption();
        }
        public static void Flee()
        {
            int userInput;
            Console.WriteLine($"\nAre you sure?");
            Console.WriteLine("(1) Yes");
            Console.WriteLine("(2) No");
            userInput = Convert.ToInt32(Console.ReadLine());
            if (userInput == 1)
            {
                Console.WriteLine();
                UserInterface.GameMenu();
            }
            if (userInput == 2)
            {
                Console.WriteLine();
                GoIntoBattle();
            }

        }
    }
}