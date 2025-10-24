# FCA
The Filing Cabinet for Accounts application is meant to store credentials related to accounts across the board, creating a streamlined experience searching and fetching pesky passwords or pins for one of the hundred accounts you have to make nowadays.

# Day 1: Scoping out the project

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

# Day 2: Save System and Initial Front-End

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