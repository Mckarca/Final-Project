namespace CharacterCoding
{
    public class UserCharacter
    {
        public static int userLevel { get; set; } = 0;
        public static int userHealth { get; set; } = ((userLevel - 1) * 2) + 10;
        public static int userAttackDamage { get; set; } = userLevel + 1;
        public static int userGoldCount { get; set; } = 0;
        
    }
} 
