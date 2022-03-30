using System;
namespace Battle
{
    interface IOpponents
    {
        int health();
        int attackDamage();
        string message();
    }

    public class LesserKnight : IOpponents
    {
        public virtual int health()
        {
            return 10;
        }

        public virtual int attackDamage()
        {
            return 2;
        }

        public virtual string message()
        {
            return "Get back scum!";
        }
    }

    public class RegularKnight : LesserKnight, IOpponents
    {
        public override int health()
        {
            return 15;
        }

        public override int attackDamage()
        {
            return 4;
        }

        public override string message()
        {
            return "Prepare to die.";
        }
    }

    public class GreaterKnight : RegularKnight, IOpponents
    {
        public override int health()
        {
            return 20;
        }

        public override int attackDamage()
        {
            return 6;
        }

        public override string message()
        {
            return "You will be slaughtered at my hands!";
        }

        public int superAttackDamage()
        {
            return 12;
        }
    }

    public class Battle
    {

    }
}