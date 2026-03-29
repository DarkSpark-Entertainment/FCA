`INITIALIZATION`
- Pin Pad Scene is displayed
- Load Accounts scene in tandem via a coroutine (SaveSystem.Load())
- populate accounts listing
  + Use SaveData.folders[0-N] to first populate folders in scroll view
  + SaveData.folders[0-N][0-N] is used to create and hide Account Cards (gameobject with information filled out for the related account)
  + Use SaveData.accounts[0-N] to populate the remaining Accounts that are not in a folder
- Wait for user to input PIN or use biometric
- Move to pre-loaded Accounts scene

`USE CASE #1 | FOLDER IS ENGAGED`
- Hide all other game objects via some kind of AccountListingController.HideAll()
- Reveal all accounts related to folder that was engaged. 
- put folder name in search bar (leave operable)
- EDGE CASES
  + 1 | USER ENGAGES SEARCH BAR
    - when search is engaged it should state 'Searching [Folder Name]...' and override Search Bar's base script to search exclusively that folder.
    - when search is cleared, bring back folder name (utilize TMPro placeholder text)
    - repopulate accounts in folder as needed

`USE CASE #2 | ACCOUNT IS ENGAGED`
- Expands the account card revealing all user information.
- All fields (save for the security questions) are copy and pasteable via a single tap.
- If the user presses on the account name it will recollapse hiding the information.
- Password and security questions are censored until they are held-pressed for 2 or more seconds revealing the information. 
  + If the password is tapped, it copies it, if its held then it behaves as described above.
- EDGE CASES
  + 1 | USER EXPANDS ANOTHER ACCOUNT/FOLDER
    - Automatically collapse the previously engaged account to avoid readability issues.

`USE CASE #3 | ACCOUNT IS HELD`
- If an Account GameObject is held for 2 or more seconds, 5 buttons will populate next to where the user pressed
- Create Folder
  + Will shade the background and bring a name textfield to fill out as well as a checkmark to mark creation
  + when checkmark is pressed, whatever was in the textfield will be used to create a folder object, assign its name, and the account to its listing.
  + The Folder will populate in the main listing and the account will be hidden unless that folder is engaged.
    - Should we automatically go into that folder? functionally doesnt make sense but *feels* intuitive.
- Move Folders
  + Shades the background and provides a dropdown that has all folder names
  + Checkmark is populated next to the dropdown, once pressed the account will be moved into that folder and removed from any previous folder it was in.
- Edit Account
  + will bring the user to the account creation page
  + fills out form automatically with previously stored information.
  + user can make changes freely, changes are automatically stored in local cache but nothing changes until they press the SAVE button.
  + User will be brought back to the main screen with account opened where they were (including if they were in a folder)
- Delete Account
  + Brings a warning panel up that confirms deletion
  + user can either back out using the "Nevermind..." button, or confirm with "Delete." button.
  + Upon deletion the AccountGame object is purged from listing, taken out of SaveData.Accounts, removed from any folders containing its ID, and then SaveSystem.Save() is engaged.
- Exit
  + A small circle with an 'X' inside allows user to back out of selection entirely.

`USE CASE #4 | FOLDER IS HELD`
- If a Folder GameObject is held for 2 or more seconds, 3 buttons populate next to where the user held down.
- Rename Folder
  + Shades the background and provides a textfield and check mark
  + Textfield is auto-populated with the current name
  + When check mark is pressed, whatever is inside the textfield is saved as the new name.
    - SaveData.Folders is then updated, as well as the GameObject associated with this folder.
- Delete Folder
  + Same as delete account, brings a warning panel confirming deletion, "Nevermind..." and "Delete." are provided.
- Exit
  + A small circle with an 'X' inside allows user to back out of selection entirely.


## Additional Features

Additionally, a few more features have been baked in the oven and I wish to include them:
- Biometric access is becoming more and more of a must.
- Press and Hold Override
  + This is tricky, an Android user can press and hold on a textfield and some options populate for pasting, select all text, etc.
  + I want to add buttons to that field OUTSIDE OF THE APP, meaning that 
    - FCA has to be allowed to run in the background at all times waiting for the user input override.
    - Permissions must be given
    - FCA must be allowed to add onto the button listing in some way or another.
  + What these buttons will do?
    - Add a Search button with FCA logo nearby to show the user what it is.
    - when engaged the user can simply search the account they need, and it will bring a tiny info
      card out that has the username and (censored) password, which the user can press to copy and then 
      paste into the textfield.