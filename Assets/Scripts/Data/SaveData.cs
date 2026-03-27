using UnityEngine;
using System;
using System.Collections.Generic;

/**
* This class while not static, can have a static instance made elsewhere that allows for one copy of the
* SaveData to be accessible across all scripts. Serializable tells Unity that this data can be saved and stored.
*/

[Serializable]
public class AccountData 
{
    public string id; // e.g. a GUID for this account
    public string folder_id; // e.g. GUID for the folder this may belong to. No value if no folder assigned.
    public string display_name; // e.g. "Bank of America" or "Wells Fargo"
    public Dictionary<string, string> account_information = new(); // 1 = user, pw, pin, etc, 2 = literal value assigned
}

[Serializable]
public class FolderData
{
    public string id; // e.g. a GUID for this folder
    public string display_name; // the folder's name given by the end-user
    public List<string> accounts_ids = new(); // list of account's inside this folder.
}

[Serializable]
public class SaveData
{
    public Dictionary<string, FolderData> folders = new(); // 1 = folder_guid, 2 = FolderData (see above)
    public Dictionary<string, AccountData> accounts = new(); // 1 = account_guid, 2 = AccountData (see above)
}