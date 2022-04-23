using NUnit.Framework;
using CharacterCoding;
using System;
using SaveAndLoadCoding;
using System.Text.Json;
using System.IO;
using ItemCoding;
using System.Collections.Generic;

namespace Tests;
// public class Save : ISaving
// {
//     int userGold;
//     public Save(int myGold)
//     {
//         myGold = userGold;
//     }
//     public void SaveUserGold()
//     {
//         var goldCount = new StreamWriter("MyGold.txt");
//         goldCount.WriteLine(userGold);
//         goldCount.Close();

//         StreamReader goldLoader = new StreamReader("MyGold.txt");
//     int loadedGoldCount = Int32.Parse(goldLoader.ReadLine());
//     goldLoader.Close();
//     }
// }

// public class Load : ILoading
// {
//     public void LoadUserGold()
//     {
//     StreamReader goldLoader = new StreamReader("MyGold.txt");
//     int loadedGoldCount = Int32.Parse(goldLoader.ReadLine());
//     goldLoader.Close();
//     }
//}
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestSavingUserInfo()
    {

        //Assert.AreEqual(userGold, UserCharacter.userGoldCount);

    }
}





 // public class Save : ISaving
        // {
        //     int userGold = 50;
        //     public void SaveUserGold()
        //     {
        //         var goldCount = new StreamWriter("MyGold.txt");
        //         goldCount.WriteLine(userGold);
        //         goldCount.Close();
        //     }
        // }
        // SaveGame userGold = new SaveGame();
        //SaveUserGold();


        // StreamReader goldloader = new StreamReader("MyGold.txt");
        // int myLoadedGold = Int32.Parse(goldloader.ReadLine());
        // //UserCharacter.userGoldCount = loadedGoldCount;
        // goldloader.Close();


        //     Assert.AreEqual(userGold, myLoadedGold);