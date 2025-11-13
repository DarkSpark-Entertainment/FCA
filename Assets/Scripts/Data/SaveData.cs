using UnityEngine;
using System;
using System.Collections.Generic;

/**
* Allows for quick searching for accounts based on their 'organization' attribute. Additionally
* establishes a folder-account relationship via the folder_id.
*
* This class while not static, can have a static instance made elsewhere that allows for one copy of the
* SaveData to be accessible across all scripts. Serializable tells Unity that this data can be saved and stored.
*/

[Serializable]
public class AccountData 
{
    public string folder_id; // e.g. "cd145" or "undefined"
    public Dictionary<string, string> account_information = new(); // 1 = user, pw, pin, etc, 2 = literal value assigned
}

[Serializable]
public class SaveData
{
    public Dictionary<string, AccountData> accounts = new(); // 1 = organization_name, 2 = AccountData (see above)
    public Dictionary<string, string> folders = new(); // 1 = folder_id, 2 = folder_name
}