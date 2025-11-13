using UnityEngine;
using System.IO;

public static class SaveSystem
{
    // ============[ Variables ]============ \\
    private static readonly string SAVE_PATH = Application.persistentDataPath + "/data.json";
    public static SaveData Current_Data; // global STATIC instance of the SaveData.

    // ============[ Serialization Methods ]============ \\

    /**
    * Saves the Current_Data to the file at the path above, overwriting what was there if anything.
    */
    public static void Save()
    {
        string json_encrypted_data = JsonUtility.ToJson(Current_Data, true); // encode the saveData to json
        File.WriteAllText(SAVE_PATH, json_encrypted_data); // save the encrypted json string to the SAVE_PATH outlined above.
        Debug.Log($"[SaveSystem]: Data saved to {SAVE_PATH}");
    }

    /**
    * Loads save data found from the path above, or creates a new static instance of SaveData.
    */
    public static void Load()
    {
        // If the file doesn't exist, make a new SaveData
        if (!File.Exists(SAVE_PATH))
        {
            Debug.LogWarning("[SaveSystem]: No save file found, creating new file...");
            Current_Data = new SaveData();
        }
        else { // otherwise read from SAVE_PATH and assign the decrypted json data
            string json = File.ReadAllText(SAVE_PATH);
            Current_Data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log($"[SaveSystem] Data loaded from {SAVE_PATH}");
        }
    }

    /**
    * Fetches and deletes the data.json file if it exists.
    */
    public static void Delete()
    {
        if (File.Exists(SAVE_PATH))
        {
            File.Delete(SAVE_PATH);
            Debug.Log("[SaveSystem]: Save file deleted.");
        }
    }

    // ============[ Get-Set Methods ]============ \\
    public static bool SaveFileExists() => File.Exists(SAVE_PATH);

}
