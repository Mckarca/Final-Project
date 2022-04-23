using CharacterCoding;
namespace SaveAndLoadCoding
{
    public interface ISaving
    {
        //public void SaveUserInventory();
        public void SaveUserGold();
        //public void SaveUserLevel();  
    }

    public interface ILoading
    {
        //public void LoadUserInventory();
        public void LoadUserGold();
        //public void LoadUserLevel();
    }

    public class SaveGame : ISaving
    {
        public void SaveUserGold()
        {
            var goldWriter = new StreamWriter("GoldCount.txt");
            goldWriter.WriteLine(UserCharacter.userGoldCount);
            goldWriter.Close();
            Console.WriteLine("Your gold has been saved!");
        }
    }

    public class LoadGame
    {
        public void LoadUserGold()
        {
            StreamReader goldReader = new StreamReader("GoldCount.txt");
            int loadedGoldCount = Int32.Parse(goldReader.ReadLine());
            UserCharacter.userGoldCount = loadedGoldCount;
            goldReader.Close();
            Console.WriteLine("Your gold has been loaded!");
        }
    }





}