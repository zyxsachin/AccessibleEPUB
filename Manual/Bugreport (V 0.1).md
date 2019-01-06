### 10.09.2018 (V 0.1)

- Erstelle neue Datei mit: Titel, Autor, Publisher, German. Datei ist nicht sofort editierbar: Editor ist nich anwählbar, Programm hängt sich auf. Programmneustart erforderlich.
- Knopf "Bold" funktioniert nur in eine Richtung.
- Wie füge ich Seitenzahlen ein? Sind die überhaupt notwendig?
- Headers-Navigation verfolgt nicht die Hierarchie.
- Verschiedene Seitennummerierungen? (i,ii,...,1,2,...)
- Kein Feedback, ob erfolgreich gespeichert.

> 10.09.2018 22:00 - 23:11

Inline Math in HTML:

- https://www.w3.org/MarkUp/html3/maths.html
- http://jkorpela.fi/math/index.html
- https://developer.mozilla.org/de/docs/Web/MathML/Element/math
- Display whole version number in "about"
- "s inside alt-texts break the HTML-Code. ->Escape Char?

$$\sqrt{5}$$ 



> 06.11.2018 17:00 - 19:45

> 18.12.2018 18:26 - 18:40, 19:18 - 20:58

# V0.1.8:

- Doppelkick auf Wort sollte das Wort auswählen (nicht der Fall)
- Neben Buttons für Fett, Kursiv, Unterstrichen, sollte auch ein Button "zu inline Formel" existieren.
- Umgang mit Fließtext in Formeln: mehrere Formelumgebungen nacheinander (umständlich für Blinde), oder *\text{}*, oder nur eine Formel (schwer lesbarer Kursivtext für Standard und Impaired Ansicht).
- TeX: `x\in` produziert "xN" und unterbricht Formelumgebung, anstelle sich äquivalent zu `x \in` zu verhalten ($x \in$).
- Ansicht Code-Editor hat keine Zeilenumbrüche?
- Verhalten der Inline-Formelumgebung hängt von Leerzeichen vor und nach $$ ab.
- Vorschau-Aktualisierung springt zurück zu Anfang des Dokumentes.
- Vorschau-Aktualisierung lässt Programm aufhängen und Cursor verliert Fokus auf das Eingabefenster.
- last saved aktualisiert erst nach Eingabe eines neuen Zeichens
- TeX: Inline Formel `P(M) = \{ \{ 1,2 \} , \{ 1 \} , \{ 2 \} , \emptyset \}` funktioniert, aber über Formel einfügen-Fenster nicht.

> 26.12.2018 18:00 - 22:00

# V0.1.9:

- After execution of .msi-package (install.exe not used): Path "AppData/Local/Temp/AccessibleEPUB needed to be created manually, as hinted by error messsage (unhandled exception). After that, opening and creating new files worked as usual.
- Disabled automatic refresh info-box is a great addition!
- Again, conflict between target users (Question about formulas): The expression `Seien $$M, N$$ Mengen` presents the conflict: a double formula in order to respect the space between both sets makes it bloated for blind users (as would `$$M,\ N$$`).
  This should be clarified in the standard for all conflict cases (a priority is required).
- **Major:** Typing in notepad++ and pressing CTRL+S triggers conversion inside the EPUB editor??? (a window opens telling "please wait while the conversion is done").
  Also happens with Typora.
- Selecting text and pressing the button for cursive should not set the following cursor to cursive, but only set the selected as cursive and allow to continue typing in standard formatting without further manipulation.
- I am thinking of a user-readable standard formatting to mark the end of certain paragraphs.
  Use case: An example is opened with a sub-header called "Example number X" inside the text of the actual section. When does the text switch back to the section-content and leaves the example? In most documents, this is achieved through visual formatting, lost in the blind verions.
- allow "insert formula" window to be smaller (is currently not suited for side-to-side desktop workspace-arrangement on a smaller screen. 
- TeX: Document specific LaTeX-Commands/Packages? In order to use `$$ \mathbb{R} $$` for example ($$\mathbb{R}$$). At least the missing `amssymb`and `amsfont` makes many math symbols difficult to set.
- TeX: Following code is not working `M=N= R, f: R \left\{ \begin{array} R \rightarrow R \\ x \rightarrow x^2 \right\}`.
- TeX: `\{`and `\}` are essential and don't work.
- TeX: need clarification on "override parser": Program crashed.
- Restoration of crashed files? A file still is stored in AppData/Local/Temp/AccessibleEPUB after the crash.
- Localization: French keyboards have numbers accessible through shift. Hence, "CTRL+3" does not work as a shortcut to set headers (resulting in a CTRL+"). 
- Small window witdh: the buttons to add fomulas, tables, etc... could move up next to the save buttons, instead of disappearing inside a pop-up menu.
- **Major:** See Bug 1
- The visual formattin capabilites of the format should be clarified, most importantly in comparison with TeX-Files (f.e.: Smallcaps for names)

###Major Bug event 1:

- saving corrupted the variable startIndex? see backup as `HM-Skript_Css - Copie.epub` and `HM-Skript_Css - Copie error text.epub`.

During editing of the HM-Skript_Css.epub, I added a formula (figure) containing the TeX-code `g\circ f : M \rightarrow P, a \rightarrow g(f(a))`. The formula does not have Title or caption, and is inserted between text.

After saving, the error `HM-Skript_Css - Copie error text.epub` was returned. Continuing allows scroll up/down navigation but no further editing. After a while, the program crashes.

The file was restored using the following method:

- opening the corrupted file
- switch to code-view
- Copy text
- insert text in notepad++
- remove latest figure in each version
- re-download and open the converted `HM-Skript_Css.epub`
- switch to code-view, paste modified code
- save as
- open restored file, overwrite corrupted file (backuped as named above).
- insert figure-formula again, `g \circ f : ( M \rightarrow P, a \rightarrow g(f(a)) )`with title `Beispiel Hintereinanderausfuehrung` and caption `g kreis f`

It is unclear if I somehow interrupted the saving and conversion process.

---

> 30.12.2018 11:15 - 12:00

### Bug encountered again: _"StartIndex cannot be less than zero."_

- Working on inserting a formula (a recognized one: `\forall a,b,c \in R (a+b)+c = a+(b+c)`) with a title: `Assoziativgesetz der Addition` but no caption. No alignement, no override.
- Bug from last time triggers again.
- CTRL+S also triggers the save process again while in another window (GLOBAL shortcut???).
- After saving, exited the formula-window via "_cancel_"
- Closed the file
- Reopening it doesn't seem to cause the bug again.
- Second try insterting the formula: Same title, same formula, <u>but this time with caption</u> (`Die Addition ist assoziativ`).
- Info-Box opens asking for overwrite of same-titled existing formula.
- "yes"
- No further apparent problems encountered.

! <u>Caption as well as title seems mandatory when inserting figure-formulas.</u> !

- On small window (halved 1376px-wide screen): empty space is kept in the bottom bar between "_Character Count_" and "_Document language_", masking the last time the file was saved (when no save was done since opening the file).
  After save process: the Version display gets "kicked out" of the window to the right.
- Saving/Conversion takes more than 2 minutes on this machine.

> 05.01.2019 17:30 - 18:15
>
> 06.01.2019 13:15 - 13:45

- TeX: Compilers are inconsistent (inline recognises `\mathbb{R}` whereas figure doesn't).
- TeX: `<`and `>`are not rendered and break formulas: they result in _`&gt;`_ and _`&lt;`_ instead. And the leading _`&`_ is even interpreted by TeX. 
- 