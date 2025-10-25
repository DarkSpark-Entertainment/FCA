using UnityEngine;
using System;
using System.Collections.Generic;

public class DataManager : MonoBehaviour
{
    public SaveData currentData;

    private void Awake()
    {
        currentData = SaveSystem.LoadDataFromFile();
    }

    public void SaveAll()
    {
        SaveSystem.SaveDataToFile(currentData);
    }

    public void AddFolder(string folder_name)
    {
        string new_id = Guid.NewGuid().ToString().Substring(0, 6); // short random ID
        currentData.folders.Add(new FolderData { id = new_id, name = folder_name });
        SaveAll();
    }

    public void AddAccount(string org_name, string fold_id, List<AccountField> listed_fields) 
    {
        currentData.accounts.Add(new AccountData { organization = org_name, folder_id = fold_id, fields = listed_fields });
        SaveAll();
    }

    public void DeleteFolder(string folder_id)
    {
        //string folder_name = currentData.folders

        currentData.folders.RemoveAll(f => f.id == folder_id); // loop that searches the folders list and removes all elements that match the ID arg
        currentData.accounts.RemoveAll(a => a.folder_id == folder_id); // then we purge all associated accounts (due to how we store the data, the accounts arent actually inside a folder lol)

        SaveAll();
        Debug.Log($"[DataManager]: Folder {folder_id} and its accounts have been purged.");
    }

    public void DeleteAccount(string org_name)
    {
        //currentData.accounts.RemoveAll(a => a.organization == org_name)

        SaveAll();
        Debug.Log($"[DataManager]: Account under {org_name} has been deleted.");
    }
}