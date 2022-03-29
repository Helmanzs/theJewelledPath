using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveGame
{
    public static void SaveCurrentGame()
    {
        SaveData saveData = CreateSaveDataObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, saveData);
        file.Close();

        Debug.Log(Application.persistentDataPath);
        Debug.Log("Game Saved");
    }

    public static SaveData CreateSaveDataObject()
    {
        SaveData data = new SaveData();
        data.exp += 50;
        return data;
    }
}
