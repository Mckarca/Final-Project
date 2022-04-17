using CharacterCoding;
namespace BattleCoding
{
    public class LesserKnight
    {
        public static int health { get; set; } = 9;
        public static int attackDamage { get; set; } = 2;
        public static string message { get; set; } = "Get back scum!";
        public  static int goldWinnings { get; set; } = 10;
    }
    public class RegularKnight
    {
        public static int health { get; set; } = 13;
        public static int attackDamage { get; set; } = 4;

        public static string message { get; set; } = "Prepare to die.";

        public static int goldWinnings { get; set; } = 15;
    }
    public class GreaterKnight
    {
        public static int health { get; set; } = 17;
        public static int attackDamage { get; set; } = 6;
        public static string message { get; set; } = "You will be slaughtered at my hands!";
        public static int superAttackDamage { get; set; } = 12;
        public static int goldWinnings { get; set; } = 20;
    }

    abstract class Boss
    {
        public abstract int health();
        public abstract int attackDamage();
        public abstract int GoldWinnings();
        public abstract string Message();
    }

    class TyrantKing : Boss
    {
        public override int health()
        {
            return 50;
        }
        public override int attackDamage()
        {
            return 15;
        }
        public override int GoldWinnings()
        {
            return 100;
        }
        public override string Message()
        {
            return "You have met your match in me. You will be dragged out of here in pieces.";
        }
    }


    public class Attack
    {
        public static void AttackLesserKnight()
        {
            LesserKnight.health = LesserKnight.health - UserCharacter.userAttackDamage;
            UserCharacter.userHealth = UserCharacter.userHealth - LesserKnight.attackDamage;
        }
        public static void AttackRegularKnight()
        {
            RegularKnight.health = RegularKnight.health - UserCharacter.userAttackDamage;
            UserCharacter.userHealth = UserCharacter.userHealth - RegularKnight.attackDamage;
        }
        public static void AttackGreaterKnight()
        {
            GreaterKnight.health = GreaterKnight.health - UserCharacter.userAttackDamage;
            UserCharacter.userHealth = UserCharacter.userHealth - GreaterKnight.attackDamage;    
        }
        public static int OpponentAttacksCharacter(int opponentAttackDamage)
        {
            UserCharacter.userHealth = UserCharacter.userHealth - opponentAttackDamage;
            return UserCharacter.userHealth;
        }

    }
    public class DefeatInBattle
    {
        public static bool UserDefeatInBattle()
        {
            if (UserCharacter.userHealth <= 0)
            {
                UserCharacter.userHealth = 10;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool OpponentDefeatInBattle()
        {
            if (LesserKnight.health <= 0)
            {
                LesserKnight.health = 9;
                UserCharacter.userGoldCount = UserCharacter.userGoldCount + LesserKnight.goldWinnings;
                Console.WriteLine($"You have won {LesserKnight.goldWinnings} gold");
                return true;
            }
            if (RegularKnight.health <= 0)
            {
                RegularKnight.health = 13;
                UserCharacter.userGoldCount = UserCharacter.userGoldCount + RegularKnight.goldWinnings;
                Console.WriteLine($"You have won {RegularKnight.goldWinnings} gold");
                return true;
            }
            if (GreaterKnight.health <= 0)
            {
                GreaterKnight.health = 17;
                UserCharacter.userGoldCount = UserCharacter.userGoldCount + GreaterKnight.goldWinnings;
                Console.WriteLine($"You have won {GreaterKnight.goldWinnings} gold");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}















// public void SaveAccounts()
// {
//storageService.SaveAccounts(accounts);//all below goes into an implementation of an interface
//     using (var writer = new StreamWriter(accounts.txt"))
//     {
//         foreach (var account in accounts)
//         {
//             account.Save(writer);
//         }
//         Writer.Close();
//     }
// }

// public void LoadAccounts()
// {
//     if (File.Exists("accounts.txt"))
//     {
//         LoadAccounts = Account.Load("accounts.txt");
//     }
// }



// public void SavePerson()
// {
//     using (var writer = new StreamWriter("name.txt"))
//     {
//         for each(var people in People)
//         {
//             writer.WriteLine("dsjbgsdgg");
//         }
//         writer.Close();
//     }
// }