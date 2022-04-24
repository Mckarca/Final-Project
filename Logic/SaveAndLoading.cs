using CharacterCoding;
using System.Text.Json;
using ItemCoding;
//using NormalUserInterface;

namespace SaveAndLoadCoding
{
    public interface ISaving
    {
        public static void SaveUserInventory(List<Potions> inventory) =>  throw new NotImplementedException();
        public static void SaveUserGold() =>  throw new NotImplementedException();
        public static void SaveUserLevel() =>  throw new NotImplementedException();
    }

    public interface ILoading
    {
        public static void LoadUserInventory() =>  throw new NotImplementedException();
        public static void LoadUserGold() =>  throw new NotImplementedException();
        public static void LoadUserLevel() =>  throw new NotImplementedException();
    }

    public class SaveGame : ISaving
    {
        public static void SaveUserInventory(List<Potions> inventory)
        {
            var json = JsonSerializer.Serialize(inventory);
            File.WriteAllText("inventory.json", json);
        }

        public static void SaveUserGold()
        {
            var goldWriter = new StreamWriter("GoldCount.txt");
            goldWriter.WriteLine(UserCharacter.userGoldCount);
            goldWriter.Close();
        }

        public static void SaveUserLevel()
        {
            var levelWriter = new StreamWriter("LevelCount.txt");
            levelWriter.WriteLine(UserCharacter.userLevel);
            levelWriter.Close();
        }
    }
    public class LoadGame : ILoading
    {
        public static List<Potions> LoadUserInventory()
        {
            var json = File.ReadAllText("inventory.json");
            List<Potions>? loadedInventory = JsonSerializer.Deserialize<List<Potions>>(json);
            //MainMenu.GameMenu(loadedInventory);
            return loadedInventory;
        }
        public static void LoadUserGold()
        {
            StreamReader goldReader = new StreamReader("GoldCount.txt");
            int loadedGoldCount = Int32.Parse(goldReader.ReadLine());
            UserCharacter.userGoldCount = loadedGoldCount;
            goldReader.Close();
        }

        public static void LoadUserLevel()
        {
            StreamReader levelReader = new StreamReader("LevelCount.txt");
            int loadedUserLevel = Int32.Parse(levelReader.ReadLine());
            UserCharacter.userLevel = loadedUserLevel;
            levelReader.Close();
            UserCharacter.userHealth = ((UserCharacter.userLevel - 1) * 2) + 10;
            UserCharacter.userAttackDamage = UserCharacter.userLevel + 1;

        }
    }
}






