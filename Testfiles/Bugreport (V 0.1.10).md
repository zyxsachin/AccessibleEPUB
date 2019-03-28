> Erste Besprechung am 09.01.2019

#ToDo (Ulrich)


- [x] (A) Bugreport fŤär overide Parser typing wrong formula breaks everything
- [x] (B) Check header shortcut
- [ ] (C) Top1: Neues Logo
- [x] (D) Sigil anschauen
- [ ] (E) Brailleauthority.org checken http://www.brailleauthority.org/ueb/symbols_list.pdf
- [ ] (G) **Inline**: MathML durch Pandoc, **figure live Preview**: WPF-Math, **figure in Text**: Wpf as svg
- [ ] (H) Handbuch?
- [x] (I) < and > symbols after saving/reopening file. **-> Use \lt \gt instead**
- [ ] (T) Liste der TeX-Befehle die aus Blindenversion rausgefiltert werden müssen.
- [ ] (S) Shortcuts need to be listed all at one place, to gain overview and adapt them best. Possible combination with Graphics-list?
- [ ] (B) BMWF is to be checked out
- [ ] (N) NVDA is a freely accessible Screen reader for Windows (recommend with the Windows-voices), and can be used to test the AEPUB-files.
- [ ] (Q) Formatting possibilities: begin and end markers for subparagraphs like examples? -> eventuell nur für Einrückungen
- [ ] High: (L) Insert newly implemented Linebreaks to HM-Skript, +beautify it.



#Pending Tests (Ulrich)

- [ ] _Test (tF)_ Inline Formeln überprüfen zwischen pandoc und epub
- [ ] _Test (tD)_ Additional tests related to manually set font-sizes influencing the displayed font-size in ebook-readers are required.
- [ ] _Test (GreaterThan)_: The replace function concerning `<` and `>` symbols has been implemented
- [ ] _Test (Preview)_: A button has been implemented to allow [refresh of preview browser] without [scrolling to the bottom every time].
- [x] _Test (tF)_: A shortcut launching the inline-formula conversion has been implemented with CTRL+Shift+C.
  --> It works.
- [ ] _Test (tP)_: Page breaks are not 100% reliable yet. Investigation pending
- [x] _Test (Void)_: A new line (\n) is added after creating a new file to prevent this.
- [x] _Test (Safeplace)_: Save as in Windows title of the window is not updated to the new file name 
- [ ] _Test (Reader Fontsize)_: The text size of lists and normal text should now be fixed, but still has to be tested.
- [ ] 






#Table of Abbreviations

| Table of Abbreviations: | Javascript | CSS  |
| ----------------------- | ---------- | ---- |
| English                 | EJ         | EC   |
| German                  | GJ         | GC   |

# Table of Bugs
|      | Defining Problem types:                                   | Short Description                                            |
| ---- | --------------------------------------------------------- | ------------------------------------------------------------ |
|      | "Crash"/"Crashes"                                         | GUI is greyed out, Windows-Box appears "ACCESSIBLE EPUB" stopped working with single option "close" (or "exit"), then the editor-Window closes. |
|      | Error Message                                             | An info-box with red cross opens, reporting an unhandled exception. |
| [x]  | Leroy                                                     | "StartIndex is Less than Zero" ;)                            |
| [x]  | Leyline                                                   | Editor crashes when modifying an inline-formula in files opened from Win-Explorer, EN-CSS. |
| [x]  | Void                                                      | Saving a newly created empty file causes an error message.   |
| [ ]  | Preview                                                   | Preview jumps unavoidably to the bottom.                     |
| [ ]  | Idle                                                      | Program closes unexpectedly when open but not in use. *Requires further testing.* |
| [ ]  | ListNumerBreaks                                           | List behaviour when changing symbol for unnumbered list breaks list. *Requires further testing.* |
| [ ]  | TextImport                                                | What does `Import Text` do?                                  |
| [ ]  | Preformatcolour                                           | Text colours and applying/changing Preformatting             |
| [ ]  | [ParserFeedback](#[[Bug](#Table of Bugs): ParserFeedback) | Preview actualisation of Parser-incompatible figure formulas does not give feedback of working. |
| [x]  | Safeplace                                                 | Window title does not change according to filename used in "save as..." |
| [ ]  | Metadata                                                  | Metadata missing in Reasily                                  |
| [ ]  | Macbreaks                                                 | Pagebreaks in Mac/iOS default ebook-reader                   |
| [ ]  | Reader Fontsize                                           | the fontsize between lists and plain text varies too much    |
| [ ]  | GreaterThan                                               | Handling of `<` and `>` symbols inside inline formulas is problematic. |
| [ ]  | Traces                                                    | Older files not being forward-compatible with some features. |
| [ ]  | CopyLess                                                  | Copying text from one instance to another causes problems when pagebreaks are included in the copied content. |
| [ ]  | PageCounter                                               | The increase in the page numbering does not consider deleted page breaks |

---

#List of features wished for:

- [ ] (very high) Pagebreak, with number and STRG+Enter, using the epub3-standard, as well as the SZS standard: `<seite>X<\seite>`
- [ ] (high) Scroll sync/lock between editor and preview panel (edited area should match previewed area).
- [ ] (very low) Possibility to load barrier free pictures in the file, that are associated to the normal images and could eventually be printed. (or create "linked" additional-file?) --> See Fragen an SZS
- [ ] Keyboard Shortcut to start rendering of inline formulas? --> See ToDo (S). 
- [ ] Keyboard Shortcut to insert inline-formula (inserts $$ $$ in editor).
- [ ] (low) Possibility to insert text "blocks". For Quotations or coloured/highlighted paragraphs? Already done via indent? Requires feedback.
- [ ] Possibility for me to access and modify the used menu-icons via git.
- [ ] Search/Replace function
- [x] **Table of EPUB readers and compatibility**
- [ ] Hierarchised Headers Sidepanel
- [ ] To ease development: a menu-button opening the path to the temp-folder containing the file in windows explorer.
- [ ] (medium) TeX-Filter for blind-version only, removing unnecessary layout/formatting-commands. --> See TeX-Limitations.md
- [ ] (high) Footnotes. Inline or linked syntax? --> Needs testing.
- [ ] 



---

# V 0.1.10

## Accessible EPUB changelog

### 0.1.10

- Removed bug where the AccessibleEPUB temp folder is not created and therefore an error is shown
- Removed bug where "StartIndex can not be less than 0" is shown. This was due to the element "alttext" being removed when a math formula figure is added, now it has been added again
- Removed the problem with the global saving 
- Resizing of windows is possible below a certain size is now possible
- The file dialogs remember the last directory location
- Removed bug where CSS files opened with the OS's "Open With" command crash
- Removed bug where the program would crash if non-existent file was opened with the "Open With" command
- Removed bug where the program would crash if a file with no text would be saved
- Added keyboard shortcuts for adding inline formulas and conversion to inline formulas
- The title of the window now changes after "Save As"
- Adjusted font size difference between lists and normal text
- Scroll lock has been added to prevent the preview from scrolling to the bottom after every change
- Added page breaks and page numbers

---



> 27.01.2019 16:30 - 19:00 :ballot_box_with_check: 

Installed Version 0.1.10.

Took a look at sigil: (with EC file)

- The behaviour of mode-switching is not as expected. The preview does not render it differently, and the editor jumps to the top. 

- Sigil seems to handle math internally, as switching View-mode starts a "Processing math" process in the preview, followed by a "Typesetting Math" process.
- Sigil does not render the Figure-Formulas in the preview. Displays "<u>[Math Processing Error]</u>" instead. Editor works fine.



Tried som TeX:

- In Testfile EN-CSS: Inserting Linebreak and inline-formula crashes the program.
- File seems to be broken
- Recreating it. -> Works now

Further TeX:

- (EC)(inline) Some commands provided by amsmath are not working, although the package is included in the conversion with pandoc. E.g.: `\dotsm`. Reported in TeX-Limitations.
- Testfile EN-CSS broken again???
- HM-Skript_Css still opens and handles edits correctly.
- <u>Major</u>: (EC) Editing or inserting inline-Formulas crashes the editor. Codename: <u>Leyline</u>



### Major: Leyline

From Windows-Explorer, and with activated automatic refresh preview:

Opening any file with EN-CSS settings works, but as soon as

- click into an inline-formula area
- A formula is added
- ~~some time has passed?~~ 
- adding characters/linebreaks behind a formula.
- SIMPLY ADDING TEXT in a file already containing inline-formulas.

and then, the 

- info-box about deactivated automatic refresh gets closed

The program crashes.



Does not concern Java-Files. Does not concern files empty of inline-formulas before opening.

Bug seems related to the info-box about automatic refresh.



> 29.01.2019 Sachin contacted me, the Leyline-bug seems to be fixed. Tests pending. Changelog above synchronized with the released changelog.

> 29.01.2019 18:00 - 19:10 :ballot_box_with_check:

Began listing required icons for graphical update.



#V 0.1.10 #1,5 (In-Between Bug correction)

Reinstalled V0.1.10 with actualised installer, in which the Leyline-Bug has been corrected.

- Bug does not seem to appear for Testfile EN-CSS.epub. Well done! :thumbsup:

Exported Logo-sketch to .ico. Will be tested for next release.



> 30.01.2019 19:00 - 20:45 :ballot_box_with_check:

Leyline did not reappear.

(B): Shortcuts for headers are not set. I don't know how I came to believed this last Christmas. Neither on the laptop with the old version, nor on desktop do they work, independently of keyboard configuration.



> 01.02.2019 16:00 - 17:30 :ballot_box_with_check: 

Testing the "import text":

Extracted pages 59-61 from test PDF to import in EC file.

- Have a file open.
- Select "new file"
- Create new file (title, author, publisher, EC)
- clicked "import text". Nothing happens. I leave the file empty and click save.

- <u>Error message:</u> `Value cannot be null. Parameter name: input` 

```
************** Exception Text **************
System.ArgumentNullException: Value cannot be null.
Parameter name: input
   at System.Text.RegularExpressions.Regex.Matches(String input)
   at AccessibleEPUB.Form1.wysiwygToHtml()
   at AccessibleEPUB.Form1.saveFile()
   at AccessibleEPUB.Form1.saveButton_Click(Object sender, EventArgs e)
   at System.Windows.Forms.ToolStripItem.RaiseEvent(Object key, EventArgs e)
   at System.Windows.Forms.ToolStripButton.OnClick(EventArgs e)
   at System.Windows.Forms.ToolStripItem.HandleClick(EventArgs e)
   at System.Windows.Forms.ToolStripItem.HandleMouseUp(MouseEventArgs e)
   at System.Windows.Forms.ToolStripItem.FireEventInteractive(EventArgs e, ToolStripItemEventType met)
   at System.Windows.Forms.ToolStripItem.FireEvent(EventArgs e, ToolStripItemEventType met)
   at System.Windows.Forms.ToolStrip.OnMouseUp(MouseEventArgs mea)
   at System.Windows.Forms.Control.WmMouseUp(Message& m, MouseButtons button, Int32 clicks)
   at System.Windows.Forms.Control.WndProc(Message& m)
   at System.Windows.Forms.ScrollableControl.WndProc(Message& m)
   at System.Windows.Forms.ToolStrip.WndProc(Message& m)
   at System.Windows.Forms.Control.ControlNativeWindow.OnMessage(Message& m)
   at System.Windows.Forms.Control.ControlNativeWindow.WndProc(Message& m)
   at System.Windows.Forms.NativeWindow.Callback(IntPtr hWnd, Int32 msg, IntPtr wparam, IntPtr lparam)

```

- Select `Continue` 
- Program stays stable, I enter a single letter in the editor. Preview gets rendered.
- Save, exit. Select "no" in info-box about saving file before exit.
- reopen file. It is empty. 
- Enter single letter, click save.
- Close, no save-warning.
- Reopen file, content is saved. 

^ The first saving attempt seems not to have worked.

- **Minor:** (EC+GC): An empty line needs to be inserted automatically at the very beginning of the document. For now, it is possible to write in the first line next to the CSS selectors.

Trying above bug again:

- Program start

- Choose "crate new file". Done with title, author, publisher, EC.
- Leave editor empty.
- Click save icon.
- <u>Error Message:</u> Like above.



### [Bug: Void

Empty newly created files cannot be saved by clicking the icon or pressing CTRL+S, and cause an error message.

However, they are written on the hard disk and use non-null disk space.

Selecting `continue`does not cause the program to crash.

The empty file can be reopened after this (WinExp), and saved without problems. 

**Solution idea:** Insert a non-deletable empty line by default in new documents to avoid this, which could also solve the problem of users writing in the same line as the one in which CSS selectors are placed.

**Update -13.03:** A solution has been implemented to avoid this, by inserting an automated new line in any new document.

_Tests:_ An empty file can now be saved correctly and the program behaves as expected. No error message was returned. However,  it is still possible to write on the Mode-Switcher line using the first line in the editor. Interestingly, the inserted line by default is not deletable, as clicking in the editor forces the cursor to be on an existing empty line.

**]**



Trying text import again, using pdftotext (on windows) preliminarily.

pdftotext does not like the pdf (returns three bold upper arrows). But it likes the exported _Bugreport(V0.1).pdf_ ...

**Update**: the windows powershell stinks.

- (EC) insert exported text into the editor. 
- Preview turns yellow and says:
  XML Parsing Error: reference to invalid character number Location: file:///C:/Users/Zauberherrscher/AppData/Local/Temp/AccessibleEPUB/Testfile2%20EN-CSS/OEBPS/Text/Content.xhtml Line Number 20, Column 2041:
  <u>with red text below corresponding to the source of the whole file.</u>
- The Line+Column number do not correspond to the source txt but to the temp file.
- Screenshot:

![1549038594220](ARCHIVE/1549038594220.png)

- exited without saving the file.

This behaviour is hard to understand. The problematic characters are: `&#xC;V0.1.9:`, more exactly the #. However, this is not the only place in original file where a Header was set with the markdown syntax `# Text`. The extracted .txt file contains the symbol `` at this position. Notepad++ renders it as FF:

![1549127153113](ARCHIVE/1549127153113.png)

And Typora displays it as a red dot in the source view of the markdown document:

![1549127263722](ARCHIVE/1549127263722.png)

This is supposedly an error caused by pdftotext, but could also be created when converting a markdown file to pdf using Typora. Also possible: encoding inconsistency.

> 02.02.2019 17:00 - 18:45 :ballot_box_with_check:

Created Bugreport(V0.1)_cleaned.txt in which the problematic symbols have been removed.

The text cna now be copy/pasted without problems in the editor.



###[Bug: Preview

The preview jumps back to bottom. Scrolling up only in the preview is not possible. This is independent of the cursor position and takes half a second after releasing the scroll wheel.

**Update - 09.02:** Now it is locked at the top? (HM-Skript_CSS2.epub) Is this what you call "scroll lock"? :sweat_smile: 

**Update - 14.02:** The bug appears only after the "automatic refresh" info-box has been dismissed. Scrolling in both views works perfectly fine, until the editor window is selected and a text input is given. The bug makes the preview jump to the point it was at before dismissing the info-box.

**Update - 13.03:** A button has been implemented to allow [refresh of preview browser] without [scrolling to the bottom every time].

_Test:_ I have to dig further, but the behaviour is not fully satisfactory yet (I feel like it now jumps back to the place I first activated Scroll lock). The button should give feedback when it is pressed.

**]**





> 07.02.2019 20:00 - 22:45 :ballot_box_with_check:

### [Bug: Idle

Encountered random crash. Program was open while writing the manual, but not active excepted a few times in-between to test banal specific behaviour.

Happened two times.

Requires further documentation.

**]**



### [Bug: ListNumerBreak

Setting the Symbol for unnumbered lists to Square breaks the list.

Requires further documentation.

**]**



> 09.02.2019 20:00 - 22:00 :ballot_box_with_check:

Playing around with icons.

Continuing writing math script (corrected sections [0-1[ ):

###[Bug: Preformatcolour

the preformatting of a header does reset user-selected colors for the text.

- Write text line
- Set as header 3
- Set first word to green
- Set line as header 2
- green replaced with black

**]**

###[[Bug](#Table of Bugs): ParserFeedback

Replacing formula in figure-formula does not change the preview?

- Opening existing document, open edit window for pre-existing figure formula
- replace formula with something the parser doesn't recognise (use of `\cases` for example)
- select "override parser", close window
- Preview in Editor remains the same as before the edit. Double-click on the figure shows the new formula is saved.

**]**

## **Major:** <u>Safeplace</u>

 Opening an existing file (WinExplorer), "Saving as..." under a new name.

- The Window title of the program does not change to the new file name. 
- It is unclear, if saving will now replace the first file, or the newly created copy of it. <u>!!!!</u> (it actually does overwrite the newest copy)

**Update - 13.03:** The title bar should now display the last file name it was saved as.

_Test:_ It does.

**]**



> 14.02.2019 19:00 - 20:00 :ballot_box_with_check:

We have a problem concerning CSS-capable readers for Desktop (windows). Listed in Sachin's preliminary works are Reasily and Readium, but Reasily is Android-Only, and Readium is hard to access and currently only in an Alpha.2 release (see [here](https://github.com/readium/readium-desktop/releases)). This makes tests outside of the AEPUB-Editor difficult, and Sigil being an editor too, it is not really simulating the end-user experience.

- Readium does not display math figures

Quoting from the Bachelor's Thesis: "_In the preview browser in Accessible EPUB and when the individual XHTML ﬁles were opened in web  browsers, the switching mechanism behaved correctly._". The Idea of directly readable XHTML-Files intrigues me, and makes me question the advantages of EPUB-Readers. Wouldn't a modern browser not offer all necessary features? What would be missing?



Continue beautifying the HM-script:

- this time, I don't get the bug of the preview jumping to top/bottom...?
- CORRECTION: The bug appears only after the "automatic refresh" info-box has been dismissed. Scrolling in both views works perfectly fine, until the editor window is selected and a text input is given.
- Could there be a way to recognise wrongly rendered inline-formulas? So that they are rendered in a different color f.e.. Seems hard to implement as there are various reasons why it isn't recognized, or working.
- **Bug:** (Idle) Program crashed again after longer inactivity, without saving.



> 15.02.2019 18:00 - 19:00 :ballot_box_with_check:

Continue beautifying the HM-script.

- The < and > symbols seem not to be overwritten by editing the source.

TeX: Testing further the TeX commands `\lt` and `\gt`

- Writing in Testfile2 EN-CSS. Some text. First inline equation.
  - Save, close, reopen.
  - Add text, second equation.
  - Save, close, reopen.
  - Add text, third equation. All three with `\lt` and `\gt`.
    - So far, no problems occuring with rendering the < and > symbols.
- Add text, fourth equation, this time with `<` and `>`.
  - Save, close, reopen
- Add text, fifth equation, regular text <.
  - Additional `amp;` is added in front of previous `\lt`.
  - in-formula replaced by `&gt;`.
  - in-text unproblematic.
- Add text, sixth equation, regular text >.
  - Save, close, reopen
  - Enter text, seventh equation, regular text>.
  - Save, conversion adds additional `amp;` in front of each `lt;` or `gt;`.
- Trying to revert the bug:
  - replacing `&amp;lt;` with `\lt` seems to work here. But the HM-script does not behave the same way.
- HM-script: changed one single equation from `&amp;lt;` to `\lt`. (wait 8minutes...)
  - This seems to have worked.
  - Contrary to editing all formulas in one batch and converting only once.
  - <u>correction:</u> I must have reopened the content.xhtml too early after the changes, editing all `amp` to `\lt`s at once seems to have worked as expected.

### [Bug: GreaterThan

Opened 13.03: in order to group all updates here (should have been marked as a bug from the beginning).

The preview Browser is not capable of rendering `<` and `>` symbols inside inline formulas, displaying `&lt;` and `&gt` instead. This caused a loop where each time opening the file, an `&amp;` was appended. Also, this blocked the rendering of inline formulas (see tests above).

**Update - 13.03:** A solution has been implemented, where text inputs of `<, >` are replaced by `\lt, \gt`. Hence, the problem should be avoided now.

_Test:_ At which moment is the input replaced? Opening the older `Testfile2 EN-CSS.epub` and trying around by inputting new formulas including an `<` still gives the described behaviour from the bug.





**]**

> 25.02.2019 19:00 - 20:00 :ballot_box_with_check:

---

# Second Meeting on 28/02/2019

---

> 28.02.2019 10:00 - 11:25 Präsenz SZS :ballot_box_with_check:

Meeting to discuss "Fragen an SZS.md" and further development.

"Fragen an SZS.md":

- <u>Feature:</u> TeX-Filter einbauen? Vereinfachung der Formeln. I.A.: Konflikte zwischen Formatierung des Umsetzers und reduzierter Version für Blinde.
  - approved, requires list of TeX-commands (see "TeX-Limitations.md"), which can include the `\text{}`-command
- (ToDo (C)) Logo-Gestaltung // Feedback, Ziele, Anforderungen
  - approved. Haben vollkommene Freiheit.
- <u>Feature:</u> Konkreter, standardisierter Syntax für Seitenangaben (Ende der Seite?, <> oder (())?). Und: Unterstützung durch Screenreader? Konflikte EPUB/Screenreader?
  - `<seite>X<\seite>`
- <u>Feature:</u> Possibility to load barrier free pictures in the file,  that are associated to the normal images and could eventually be printed. (or create "linked" additional-file?)
  - wanted, but secondary
- _Test (Q)_ : The needed formatting possibilities need to be discussed: Textblocks for quotes/Coloured paragraphs? begin and end markers for subparagraphs like examples?
  - eventuell für Einrückungen

Other discussed themes:

- Sachin will leave the project at end of March/April to spend more time on his studies. He offers further assistance beyond his contract duration time.
- <u>Feature</u>: Linebreaks using the EPUB3-standard, they have absolute priority and are planned for end of April. Also, a first implementation is required for the 6th of March, as demonstration usage.
  Potentially, the CSS Mode-switcher could be displayed on each new page in a header.
- **Bug: ** Metadata is missing in Reasily, this requires further testing. (Also in Calibre and Readium.)  :ballot_box_with_check:
- _Test (B)_:  BMWF is to be checked out
- _Test (N)_: NVDA is a freely accessible Screen reader for Windows (recommend with the Windows-voices), and can be used to test the AEPUB-files.
- **Bug: ** the standard ebook-reader on Mac/iOS, pagebreaks are not working. Where lies the cause? To be tested on site at the SZS. :ballot_box_with_check:
- Again, list of usable ebook-readers:
  Marvin (iOS), Reasily (Android), Calibre+Readium (Win)
- **Bug:** tests for the font-size are required. (Bug with plain text being too small.) :ballot_box_with_check:
- <u>Feature:</u> Footnotes are a feature wished for.  On the long term, it has to be clarified, if they are to be written at the mark in the text, or just linked and developed further down below.
- _Test (tD)_: Additional tests related to manually set font-sizes influencing the displayed font-size in ebook-readers are required.

Github issues created during the meeting:

- Page numbers and page breaks (#9):
  Page numbers allow blind users to work better with normally sighted users, as they tend to use page numbers to go to a section of text. Page breaks should be added with a separate button or CTRL+Enter and the number of pages should increment automatically.
  Also add the changing hyperlinks right after the page number. First only do arabic numerals. Later roman numerals should be added.
- Replace text < and > through their LaTeX code (#13):
  Replace text < and > through their LaTeX code \lt and \gt, respectively.

:ballot_box_with_check: Needed tests and ToDos added to ToDo-List.

:ballot_box_with_check: ​Noted bugs added to Bug-List.

:ballot_box_with_check: Wished for Features and requirements added to Feature-list.



### [Bug: Metadata

The Metadata is missing in Reasily, this requires further testing. (Also in Calibre and Readium.)

Update (07.03.2019): Readium knows nothing, Calibre finds out the document language and title.

**]**



### [Bug: Macbreaks

In the standard ebook-reader on Mac/iOS, pagebreaks are not working. Where lies the cause? To be tested on site at the SZS.



**]**



### [Bug: Reader Fontsize

Further tests for the font-size are required. (Bug with plain text being too small.)

**Update - 13.03:** This has been corrected. Tests pending.



**]**

> 04.03.2019 22:30 - 00:00 Meeting summary and protocol :ballot_box_with_check:

> 05.03.2019 00:00 - 00:45 :ballot_box_with_check:

> 07.03.2019 03:00 - 04:30 :ballot_box_with_check:

#V 0.1.10 #2 (Second Instance, Pagebreaks)

Inserting page numbers to HM-script, into file `HM-Skript_Css3.epub`.

- Page breaks reset list numbering, which is problematic if the source document has lists spanning multiple pages.

Readium:

- Paginated-mode only uses own page-breaks when space of single page is full. It does not respect the document-owned page markers.
- empty pages are not rendered (instead two neighbouring page breaks are displayed one directly below another).

Calibre:

- It takes ages to process the math. Or to switch to fullscreen window size.
- It seems to be caused by my computer lagging. Closing and reopening everything helped a lot to increase loading times.
- maximizing the window still causes heavy lag and crashes calibre.
- Calibre behaves the same way than readium. I suppose this is due to the EPUB-format being required to work independently of the end-user's device screen size.

Reasily:

- not CSS compatible...

Shortened the file `HM-Skript_Css3.epub` to `HM-Skript_Css3-shortened.epub` in order to remove the preamble, and all pages numbered with roman numerals. Testing this version...

- nothing changed.



Updated Logo to: (during conversion time of HM-Skript :stuck_out_tongue_closed_eyes: )

- remove white dots (not looking good on a small scale),
- create version without "epub", probably better usable for file-associations.

On the small taskbar (second monitor), the old logo is shown: ![1551926315382](ARCHIVE/1551926315382.png) whereas on the main taskbar, it is the new logo: ![1551926366689](ARCHIVE/1551926366689.png) .





# V.0.1.10 #3 (Third instance, "release" version)

> 13.03.2019 14:45-17:00 :ballot_box_with_check:

Catching up on new features.

The Changelog on top of this log has been completed, according to Sachin's markdown file. New in this instance and the previous one:

- Removed bug where the program would crash if non-existent file was opened with the "Open With" command
- Removed bug where the program would crash if a file with no text would be saved
- Added keyboard shortcuts for adding inline formulas and conversion to inline formulas
- The title of the window now changes after "Save As"
- Adjusted font size difference between lists and normal text
- Scroll lock has been added to prevent the preview from scrolling to the bottom after every change
- Added page breaks and page numbers



Catching up on Github.

- _Test (GreaterThan)_: The replace function concerning `<` and `>` symbols has been implemented
- _Test (Preview)_: A button has been implemented to allow [refresh of preview browser] without [scrolling to the bottom every time].
- _Test (tF)_: A shortcut launching the inline-formula conversion has been implemented with CTRL+Shift+C.
- _Test (tP)_: Page breaks are not 100% reliable yet. Investigation pending
- _Test (Void)_: A new line (\n) is added after creating a new file to prevent this.
- _Test (Safeplace)_: Save as in Windows title of the window is not updated to the new file name 
- _Test (Reader Fontsize)_: The text size of lists and normal text should now be fixed, but still has to be tested.



The third instance has now been installed on my computer.

The bugs "Void" and "Safeplace" are confirmed to be solved. "Preview" is not fully functional yet.

"GreaterThan", "Traces" and "CopyLess" have been added to the bug list.



### [Bug: Traces

I suppose that newly implemented features do not always work with non-empty files older than their implementation.

So far, this seems to concern pagebreaks as well as the <-text-replace function.



**]**

### [Bug: CopyLess

When copying selected text from one editor instance of Accessible EPUB (CTRL+C), and then inserting it in another editor instance (CTRL+V):

Error message "problem converting WYSIWYG to HTML" is returned. This is caused by the presence of pagebreaks in the clipboard and the WYSIWIG text. Removing them allows conversion of the document, and pagebreaks can then be inserted again in the editor without causing problems.

**Update:** Copying the contents of `HM-Skript_Css3.epub` into `HM-Skript_Css4.epub` did not return an error, and conversion could be completed. However, what did not get copied along are:

- Formatting
- colors
- figures content (only tags and alt-texts)
- Tables (the content is now one cell per document text line)



**]**



>14.03.2019 18:15-19:15

Trying to give the HM-Script pagebreaks.

- create new empty file `HM-Skript_Css4.epub` with
  Title - Höhere Mathematik für Informatiker
  Author - Daniel Winkler
  Publisher - SZS
  Language - DE
  Format - CSS
- Open `HM-Skript_Css3.epub` in new program-instance.
- Select all text (CTRL+A), copy (CTRL+C), and paste into empty file (CTRL+V)
- Start conversion of the newest file via shortcut (apparently, this started the conversion in the other window).
- Saving the newer file apparently generated a first preview (without inline-formulas)
- Removed all pagebreaks from the file, saving (and converting). Formulas are now converted.
- Inserting two default page breaks, saving, converting.
- opening with calibre viewer. Page breaks seem to work.
  _Urrrrrgh, I resized the calibre window by mistake_
- Crashed calibre via task manager. 
- Reopening the script: Page breaks work, but if a single page is too high for the display size, calibre inserts a page break and separates it's content. The next page break then is respected again.
- However, the older script-file still doesn't work in calibre.

I may have to format the whole transcribed script again, setting headers and figures and page breaks anew in the new file.

Note: saving the older in a new file did not helpt making it's page breaks functional in calibre.



>  28.03.2019 22:15 - 23:30

Continue work on the script: formatting needs to be done.

- Adding sections. :ballot_box_with_check: 
- Page breaks :ballot_box_with_check: 

The page breaks now work in calibre, and all is nice and clean. Next: reinsert lists and formatting.



### [Bug: PageCounter

The increase in the page numbering does not consider deleted page breaks. It increases every time CTRL+Enter is hit, regardless of the actual count in the document.



**]**