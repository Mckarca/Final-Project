﻿using CharacterCoding;
namespace BattleCoding
{
    
    public delegate int opponentStat();
    
    
    // interface IOpponents
    // {
    //     int health();
    //     int attackDamage();
    //     string message();
    //     int goldWinnings();
    // }
    public class LesserKnight
    {
        public static int health()
        {
            return 10;
        }

        public static int attackDamage()
        {
            return 2;
        }

        public static string message()
        {
            return "Get back scum!";
        }

        public static int goldWinnings()
        {
            return 10;
        }
        
    }

    public class PracticeOpponent
    {
        public int health {get; set;} = 10;
        public int attackDamage {get; set;} = 2;
    }

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
        //health, attack, message, gold
        public abstract int health();
        public abstract int attackDamage();
        public abstract int GoldWinnings();
        public  abstract string Message();
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