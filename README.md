# Lincoln Baby Lab - Andrew Irvine

File Guide:

Basler/BaslerCam.cs - Camera class. Instantiate once per camera

Create/AttnGetterWindow.cs - Selects image and sound for attention getters

Create/Create.cs - Create window. Used to set up trials

Create/NewBlockTextInput.cs - Popup dialog for new block

DataAnalyser/DataWindow.cs - Reads outputs of Present and Score to make final output

Present/Present.cs - Sets up trials, controls cameras and starts the window on the other screen

Present/PresentKBOp.cs - Settings window for changing the keys used to control the trial presentation

Present/pressKeyDialog.cs - Input window for key config

Present/StimWindow.cs - Window that shows on 2nd screen and shows the stimulus. Accepts input, needs to have focus during trials

utils/utils.cs - Class for custom functions that may be needed by more than one class

MainMenu.cs - Main menu that launches sub sections. Makes sure we have stimulus and displays progress of present/scoring etc.

MainPrefs.cs - Settings that are used across the program, like Stimuli location

PlainTextInput.cs - Popup dialog for Project name

Program.cs -The main entry point for the application

randOptions.cs - Proably no longer needed randomisation dialog

ReadXML.cs - Reads and writes XML files, currently just the .bex file

ScoreOCV.cs - Loads output and videos of each particpant for scoring, uses OpenCVSharp
