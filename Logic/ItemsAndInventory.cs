using CharacterCoding;
namespace ItemCoding
{
    public enum Potions
    {
        LesserHealthPotion,
        GreaterHealthPotion,
        LevelUpPotion
        //AttackPotion
    }

    public class Inventory
    {
        public static int DisplayLesserHealthPotions(List<Potions> inventory)
        {
            int lesserHealthPotionCount = 0;
            for (int i = 0; i < inventory.Count; i++)
            {
                // Console.WriteLine($"({i+1}) {inventory[i]}");
                if (inventory[i] == Potions.LesserHealthPotion)
                {
                    lesserHealthPotionCount++;
                }
            }
            return lesserHealthPotionCount;
        }

        public static int DisplayGreaterHealthPotions(List<Potions> inventory)
        {
            int greaterHealthPotionCount = 0;
            for (int i = 0; i < inventory.Count; i++)
            {
                // Console.WriteLine($"({i+1}) {inventory[i]}");
                if (inventory[i] == Potions.GreaterHealthPotion)
                {
                    greaterHealthPotionCount++;
                }
            }
            return greaterHealthPotionCount;
        }

        public static int DisplayLevelUpPotions(List<Potions> inventory)
        {
            int levelUpPotionCount = 0;
            for (int i = 0; i < inventory.Count; i++)
            {
                // Console.WriteLine($"({i+1}) {inventory[i]}");
                if (inventory[i] == Potions.LevelUpPotion)
                {
                    levelUpPotionCount++;
                }
            }
            return levelUpPotionCount;
        }
    }
    public class UsingPotions
    {
        public static void UseLesserHealthPotion(List<Potions> inventory)
        {
            UserCharacter.userHealth = UserCharacter.userHealth + 5;
            inventory.Remove(Potions.LesserHealthPotion);
        }

        public static void UseGreaterHealthPotion(List<Potions> inventory)
        {
            UserCharacter.userHealth = UserCharacter.userHealth + 10;
            inventory.Remove(Potions.GreaterHealthPotion);
        }

        public static void UseLevelUpPotion(List<Potions> inventory)
        {
            UserCharacter.userLevel++;
            UserCharacter.userHealth = ((UserCharacter.userLevel - 1) * 2) + 10;
            UserCharacter.userAttackDamage = UserCharacter.userLevel + 1;
            inventory.Remove(Potions.LevelUpPotion);
        }
    }
}