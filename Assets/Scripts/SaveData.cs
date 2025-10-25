using UnityEngine;
using System;
using System.Collections.Generic;

/**
* Allows for quick searching for accounts based on their 'organization' attribute. Additionally
* establishes a folder-account relationship via the folder_id.
*/

[Serializable]
public class AccountData 
{
    public string organization; // e.g. "Wells Fargo"
    public string folder_id; // e.g. "cd145" or "undefined"
    public List<AccountField> fields = new List<AccountField>(); // e.g. user, pw, pin, em...
}

[Serializable]
public class AccountField
{
    public string tag; // e.g. <user>, <pw>, <pin>...
    public string value; // literal value assigned to field
}

[Serializable]
public class FolderData
{
    public string id; // e.g. "cd146"
    public string name; // e.g. "Banks"
}

[Serializable]
public class SaveData
{
    public List<FolderData> folders = new List<FolderData>();
    public List<AccountData> accounts = new List<AccountData>();
}