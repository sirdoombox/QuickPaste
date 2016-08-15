# QuickPaste

A utility written in C# using WPF designed to make quickly pasting code-snippets online a little more convenient. 

## Screenshots
![Settings](http://i.imgur.com/drrySUP.png)
![History](http://i.imgur.com/JopHZkR.png)

## Current Features
- **Paste History** - *Keep a record of all your previous pastes*
- **Default Language Extensions** - *Set a default language and completely ignore Hastebin's often poor attempts at guessing what language your snippet was written in*
- **Minimise To Taskbar & Start On Windows Startup** - *Run it in the background and never worry about it again, it'll always be there for you*
- **Custom Hotkey Binding**  - *Define your own key combination for quick-pasting*
- **Mutiple Upload Locations** - *Upload your pastes wherever you like!*

### Supported Upload Locations

| Location | API Key Required |
| -------- | ---------------: |
| Hastebin | No               |
| Pastebin | Yes              |

## Planned Features
- **Paste Notes** - *Quickly make a note in your paste history reminding you what a paste contains - Make it easier to find in the future*
- **Paste Sorting & Searching** - *Sort and search through the dates & note contents to make it even more convenient*
- **Multi Hotkeys** - *Set up multiple hotkeys for seperate languages to make working with multiple languages a little easier*
- **Additional Upload Locations** - *Improve the selection of available paste upload locations*

## Tools Used
* **JSON.NET** - *Used for BSON serialisation of user data*
* **MahApps.Metro** - *UI graphics toolkit.*
* **NotifyIcon** - *System Tray Icon*
* **Costura.Fody** - *Embedding references into assembly*
