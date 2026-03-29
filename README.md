# FCA
The Filing Cabinet for Accounts application is meant to store credentials related to accounts across the board, creating a streamlined experience searching and fetching pesky passwords or pins for one of the hundred accounts you have to make nowadays.

## Naming Conventions and Syntax:
*Classes, Methods/Functions, Folders/Scripts, and Instance's of a Class*: `UpperCamelCase`
*Instance Variables*: `lower_snake_case`
*Static Variables*: `Upper_Snake_Case`
*Const/Readonly Variables*: `ALL_CAPS_SNAKE_CASE`

# [Scripts](Assets/Scripts)
Inside this folder (considerably the `main` directory) contains the major working components for the project, organized as `Core`, `Data`, and `UI`. The `UI` folder contains scripts that 
are intended to interact directly with users, usually containing files with the postfix `Controller` to denote the functionality. `Data` contains scripts that deal with the ingest and egress
processes with data, including serialization. Lastly, `Core` contains scripts that deal with fundamental background logic to the total application.

*Generally, anyone perusing this repository won't find anything of interest (that isnt already in Unity's own API documentation [https://docs.unity3d.com/6000.0/Documentation/ScriptReference/index.html]) outside of the `/Scripts` and `/Scenes` folders.*

# [Scenes](Assets/Scenes)
This folder possesses all scenes in the project, you can find in each scene file the meta data used to put together the Unity UI elements and how they interact with the scripts made for the project.