> Erste Besprechung am 09.01.2019


- [ ] (A) Bugreport für overide Parser typing wrong formula breaks everything
- [ ] (B) Check header shortcut
- [ ] (C) Top1: Neues Logo
- [ ] (D) Sigil anschauen
- [ ] (E) Brailleauthority.org checken http://www.brailleauthority.org/ueb/symbols_list.pdf
- [ ] (F) Inline Formeln überprüfen zwischen pandoc und epub
- [ ] (G) **Inline**: MathML durch Pandoc, **figure live Preview**: WPF-Math, **figure in Text**: Wpf as svg
- [ ] (H) Handbuch?
- [ ] (I) < and > symbols after saving/reopening file. **-> Use \less \greater instead**
- [ ] (T) Liste der TeX-Befehle die aus Blindenversion rausgefiltert werden müssen.
- [ ] (S) Shortcuts need to be listed all at one place, to gain overview and adapt them best. Possible combination with Graphics-list?
- [ ] 





| Table of Abbreviations: | Javascript | CSS  |
| ----------------------- | ---------- | ---- |
| English                 | EJ         | EC   |
| German                  | GJ         | GC   |

|      | Defining Crash types: | Short Description                                            |
| ---- | --------------------- | ------------------------------------------------------------ |
|      | "Crash"/"Crashes"     | GUI is greyed out, Windows-Box appears "ACCESSIBLE EPUB" stopped working with single option "close" (or "exit"), then the editor-Window closes. |
| [x]  | Leroy                 | "StartIndex is Less than Zero" ;)                            |
| [x]  | Leyline               | Editor crashes when modifying an inline-formula in fiiles opened from Win-Explorer, EN-CSS. |

---

#List of features wished for:

- Pagebreak, with number and STRG+Enter
- Scroll sync/lock
- Possibility to load barrier free pictures in the file, that are associated to the normal images and could eventually be printed. (or create "linked" additional-file?) --> See Fragen an SZS
- Keyboard Shortcut to start rendering of inline formulas? --> See ToDo (S). 
- 



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

---



> 27.01.2019 16:30 - 19:00 :ballot_box_with_check: 

Installed Version 0.1.10.

Took a look at sigil: (with EC file)

- The behaviour of mode-switching is not as expected. The preview does not render it differently, and the editor jumps to the top. 

- Sigil seems to handle math internally, as switching View-mode starts a "Processing math" process in the preview, followed by a "Typesetting Math" process.
- Sigil does not render the Figure-Formulas in the preview. Displays "<u>[Math Processing Error]</u>" instead. Editor works fine.
- 



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

> 29.01.2019 18:00 - 19:00 :ballot_box_with_check:

Began listing required icons for graphical update.

Reinstalled V0.1.10 with actualised installer, in which the Leyline-Bug has been corrected.

- Bug does not seem to appear for Testfile EN-CSS.epub. Well done! :thumbsup:

Exported Logo-sketch to .ico. Will be tested for next release.