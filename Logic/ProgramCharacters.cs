namespace CharacterCoding
{
    public class UserCharacter
    {
        public static int userLevel { get; set; } = 15;
        public static int userHealth { get; set; } = ((userLevel - 1) * 2) + 10;
        public static int userAttackDamage { get; set; } = userLevel + 1;
        public static int userGoldCount { get; set; } = 200;
        public static int userDefeatedCount { get; set; } = 0;
    }

     public class LesserKnight
    {
        public static int health { get; set; } = 7;
        public static int attackDamage { get; set; } = 1;
        public static int goldWinnings { get; set; } = 20;
    }

    public class RegularKnight
    {
        public static int health { get; set; } = 13;
        public static int attackDamage { get; set; } = 4;
        public static int goldWinnings { get; set; } = 30;
    }

    public class GreaterKnight
    {
        public static int health { get; set; } = 25;
        public static int attackDamage { get; set; } = 13;
        public static int goldWinnings { get; set; } = 45;
    }

    public class TyrantKing
    {
        public static int health { get; set; } = 100;
        public static int attackDamage { get; set; } = 15;
        public static int goldWinnings { get; set; } = 100;
    }
}
