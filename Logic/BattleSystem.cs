﻿using CharacterCoding;
using ItemCoding;
namespace BattleCoding
{

    public class Attack
    {
        public static void AttackLesserKnight()
        {
            // if (UsingPotions.attackPotionInUse == true)
            // {
            //     //UsingPotions.UseAttackPotion(inventory);
            //     UserCharacter.userAttackDamage = UserCharacter.userAttackDamage + 5;
            //     UsingPotions.attackPotionInUse = false;
            // }
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

        public static void AttackTyrantKing()
        {
            TyrantKing.health = TyrantKing.health - UserCharacter.userAttackDamage;
            UserCharacter.userHealth = UserCharacter.userHealth - TyrantKing.attackDamage;
        }

        // public static int OpponentAttacksCharacter(int opponentAttackDamage)
        // {
        //     UserCharacter.userHealth = UserCharacter.userHealth - opponentAttackDamage;
        //     return UserCharacter.userHealth;
        // }
    }

    public class DefeatInBattle
    {
        public static bool UserDefeatInBattle()
        {
            if (UserCharacter.userHealth <= 0)
            {
                UserCharacter.userHealth = ((UserCharacter.userLevel - 1) * 2) + 10;
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
            if (TyrantKing.health <= 0)
            {
                TyrantKing.health = 100;
                UserCharacter.userGoldCount = UserCharacter.userGoldCount + TyrantKing.goldWinnings;
                Console.WriteLine($"You have won {TyrantKing.goldWinnings} gold");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
    public class FleeFromBattle
    {
        public static void ResetOpponentHealth()
        {
           LesserKnight.health = 9;
           RegularKnight.health = 13;
           GreaterKnight.health = 17;
           TyrantKing.health = 100;
        }
    }
}