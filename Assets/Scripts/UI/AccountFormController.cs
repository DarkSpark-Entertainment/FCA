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
            TMP_InputField captured_field = field; // Safety net to ensure we obtained the correct datatype
            // input_text is a value given by onEndEdit after its been invoked.
            captured_field.onEndEdit.AddListener((input_text) => UpdateAccountData(captured_field.name, input_text)); // the line `(input_text) =>` is a *function reference*, which is using everything after as its function body (e.g. us passing in input_text like an argument)
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