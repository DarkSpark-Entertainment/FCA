using UnityEngine;
using System;
using TMPro;
using System.Collections.Generic;

public class AccountFormController : MonoBehaviour
{
    // ============[ Variables ]============ \\

    private AccountData Account; // used to store the organization name and account_information fields

    [SerializeField]
    public TMP_InputField[] input_fields;
    public TMP_InputField DisplayName; // Denoted as display_name for accounts
    public TMP_InputField FolderName; // If a value is assigned, will trigger the creation of a folder on a SaveAccountData action


    // ============[ System ]============ \\

    public void Awake()
    {
        Account = new AccountData();

        // Iterate through all input fields, attaching listener that on end edit will update the dictionary.
        foreach (TMP_InputField field in input_fields) 
        {
            TMP_InputField captured_field = field; // Safety net to ensure we obtained the correct datatype
            // input_text is a value given by onEndEdit after its been invoked.
            captured_field.onEndEdit.AddListener((input_text) => UpdateAccountData(captured_field.name, input_text)); // the line `(input_text) =>` is a *function reference*, which is using everything after as its function body (e.g. us passing in input_text like an argument)
        }
    }

    // ============[ Background Functions ]============ \\
    
    public void UpdateAccountData(string label, string information)
    {
       Debug.Log($"[AccountFormController]: Label- {label} Information- {information}");
       Account.account_information[label] = information;
    }

    public void SaveAccountData()
    {
        // Check if FolderName is empty, if not, cross check if the folder already exists.

        // if folder exists, assign its id to this account

        // if not, create new folder

        // Assign DisplayName

        // Create account (already saves on creation)
        
    }
}