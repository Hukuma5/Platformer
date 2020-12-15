using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad
{
    private static string path = Application.persistentDataPath + "/save";
    private static string pathforautosave = Application.persistentDataPath + "/autosave";
    private static BinaryFormatter formatter = new BinaryFormatter();

    public static void SaveGame(CharacterControllerScript character)
    {
        FileStream fs = new FileStream(path, FileMode.Create);
        SaveData data = new SaveData(character);
        formatter.Serialize(fs, data);
        fs.Close();
    }

    public static SaveData LoadGame()
    {
        if (File.Exists(path))
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            SaveData data = formatter.Deserialize(fs) as SaveData;
            fs.Close();
            return data;
        }
        else
        {
            return null;
        }
    }

    public static void AutoSaveGame(CharacterControllerScript character)
    {
        FileStream fs = new FileStream(pathforautosave, FileMode.Create);
        SaveData data = new SaveData(character);
        formatter.Serialize(fs, data);
        fs.Close();
    }

    public static SaveData AutoLoadGame()
    {
        if (File.Exists(pathforautosave))
        {
            FileStream fs = new FileStream(pathforautosave, FileMode.Open);
            SaveData data = formatter.Deserialize(fs) as SaveData;
            fs.Close();
            return data;
        }
        else
        {
            return null;
        }
    }
}