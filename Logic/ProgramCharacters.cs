namespace CharacterCoding
{
    public class UserCharacter
    {
        public static int userLevel { get; set; } = 1;
        public static int userHealth { get; set; } = ((userLevel - 1) * 2) + 10;
        public static int userAttackDamage { get; set; } = userLevel + 1;
        public static int userGoldCount { get; set; } = 0;
    }

     public class LesserKnight
    {
        public static int health { get; set; } = 9;
        public static int attackDamage { get; set; } = 2;
        public static string message { get; set; } = "Get back scum!";
        public static int goldWinnings { get; set; } = 10;
    }

    public class RegularKnight
    {
        public static int health { get; set; } = 13;
        public static int attackDamage { get; set; } = 4;
        public static string message { get; set; } = "Prepare to die.";
        public static int goldWinnings { get; set; } = 20;
    }

    public class GreaterKnight
    {
        public static int health { get; set; } = 17;
        public static int attackDamage { get; set; } = 6;
        public static string message { get; set; } = "You will be slaughtered at my hands!";
        //public static int superAttackDamage { get; set; } = 12;
        public static int goldWinnings { get; set; } = 30;
    }

    public class TyrantKing
    {
        public static int health { get; set; } = 100;
        public static int attackDamage { get; set; } = 15;
        public static string message { get; set; } = "You have met your match in me. You will be dragged out of here in pieces.";
        //public static int superAttackDamage { get; set; } = 12;
        public static int goldWinnings { get; set; } = 100;
    }
    

    // abstract class Boss
    // {
    //     public abstract int health();
    //     public abstract int attackDamage();
    //     public abstract int GoldWinnings();
    //     public abstract string Message();
    // }

    // class TyrantKing : Boss
    // {
    //     public override int health()
    //     {
    //         return 50;
    //     }
    //     public override int attackDamage()
    //     {
    //         return 15;
    //     }
    //     public override int GoldWinnings()
    //     {
    //         return 100;
    //     }
    //     public override string Message()
    //     {
    //         return "You have met your match in me. You will be dragged out of here in pieces.";
    //     }
    // }

}
