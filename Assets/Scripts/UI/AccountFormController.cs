using UnityEngine;
using System;
using TMPro;
using System.Collections.Generic;

public class AccountFormController : MonoBehaviour
{
    // ============[ Variables ]============ \\

    public AccountData Account; // used to store the organization name and account_information fields

    [SerializeField]
    public TMP_InputField[] input_fields;


    // ============[ System ]============ \\

    public void Awake()
    {
        Account = new AccountData();

        // Iterate through all input fields, attaching listener that on end edit will update the dictionary.
        foreach (TMP_InputField field in input_fields) 
        {
            field.onEndEdit.AddListener() => UpdateAccountData(field.Name, field.Text);
        }
    }

    // ============[ Background Functions ]============ \\
    
    public void UpdateAccountData(string label, string information)
    {
       Account.account_information[label] = information;
    }

    public void Save()
    {
        
    }
}