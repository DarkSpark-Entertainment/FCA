# FCA
The Filing Cabinet for Accounts application is meant to store credentials related to accounts across the board, creating a streamlined experience searching and fetching pesky passwords or pins for one of the hundred accounts you have to make nowadays.

## Naming Conventions and Syntax:
*Classes, Methods/Functions, Folders/Scripts, and Instance's of a Class*: `UpperCamelCase`
*Instance Variables*: `lower_snake_case`
*Static Variables*: `Upper_Snake_Case`
*Const/Readonly Variables*: `ALL_CAPS_SNAKE_CASE`

# Day 1: Scoping out the project (10/25/2025)

Expected goals are to create the rough abstract of the project, and get the outline going as well as establishing the repository, the Unity project, and the baseline
for how the program is expected to behave for the user. Below is the projected functionality of the file structure:

```
1 - we read the save file (key = name of organization e.g. Wells Fargo, value = table of strings e.g. username, password, email, pin, security questions). 

2 - The key would have a "<>" that contains an ID that was generated with the folder the file belongs to (or "null" if there is no folder assigned during file creation)

3 - the values will each have a flag identifier as well to determine where to be placed, done in the same fashion as above (e.g. <user>, <pin>, <pw>, <em>, etc) 

4 - while reading the save file we make gameobjects looking at the value id's and filling out the form, afterwards storing and then hiding it in the main scroll pane. 

5 - lastly, we unhide the gameobjects that are allowed to be viewed at start, which is only folders, denoted by the value being completely empty, and when we open a folder, all folders are hidden, and only the file cards associated with that folder via its ID will be made visible.

6 - if the user clicks the back button that generates on the top left, the files will be hidden again and all folders will be made visible.
```

Additionally there will be a pin code to get into the app that has to be brought into the save system somehow, and potentially it would be nice to add the feature of fingerprint
verification to access the app rather than just a pin option.

# Day 2: Save System and Initial Front-End (10/27/2023)

Expected goals are to create the three main pages (Pin Pad, Accounts, and Account Creation). Then, add the necessary buttons on the Accounts and Account Creation screens:

## Initial Front-End

### Accounts
- Back Button
- Settings Button
- Search Bar
- Main Scroll Pane
- Create Account Button

### Account Creation
- Main Scroll Pane
- Back Button
- Folder Assignment Combo Box
- Account Name Field (e.g. Wells Fargo, Chase, Github, etc)
- Username Field
- Password Field
- Email Field
- Pin Field
- Security Questions Drop-Down Button
- Add Security Question Button (adds one field underneath the auto-generated first 3)
- Security Answers 1-3
- Create Account Button (finishes process and kicks to Acccounts Screen)

## Save System

The coding segment expected would be to create a JSON enc/dec system that takes the information as outlined on Day 1, and being plugging it into the front end we made prior.

### Notes
These are to be organized later:

- The animation for settings pane will be fast to gradual coming in, and then quick exit.
- Settings includes a switch for Light Mode/Dark Mode, a checkbox for 'Censor Passwords', a checkbox for 'Auto-unhide File Contents when Searching', a checkbox for 'Fancy Animations', and a download button for 'Download Zip of all Accounts'
- The animation for creating an account will fade out the button and take a white circle expanding to cover the whole screen, scene change, and then a white circle shrinking until it covers the area for the back button on the account creation screen, and that button then fades in.
- When pressed and held down on a file, a small settings pane appears that has the options "Edit", "Move to..." and "Delete"
- The username and password are required fields, but the username can also be opted for an email instead, so if the user type an email in, it will make the username not required any longer, and vice versa.

# Day 3: Save System Overhaul and Organizing Script Logic (11/13/2023)

So, none of the layout goals were met because I was interrupted a while back during a dev session and then was hit with a wave of work so overwhelming that I started falling behind even in basic chores around the house. With that being said, getting back onto the horse was not easy as the state of the project was a mess due to me throwing around several ideas during the last development day. Below is what was accomplished on the actual "Day 2" but is being put as Day 3 due to the time skip.

## The Changes Between Day 2 and 3

The SaveSystem was overhauled to store a static instance of SaveData, called CurrentData, which will act as the only instance throughout the project. Additionally to support the totality of its new static behavior--and to avoid unnecessary called to LoadDataFromFile (now just called Load())-- there is a new 'Core' script called Initialize which calls Load() to essentially jumpstart the application.

SaveData was only slightly tweaked, but the functionality has been changed from Day 1's initial concept. No longer are we attempting to add tags to the variables, but opted to just have Dictionary's to store the data in a lovely key-value pair fashion. Additionally, I decided to keep the folder_id logic only because it is a helpful tool for idiot proofing the folder creation later.

Calls in SaveSystem were simplified from their overly verbose nature to simply Save, Load, and Delete, with comments added to describe them instead. Aids heavily in readability.

Speaking of readability, I also decided to enforce a naming convention:
*Classes, Methods/Functions, Folders/Scripts, and Instance's of a Class*: `UpperCamelCase`
*Instance Variables*: `lower_snake_case`
*Static Variables*: `Upper_Snake_Case`
*Const/Readonly Variables*: `ALL_CAPS_SNAKE_CASE`

Which is fairly new for my standards, but I want to get into better care for my naming conventions so that it's easier to read the code without 'reading' the code, ya know?

SaveDataManager got refactored to SaveDataController and was organized in a new series of folders `Core`, `Data`, and `UI`. It belongs in `UI` along with another new file AccountFormController. These scripts handle GameObject logic and will be interacting directly with users (hence the name Controller), SaveData and SaveSystem both deal directly with memory, so they get put with `Data`, and Initialize and SceneContext (another new file that stores literally just a boolean and key to determine whether an account is being created or edited) are in `Core` due to them being fundamental to background logic. Last one is a bit of a stretch but works for now.

# Day 4: User-Cases and General Development Planning (3/26/2026)

Per the usual, it's been a while. Getting back into the swing of things was a bit interesting as I had decided my initial strategy wasn't the most intuitive. Taking a step back it came to my attention
that it may be in my best interest to utilize User Stories as a way of organizing my thoughts for this project as there will be many difficult branches, so we need a strong foundation. Below are my 
mostly filtered notes for 'User Stories' formed as Use Cases that elaborate on the action the user can take, and explaining what happens from the front end to the back end, including edge-cases:

## User Stories (sort of)

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

## The Changes of Day 4

SaveData was refactored, opting to go for intentional redundancy in the data handling. While the GUID's made for the accounts and folders
are used as the keys now in SaveData's dictionaries, they are also stored in the data types themselves. This is because they will be used
independently to the dictionary to create the associated GameObjects. Additionally, it allows the objects to become entities, meaning that
if we wanted to make independent changes to it, we can, and can easily find where it is associated and make edits, adjustments, and save 
at a much faster pace.

I then debugged AccountFormController, attempting to understand my pseudo-code that was half-baked thoughts. Making a breakthrough with understandings
of the syntactic sugar that is lambda expressions, I managed to get the compiler errors to cease and left notes for me to continue referencing to 
reinforce the use of AddListener() as well as Unity functions as a whole (such as onEndEdit).

Going forward for day 5 is listed below:

- Hook up Save() to the SaveSystem
- Replace all scripts that are missing on the SceneManager
- Hook up the button and text fields to the new scripts
- add print outs for debug purposes in AccountFormController and SaveDataController
- Add remaining fields for testing
- Plug those fields into the script and test the automation process
- Begin developing methods inside of SaveDataController

After those are implemented we can move on to some of the next planning phases. UI for this project will be put on hold until the major functions are operational,
which includes the pin pad screen as well as the saving, editing, and deleting of accounts and their respective folders. Then we move on to the search features, and then 
the ZIP file feature, and FINALLY we can move on to the more technical and advanced sections (e.g. biometric login, use of app outside of itself, and press and hold features.)

After all that, we can move onto UI and then porting it onto a phone.
