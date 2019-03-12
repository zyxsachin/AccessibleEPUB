# Accessible EPUB changelog

## 0.1.10
- Removed bug where the AccessibleEPUB temp folder is not created and therefore an error is shown
- Removed bug where "StartIndex can not be less than 0" is shown. This was due to the element "alttext" being removed when a math formula figure is added, now it has been added again
- Removed the problem with the global saving 
- Resizing of windows is possible below a certain size is now possible
- The file dialogs remember the last directory location
- Removed bug where CSS files opened with the "Open With" command crash
- Removed bug where the program would crash if non-existent file was opened with the "Open With" command
- Removed bug where the program would crash if a file with no text would be saved
- Added keyboard shortcuts for adding inline formulas and conversion to inline formulas
- The title of the window now changes after "Save As"
- Adjusted font size difference between lists and normal text
- Scroll lock has been added to prevent the preview from scrolling to the bottom after every change
- Added page breaks and page numbers

## 0.1.9
- Changed date of last modified of a new file to creation point
- Pausing refresh now works earlier and avoids extra overhead
- The LaTeX parser can now be deactivated so that any formulas recognized by pandoc can be inserted, but at the cost of error proofing
- Fixed a bug where only one math formula can be added as a figure in a session 
- Fixed an issue, where having too many inline formulas would slow down the program substantially as they converted in real time to show in the preview. Now they won't be converted in real time, and a button has to be pressed instead if there are too many formulas

## 0.1.8
- Added ability to insert inline math by surrounding them with two dollar signs
- Updated Gecko Browser to the newest version

## 0.1.7
- Converter between CSS and JavaScript versions
- Added logo
- Can open EPUB files with Accessible EPUB
- Fixed text type recognition with mouse click and that <span> elements are created automatically

## 0.1.6
- The exception caused when hitting a key in an empty editor is now removed
- Fixed the error when inserting images with width and height
## 0.1.5
- Feature to seek position of editor with Header and Figures
- Changed how tables appear in the standard
## 0.1.4
- Ability to edit images and formulas after being inserted with mouse and keyboard
- Ability to change ordered and unordered list style
- Fixed import text so that the inserted text is not treated as one block
- Alternative images can be added
- Images and math can have float align property added
