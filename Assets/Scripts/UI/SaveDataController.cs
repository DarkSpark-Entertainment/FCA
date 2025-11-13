using UnityEngine;
using System;
using System.Collections.Generic;

public class SaveDataController : MonoBehaviour
{
    // ============[ Variables ]============ \\


    // ============[ UI Interaction Functions ]============ \\
    public void AddFolder(string folder_name)
    {
        //string new_id = Guid.NewGuid().ToString().Substring(0, 6); // short random ID
        //SaveSystem.Current_Data.folders.Add(new FolderData { id = new_id, name = folder_name });
        //SaveSystem.Save();
    }

    public void AddAccount(string org_name) 
    {
        //SaveSystem.Current_Data.accounts.Add(new AccountData { organization = org_name, folder_id = fold_id, fields = listed_fields });
        //SaveSystem.Save();
    }

    public void DeleteFolder(string folder_id)
    {
        //string folder_name = SaveSystem.Current_Data.folders

        //SaveSystem.Current_Data.folders.RemoveAll(f => f.id == folder_id); // loop that searches the folders list and removes all elements that match the ID arg
        //SaveSystem.Current_Data.accounts.RemoveAll(a => a.folder_id == folder_id); // then we purge all associated accounts (due to how we store the data, the accounts arent actually inside a folder lol)

        //SaveSystem.Save();
        Debug.Log($"[DataManager]: Folder {folder_id} and its accounts have been purged.");
    }

    public void DeleteAccount(string org_name)
    {
        //SaveSystem.Current_Data.accounts.RemoveAll(a => a.organization == org_name)

        //SaveSystem.Save();
        Debug.Log($"[DataManager]: Account under {org_name} has been deleted.");
    }
}