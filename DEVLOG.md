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
that it may be in my best interest to utilize User Stories as a way of organizing my thoughts for this project as there will be many difficult branches, so we need a strong foundation. Found in the file `UserStories.md` are my mostly filtered notes for 'User Stories' formed as Use Cases that elaborate on the action the user can take, and explaining what happens from the front end to the back end, including edge-cases.

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

# Day 5: Control Development and Refinement of Current Structures (3/28/2026)
First thing's first since this is now a public repository is to clean up the mess that was the initial README.md and separate my ramblings into a proper devlog, as well as separate my 
user stories into their own file that I can come back to more frequently as the project progresses.

Second thing was to address my todo list left on Day 4.


