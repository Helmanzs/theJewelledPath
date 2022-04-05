using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem

{
    public static bool CheckIfFolderExists => Directory.Exists(Application.persistentDataPath + "/Saves");
    public static bool CheckIfFileExists(string fileName) => File.Exists(Application.persistentDataPath + $"/Saves/{fileName}.save");


    public static void SavePlayer(string fileName)
    {
        if (!CheckIfFolderExists)
            CreateSaveFolder();

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = new FileStream(Application.persistentDataPath + $"/Saves/{fileName}.save", FileMode.Create);
        PlayerData data = new PlayerData(Player.Instance);

        formatter.Serialize(file, data);
        file.Close();
    }

    public static PlayerData LoadPlayer(string fileName)
    {
        if (!CheckIfFileExists(fileName))
            return null;

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = new FileStream(Application.persistentDataPath + $"/Saves/{fileName}.save", FileMode.Open);
        PlayerData data = formatter.Deserialize(file) as PlayerData;
        file.Close();
        return data;
    }

    public static void SaveCurrentGame()
    {
        if (!CheckIfFolderExists)
        {
            CreateSaveFolder();
        }

        // PlayerData saveData = CreateSaveDataObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Saves/gamesave.save");
        //  bf.Serialize(file, saveData);
        file.Close();
    }

    public static void CreateSaveFolder()
    {
        Directory.CreateDirectory(Application.persistentDataPath + "/Saves");
    }

    public static void CreateSaveFile(string fileName, string saveName)
    {
        /* PlayerData saveData = SaveSystem.CreateSaveDataObject();
         saveData.saveName = saveName;

         File.Delete(Application.persistentDataPath + $"/Saves/{fileName}.save");
         FileStream file = File.Create(Application.persistentDataPath + $"/Saves/{fileName}.save");

         BinaryFormatter bf = new BinaryFormatter();
         bf.Serialize(file, saveData);
         file.Close();*/
    }
}
