using UnityEngine;
using System.IO;

public static class SaveSystem
{
    private static readonly string savePath = Application.persistentDataPath + "save_data.json";

    public static void SaveDataToFile(SaveData data)
    {
        string json = JsonUtility.ToJson(data, true); // encode the saveData to json
        File.WriteAllText(savePath, json); // save the encrypted json string to the savePath outlined above.
        Debug.Log($"[SaveSystem]: Data saved to {savePath}");
    }

    public static void LoadDataFromFile()
    {
        if (!File.Exists(savePath))
        {
            Debug.LogWarning("[SaveSystem]: No save file found, creating new file...");
            return new SaveData();
        }

        string json = File.ReadAllText(savePath);
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        Debug.Log($"[SaveSystem] Data loaded from {savePath}");
        return data;
    }

    public static bool SaveFileExists() => File.Exists(savePath);

    public static void DeleteSave()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
            Debug.Log("[SaveSystem]: Save file deleted.");
        }
    }
}
