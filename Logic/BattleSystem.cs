using CharacterCoding;
namespace BattleCoding
{

    //public delegate int opponentStat();


    // interface IOpponents
    // {
    //     int health();
    //     int attackDamage();
    //     string message();
    //     int goldWinnings();
    // }
    public class LesserKnight
    {
        public int health { get; set; } = 10;
        public int attackDamage { get; set; } = 2;
        public  string message { get; set; } = "Get back scum!";
        public int goldWinnings { get; set; } = 10;
    }

    public class PracticeOpponent
    {
        public int health { get; set; } = 10;
        public int attackDamage { get; set; } = 2;
    }

    public class RegularKnight
    {
        public int health { get; set; } = 15;
        public int attackDamage { get; set; } = 4;

        public string message { get; set; } = "Prepare to die.";

        public int goldWinnings { get; set; } = 15;
    }

    public class GreaterKnight
    {
        public int health { get; set; } = 20;
        public int attackDamage { get; set; } = 6;
        public string message { get; set; } = "You will be slaughtered at my hands!";
        public int superAttackDamage { get; set; } = 12;
        public int goldWinnings { get; set; } = 20;
    }
    //regular knight inheriting from IOpponents and LesserKnight, greater knight inheriting from Iopponets and regular knight
    // public class RegularKnight : LesserKnight, IOpponents
    // {
    //     public override int health()
    //     {
    //         return 15;
    //     }

    //     public override int attackDamage()
    //     {
    //         return 4;
    //     }

    //     public override string message()
    //     {
    //         return "Prepare to die.";
    //     }

    //     public override int goldWinnings()
    //     {
    //         return 15;
    //     }
    // }

    // public class GreaterKnight : RegularKnight, IOpponents
    // {
    //     public override int health()
    //     {
    //         return 20;
    //     }

    //     public override int attackDamage()
    //     {
    //         return 6;
    //     }

    //     public override string message()
    //     {
    //         return "You will be slaughtered at my hands!";
    //     }

    //     public int superAttackDamage()
    //     {
    //         return 12;
    //     }

    //     public override int goldWinnings()
    //     {
    //         return 20;
    //     }
    // }

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
        public static int CharacterAttacksOpponent(int opponentHealth)
        {
            opponentHealth = opponentHealth - UserCharacter.userAttackDamage;
            return opponentHealth;
        }

        public static int OpponentAttacksCharacter(int opponentAttackDamage)
        {
            UserCharacter.userHealth = UserCharacter.userHealth - opponentAttackDamage;
            return UserCharacter.userHealth;
        }

        public static void OpponentDefeat()
        {

        }
    }
}

