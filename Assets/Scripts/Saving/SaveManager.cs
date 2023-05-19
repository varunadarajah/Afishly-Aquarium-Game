using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{ 
    public static void Save(Game game)
    {
        string savefile = Application.persistentDataPath + "/savedata.txt";

        SaveData data = new SaveData(game);
        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(savefile, json);

        Debug.Log("Saved data to " + savefile);
    }

    public static SaveData Load()
    {
        string savefile = Application.persistentDataPath + "/savedata.txt";

        if(File.Exists(savefile))
        {
            string json = File.ReadAllText(savefile);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            return data;
        } 
        else
        {
            return null;
        }
    }
}
