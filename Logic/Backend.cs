using System;
namespace Backend
{
    interface IOpponents
    {
        int health();
        int attackDamage();
        string message();
    }

    public class LesserKnight : IOpponents
    {
        public int health()
        {
            return 10;
        }

        public int attackDamage()
        {
            return 2;
        }

        public string message()
        {
            return "Hello there";
        }
    }
}