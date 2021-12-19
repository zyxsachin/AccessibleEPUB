[]{#Content.xhtml}

<!--?xml version="1.0" encoding="utf-8"?-->

\
[Normal](#Content.xhtml#visible){#Content.xhtml#a1 .versionChanger}
[Visually impaired](#Content.xhtml#impaired){#Content.xhtml#a2
.versionChanger} [Blind](#Content.xhtml#blind){#Content.xhtml#a3
.versionChanger} <!--StartOfContent-->

::: {#Content.xhtml#impaired .impaired style="padding:none"}
<!--StartOfImpairedSection-->

Höhere Mathematik für Informatiker {#Content.xhtml#toc_0}
==================================

Inoffizielles Skriptum zur Vorlesung Höhere Mathematik für Informatiker
basierend auf Vorlesungen an der Universität Karlsruhe (TH) 2000 \--
2004

\

![](Images/title_1.png "Titelbild"){.imageOthers}

\

((Seitei))

##### Anmerkungen des Autors: {#Content.xhtml#toc_1}

Dieses Werk ist unter einem Creative Commons
Namensnennung-NichtKommerziell-Weitergabe unter gleichen\
Bedingungen Lizenzvertrag lizensiert. Um die Lizenz anzusehen, gehen Sie
bitte zu <http://creativecommons.org/licenses/by-nc-sa/2.0/de/> oder
schicken Sie einen Brief an Creative Commons, 559 Nathan Abbott Way,
Stanford, California 94305, USA.

###### WICHTIGER HINWEIS: {#Content.xhtml#toc_2}

Dies ist KEIN offiziell autorisiertes Skript der genannten Dozenten!
Entsprechend erhebt der Mitschrieb und die enthaltenen Ergänzungen
keinen Anspruch auf Vollständigkeit und Korrektheit!

###### Von der Website: {#Content.xhtml#toc_3}

Das \"inoffizielle Skript\" entstand in Zusammenarbeit mit [Markus
Westphal](http://www.markuswestphal.de/), [Christian
Senger](http://www.sengernet.de/) und anderen Kommilitonen. Es basiert
auf meinem Mitschrieb der Vorlesung von [Prof.
Plum](http://www.math.kit.edu/iana2/~plum/) 2000/2001 an der Universität
Karlsruhe (TH) (heute: KIT). Kombiniert wurde er mit Teilen aus der
Vorlesung von [Dr. Kunstmann](http://www.math.kit.edu/iana3/~kunstmann/)
2002/2003 und aus den Vorlesungen von [Dr.
Schmoeger](http://www.math.kit.edu/iana3/~schmoeger/) 2001/2002 und
2003/2004.\
Sowohl die Konzeption als auch das Manuskript der genannten Vorlesungen
stammen allein von [Dr.
Schmoeger](http://www.math.kit.edu/iana3/~schmoeger/).

Wer ebenfalls Interesse daran hat, die aktuelle HM-Vorlesung in die
bestehenden Quellen einzuarbeiten oder gerne die Lesbarkeit und das
Erscheinungsbild verbessern und weitere Skizzen einfügen möchte: eine
eMail an `<post AT danielwinkler.de>` genügt. 

Wir erheben keinen Anspruch auf Vollständigkeit und Korrektheit!

##### Anmerkungen des Umsetzers: {#Content.xhtml#toc_4}

Da die Vorlage keine farbigen Graphiken enthält, entspricht dieses
Dokument De Facto einer Umsetzung der Schwarz-Weiß-Version des Skriptes.
Das Skript wird möglichst nah am Original umgesetzt, mithilfe aller
verfügbaren Werkzeuge des Editors.

Schlüsselwörter wie \"Beispiel\" und \"Lemma\", welche in der Vorlage
farbig markiert sind, sind es hier ebenfalls, in den vergleichbaren
Farben.\

Dieses Dokument ist vorläufig nur eine Testversion um den Editor an
einem Umsetzungsbeispiel anzuwenden.

###### Bisherige Probleme dieser Umsetzung: {#Content.xhtml#toc_5}

-   Bilder sind zurzeit als Rastergraphik eingebettet, obwohl die
    Quellen im vektoriellen EPS-Format vorliegen.
-   Konsistenz der Notation muss noch gefunden werden.

((Seiteii))

(Inhaltsverzeichnis) {#Content.xhtml#toc_6}
====================

((Seitevi))

(Tabellenverzeichnis) {#Content.xhtml#toc_7}
=====================

 Dieses Werk ist unter einem Creative Commons
Namensnennung\--Nicht-Kommerziell\--Weitergabe unter gleichen
Bedingungen\-\--Lizenzvertrag lizensiert. Um die Lizenz anzusehen, gehen
Sie bitte zu <http://creativecommons.org/licenses/by-nc-sa/2.0/de/> oder
schicken Sie einen Brief an Creative Commons, 559 Nathan Abbott Way,
Stanford, California 94305, USA.

\

![](Images/cc_2.png "Lizensangabe: Creative Commons"){.imageOthers}

Dieses Skriptum erhebt keinen Anspruch auf Vollständigkeit und
Korrektheit. Einige Beweise, die in den Saalübungen geführt wurden, sind
nicht enthalten.

Kommentare, Fehler, Patches und Vorschläge bitte an
[post\@danielwinkler.de](mailto:post@danielwinkler.de%7D%7B%7D%7B%7D%7Bpost@danielwinkler.de) senden.
Bei Fehlern bitte **nicht** die Seitenzahl sondern die Nummer des
Satzes, der Abbildung etc. sowie die Revisionsnummern angeben.

Die aktuelle Version dieses Dokuments sowie die Quelldateien hierzu sind
unter der Web-Adresse\
[http://www.danielwinkler.de/hm/](http://www.danielwinkler.de/hm/%20) zu
finden.

Dieses inoffizielle Skriptum basiert auf dem Mitschrieb von Daniel
Winkler zu den Vorlesungen an der Universität\
Karlsruhe (heute: Karlsruher Institut für Technologie, KIT) in den
Jahren 2000 und 2001 von Prof. M. Plum. Kombiniert wurde er durch Markus
Westphal und Sebastian Reichelt mit Material aus den Vorlesungen in den
Jahren 2002 bis 2004 von HDoz. Dr. P. Kunstmann und AOR Dr. Ch.
Shmoeger.

Sowohl die Konzeption als auch das Manuskript der genannten
Vorlesungen stammen allein von AOR Dr. Ch. Schmoeger.

Weitere Korrekturen und Ergänzungen wurden eingebracht von Julian
Dibbelt, Martin Röhricht, Christian Senger, Norbert Silberhorn, Johannes
Singler und Richard Walter.

  Teil     Rev.
  -------- ------
  Layout   282
  HM 1     289
  HM 2     291
  Anhang   256

((Seitevii))

*Don\'t panic!*\

((Seiteviii))

\

Teil I. Eindimensionale Analsysis {#Content.xhtml#toc_8 align="center"}
=================================

((Seite1))

((Seite2))

0. Vorbemerkungen {#Content.xhtml#toc_9}
=================

0.1. Mengen {#Content.xhtml#toc_10}
-----------

Eine *Menge* ist nach Cantor eine Zusammenfassung [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> von bestimmten
wohlunterschiedenen Objekten unserer Anschauung oder unseres Denkens
(welche Elemente von [[$M$ ]{.math display="inline"
role="math"}[$\mathsf{M}$ ]{.mathImpaired display="inline"
role="math"}[\$M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> genannt werden) zu einem
Ganzen.

**Notation**: geschweifte Klammern [[$\{\}$ ]{.math display="inline"
role="math"}[$\mathsf{\{\}}$ ]{.mathImpaired display="inline"
role="math"}[\$\\left\\{ \\right\\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

#### Beispiel 0.1. Notationen: {#Content.xhtml#toc_11}

-   <font size="1">[[$M = \{ 1,2,3\}$ ]{.math display="inline"
    role="math"}[$\mathsf{M = \{ 1,2,3\}}$ ]{.mathImpaired
    display="inline" role="math"}[\$M = \\{ 1,2,3 \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--></font>
-   <font size="1">[[$M = \{ x:x{\mspace{6mu}\text{ist\ Vielfaches\ von}\mspace{6mu}}7\}$
    ]{.math display="inline"
    role="math"}[$\mathsf{M = \{ x:x{\mspace{6mu}\text{ist\ Vielfaches\ von}\mspace{6mu}}7\}}$
    ]{.mathImpaired display="inline" role="math"}[\$M = \\{ x: x \\text{
    ist Vielfaches von }7 \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> oder
    [[$\{ x \in N:x{\mspace{6mu}\text{Vielfaches\ von}\mspace{6mu}}7\}$
    ]{.math display="inline"
    role="math"}[$\mathsf{\{ x \in N:x{\mspace{6mu}\text{Vielfaches\ von}\mspace{6mu}}7\}}$
    ]{.mathImpaired display="inline" role="math"}[\$\\{ x \\in N: x
    \\text{ Vielfaches von }7 \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--></font>

Weitere Grundnotation: Doppelpunkt zur Kennzeichnung von *Definitionen*.

#### <font color="#008000">Beispiel</font> 0.2. {#Content.xhtml#toc_12}

Wollen die Funktion [[$f$ ]{.math display="inline"
role="math"}[$\mathsf{f}$ ]{.mathImpaired display="inline"
role="math"}[\$f\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> definieren. Schreibe
(z.B.) [[$f(x):=x^{2}$ ]{.math display="inline"
role="math"}[$\mathsf{f(x):=x^{2}}$ ]{.mathImpaired display="inline"
role="math"}[\$f(x):=x\^2\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Nur bei einer
Neudefinition, nicht bei einer Gleichung. Oder
[[$\left. a:=15,f{\mspace{6mu}\text{heißt\ injektiv}\mspace{6mu}}:\Leftrightarrow{\mspace{6mu}\text{Für\ alle}\mspace{6mu}}a,\widetilde{a} \in M{\mspace{6mu}\text{mit}\mspace{6mu}}a \neq \widetilde{a} \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. a:=15,f{\mspace{6mu}\text{heißt\ injektiv}\mspace{6mu}}:\Leftrightarrow{\mspace{6mu}\text{Für\ alle}\mspace{6mu}}a,\widetilde{a} \in M{\mspace{6mu}\text{mit}\mspace{6mu}}a \neq \widetilde{a} \right.}$
]{.mathImpaired display="inline" role="math"}[\$a:=15, f \\text{ heißt
injektiv } : \\Leftrightarrow \\text{ Für alle } a, \\tilde{a} \\in M
\\text{ mit } a \\neq \\tilde{a}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> gilt\...

[[$a \in M$ ]{.math display="inline" role="math"}[$\mathsf{a \in M}$
]{.mathImpaired display="inline" role="math"}[\$a \\in M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (oder [[$M \ni a$ ]{.math
display="inline" role="math"}[$\mathsf{M \ni a}$ ]{.mathImpaired
display="inline" role="math"}[\$M \\ni a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->): [[$a$ ]{.math
display="inline" role="math"}[$\mathsf{a}$ ]{.mathImpaired
display="inline" role="math"}[\$a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist Element von [[$M$
]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->; [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> enthält [[$a$ ]{.math
display="inline" role="math"}[$\mathsf{a}$ ]{.mathImpaired
display="inline" role="math"}[\$a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
[[$a \notin M$ ]{.math display="inline"
role="math"}[$\mathsf{a \notin M}$ ]{.mathImpaired display="inline"
role="math"}[\$a \\notin M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (oder [[$M a$ ]{.math
display="inline" role="math"}[$\mathsf{M a}$ ]{.mathImpaired
display="inline" role="math"}[\$M \\notni a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->): analog s.o.\
[[$M = N$ ]{.math display="inline" role="math"}[$\mathsf{M = N}$
]{.mathImpaired display="inline" role="math"}[\$M = N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->: [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> enthält die selben
Elemente wie [[$N$ ]{.math display="inline" role="math"}[$\mathsf{N}$
]{.mathImpaired display="inline" role="math"}[\$N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
[[$M \neq N$ ]{.math display="inline" role="math"}[$\mathsf{M \neq N}$
]{.mathImpaired display="inline" role="math"}[\$M \\neq
N\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->: analog s.o.\
[[$M \subset N$ ]{.math display="inline"
role="math"}[$\mathsf{M \subset N}$ ]{.mathImpaired display="inline"
role="math"}[\$M \\subset N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (oder [[$M \subseteq N$
]{.math display="inline" role="math"}[$\mathsf{M \subseteq N}$
]{.mathImpaired display="inline" role="math"}[\$M \\subseteq
N\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->): [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist Tielmenge von [[$N$
]{.math display="inline" role="math"}[$\mathsf{N}$ ]{.mathImpaired
display="inline" role="math"}[\$N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, d.h. jedes Element von
[[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist auch ein Element von
[[$N$ ]{.math display="inline" role="math"}[$\mathsf{N}$ ]{.mathImpaired
display="inline" role="math"}[\$N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->; Gleichheit der Mengen
ist erlaubt.\
[[$N \supset M$ ]{.math display="inline"
role="math"}[$\mathsf{N \supset M}$ ]{.mathImpaired display="inline"
role="math"}[\$N \\supset M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (oder [[$N \supseteq M$
]{.math display="inline" role="math"}[$\mathsf{N \supseteq M}$
]{.mathImpaired display="inline" role="math"}[\$N \\supseteq
M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->): [[$N$ ]{.math
display="inline" role="math"}[$\mathsf{N}$ ]{.mathImpaired
display="inline" role="math"}[\$N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist Obermenge von [[$M$
]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->; analog\
[[$M \subsetneqq N$ ]{.math display="inline"
role="math"}[$\mathsf{M \subsetneqq N}$ ]{.mathImpaired display="inline"
role="math"}[\$M \\subsetneqq N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->: [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist echte Teilmenge von
[[$N$ ]{.math display="inline" role="math"}[$\mathsf{N}$ ]{.mathImpaired
display="inline" role="math"}[\$N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->; [[$M \neq N$ ]{.math
display="inline" role="math"}[$\mathsf{M \neq N}$ ]{.mathImpaired
display="inline" role="math"}[\$M \\neq N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
[[$\varnothing$ ]{.math display="inline"
role="math"}[$\mathsf{\varnothing}$ ]{.mathImpaired display="inline"
role="math"}[\$\\emptyset\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->: leere Menge

[[$M \cup N = \{ a:a \in M{\mspace{6mu}\text{oder}\mspace{6mu}}a \in N\}$
]{.math display="inline"
role="math"}[$\mathsf{M \cup N = \{ a:a \in M{\mspace{6mu}\text{oder}\mspace{6mu}}a \in N\}}$
]{.mathImpaired display="inline" role="math"}[\$M \\cup N = \\{ a: a
\\in M \\text{ oder } a \\in N\\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (Vereinigungsmenge)\
[[$M \cap N = \{ a:a \in M{\text{~und}\mspace{6mu}}a \in N\}$ ]{.math
display="inline"
role="math"}[$\mathsf{M \cap N = \{ a:a \in M{\text{~und}\mspace{6mu}}a \in N\}}$
]{.mathImpaired display="inline" role="math"}[\$M \\cap N = \\{ a: a
\\in M \\text{ und } a \\in N\\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (Schnittmenge)\
[[$M\backslash N = \{ a:a \in M{\mspace{6mu}\text{und}\mspace{6mu}}a \notin N\}$
]{.math display="inline"
role="math"}[$\mathsf{M\backslash N = \{ a:a \in M{\mspace{6mu}\text{und}\mspace{6mu}}a \notin N\}}$
]{.mathImpaired display="inline" role="math"}[\$M \\setminus N = \\{ a:
a \\in M \\text{ und } a \\notin N\\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (Komplementmenge)

[[$M,N$ ]{.math display="inline" role="math"}[$\mathsf{M,N}$
]{.mathImpaired display="inline" role="math"}[\$M,N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißen disjunkt, wenn
[[$M \cap N = \varnothing$ ]{.math display="inline"
role="math"}[$\mathsf{M \cap N = \varnothing}$ ]{.mathImpaired
display="inline" role="math"}[\$M \\cap N = \\emptyset\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
[[$P(M) = \{ N:N \subset M\}$ ]{.math display="inline"
role="math"}[$\mathsf{P(M) = \{ N:N \subset M\}}$ ]{.mathImpaired
display="inline" role="math"}[\$P(M) = \\{N: N\\subset
M\\}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->: Potenzmenge von [[$M$
]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (Menge aller Teilmengen)

Beispiel 0.3.

Beispiel für die Potenzmenge von [[$M = \{ 1,2\}$ ]{.math
display="inline" role="math"}[$\mathsf{M = \{ 1,2\}}$ ]{.mathImpaired
display="inline" role="math"}[\$M= \\{1,2\\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->:\
[[$P(M) = \{\{ 1,2\},\{ 1\},\{ 2\},\varnothing\}$ ]{.math
display="inline"
role="math"}[$\mathsf{P(M) = \{\{ 1,2\},\{ 1\},\{ 2\},\varnothing\}}$
]{.mathImpaired display="inline" role="math"}[\$P(M) = \\{ \\{ 1,2 \\} ,
\\{ 1 \\} , \\{ 2 \\} , \\emptyset \\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

0.2. Abbildungen {#Content.xhtml#toc_13}
----------------

Seien [[$M,N$ ]{.math display="inline" role="math"}[$\mathsf{M,N}$
]{.mathImpaired display="inline" role="math"}[\$M,N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> Mengen. Eine *Abbildung*
oder *Funktion* [[$f$ ]{.math display="inline" role="math"}[$\mathsf{f}$
]{.mathImpaired display="inline" role="math"}[\$f\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> von [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> nach [[$N$ ]{.math
display="inline" role="math"}[$\mathsf{N}$ ]{.mathImpaired
display="inline" role="math"}[\$N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist eine Vorschrift, die
jedem Element [[$a \in M$ ]{.math display="inline"
role="math"}[$\mathsf{a \in M}$ ]{.mathImpaired display="inline"
role="math"}[\$a \\in M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> in eindeutiger Weise ein
[[$f(a) \in N$ ]{.math display="inline"
role="math"}[$\mathsf{f(a) \in N}$ ]{.mathImpaired display="inline"
role="math"}[\$f(a) \\in N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> zuordnet.

**Notation:** [[$\left. f:M\rightarrow N,a\rightarrow f(a) \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. f:M\rightarrow N,a\rightarrow f(a) \right.}$
]{.mathImpaired display="inline" role="math"}[\$f: M \\rightarrow N, a
\\rightarrow f(a)\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

### <font color="#008000">Beispiel</font> 0.4.

\

[[$M = N = \mathbb{R},f:\left\{ \begin{array}{l}
\left. \mathbb{R}\leftarrow\mathbb{R} \right. \\
\left. x\mapsto x^{2} \right. \\
\end{array} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{M = N = \mathbb{R},f:\left\{ \begin{array}{l}
\left. \mathbb{R}\leftarrow\mathbb{R} \right. \\
\left. x\mapsto x^{2} \right. \\
\end{array} \right.}$ ]{.mathImpaired display="inline" role="math"}[\$M
= N = \\mathbb{R}, f: \\begin{cases} \\mathbb{R} \\leftarrow \\mathbb{R}
\\\\ x \\mapsto x\^2 \\end{cases}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\

![Eine Abbildung von Real nach Real, macht x zu x
quadrat](Images/Beispiel%200.4..svg "Beispiel 0.4."){.toRemove}

\
[[$\left. f_{1}:M_{1}\rightarrow N_{1} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. f_{1}:M_{1}\rightarrow N_{1} \right.}$
]{.mathImpaired display="inline" role="math"}[\$f\_1: M\_1 \\rightarrow
N\_1\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und
[[$\left. f_{2}:M_{2}\rightarrow N_{2} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. f_{2}:M_{2}\rightarrow N_{2} \right.}$
]{.mathImpaired display="inline" role="math"}[\$f\_2: M\_2 \\rightarrow
N\_2\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heissen *gleich* (kurz
[[$f_{1}f_{2}$ ]{.math display="inline"
role="math"}[$\mathsf{f_{1}f_{2}}$ ]{.mathImpaired display="inline"
role="math"}[\$f\_1 f\_2\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->) (identisch), wenn
[[$M_{1} = M_{2},N_{1} = N_{2}$ ]{.math display="inline"
role="math"}[$\mathsf{M_{1} = M_{2},N_{1} = N_{2}}$ ]{.mathImpaired
display="inline" role="math"}[\$M\_1=M\_2, N\_1=N\_2\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und
[[$f_{1}(a) = f_{2}(a)$ ]{.math display="inline"
role="math"}[$\mathsf{f_{1}(a) = f_{2}(a)}$ ]{.mathImpaired
display="inline" role="math"}[\$f\_1(a)=f\_2(a)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> für alle [[$a \in M_{1}$
]{.math display="inline" role="math"}[$\mathsf{a \in M_{1}}$
]{.mathImpaired display="inline" role="math"}[\$a \\in
M\_1\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
\

[[$\left. f:M\rightarrow N \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. f:M\rightarrow N \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$f:M \\rightarrow N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heisst

-   *injektiv*, wenn für alle [[$a,\widetilde{a} \in M$ ]{.math
    display="inline" role="math"}[$\mathsf{a,\widetilde{a} \in M}$
    ]{.mathImpaired display="inline" role="math"}[\$a, \\tilde{a} \\in
    M\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> mit
    [[$a \neq \widetilde{a}$ ]{.math display="inline"
    role="math"}[$\mathsf{a \neq \widetilde{a}}$ ]{.mathImpaired
    display="inline" role="math"}[\$a \\neq \\tilde{a}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> gilt:
    [[$f(a) \neq f(\widetilde{a})$ ]{.math display="inline"
    role="math"}[$\mathsf{f(a) \neq f(\widetilde{a})}$ ]{.mathImpaired
    display="inline" role="math"}[\$f(a) \\neq
    f(\\tilde{a})\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->;
    ([[$\left. x\mapsto x \right.$ ]{.math display="inline"
    role="math"}[$\mathsf{\left. x\mapsto x \right.}$ ]{.mathImpaired
    display="inline" role="math"}[\$x \\mapsto x\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist injektiv,
    [[$\left. x\mapsto x^{2} \right.$ ]{.math display="inline"
    role="math"}[$\mathsf{\left. x\mapsto x^{2} \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$x \\mapsto
    x\^2\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nicht)
-   *surjektiv*, wenn für alle [[$\widetilde{a} \in M$ ]{.math
    display="inline" role="math"}[$\mathsf{\widetilde{a} \in M}$
    ]{.mathImpaired display="inline" role="math"}[\$\\tilde{a} \\in
    M\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ein [[$a \in M$
    ]{.math display="inline" role="math"}[$\mathsf{a \in M}$
    ]{.mathImpaired display="inline" role="math"}[\$a \\in
    M\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> existiert mit
    [[$f(a) = \widetilde{a}$ ]{.math display="inline"
    role="math"}[$\mathsf{f(a) = \widetilde{a}}$ ]{.mathImpaired
    display="inline" role="math"}[\$f(a)=\\tilde{a}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> (die Bildmenge wird
    voll ausgeschöpft)
-   *bijektiv*, wenn [[$f$ ]{.math display="inline"
    role="math"}[$\mathsf{f}$ ]{.mathImpaired display="inline"
    role="math"}[\$f\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> sowohl injektiv als
    aus surjektiv ist: eindeutige Zuordnung\

Für [[$M_{1} \subset M$ ]{.math display="inline"
role="math"}[$\mathsf{M_{1} \subset M}$ ]{.mathImpaired display="inline"
role="math"}[\$M\_1 \\subset M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heisst
[[$f(M_{1}) = f(a):a \in M_{1}$ ]{.math display="inline"
role="math"}[$\mathsf{f(M_{1}) = f(a):a \in M_{1}}$ ]{.mathImpaired
display="inline" role="math"}[\$f(M\_1) = f(a): a \\in
M\_1\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> Bildmenge von [[$M_{1}$
]{.math display="inline" role="math"}[$\mathsf{M_{1}}$ ]{.mathImpaired
display="inline" role="math"}[\$M\_1\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (unter [[$f$ ]{.math
display="inline" role="math"}[$\mathsf{f}$ ]{.mathImpaired
display="inline" role="math"}[\$f\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->).\
Für [[$N_{1} \subset N$ ]{.math display="inline"
role="math"}[$\mathsf{N_{1} \subset N}$ ]{.mathImpaired display="inline"
role="math"}[\$N\_1 \\subset N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heisst
[[$f^{- 1}(N_{1}) = a \in M:f(a) \in N_{1}$ ]{.math display="inline"
role="math"}[$\mathsf{f^{- 1}(N_{1}) = a \in M:f(a) \in N_{1}}$
]{.mathImpaired display="inline" role="math"}[\$f\^{-1}(N\_1) = a \\in M
: f(a) \\in N\_1\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> *Urbildmenge* von
[[$N_{1}$ ]{.math display="inline" role="math"}[$\mathsf{N_{1}}$
]{.mathImpaired display="inline" role="math"}[\$N\_1\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (unter [[$f$ ]{.math
display="inline" role="math"}[$\mathsf{f}$ ]{.mathImpaired
display="inline" role="math"}[\$f\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->).\
Sind [[$\left. f:M\rightarrow N \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. f:M\rightarrow N \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$f:M \\rightarrow N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und
[[$\left. g:N\rightarrow P \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. g:N\rightarrow P \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$g: N \\rightarrow P\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> Abbildungen, so heisst
die Abbildung

[[$g \circ f:\left\{ \begin{array}{l}
\left. M\leftarrow P \right. \\
\left. a\mapsto g(f(a)) \right. \\
\end{array} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{g \circ f:\left\{ \begin{array}{l}
\left. M\leftarrow P \right. \\
\left. a\mapsto g(f(a)) \right. \\
\end{array} \right.}$ ]{.mathImpaired display="inline" role="math"}[\$g
\\circ f : \\begin{cases} M \\leftarrow P \\\\ a \\mapsto g(f(a))
\\end{cases}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\

![g kreis
f](Images/Beispiel%20Hintereinanderausfuehrung.svg "Beispiel Hintereinanderausfuehrung"){.toRemove}

\

*Hintereinanderausführung* von [[$f$ ]{.math display="inline"
role="math"}[$\mathsf{f}$ ]{.mathImpaired display="inline"
role="math"}[\$f\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[$g$ ]{.math
display="inline" role="math"}[$\mathsf{g}$ ]{.mathImpaired
display="inline" role="math"}[\$g\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

0.3 Aussagen
------------

Unter einer *Aussage* verstehen wir ein sprachliches oder gedankliches
Gefüge, welches entweder wahr oder falsch ist.

##### Beispiel 0.5.

-   \"4 ist eine gerade Zahl\" ist eine wahre Aussage.
-   \"Bananen sind kugelförmig\" ist eine falsche Aussage.
-   \"Nachts ist es kälter als draussen\" ist keine Aussage.
-   \"Es gibt unendlich viele Sterne\" ist eine Aussage, die wahr oder
    falsch sein kann.

Sind [[$A,B$ ]{.math display="inline" role="math"}[$\mathsf{A,B}$
]{.mathImpaired display="inline" role="math"}[\$A,B\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> Aussagen, so sind die
Aussagen
[[$\left. \neg A,A \land B,A \vee B,A\dot{\vee}B,A\Rightarrow B,A\Leftrightarrow B \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. \neg A,A \land B,A \vee B,A\dot{\vee}B,A\Rightarrow B,A\Leftrightarrow B \right.}$
]{.mathImpaired display="inline" role="math"}[\$\\neg A, A \\wedge B, A
\\vee B, A \\dot{\\vee} B, A \\Rightarrow B, A \\Leftrightarrow
B\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> erklärt durch:

-   [[$\neg A$ ]{.math display="inline" role="math"}[$\mathsf{\neg A}$
    ]{.mathImpaired display="inline" role="math"}[\$\\neg
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: [[$A$ ]{.math
    display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
    display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist falsch (Negation)
-   [[$A \land B$ ]{.math display="inline"
    role="math"}[$\mathsf{A \land B}$ ]{.mathImpaired display="inline"
    role="math"}[\$A \\wedge B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: [[$A$ ]{.math
    display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
    display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> und [[$B$ ]{.math
    display="inline" role="math"}[$\mathsf{B}$ ]{.mathImpaired
    display="inline" role="math"}[\$B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> sind beide wahr (und)
-   [[$A \vee B$ ]{.math display="inline"
    role="math"}[$\mathsf{A \vee B}$ ]{.mathImpaired display="inline"
    role="math"}[\$A \\vee B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: [[$A$ ]{.math
    display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
    display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> oder [[$B$ ]{.math
    display="inline" role="math"}[$\mathsf{B}$ ]{.mathImpaired
    display="inline" role="math"}[\$B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist wahr (oder)
-   [[$A\dot{\vee}B$ ]{.math display="inline"
    role="math"}[$\mathsf{A\dot{\vee}B}$ ]{.mathImpaired
    display="inline" role="math"}[\$A \\dot{\\vee} B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: entweder [[$A$
    ]{.math display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
    display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> oder [[$B$ ]{.math
    display="inline" role="math"}[$\mathsf{B}$ ]{.mathImpaired
    display="inline" role="math"}[\$B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist wahr (excl. oder)
-   [[$AB$ ]{.math display="inline" role="math"}[$\mathsf{AB}$
    ]{.mathImpaired display="inline" role="math"}[\$A B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: aus [[$A$ ]{.math
    display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
    display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> folgt [[$B$ ]{.math
    display="inline" role="math"}[$\mathsf{B}$ ]{.mathImpaired
    display="inline" role="math"}[\$B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->; wenn [[$A$ ]{.math
    display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
    display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> wahr ist, dann ist
    auch [[$B$ ]{.math display="inline" role="math"}[$\mathsf{B}$
    ]{.mathImpaired display="inline" role="math"}[\$B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> wahr (Implikation)\
    (ist immer wahr, wenn [[$A$ ]{.math display="inline"
    role="math"}[$\mathsf{A}$ ]{.mathImpaired display="inline"
    role="math"}[\$A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> falsch ist; ist
    nur dann falsch, wenn [[$B$ ]{.math display="inline"
    role="math"}[$\mathsf{B}$ ]{.mathImpaired display="inline"
    role="math"}[\$B\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> falsch ist)\
    Bsp: \"Wenn Bananen kugelförmig sind, ist 4 gerade.\" ist eine wahre
    Aussage.
-   [[$\left. A\Leftrightarrow B \right.$ ]{.math display="inline"
    role="math"}[$\mathsf{\left. A\Leftrightarrow B \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$A \\Leftrightarrow
    B\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: [[$A$ ]{.math
    display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
    display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist genau dann wahr,
    wenn [[$B$ ]{.math display="inline" role="math"}[$\mathsf{B}$
    ]{.mathImpaired display="inline" role="math"}[\$B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> wahr ist.
    (Äquivalenz)

Sei [[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$
]{.mathImpaired display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine Menge und [[$E$
]{.math display="inline" role="math"}[$\mathsf{E}$ ]{.mathImpaired
display="inline" role="math"}[\$E\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine Eigenschaft, die ein
Element [[$a \in M$ ]{.math display="inline"
role="math"}[$\mathsf{a \in M}$ ]{.mathImpaired display="inline"
role="math"}[\$a \\in M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> haben kann. Dann sind
folgende Aussagen machbar:

-   [[$\forall_{a \in M}a$ ]{.math display="inline"
    role="math"}[$\mathsf{\forall_{a \in M}a}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\forall\_{a \\in M}
    a\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> hat die Eigenschaft
    [[$E$ ]{.math display="inline" role="math"}[$\mathsf{E}$
    ]{.mathImpaired display="inline" role="math"}[\$E\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: jedes [[$a \in M$
    ]{.math display="inline" role="math"}[$\mathsf{a \in M}$
    ]{.mathImpaired display="inline" role="math"}[\$a \\in
    M\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> hat die Eigenschaft
    [[$E$ ]{.math display="inline" role="math"}[$\mathsf{E}$
    ]{.mathImpaired display="inline" role="math"}[\$E\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ([[$\forall$ ]{.math
    display="inline" role="math"}[$\mathsf{\forall}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\forall\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> heisst *All-Quantor*)

((Seite4))

-   [[$\exists_{a \in M}a$ ]{.math display="inline"
    role="math"}[$\mathsf{\exists_{a \in M}a}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\exists\_{a \\in M}
    a\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> hat die Eigenschaft
    [[$E$ ]{.math display="inline" role="math"}[$\mathsf{E}$
    ]{.mathImpaired display="inline" role="math"}[\$E\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: es existiert ein
    [[$a \in M$ ]{.math display="inline" role="math"}[$\mathsf{a \in M}$
    ]{.mathImpaired display="inline" role="math"}[\$a \\in
    M\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> mit der Eigenschaft
    [[$E$ ]{.math display="inline" role="math"}[$\mathsf{E}$
    ]{.mathImpaired display="inline" role="math"}[\$E\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ([[$\exists$ ]{.math
    display="inline" role="math"}[$\mathsf{\exists}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\exists\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> heisst
    *Existenzquantor*)
-   [[$\exists_{a \in M}^{1}a$ ]{.math display="inline"
    role="math"}[$\mathsf{\exists_{a \in M}^{1}a}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\exists\^1\_{a \\in M}
    a\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> hat die Eigenschaft
    [[$E$ ]{.math display="inline" role="math"}[$\mathsf{E}$
    ]{.mathImpaired display="inline" role="math"}[\$E\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: es existiert *genau
    ein* [[$a \in M$ ]{.math display="inline"
    role="math"}[$\mathsf{a \in M}$ ]{.mathImpaired display="inline"
    role="math"}[\$a \\in M\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> mit der Eigenschaft
    [[$E$ ]{.math display="inline" role="math"}[$\mathsf{E}$
    ]{.mathImpaired display="inline" role="math"}[\$E\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

Grundsätzliches Ziel der Mathematik: Möglichst viele nichttriviale
Aussagen über gewisse Objekte. Ein solches gedankliches Gebäude kann
nicht aus dem \"Nichts\" kommen. Start des mathematischen Denkens:
Grundannahmen, *Axiome*, die nicht bewiesen werden können.

Insbesondere brauchen wir Axiome, die uns die *Zahlen* liefern.

Möglichkeiten:

-   Peano-*Axiome* liefern die natürlichen Zahlen [[$\mathbb{N}$ ]{.math
    display="inline" role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, daraus lassen sich
    ganze Zahlen und rationale Zahlen *konstruieren*. Ein weiteres Axiom
    lierfert die reellen Zahlen [[$\mathbb{R}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{R}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{R}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, woraus auch die
    komplexen Zahlen konstruierbar sind.
-   Wir können die Axiome sofort auf der Ebene der reellen Zahlen
    fordern. Das wollen wir auch im Folgenden tun.

((Seite5))

((Seite6))

1. Zahlen
=========

1.1 Reelle Zahlen
-----------------

Axiomatische Forderung: Es gibt eine Menge [[$\mathbb{R}$ ]{.math
display="inline" role="math"}[$\mathsf{\mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$\\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, genannt die Menge der
reellen Zahlen, mit folgenden Eigenschaften:

1.2. Axiome der reellen Zahlen
------------------------------

### 1.2.1. Körperaxiome 

In [[$\mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{\mathbb{R}}$ ]{.mathImpaired display="inline"
role="math"}[\$\\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> seien zwei Verknüpfungen
[[$+ , \cdot$ ]{.math display="inline" role="math"}[$\mathsf{+ , \cdot}$
]{.mathImpaired display="inline" role="math"}[\$+,\\cdot\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> gegeben, die jedem Paar
[[$a,b \in \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{a,b \in \mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$a, b \\in \\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> genau ein
[[$a + b \in \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{a + b \in \mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$a+b \\in \\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und ein
[[$a \cdot b \in \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{a \cdot b \in \mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$a \\cdot b \\in
\\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> zuordnen. Dabei sollte
gelten:

**A1: Assoziativgesetz der Addition**

![Die Addition ist
assoziativ](Images/Assoziativgesetz%20der%20Addition.svg "Assoziativgesetz der Addition"){.toRemove}

**A2: neutrales Element der Addition\
**[[$\exists 0 \in \mathbb{R}\forall a \in \mathbb{R}a + 0 = a$ ]{.math
display="inline"
role="math"}[$\mathsf{\exists 0 \in \mathbb{R}\forall a \in \mathbb{R}a + 0 = a}$
]{.mathImpaired display="inline" role="math"}[\$\\exists 0 \\in
\\mathbb{R} \\forall a \\in \\mathbb{R} a+0=a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

**A3: inverses Element der Addition\
**[[$\forall a \in \mathbb{R}\exists( - a) \in \mathbb{R}a + ( - a) = 0$
]{.math display="inline"
role="math"}[$\mathsf{\forall a \in \mathbb{R}\exists( - a) \in \mathbb{R}a + ( - a) = 0}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a \\in
\\mathbb{R} \\exists (-a) \\in \\mathbb{R} a+ (-a) =0\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

**A4: Kommutativgesetz der Addition\
**[[$\forall a,b \in \mathbb{R}a + b = b + a$ ]{.math display="inline"
role="math"}[$\mathsf{\forall a,b \in \mathbb{R}a + b = b + a}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b \\in
\\mathbb{R} a+b=b+a\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
\

A1 bis A4 ergibt: ([[$\mathbb{R}, +$ ]{.math display="inline"
role="math"}[$\mathsf{\mathbb{R}, +}$ ]{.mathImpaired display="inline"
role="math"}[\$\\mathbb{R}, +\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->) ist eine *kommutative
Gruppe*.\

**A5: Assoziativgesetz der Multiplikation\
**[[$\forall a,b,c \in \mathbb{R}(a \cdot b) \cdot c = a \cdot (b \cdot c)$
]{.math display="inline"
role="math"}[$\mathsf{\forall a,b,c \in \mathbb{R}(a \cdot b) \cdot c = a \cdot (b \cdot c)}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b,c \\in
\\mathbb{R} (a \\cdot b) \\cdot c = a \\cdot (b \\cdot
c)\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

**A6: neutrales Element der Multiplikation\
**[[$\exists 1 \in \mathbb{R}\forall a \in \mathbb{R}a \cdot 1 = a,1 \neq 0$
]{.math display="inline"
role="math"}[$\mathsf{\exists 1 \in \mathbb{R}\forall a \in \mathbb{R}a \cdot 1 = a,1 \neq 0}$
]{.mathImpaired display="inline" role="math"}[\$\\exists 1 \\in
\\mathbb{R} \\forall a \\in \\mathbb{R} a \\cdot 1=a, 1 \\neq
0\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

**A7: inverses Element der Multiplikation\
**[[$\forall a \in \mathbb{R}\backslash\{ 0\}\exists a^{- 1} \in \mathbb{R}a \cdot a^{- 1} = 1$
]{.math display="inline"
role="math"}[$\mathsf{\forall a \in \mathbb{R}\backslash\{ 0\}\exists a^{- 1} \in \mathbb{R}a \cdot a^{- 1} = 1}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a \\in
\\mathbb{R} \\setminus \\{0\\} \\exists a\^{-1} \\in \\mathbb{R} a
\\cdot a\^{-1}=1\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

**A8: Kommutitativgesetz der Multiplikation\
**[[$\forall a,b \in \mathbb{R}a \cdot b = b \cdot a$ ]{.math
display="inline"
role="math"}[$\mathsf{\forall a,b \in \mathbb{R}a \cdot b = b \cdot a}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b \\in
\\mathbb{R} a \\cdot b=b \\cdot a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

A5 bis A8 ergibt: ([[$\mathbb{R}\backslash\{ 0\}, \cdot$ ]{.math
display="inline"
role="math"}[$\mathsf{\mathbb{R}\backslash\{ 0\}, \cdot}$
]{.mathImpaired display="inline" role="math"}[\$\\mathbb{R} \\setminus
\\{ 0 \\}, \\cdot\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->) ist eine *kommutative
Gruppe*.\

**A9: Distributivgesetz\
**[[$\forall a,b,c \in \mathbb{R}a \cdot (b + c) = a \cdot b + a \cdot c$
]{.math display="inline"
role="math"}[$\mathsf{\forall a,b,c \in \mathbb{R}a \cdot (b + c) = a \cdot b + a \cdot c}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b,c \\in
\\mathbb{R} a \\cdot (b+c) = a \\cdot b + a \\cdot c\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

A1 bis A9 ergibt: [[$(\mathbb{R}, + , \cdot )$ ]{.math display="inline"
role="math"}[$\mathsf{(\mathbb{R}, + , \cdot )}$ ]{.mathImpaired
display="inline" role="math"}[\$( \\mathbb{R},+, \\cdot
)\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist ein *Körper*.

Alle bekannten Regeln der Grundrechenarten lassen sich aus A1 bis A9
herleiten und seien von nun an bekannt.

Schreibweise:

Für [[$a,b \in \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{a,b \in \mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$a,b \\in\\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->:\
[[$ab:=a \cdot b$ ]{.math display="inline"
role="math"}[$\mathsf{ab:=a \cdot b}$ ]{.mathImpaired display="inline"
role="math"}[\$ab := a \\cdot b\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
[[$a - b:=a + ( - b)$ ]{.math display="inline"
role="math"}[$\mathsf{a - b:=a + ( - b)}$ ]{.mathImpaired
display="inline" role="math"}[\$a-b := a + (-b)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
falls [[$a \neq 0:=\frac{a}{b}:=ba^{- 1}$ ]{.math display="inline"
role="math"}[$\mathsf{a \neq 0:=\frac{a}{b}:=ba^{- 1}}$ ]{.mathImpaired
display="inline" role="math"}[\$a \\neq 0 := \\frac{a}{b} :=
ba\^{-1}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

#### Biespiel 1.1.

1.  Das Nullement 0 ist eindeutig:\
    Sei [[$\widetilde{0}$ ]{.math display="inline"
    role="math"}[$\mathsf{\widetilde{0}}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\tilde{0}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> weiteres Element mit
    [[$\forall a \in \mathbb{R}a + \widetilde{0} = a$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\forall a \in \mathbb{R}a + \widetilde{0} = a}$
    ]{.mathImpaired display="inline" role="math"}[\$\\forall a \\in
    \\mathbb{R} a+ \\tilde{0} =a\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    Dann: [[$\widetilde{0} = \widetilde{0}0 = 0\widetilde{0} = 0$
    ]{.math display="inline"
    role="math"}[$\mathsf{\widetilde{0} = \widetilde{0}0 = 0\widetilde{0} = 0}$
    ]{.mathImpaired display="inline" role="math"}[\$\\tilde{0} =
    \\tilde{0}0 = 0 \\tilde{0} = 0\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
2.  [[$\forall a \in \mathbb{R}a \cdot 0 = 0$ ]{.math display="inline"
    role="math"}[$\mathsf{\forall a \in \mathbb{R}a \cdot 0 = 0}$
    ]{.mathImpaired display="inline" role="math"}[\$\\forall a \\in
    \\mathbb{R} a \\cdot 0 =0\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->:\
    [[$a \cdot 0 = a \cdot (0 + 0) = a \cdot 0 + a \cdot 0\quad| - (a \cdot 0)$
    ]{.math display="inline"
    role="math"}[$\mathsf{a \cdot 0 = a \cdot (0 + 0) = a \cdot 0 + a \cdot 0\quad| - (a \cdot 0)}$
    ]{.mathImpaired display="inline" role="math"}[\$a \\cdot 0 = a
    \\cdot (0+0) = a \\cdot 0 + a \\cdot 0 \\quad \\vert -(a \\cdot
    0)\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$0 = a \cdot 0$ ]{.math display="inline"
    role="math"}[$\mathsf{0 = a \cdot 0}$ ]{.mathImpaired
    display="inline" role="math"}[\$0= a \\cdot 0\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
3.  [[$\forall a \in \mathbb{R}a^{2} = ( - a)^{2}({\text{wobei:}\mspace{6mu}}a^{2} = a \cdot a)$
    ]{.math display="inline"
    role="math"}[$\mathsf{\forall a \in \mathbb{R}a^{2} = ( - a)^{2}({\text{wobei:}\mspace{6mu}}a^{2} = a \cdot a)}$
    ]{.mathImpaired display="inline" role="math"}[\$\\forall a \\in
    \\mathbb{R} a\^2 = (-a)\^2 ( \\text{wobei: } a\^2 = a \\cdot
    a)\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->:\
    [[$a^{2} = a \cdot a = a \cdot (a + a - a) = a \cdot (a + a) + a \cdot ( - a)$
    ]{.math display="inline"
    role="math"}[$\mathsf{a^{2} = a \cdot a = a \cdot (a + a - a) = a \cdot (a + a) + a \cdot ( - a)}$
    ]{.mathImpaired display="inline" role="math"}[\$a\^2 = a \\cdot a =
    a \\cdot (a+a-a) = a\\cdot (a+a)+a \\cdot (-a)\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$= a \cdot (a + a) + ( - a) \cdot (a + a - a) = a \cdot (a + a) + ( - a) \cdot (a + a) + ( - a) \cdot ( - a)$
    ]{.math display="inline"
    role="math"}[$\mathsf{= a \cdot (a + a) + ( - a) \cdot (a + a - a) = a \cdot (a + a) + ( - a) \cdot (a + a) + ( - a) \cdot ( - a)}$
    ]{.mathImpaired display="inline" role="math"}[\$= a \\cdot (a+a) +
    (-a) \\cdot (a+a-a) = a \\cdot (a+a) + (-a) \\cdot (a+a)+ (-a)
    \\cdot (-a)\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$= (a + a) \cdot (a - a) + ( - a)^{2} = (a + a) \cdot 0 + ( - a)^{2} = ( - a)2$
    ]{.math display="inline"
    role="math"}[$\mathsf{= (a + a) \cdot (a - a) + ( - a)^{2} = (a + a) \cdot 0 + ( - a)^{2} = ( - a)2}$
    ]{.mathImpaired display="inline" role="math"}[\$= (a+a) \\cdot
    (a-a) + (-a)\^2 = (a+a) \\cdot 0 + (-a)\^2 = (-a)2\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

### 1.2.2 Anordnungsaxiome

In [[$\mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{\mathbb{R}}$ ]{.mathImpaired display="inline"
role="math"}[\$\\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist eine Relation
[[$\leq$ ]{.math display="inline" role="math"}[$\mathsf{\leq}$
]{.mathImpaired display="inline" role="math"}[\$\\leq\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> gegeben, für die gilt:

**A10**\
[[$\forall a,b \in \mathbb{R}\lbrack a \leq b \vee b \leq a\rbrack$
]{.math display="inline"
role="math"}[$\mathsf{\forall a,b \in \mathbb{R}\lbrack a \leq b \vee b \leq a\rbrack}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b
\\in \\mathbb{R} \[a \\leq b \\vee b \\leq a\]\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

**A11**\
[[$\left. \forall a,b \in \mathbb{R}\lbrack(a \leq b \land b \leq a)\Rightarrow a = b\rbrack \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. \forall a,b \in \mathbb{R}\lbrack(a \leq b \land b \leq a)\Rightarrow a = b\rbrack \right.}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b \\in
\\mathbb{R} \[(a \\leq b \\wedge b \\leq a) \\Rightarrow
a=b\]\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

((Seite8))

**A12**\
[[$\left. \forall a,b,c \in \mathbb{R}\lbrack(a \leq b \land b \leq c)\Rightarrow a \leq c\rbrack \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. \forall a,b,c \in \mathbb{R}\lbrack(a \leq b \land b \leq c)\Rightarrow a \leq c\rbrack \right.}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b,c \\in
\\mathbb{R}  \[(a \\leq b \\wedge b \\leq c) \\Rightarrow a \\leq
c\]\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

[[$\left. \Rightarrow\mathbb{R} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. \Rightarrow\mathbb{R} \right.}$
]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow
\\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist eine total geordnete
Menge.

**A13**\
[[$\left. \forall a,b,c \in \mathbb{R}\lbrack(a \leq b)\Rightarrow(a + c \leq b + c)\rbrack \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. \forall a,b,c \in \mathbb{R}\lbrack(a \leq b)\Rightarrow(a + c \leq b + c)\rbrack \right.}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b,c \\in
\\mathbb{R} \[(a \\leq b) \\Rightarrow (a+c \\leq b+c)\]\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

**A14**\
[[$\left. \forall a,b,c \in \mathbb{R}\lbrack(a \leq b \land 0 \leq c)\Rightarrow a \cdot \leq b \cdot c\rbrack \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. \forall a,b,c \in \mathbb{R}\lbrack(a \leq b \land 0 \leq c)\Rightarrow a \cdot \leq b \cdot c\rbrack \right.}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b,c \\in
\\mathbb{R} \[(a \\leq b \\wedge 0 \\leq c) \\Rightarrow a \\cdot \\leq
b \\cdot c\]\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

Schreibweisen: [[$\forall a,b \in \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{\forall a,b \in \mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$\\forall a,b \\in
\\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

-   [[$\left. b \geq a:\Leftrightarrow a \leq b \right.$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\left. b \geq a:\Leftrightarrow a \leq b \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$b \\geq a :
    \\Leftrightarrow a \\leq b\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
-   [[[\$a &lt; b : \\Leftrightarrow (a \\leq b \\wedge a \\neq
    b)\$]{.math .inline} ]{.math display="inline" role="math"}[[\$a &lt;
    b : \\Leftrightarrow (a \\leq b \\wedge a \\neq b)\$]{.math .inline}
    ]{.mathImpaired display="inline" role="math"}[\$a \< b :
    \\Leftrightarrow (a \\leq b \\wedge a \\neq b)\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
-   [[[\$b &gt; a: \\Leftrightarrow a &lt; b\$]{.math .inline} ]{.math
    display="inline" role="math"}[[\$b &gt; a: \\Leftrightarrow a &lt;
    b\$]{.math .inline} ]{.mathImpaired display="inline"
    role="math"}[\$b \> a: \\Leftrightarrow a \< b\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

Alle bekannten Regeln für Ungleichungen lassen sich aus A1 bis A14
herleiten und seien von nun an bekannt.

Beispiel 1.2.

1.  [[$\left. \forall a,b,c \in \mathbb{R}\lbrack a \leq b \land c \leq 0)\Rightarrow a \cdot c \leq b \cdot c\rbrack \right.$
    ]{.math display="inline"
    role="math"}[$\mathsf{\left. \forall a,b,c \in \mathbb{R}\lbrack a \leq b \land c \leq 0)\Rightarrow a \cdot c \leq b \cdot c\rbrack \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\forall a,b,c \\in
    \\mathbb{R} \[a \\leq b \\wedge c \\leq 0) \\Rightarrow a \\cdot c
    \\leq b\\cdot c\]\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    **Beweis:**\
    [[$\left. c \leq 0\Rightarrow 0 \leq - c \right.$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\left. c \leq 0\Rightarrow 0 \leq - c \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$c \\leq 0
    \\Rightarrow 0 \\leq -c\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$\left. \Rightarrow a \cdot ( - c) \leq b \cdot ( - c) \right.$
    ]{.math display="inline"
    role="math"}[$\mathsf{\left. \Rightarrow a \cdot ( - c) \leq b \cdot ( - c) \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow a
    \\cdot (-c) \\leq b \\cdot (-c)\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$\left. \Rightarrow bc \leq ac \right.$ ]{.math display="inline"
    role="math"}[$\mathsf{\left. \Rightarrow bc \leq ac \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow bc
    \\leq ac\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\square\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
2.  [[[\$\\forall a,b,c \\in \\mathbb{R} \[(a \\leq b \\wedge c&gt;0)
    \\Rightarrow a \\cdot c \\leq b \\cdot c\]\$]{.math .inline} ]{.math
    display="inline" role="math"}[[\$\\forall a,b,c \\in \\mathbb{R}
    \[(a \\leq b \\wedge c&gt;0) \\Rightarrow a \\cdot c \\leq b \\cdot
    c\]\$]{.math .inline} ]{.mathImpaired display="inline"
    role="math"}[\$\\forall a,b,c \\in \\mathbb{R} \[(a \\leq b \\wedge
    c\>0) \\Rightarrow a \\cdot c \\leq b \\cdot c\]\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

Betrag einer reellen Zahl:\
[[$\forall a \in \mathbb{R}|a|:=\left\{ \begin{array}{lc}
{a{\mspace{6mu}\text{falls}\mspace{6mu}}a \geq 0} & \\
{- a{\mspace{6mu}\text{falls}\mspace{6mu}}a} & {lt;0} \\
\end{array} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\forall a \in \mathbb{R}|a|:=\left\{ \begin{array}{lc}
{a{\mspace{6mu}\text{falls}\mspace{6mu}}a \geq 0} & \\
{- a{\mspace{6mu}\text{falls}\mspace{6mu}}a} & {lt;0} \\
\end{array} \right.}$ ]{.mathImpaired display="inline"
role="math"}[\$\\forall a \\in \\mathbb{R} \|a\| := \\begin{cases} a
\\text{ falls } a \\geq 0 \\\\ -a \\text{ falls } a \< 0
\\end{cases}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\

[[$|a|$ ]{.math display="inline" role="math"}[$\mathsf{|a|}$
]{.mathImpaired display="inline" role="math"}[\$\|a\|\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->: Abstand von [[$a$
]{.math display="inline" role="math"}[$\mathsf{a}$ ]{.mathImpaired
display="inline" role="math"}[\$a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> zur 0\
[[$|a - b|$ ]{.math display="inline" role="math"}[$\mathsf{|a - b|}$
]{.mathImpaired display="inline" role="math"}[\$\|a-b\|\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->: Abstand von [[$a$
]{.math display="inline" role="math"}[$\mathsf{a}$ ]{.mathImpaired
display="inline" role="math"}[\$a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[$b$ ]{.math
display="inline" role="math"}[$\mathsf{b}$ ]{.mathImpaired
display="inline" role="math"}[\$b\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

1.  [[$|a| \geq 0$ ]{.math display="inline"
    role="math"}[$\mathsf{|a| \geq 0}$ ]{.mathImpaired display="inline"
    role="math"}[\$\|a\| \\geq 0\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
2.  [[$\left. |a| = 0\Leftrightarrow a = 0 \right.$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\left. |a| = 0\Leftrightarrow a = 0 \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\|a\| = 0
    \\Leftrightarrow a=0\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
3.  [[$|a| = | - a|$ ]{.math display="inline"
    role="math"}[$\mathsf{|a| = | - a|}$ ]{.mathImpaired
    display="inline" role="math"}[\$\|a\| = \|-a\|\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
4.  [[$|a \cdot b| = |a| \cdot |b|$ ]{.math display="inline"
    role="math"}[$\mathsf{|a \cdot b| = |a| \cdot |b|}$ ]{.mathImpaired
    display="inline" role="math"}[\$\|a \\cdot b\| = \|a\| \\cdot
    \|b\|\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
5.  [[$a \leq |a|, - a \leq |a|$ ]{.math display="inline"
    role="math"}[$\mathsf{a \leq |a|, - a \leq |a|}$ ]{.mathImpaired
    display="inline" role="math"}[\$a \\leq \|a\|, -a \\leq
    \|a\|\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
6.  Dreiecksungleichung:\
    [[$|a + b| \leq |a| + |b|$ ]{.math display="inline"
    role="math"}[$\mathsf{|a + b| \leq |a| + |b|}$ ]{.mathImpaired
    display="inline" role="math"}[\$\|a+b\| \\leq \|a\| +
    \|b\|\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
7.  [[$||a| - |b|| \leq |a - b|$ ]{.math display="inline"
    role="math"}[$\mathsf{||a| - |b|| \leq |a - b|}$ ]{.mathImpaired
    display="inline" role="math"}[\$\| \|a\|-\|b\| \| \\leq
    \|a-b\|\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

((Seite9))

**Beweis:** zu 6.

1\. Fall: [[$a + b \geq 0$ ]{.math display="inline"
role="math"}[$\mathsf{a + b \geq 0}$ ]{.mathImpaired display="inline"
role="math"}[\$a+b \\geq 0\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Dann:\
[[$|a + b| = a + b \leq |a| + b \leq |a| + |b|$ ]{.math display="inline"
role="math"}[$\mathsf{|a + b| = a + b \leq |a| + b \leq |a| + |b|}$
]{.mathImpaired display="inline" role="math"}[\$\|a+b\| = a+b \\leq
\|a\|+b \\leq \|a\|+\|b\|\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

2\. Fall: [[[\$a+b &lt; 0\$]{.math .inline} ]{.math display="inline"
role="math"}[[\$a+b &lt; 0\$]{.math .inline} ]{.mathImpaired
display="inline" role="math"}[\$a+b \< 0\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Dann:\
[[$|a + b| = - (a + b) = ( - a) + ( - b) \leq |a| + |b|$ ]{.math
display="inline"
role="math"}[$\mathsf{|a + b| = - (a + b) = ( - a) + ( - b) \leq |a| + |b|}$
]{.mathImpaired display="inline" role="math"}[\$\|a+b\| = -(a+b) =
(-a)+(-b) \\leq \|a\|+\|b\|\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

### Definition 1.3.

Sei [[$M \subset \mathbb{R},M \neq \varnothing$ ]{.math display="inline"
role="math"}[$\mathsf{M \subset \mathbb{R},M \neq \varnothing}$
]{.mathImpaired display="inline" role="math"}[\$M \\subset \\mathbb{R},
M \\neq \\emptyset\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißt *nach oben
Beschränkt\
*[[$\left. :\Leftrightarrow\exists\gamma \in \mathbb{R}\forall x \in Mx \leq \gamma \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. :\Leftrightarrow\exists\gamma \in \mathbb{R}\forall x \in Mx \leq \gamma \right.}$
]{.mathImpaired display="inline" role="math"}[\$: \\Leftrightarrow
\\exists \\gamma \\in \\mathbb{R} \\forall x \\in M x \\leq
\\gamma\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

[[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißt *nach unten
beschränkt*\
[[$\left. :\Leftrightarrow\exists\gamma \in \mathbb{R}\forall x \in Mx \geq \gamma \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. :\Leftrightarrow\exists\gamma \in \mathbb{R}\forall x \in Mx \geq \gamma \right.}$
]{.mathImpaired display="inline" role="math"}[\$: \\Leftrightarrow
\\exists \\gamma \\in \\mathbb{R} \\forall x \\in M x \\geq
\\gamma\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

In diesem Fall heißt [[$\gamma$ ]{.math display="inline"
role="math"}[$\mathsf{\gamma}$ ]{.mathImpaired display="inline"
role="math"}[\$\\gamma\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> obere Schranke (bzw.
untere Schranke) von [[$M$ ]{.math display="inline"
role="math"}[$\mathsf{M}$ ]{.mathImpaired display="inline"
role="math"}[\$M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

Ist [[$\gamma$ ]{.math display="inline" role="math"}[$\mathsf{\gamma}$
]{.mathImpaired display="inline" role="math"}[\$\\gamma\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine obere Schranke von
[[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und gilt für *jede*
weitere obere Schranke [[$\widetilde{\gamma}$ ]{.math display="inline"
role="math"}[$\mathsf{\widetilde{\gamma}}$ ]{.mathImpaired
display="inline" role="math"}[\$\\tilde{\\gamma}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> von [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> :
[[$\gamma \leq \widetilde{\gamma}$ ]{.math display="inline"
role="math"}[$\mathsf{\gamma \leq \widetilde{\gamma}}$ ]{.mathImpaired
display="inline" role="math"}[\$\\gamma \\leq
\\tilde{\\gamma}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, (d.h. [[$\gamma$ ]{.math
display="inline" role="math"}[$\mathsf{\gamma}$ ]{.mathImpaired
display="inline" role="math"}[\$\\gamma\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist *kleinste* obere
Schranke von [[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$
]{.mathImpaired display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->), so heißt [[$\gamma$
]{.math display="inline" role="math"}[$\mathsf{\gamma}$ ]{.mathImpaired
display="inline" role="math"}[\$\\gamma\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> das *Supremum* von [[$M$
]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

Ist [[$\gamma$ ]{.math display="inline" role="math"}[$\mathsf{\gamma}$
]{.mathImpaired display="inline" role="math"}[\$\\gamma\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine untere Schranke von
[[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und gilt für *jede*
weitere untere Schranke [[$\widetilde{\gamma}$ ]{.math display="inline"
role="math"}[$\mathsf{\widetilde{\gamma}}$ ]{.mathImpaired
display="inline" role="math"}[\$\\tilde{\\gamma}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> von [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> :
[[$\gamma \geq \widetilde{\gamma}$ ]{.math display="inline"
role="math"}[$\mathsf{\gamma \geq \widetilde{\gamma}}$ ]{.mathImpaired
display="inline" role="math"}[\$\\gamma \\geq
\\tilde{\\gamma}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, (d.h. [[$\gamma$ ]{.math
display="inline" role="math"}[$\mathsf{\gamma}$ ]{.mathImpaired
display="inline" role="math"}[\$\\gamma\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist *größte* untere
Schranke von [[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$
]{.mathImpaired display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->), so heißt [[$\gamma$
]{.math display="inline" role="math"}[$\mathsf{\gamma}$ ]{.mathImpaired
display="inline" role="math"}[\$\\gamma\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> das *Infimum* von [[$M$
]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

Falls [[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$
]{.mathImpaired display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eni Supremum hat, so ist
nach A11 dieses eindeutig bestimmt. (Infimum analog)

Bezeichnung: [[$\sup M,\inf M$ ]{.math display="inline"
role="math"}[$\mathsf{\sup M,\inf M}$ ]{.mathImpaired display="inline"
role="math"}[\$\\sup M, \\inf M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

Existiert [[$\sup M$ ]{.math display="inline"
role="math"}[$\mathsf{\sup M}$ ]{.mathImpaired display="inline"
role="math"}[\$\\sup M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und gilt [[$\sup M \in M$
]{.math display="inline" role="math"}[$\mathsf{\sup M \in M}$
]{.mathImpaired display="inline" role="math"}[\$\\sup M \\in
M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, so heißt [[$\sup M$
]{.math display="inline" role="math"}[$\mathsf{\sup M}$ ]{.mathImpaired
display="inline" role="math"}[\$\\sup M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> auch *Maximum* von [[$M$
]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (Bezeichnung [[$\max M$
]{.math display="inline" role="math"}[$\mathsf{\max M}$ ]{.mathImpaired
display="inline" role="math"}[\$\\max M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->).

Existiert [[$\inf M$ ]{.math display="inline"
role="math"}[$\mathsf{\inf M}$ ]{.mathImpaired display="inline"
role="math"}[\$\\inf M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und gilt [[$\inf M \in M$
]{.math display="inline" role="math"}[$\mathsf{\inf M \in M}$
]{.mathImpaired display="inline" role="math"}[\$\\inf M \\in
M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, so heißt [[$\inf M$
]{.math display="inline" role="math"}[$\mathsf{\inf M}$ ]{.mathImpaired
display="inline" role="math"}[\$\\inf M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> auch *Minimum* von [[$M$
]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (Bezeichnung [[$\min M$
]{.math display="inline" role="math"}[$\mathsf{\min M}$ ]{.mathImpaired
display="inline" role="math"}[\$\\min M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->).

### Beispiel 1.4. Intervalle

Seien [[[\$a,b \\in \\mathbb{R}, a &lt; b\$]{.math .inline} ]{.math
display="inline" role="math"}[[\$a,b \\in \\mathbb{R}, a &lt; b\$]{.math
.inline} ]{.mathImpaired display="inline" role="math"}[\$a,b \\in
\\mathbb{R}, a \< b\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

-   [[[\$(a,b) := \\{ x \\in \\mathbb{R} : a &lt; x &lt; b \\}\$]{.math
    .inline} ]{.math display="inline" role="math"}[[\$(a,b) := \\{ x
    \\in \\mathbb{R} : a &lt; x &lt; b \\}\$]{.math .inline}
    ]{.mathImpaired display="inline" role="math"}[\$(a,b) := \\{ x \\in
    \\mathbb{R} : a \< x \< b \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> (offenes Intervall)
-   [[$\lbrack a,b\rbrack:=\{ x \in \mathbb{R}:a \leq x \leq b\}$
    ]{.math display="inline"
    role="math"}[$\mathsf{\lbrack a,b\rbrack:=\{ x \in \mathbb{R}:a \leq x \leq b\}}$
    ]{.mathImpaired display="inline" role="math"}[\$\[a,b\] := \\{ x
    \\in \\mathbb{R} : a \\leq x \\leq b \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> (abgeschlossenes
    Intervall)
-   [[[\$(a,b\] := \\{ x \\in \\mathbb{R} : a &lt; x \\leq b
    \\}\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$(a,b\] := \\{ x \\in \\mathbb{R} : a &lt; x \\leq b
    \\}\$]{.math .inline} ]{.mathImpaired display="inline"
    role="math"}[\$(a,b\] := \\{ x \\in \\mathbb{R} : a \< x \\leq b
    \\}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> (halboffenes
    Intervall)
-   [[$\lbrack a,\infty):=\{ x \in \mathbb{R}:a \leq x\}$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\lbrack a,\infty):=\{ x \in \mathbb{R}:a \leq x\}}$
    ]{.mathImpaired display="inline" role="math"}[\$\[ a, \\infty ) :=
    \\{ x \\in \\mathbb{R} : a \\leq x \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
-   [[[\$(a, \\infty ) := \\{ x \\in \\mathbb{R} : a &lt; x \\}\$]{.math
    .inline} ]{.math display="inline" role="math"}[[\$(a, \\infty ) :=
    \\{ x \\in \\mathbb{R} : a &lt; x \\}\$]{.math .inline}
    ]{.mathImpaired display="inline" role="math"}[\$(a, \\infty ) := \\{
    x \\in \\mathbb{R} : a \< x \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
-   [[[\$(- \\infty, a) := \\{ x \\in \\mathbb{R} : x&lt;a \\}\$]{.math
    .inline} ]{.math display="inline" role="math"}[[\$(- \\infty, a) :=
    \\{ x \\in \\mathbb{R} : x&lt;a \\}\$]{.math .inline}
    ]{.mathImpaired display="inline" role="math"}[\$(- \\infty, a) :=
    \\{ x \\in \\mathbb{R} : x\<a \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
-   [[$( - \infty,a\rbrack:=\{ x \in \mathbb{R}:x \leq a\}$ ]{.math
    display="inline"
    role="math"}[$\mathsf{( - \infty,a\rbrack:=\{ x \in \mathbb{R}:x \leq a\}}$
    ]{.mathImpaired display="inline" role="math"}[\$(- \\infty, a\] :=
    \\{ x \\in \\mathbb{R} : x \\leq a \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
-   [[$( - \infty,\infty):=\mathbb{R}$ ]{.math display="inline"
    role="math"}[$\mathsf{( - \infty,\infty):=\mathbb{R}}$
    ]{.mathImpaired display="inline" role="math"}[\$(- \\infty, \\infty
    ) := \\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

### Beispiel 1.5. Beispiele von Mengen und deren Schranken:

> \(1) [[$M = (1,2)$ ]{.math display="inline"
> role="math"}[$\mathsf{M = (1,2)}$ ]{.mathImpaired display="inline"
> role="math"}[\$M=(1,2)\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> obere Schranken: alle Zahlen [[$\geq 2$ ]{.math display="inline"
> role="math"}[$\mathsf{\geq 2}$ ]{.mathImpaired display="inline"
> role="math"}[\$\\geq 2\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> [[$\sup M = 2,2 \notin M$ ]{.math display="inline"
> role="math"}[$\mathsf{\sup M = 2,2 \notin M}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\sup M=2, 2 \\notin M\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, daher existiert das
> Maximum von [[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$
> ]{.mathImpaired display="inline" role="math"}[\$M\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> nicht.
>
> untere Schranken: alle Zahlen [[$\leq 1$ ]{.math display="inline"
> role="math"}[$\mathsf{\leq 1}$ ]{.mathImpaired display="inline"
> role="math"}[\$\\leq 1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> [[$\inf M = 1,1 \notin M$ ]{.math display="inline"
> role="math"}[$\mathsf{\inf M = 1,1 \notin M}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\inf M=1, 1 \\notin M\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, daher existiert
> das Minimum von [[$M$ ]{.math display="inline"
> role="math"}[$\mathsf{M}$ ]{.mathImpaired display="inline"
> role="math"}[\$M\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> nicht.

((Seite 10))

> \(2) [[$M = (1,2\rbrack$ ]{.math display="inline"
> role="math"}[$\mathsf{M = (1,2\rbrack}$ ]{.mathImpaired display="inline"
> role="math"}[\$M=(1,2\]\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> obere Schranken: alle Zahlen [[$\geq 2$ ]{.math display="inline"
> role="math"}[$\mathsf{\geq 2}$ ]{.mathImpaired display="inline"
> role="math"}[\$\\geq 2\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> [[$\left. \sup M = 2,2 \in M\Rightarrow\max M = 2 \right.$ ]{.math
> display="inline"
> role="math"}[$\mathsf{\left. \sup M = 2,2 \in M\Rightarrow\max M = 2 \right.}$
> ]{.mathImpaired display="inline" role="math"}[\$\\sup M=2, 2 \\in M
> \\Rightarrow \\max M=2\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->.
>
> untere Schranken: alle Zahlen [[$\leq 1$ ]{.math display="inline"
> role="math"}[$\mathsf{\leq 1}$ ]{.mathImpaired display="inline"
> role="math"}[\$\\leq 1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> [[$\inf M = 1,1 \notin M$ ]{.math display="inline"
> role="math"}[$\mathsf{\inf M = 1,1 \notin M}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\inf M=1, 1 \\notin M\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, daher existiert
> das Minimum von [[$M$ ]{.math display="inline"
> role="math"}[$\mathsf{M}$ ]{.mathImpaired display="inline"
> role="math"}[\$M\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> nicht.
>
> \(3) [[$M = \lbrack 2,\infty)$ ]{.math display="inline"
> role="math"}[$\mathsf{M = \lbrack 2,\infty)}$ ]{.mathImpaired
> display="inline" role="math"}[\$M=\[2, \\infty )\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> [[$\inf M = 2;2 \in M,{\mspace{6mu}\text{also}\mspace{6mu}}\min M = 2$
> ]{.math display="inline"
> role="math"}[$\mathsf{\inf M = 2;2 \in M,{\mspace{6mu}\text{also}\mspace{6mu}}\min M = 2}$
> ]{.mathImpaired display="inline" role="math"}[\$\\inf M=2; 2 \\in M,
> \\text{ also } \\min M=2\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> [[$\sup M$ ]{.math display="inline" role="math"}[$\mathsf{\sup M}$
> ]{.mathImpaired display="inline" role="math"}[\$\\sup
> M\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> existiert nicht

**A15\
**Ist [[$M \subset \mathbb{R},M \neq \varnothing,M$ ]{.math
display="inline"
role="math"}[$\mathsf{M \subset \mathbb{R},M \neq \varnothing,M}$
]{.mathImpaired display="inline" role="math"}[\$M \\subset \\mathbb{R},
M \\neq \\emptyset, M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> nach oben beschränkt, so
existiert [[$\sup M$ ]{.math display="inline"
role="math"}[$\mathsf{\sup M}$ ]{.mathImpaired display="inline"
role="math"}[\$\\sup M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

### Satz 1.6. {dir="ltr"}

Ist [[$M \subset \mathbb{R},M \neq \varnothing,M$ ]{.math
display="inline"
role="math"}[$\mathsf{M \subset \mathbb{R},M \neq \varnothing,M}$
]{.mathImpaired display="inline" role="math"}[\$M \\subset \\mathbb{R},
M \\neq \\emptyset, M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> nach unten beschränkt, so
existiert [[$\inf M$ ]{.math display="inline"
role="math"}[$\mathsf{\inf M}$ ]{.mathImpaired display="inline"
role="math"}[\$\\inf M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

**Beweis:** Betrachte [[$- M:=\{ - x,x, \in M\}$ ]{.math
display="inline" role="math"}[$\mathsf{- M:=\{ - x,x, \in M\}}$
]{.mathImpaired display="inline" role="math"}[\$-M := \\{ -x,x, \\in M
\\}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> statt [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. [[ ]{.math
display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
display="inline" role="math"}[\$\\square\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

### Definition 1.7. {dir="ltr"}

Sei [[$M \subset \mathbb{R},M \neq \varnothing$ ]{.math display="inline"
role="math"}[$\mathsf{M \subset \mathbb{R},M \neq \varnothing}$
]{.mathImpaired display="inline" role="math"}[\$M \\subset \\mathbb{R},
M \\neq \\emptyset\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
[[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißt *beschränkt*, wenn
[[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> nach oben und nach unten
beschränkt ist.

Es gilt: [[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$
]{.mathImpaired display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> beschränkt
[[[\$\\Leftrightarrow \\exists c &gt; 0 \\forall x \\in M \|x\| \\leq
c\$]{.math .inline} ]{.math display="inline"
role="math"}[[\$\\Leftrightarrow \\exists c &gt; 0 \\forall x \\in M
\|x\| \\leq c\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$\\Leftrightarrow \\exists c \> 0 \\forall x \\in M \|x\|
\\leq c\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

### Satz 1.8. {dir="ltr"}

Sei [[$B \subset A \subset \mathbb{R},B \neq \varnothing$ ]{.math
display="inline"
role="math"}[$\mathsf{B \subset A \subset \mathbb{R},B \neq \varnothing}$
]{.mathImpaired display="inline" role="math"}[\$B \\subset A \\subset
\\mathbb{R}, B \\neq \\emptyset\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, dann gilt:

1.  <div>

    Ist [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> beschränkt, so gilt
    [[$\inf A \leq \sup A$ ]{.math display="inline"
    role="math"}[$\mathsf{\inf A \leq \sup A}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\inf A \\leq \\sup
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

    </div>

2.  <div>

    Ist [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nach oben beschränkt,
    so ist auch [[$B$ ]{.math display="inline" role="math"}[$\mathsf{B}$
    ]{.mathImpaired display="inline" role="math"}[\$B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nach oben beschränkt,
    und [[$\sup B \leq \sup A$ ]{.math display="inline"
    role="math"}[$\mathsf{\sup B \leq \sup A}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\sup B \\leq \\sup
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    Ist [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nach unten
    beschränkt, so ist auch [[$B$ ]{.math display="inline"
    role="math"}[$\mathsf{B}$ ]{.mathImpaired display="inline"
    role="math"}[\$B\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nach unten
    beschränkt, und [[$\inf B \geq \inf A$ ]{.math display="inline"
    role="math"}[$\mathsf{\inf B \geq \inf A}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\inf B \\geq \\inf
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

    </div>

3.  <div>

    Ist [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nach oben beschränkt
    und [[$\gamma$ ]{.math display="inline"
    role="math"}[$\mathsf{\gamma}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\gamma\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> eine obere Schranke
    von [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, so gilt:\
    [[[\$\\gamma = \\sup A \\Leftrightarrow \\forall \\epsilon &gt; 0
    \\exists x \\in A x &gt; \\gamma - \\epsilon\$]{.math .inline}
    ]{.math display="inline" role="math"}[[\$\\gamma = \\sup A
    \\Leftrightarrow \\forall \\epsilon &gt; 0 \\exists x \\in A x &gt;
    \\gamma - \\epsilon\$]{.math .inline} ]{.mathImpaired
    display="inline" role="math"}[\$\\gamma = \\sup A \\Leftrightarrow
    \\forall \\epsilon \> 0 \\exists x \\in A x \> \\gamma -
    \\epsilon\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    Ist [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nach unten beschränkt
    und [[$\gamma$ ]{.math display="inline"
    role="math"}[$\mathsf{\gamma}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\gamma\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> eine untere Schranke
    von [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, so gilt:\
    [[[\$\\gamma = \\inf A \\Leftrightarrow \\forall \\epsilon &gt; 0
    \\exists x \\in A x &lt; \\gamma + \\epsilon\$]{.math .inline}
    ]{.math display="inline" role="math"}[[\$\\gamma = \\inf A
    \\Leftrightarrow \\forall \\epsilon &gt; 0 \\exists x \\in A x &lt;
    \\gamma + \\epsilon\$]{.math .inline} ]{.mathImpaired
    display="inline" role="math"}[\$\\gamma = \\inf A \\Leftrightarrow
    \\forall \\epsilon \> 0 \\exists x \\in A x \< \\gamma +
    \\epsilon\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

    </div>

**Beweis:**\

1.  Wähle [[$x \in A$ ]{.math display="inline"
    role="math"}[$\mathsf{x \in A}$ ]{.mathImpaired display="inline"
    role="math"}[\$x \\in A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. Da [[$\sup A$
    ]{.math display="inline" role="math"}[$\mathsf{\sup A}$
    ]{.mathImpaired display="inline" role="math"}[\$\\sup
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> obere Schranke von
    [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, gilt:
    [[$x \leq \sup A$ ]{.math display="inline"
    role="math"}[$\mathsf{x \leq \sup A}$ ]{.mathImpaired
    display="inline" role="math"}[\$x \\leq \\sup A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    Da [[$\inf A$ ]{.math display="inline"
    role="math"}[$\mathsf{\inf A}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\inf A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> untere Schranke von
    [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, gilt:
    [[$x \geq \inf A$ ]{.math display="inline"
    role="math"}[$\mathsf{x \geq \inf A}$ ]{.mathImpaired
    display="inline" role="math"}[\$x \\geq \\inf A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$\left. \Rightarrow\inf A \leq \sup A \right.$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\left. \Rightarrow\inf A \leq \sup A \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow \\inf A
    \\leq \\sup A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
2.  (obere Zeile):  [[$\sup A$ ]{.math display="inline"
    role="math"}[$\mathsf{\sup A}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\sup A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist obere Schranke
    von [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, also (wegen
    [[$B \subset A$ ]{.math display="inline"
    role="math"}[$\mathsf{B \subset A}$ ]{.mathImpaired display="inline"
    role="math"}[\$B \\subset A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->) auch von [[$B$
    ]{.math display="inline" role="math"}[$\mathsf{B}$ ]{.mathImpaired
    display="inline" role="math"}[\$B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. Da [[$\sup B$
    ]{.math display="inline" role="math"}[$\mathsf{\sup B}$
    ]{.mathImpaired display="inline" role="math"}[\$\\sup
    B\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> *kleinste* obere
    Schranke von [[$B$ ]{.math display="inline"
    role="math"}[$\mathsf{B}$ ]{.mathImpaired display="inline"
    role="math"}[\$B\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, folgt
    [[$\sup B \leq \sup A$ ]{.math display="inline"
    role="math"}[$\mathsf{\sup B \leq \sup A}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\sup B \\leq \\sup
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.
3.  (obere Zeile):\
    \"[[$\Rightarrow$ ]{.math display="inline"
    role="math"}[$\mathsf{\Rightarrow}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\Rightarrow\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\": Sei
    [[$\gamma = \sup A$ ]{.math display="inline"
    role="math"}[$\mathsf{\gamma = \sup A}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\gamma = \\sup A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, und sei
    [[[\$\\epsilon &gt;0\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$\\epsilon &gt;0\$]{.math .inline} ]{.mathImpaired
    display="inline" role="math"}[\$\\epsilon \>0\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. Da [[[\$\\gamma -
    \\epsilon &lt; \\gamma\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$\\gamma - \\epsilon &lt; \\gamma\$]{.math .inline}
    ]{.mathImpaired display="inline" role="math"}[\$\\gamma - \\epsilon
    \< \\gamma\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, ist
    [[$\gamma - \epsilon$ ]{.math display="inline"
    role="math"}[$\mathsf{\gamma - \epsilon}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\gamma - \\epsilon\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> keine obere Schranke
    von [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. Also existiert ein
    [[$x \in A$ ]{.math display="inline" role="math"}[$\mathsf{x \in A}$
    ]{.mathImpaired display="inline" role="math"}[\$x \\in
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> mit [[[\$x &gt;
    \\gamma - \\epsilon\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$x &gt; \\gamma - \\epsilon\$]{.math .inline}
    ]{.mathImpaired display="inline" role="math"}[\$x \> \\gamma -
    \\epsilon\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    \"[[$\Leftarrow$ ]{.math display="inline"
    role="math"}[$\mathsf{\Leftarrow}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\Leftarrow\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\": Es gelte
    [[[\$\\forall \\epsilon &gt; 0 \\exists x \\in A x &gt; \\gamma -
    \\epsilon\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$\\forall \\epsilon &gt; 0 \\exists x \\in A x &gt;
    \\gamma - \\epsilon\$]{.math .inline} ]{.mathImpaired
    display="inline" role="math"}[\$\\forall \\epsilon \> 0 \\exists x
    \\in A x \> \\gamma - \\epsilon\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. Wäre [[$\gamma$
    ]{.math display="inline" role="math"}[$\mathsf{\gamma}$
    ]{.mathImpaired display="inline"
    role="math"}[\$\\gamma\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nicht das Supremum
    von [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, so existiert eine
    kleinere obere Schranke [[$\widetilde{\gamma}$ ]{.math
    display="inline" role="math"}[$\mathsf{\widetilde{\gamma}}$
    ]{.mathImpaired display="inline"
    role="math"}[\$\\tilde{\\gamma}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> von [[$A$ ]{.math
    display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
    display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. (also
    [[[\$\\tilde{\\gamma} &lt; \\gamma\$]{.math .inline} ]{.math
    display="inline" role="math"}[[\$\\tilde{\\gamma} &lt;
    \\gamma\$]{.math .inline} ]{.mathImpaired display="inline"
    role="math"}[\$\\tilde{\\gamma} \< \\gamma\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->).\
    Setze [[[\$\\epsilon := \\gamma - \\tilde{\\gamma} &gt;0\$]{.math
    .inline} ]{.math display="inline" role="math"}[[\$\\epsilon :=
    \\gamma - \\tilde{\\gamma} &gt;0\$]{.math .inline} ]{.mathImpaired
    display="inline" role="math"}[\$\\epsilon := \\gamma -
    \\tilde{\\gamma} \>0\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. Nach Voraussetzung
    existiert ein [[$x \in A$ ]{.math display="inline"
    role="math"}[$\mathsf{x \in A}$ ]{.mathImpaired display="inline"
    role="math"}[\$x \\in A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> mit [[[\$x &gt;
    \\gamma - \\epsilon = \\gamma - (\\gamma - \\tilde{\\gamma} ) =
    \\tilde{\\gamma}\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$x &gt; \\gamma - \\epsilon = \\gamma - (\\gamma -
    \\tilde{\\gamma} ) = \\tilde{\\gamma}\$]{.math .inline}
    ]{.mathImpaired display="inline" role="math"}[\$x \> \\gamma -
    \\epsilon = \\gamma - (\\gamma - \\tilde{\\gamma} ) =
    \\tilde{\\gamma}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$\left. \Rightarrow\widetilde{\gamma} \right.$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\left. \Rightarrow\widetilde{\gamma} \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow
    \\tilde{\\gamma}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist keine obere
    Schranke von [[$A$ ]{.math display="inline"
    role="math"}[$\mathsf{A}$ ]{.mathImpaired display="inline"
    role="math"}[\$A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. [[$\Rightarrow$
    ]{.math display="inline" role="math"}[$\mathsf{\Rightarrow}$
    ]{.mathImpaired display="inline"
    role="math"}[\$\\Rightarrow\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> Widerspruch.
    ([[[\$\\Lightning\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$\\Lightning\$]{.math .inline} ]{.mathImpaired
    display="inline" role="math"}[\$\\Lightning\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->)\
    [[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\square\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

((Seite11))

1.3. Natürliche Zahlen
----------------------

### Definition 1.9.

[[$A \subset \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{A \subset \mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$A \\subset \\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißt *Induktionsmenge*
(IM), wenn gilt:

1.  [[$1 \in A$ ]{.math display="inline" role="math"}[$\mathsf{1 \in A}$
    ]{.mathImpaired display="inline" role="math"}[\$1 \\in
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
2.  [[$\forall x \in Ax + 1 \in A$ ]{.math display="inline"
    role="math"}[$\mathsf{\forall x \in Ax + 1 \in A}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\forall x \\in A x+1 \\in
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

### Beispiel 1.10.

[[$\mathbb{R},\lbrack!,\infty),\{ 1\} \cup \lbrack 2,\infty)$ ]{.math
display="inline"
role="math"}[$\mathsf{\mathbb{R},\lbrack!,\infty),\{ 1\} \cup \lbrack 2,\infty)}$
]{.mathImpaired display="inline" role="math"}[\$\\mathbb{R}, \[!,
\\infty ), \\{ 1 \\} \\cup \[2, \\infty )\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> sind Induktionsmengen.\
[[$\{ 1\} \cup (2,\infty)$ ]{.math display="inline"
role="math"}[$\mathsf{\{ 1\} \cup (2,\infty)}$ ]{.mathImpaired
display="inline" role="math"}[\$\\{ 1 \\} \\cup (2, \\infty
)\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist keine
Induktionsmenge.

### Definition 1.11.

Die Menge [[$\mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired display="inline"
role="math"}[\$\\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

[[$:=\{ x \in \mathbb{R}:x \in A{\mspace{6mu}\text{für\ jede\ Induktionsmenge}\mspace{6mu}}A\}$
]{.math display="inline"
role="math"}[$\mathsf{:=\{ x \in \mathbb{R}:x \in A{\mspace{6mu}\text{für\ jede\ Induktionsmenge}\mspace{6mu}}A\}}$
]{.mathImpaired display="inline" role="math"}[\$:= \\{ x \\in 
\\mathbb{R} : x \\in A \\text{ für jede Induktionsmenge } A
\\}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
[[$=$ ]{.math display="inline" role="math"}[$\mathsf{=}$ ]{.mathImpaired
display="inline" role="math"}[\$=\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> Durschnitt aller
Induktionsmengen\
[[$\bigcap\limits_{A{\mspace{6mu}\text{IM}}}A$ ]{.math display="inline"
role="math"}[$\mathsf{\bigcap\limits_{A{\mspace{6mu}\text{IM}}}A}$
]{.mathImpaired display="inline" role="math"}[\$\\bigcap\\limits\_{A
\\text{ IM}} A\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

heißt *Menge der natürlichen Zahlen*.

### Satz 1.12.

1.  Ist [[$A \subset \mathbb{R}$ ]{.math display="inline"
    role="math"}[$\mathsf{A \subset \mathbb{R}}$ ]{.mathImpaired
    display="inline" role="math"}[\$A \\subset
    \\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> eine Induktionsmenge,
    dann gilt [[$\mathbb{N} \subset A$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{N} \subset A}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\mathbb{N} \\subset
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
2.  [[$\mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist eine
    Induktionsmenge.
3.  [[$\mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist nicht nach oben
    beschränkt.
4.  [[[\$\\forall x \\in \\mathbb{R} \\exists n \\in  \\mathbb{N} n &gt;
    x\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$\\forall x \\in \\mathbb{R} \\exists n \\in 
    \\mathbb{N} n &gt; x\$]{.math .inline} ]{.mathImpaired
    display="inline" role="math"}[\$\\forall x \\in \\mathbb{R} \\exists
    n \\in  \\mathbb{N} n \> x\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

**Beweis:**

1.  Klar nach Definition von [[$N$ ]{.math display="inline"
    role="math"}[$\mathsf{N}$ ]{.mathImpaired display="inline"
    role="math"}[\$N\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.
2.  Da [[$1 \in A$ ]{.math display="inline"
    role="math"}[$\mathsf{1 \in A}$ ]{.mathImpaired display="inline"
    role="math"}[\$1 \\in A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> für jede
    Induktionsmenge [[$A \subset \mathbb{R}$ ]{.math display="inline"
    role="math"}[$\mathsf{A \subset \mathbb{R}}$ ]{.mathImpaired
    display="inline" role="math"}[\$A \\subset 
    \\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, gilt auch
    [[$1 \in \bigcap\limits_{A{\mspace{6mu}\text{IM}}}A = \mathbb{N}$
    ]{.math display="inline"
    role="math"}[$\mathsf{1 \in \bigcap\limits_{A{\mspace{6mu}\text{IM}}}A = \mathbb{N}}$
    ]{.mathImpaired display="inline" role="math"}[\$1 \\in
    \\bigcap\\limits\_{A \\text{ IM}} A = \\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.\
    Sei
    [[$x \in \mathbb{N} = \bigcap\limits_{A{\mspace{6mu}\text{IM}}}A$
    ]{.math display="inline"
    role="math"}[$\mathsf{x \in \mathbb{N} = \bigcap\limits_{A{\mspace{6mu}\text{IM}}}A}$
    ]{.mathImpaired display="inline" role="math"}[\$x \\in \\mathbb{N} =
    \\bigcap\\limits\_{A \\text{ IM}} A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. Also [[$x \in A$
    ]{.math display="inline" role="math"}[$\mathsf{x \in A}$
    ]{.mathImpaired display="inline" role="math"}[\$x \\in
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> für jede
    Induktionsmenge [[$A$ ]{.math display="inline"
    role="math"}[$\mathsf{A}$ ]{.mathImpaired display="inline"
    role="math"}[\$A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.\
    Da [[$x + 1 \in A$ ]{.math display="inline"
    role="math"}[$\mathsf{x + 1 \in A}$ ]{.mathImpaired display="inline"
    role="math"}[\$x+1 \\in A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> für jede
    Induktionsmenge [[$A$ ]{.math display="inline"
    role="math"}[$\mathsf{A}$ ]{.mathImpaired display="inline"
    role="math"}[\$A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, ist
    [[$x + 1 \in \bigcap\limits_{A{\mspace{6mu}\text{IM}}}A = \mathbb{N}$
    ]{.math display="inline"
    role="math"}[$\mathsf{x + 1 \in \bigcap\limits_{A{\mspace{6mu}\text{IM}}}A = \mathbb{N}}$
    ]{.mathImpaired display="inline" role="math"}[\$x+1 \\in
    \\bigcap\\limits\_{A \\text{ IM}} A = \\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$\left. \Rightarrow\mathbb{N} \right.$ ]{.math display="inline"
    role="math"}[$\mathsf{\left. \Rightarrow\mathbb{N} \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow
    \\mathbb{N}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist Induktionsmenge.
3.  *Annahme*: [[$\mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist nach oben
    beschränkt. Nach A15 existiert also ein [[$s:=\sup\mathbb{N}$
    ]{.math display="inline" role="math"}[$\mathsf{s:=\sup\mathbb{N}}$
    ]{.mathImpaired display="inline" role="math"}[\$s := \\sup
    \\mathbb{N}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.\
    [[$\left. \Rightarrow s - 1 \right.$ ]{.math display="inline"
    role="math"}[$\mathsf{\left. \Rightarrow s - 1 \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow
    s-1\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist keine obere
    Schranke von [[$\mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.\
    [[[\$\\Rightarrow \\exists x \\in \\mathbb{N} x &gt; s-1\$]{.math
    .inline} ]{.math display="inline" role="math"}[[\$\\Rightarrow
    \\exists x \\in \\mathbb{N} x &gt; s-1\$]{.math .inline}
    ]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow
    \\exists x \\in \\mathbb{N} x \> s-1\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->; da [[$\mathbb{N}$
    ]{.math display="inline" role="math"}[$\mathsf{\mathbb{N}}$
    ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> Induktionsmenge ist,
    gilt [[$x + 1 \in \mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{x + 1 \in \mathbb{N}}$ ]{.mathImpaired
    display="inline" role="math"}[\$x+1 \\in \\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, andererseits
    [[[\$x+1 &gt; s\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$x+1 &gt; s\$]{.math .inline} ]{.mathImpaired
    display="inline" role="math"}[\$x+1 \> s\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$\Rightarrow$ ]{.math display="inline"
    role="math"}[$\mathsf{\Rightarrow}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\Rightarrow\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> Widerspruch, da [[$s$
    ]{.math display="inline" role="math"}[$\mathsf{s}$ ]{.mathImpaired
    display="inline" role="math"}[\$s\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> obere Schranke von
    [[$\mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.
4.  folgt aus 3..

[[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
display="inline" role="math"}[\$\\square\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

((Seite12))

1.4. Prinzip der vollständigen Induktion
----------------------------------------

### Satz 1.13.

Ist [[$A \subset \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{A \subset \mathbb{N}}$ ]{.mathImpaired
display="inline" role="math"}[\$A \\subset \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[$A$ ]{.math
display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
display="inline" role="math"}[\$A\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> Induktionsmenge, so ist
[[$A = \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{A = \mathbb{N}}$ ]{.mathImpaired display="inline"
role="math"}[\$A = \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

Beweis:\
[[$\mathbb{N} \subset \widetilde{A}$ ]{.math display="inline"
role="math"}[$\mathsf{\mathbb{N} \subset \widetilde{A}}$ ]{.mathImpaired
display="inline" role="math"}[\$\\mathbb{N} \\subset
\\tilde{A}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> für jede Induktionsmenge
[[$\widetilde{A}$ ]{.math display="inline"
role="math"}[$\mathsf{\widetilde{A}}$ ]{.mathImpaired display="inline"
role="math"}[\$\\tilde{A}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, insbesondere
[[$\mathbb{N} \subset A$ ]{.math display="inline"
role="math"}[$\mathsf{\mathbb{N} \subset A}$ ]{.mathImpaired
display="inline" role="math"}[\$\\mathbb{N} \\subset A\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Außerdem ist
[[$A \subset \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{A \subset \mathbb{N}}$ ]{.mathImpaired
display="inline" role="math"}[\$A \\subset \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> nach Voraussetzung, also
[[$A = \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{A = \mathbb{N}}$ ]{.mathImpaired display="inline"
role="math"}[\$A= \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
[[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
display="inline" role="math"}[\$\\square\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

### 1.4.1 Beweisverfahren durch Induktion

Für jedes [[$n \in \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{n \in \mathbb{N}}$ ]{.mathImpaired
display="inline" role="math"}[\$n \\in \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> sei eine Aussage [[$A(n)$
]{.math display="inline" role="math"}[$\mathsf{A(n)}$ ]{.mathImpaired
display="inline" role="math"}[\$A(n)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> definiert. Es gelte:

1.  [[$A(1)$ ]{.math display="inline" role="math"}[$\mathsf{A(1)}$
    ]{.mathImpaired display="inline" role="math"}[\$A(1)\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist wahr.
2.  [[$\left. \forall n \in \mathbb{N}\lbrack A(n){\mspace{6mu}\text{wahr}\mspace{6mu}}\Rightarrow A(n + 1){\mspace{6mu}\text{wahr}}\rbrack \right.$
    ]{.math display="inline"
    role="math"}[$\mathsf{\left. \forall n \in \mathbb{N}\lbrack A(n){\mspace{6mu}\text{wahr}\mspace{6mu}}\Rightarrow A(n + 1){\mspace{6mu}\text{wahr}}\rbrack \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\forall n \\in
    \\mathbb{N} \[ A(n) \\text{ wahr } \\Rightarrow A(n+1) \\text{
    wahr}\]\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

Dann gilt: [[$\forall n \in \mathbb{N}A(n)$ ]{.math display="inline"
role="math"}[$\mathsf{\forall n \in \mathbb{N}A(n)}$ ]{.mathImpaired
display="inline" role="math"}[\$\\forall n \\in \\mathbb{N}
A(n)\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist wahr.

Denn: Setze
[[$A:=\{ n \in \mathbb{N}:A(n){\mspace{6mu}\text{ist\ wahr}}\}$ ]{.math
display="inline"
role="math"}[$\mathsf{A:=\{ n \in \mathbb{N}:A(n){\mspace{6mu}\text{ist\ wahr}}\}}$
]{.mathImpaired display="inline" role="math"}[\$A:= \\{ n \\in
\\mathbb{N} : A(n) \\text{ ist wahr} \\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
Nach 1. gilt: [[$1 \in A$ ]{.math display="inline"
role="math"}[$\mathsf{1 \in A}$ ]{.mathImpaired display="inline"
role="math"}[\$1 \\in A\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->; nach 2. gilt
[[$\forall n \in \mathbb{N}n + 1 \in A$ ]{.math display="inline"
role="math"}[$\mathsf{\forall n \in \mathbb{N}n + 1 \in A}$
]{.mathImpaired display="inline" role="math"}[\$\\forall n \\in
\\mathbb{N} n+1 \\in A\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
Also [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> Induktionsmenge; ferner
[[$A \subset \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{A \subset \mathbb{N}}$ ]{.mathImpaired
display="inline" role="math"}[\$A \\subset \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Also ist nach Prinzip
der vollständigen Induktion: [[$A = \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{A = \mathbb{N}}$ ]{.mathImpaired display="inline"
role="math"}[\$A= \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, d.h. [[$A(n)$ ]{.math
display="inline" role="math"}[$\mathsf{A(n)}$ ]{.mathImpaired
display="inline" role="math"}[\$A(n)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> wahr für alle
[[$n \in \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{n \in \mathbb{N}}$ ]{.mathImpaired
display="inline" role="math"}[\$n \\in \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

#### Beispiel 1.14.

\(1) *Behauptung:* [[$\forall n \in \mathbb{N}n \geq 1$ ]{.math
display="inline"
role="math"}[$\mathsf{\forall n \in \mathbb{N}n \geq 1}$ ]{.mathImpaired
display="inline" role="math"}[\$\\forall n \\in \\mathbb{N} n \\geq
1\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

> **Beweis**: induktiv\
> [[$A(n)$ ]{.math display="inline" role="math"}[$\mathsf{A(n)}$
> ]{.mathImpaired display="inline" role="math"}[\$A(n)\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> sei die Aussage
> \"[[$n \geq 1$ ]{.math display="inline"
> role="math"}[$\mathsf{n \geq 1}$ ]{.mathImpaired display="inline"
> role="math"}[\$n \\geq 1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\".\
> [[$A(1)$ ]{.math display="inline" role="math"}[$\mathsf{A(1)}$
> ]{.mathImpaired display="inline" role="math"}[\$A(1)\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> ist wahr, da
> [[$1 \geq 1$ ]{.math display="inline" role="math"}[$\mathsf{1 \geq 1}$
> ]{.mathImpaired display="inline" role="math"}[\$1 \\geq
> 1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->.\
> Sei [[$A(n)$ ]{.math display="inline" role="math"}[$\mathsf{A(n)}$
> ]{.mathImpaired display="inline" role="math"}[\$A(n)\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> wahr, also [[$n \geq 1$
> ]{.math display="inline" role="math"}[$\mathsf{n \geq 1}$
> ]{.mathImpaired display="inline" role="math"}[\$n \\geq
> 1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->. Dann
> [[$n + 1 \geq 1 + 1 \geq 1 + 0 = 1$ ]{.math display="inline"
> role="math"}[$\mathsf{n + 1 \geq 1 + 1 \geq 1 + 0 = 1}$
> ]{.mathImpaired display="inline" role="math"}[\$n+1 \\geq 1+1 \\geq
> 1+0 =1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> d.h. also \$\$A(n+1)
> ist auch wahr für alle [[$n \in \mathbb{N}$ ]{.math display="inline"
> role="math"}[$\mathsf{n \in \mathbb{N}}$ ]{.mathImpaired
> display="inline" role="math"}[\$n \\in \\mathbb{N}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, d.n.
> [[$\forall n \in \mathbb{N}n \geq 1$ ]{.math display="inline"
> role="math"}[$\mathsf{\forall n \in \mathbb{N}n \geq 1}$
> ]{.mathImpaired display="inline" role="math"}[\$\\forall n \\in
> \\mathbb{N} n \\geq 1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->.\
> [[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\square\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

\(2) Es sei [[$m \in \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{m \in \mathbb{N}}$ ]{.mathImpaired
display="inline" role="math"}[\$m \\in \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[$x \in \mathbb{R}$
]{.math display="inline" role="math"}[$\mathsf{x \in \mathbb{R}}$
]{.mathImpaired display="inline" role="math"}[\$x \\in
\\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> mit [[[\$m &lt; x &lt; x+
1\$]{.math .inline} ]{.math display="inline" role="math"}[[\$m &lt; x
&lt; x+ 1\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$m \< x \< x+ 1\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
*Behauptung*: [[$x \notin \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{x \notin \mathbb{N}}$ ]{.mathImpaired
display="inline" role="math"}[\$x \\notin \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

> **Beweis**:\
> [[$A:=(\mathbb{N} \cap \lbrack 1,m\rbrack) \cup \lbrack m + 1,\infty)$
> ]{.math display="inline"
> role="math"}[$\mathsf{A:=(\mathbb{N} \cap \lbrack 1,m\rbrack) \cup \lbrack m + 1,\infty)}$
> ]{.mathImpaired display="inline" role="math"}[\$A := ( \\mathbb{N}
> \\cap \[1,m\]) \\cup \[m+1, \\infty )\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> ist Induktionsmenge.
> (Bew. selbst)\
> [[$\left. \Rightarrow\mathbb{N} \subset A \right.$ ]{.math
> display="inline"
> role="math"}[$\mathsf{\left. \Rightarrow\mathbb{N} \subset A \right.}$
> ]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow
> \\mathbb{N} \\subset A\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> *Annahme*: [[$x \in \mathbb{N}$ ]{.math display="inline"
> role="math"}[$\mathsf{x \in \mathbb{N}}$ ]{.mathImpaired
> display="inline" role="math"}[\$x \\in \\mathbb{N}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, denn (wegen
> [[$\mathbb{N} \subset A$ ]{.math display="inline"
> role="math"}[$\mathsf{\mathbb{N} \subset A}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\mathbb{N} \\subset A\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->): [[$x \in A$ ]{.math
> display="inline" role="math"}[$\mathsf{x \in A}$ ]{.mathImpaired
> display="inline" role="math"}[\$x \\in A\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, d.h. insbesondere
> [[$x \leq m$ ]{.math display="inline" role="math"}[$\mathsf{x \leq m}$
> ]{.mathImpaired display="inline" role="math"}[\$x \\leq
> m\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> odere [[$x \geq m + 1$
> ]{.math display="inline" role="math"}[$\mathsf{x \geq m + 1}$
> ]{.mathImpaired display="inline" role="math"}[\$x \\geq
> m+1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> [[$\Rightarrow$ ]{.math display="inline"
> role="math"}[$\mathsf{\Rightarrow}$ ]{.mathImpaired display="inline"
> role="math"}[\$\\Rightarrow\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> Widerspruch zur Annahme
> (echt kleiner etc.)\
> [[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\square\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

\(3) *Behauptung:* [[$1 + 2 + 3 + \ldots + n = \frac{n(n + 1)}{2}$
]{.math display="inline"
role="math"}[$\mathsf{1 + 2 + 3 + \ldots + n = \frac{n(n + 1)}{2}}$
]{.mathImpaired display="inline" role="math"}[\$1+2+3+ \\ldots +n =
\\frac{n(n+1)}{2}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

((Seite 13))

> **Beweis:**\
> (1) Stimmt für [[$n = 1$ ]{.math display="inline"
> role="math"}[$\mathsf{n = 1}$ ]{.mathImpaired display="inline"
> role="math"}[\$n=1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> da
> [[$1 = \frac{1(1 + 1)}{2}$ ]{.math display="inline"
> role="math"}[$\mathsf{1 = \frac{1(1 + 1)}{2}}$ ]{.mathImpaired
> display="inline" role="math"}[\$1= \\frac{1(1+1)}{2}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> (2) Gelte die Behauptung für ein beliebiges [[$n \in \mathbb{N}$
> ]{.math display="inline" role="math"}[$\mathsf{n \in \mathbb{N}}$
> ]{.mathImpaired display="inline" role="math"}[\$n \\in
> \\mathbb{N}\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->. Dann\
> [[$1 + 2 + 3 + \ldots + n + (n + 1) = \frac{n(n + 1)}{2} + (n + 1)$
> ]{.math display="inline"
> role="math"}[$\mathsf{1 + 2 + 3 + \ldots + n + (n + 1) = \frac{n(n + 1)}{2} + (n + 1)}$
> ]{.mathImpaired display="inline" role="math"}[\$1+2+3+ \\ldots
> +n+(n+1) = \\frac{n(n+1)}{2} + (n+1)\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> \$\$= (n+1)( \\frac{n}{2} +1) = \\frac{(n+1)(n+2)}{2}\
> [[$\Rightarrow$ ]{.math display="inline"
> role="math"}[$\mathsf{\Rightarrow}$ ]{.mathImpaired display="inline"
> role="math"}[\$\\Rightarrow\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> Behauptung gilt für
> [[$n + 1$ ]{.math display="inline" role="math"}[$\mathsf{n + 1}$
> ]{.mathImpaired display="inline" role="math"}[\$n+1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> [[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\square\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

#### Definition 1.15. {style="margin-right: 0px;" dir="ltr"}

[[$\mathbb{N}_{0}:=\mathbb{N} \cup \{ 0\}$ ]{.math display="inline"
role="math"}[$\mathsf{\mathbb{N}_{0}:=\mathbb{N} \cup \{ 0\}}$
]{.mathImpaired display="inline" role="math"}[\$\\mathbb{N}\_0 :=
\\mathbb{N} \\cup \\{ 0 \\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

[[$\mathbb{Z}:=\mathbb{N} \cup \{ - n:n \in \mathbb{N}\}$ ]{.math
display="inline"
role="math"}[$\mathsf{\mathbb{Z}:=\mathbb{N} \cup \{ - n:n \in \mathbb{N}\}}$
]{.mathImpaired display="inline" role="math"}[\$\\mathbb{Z} :=
\\mathbb{N} \\cup \\{ -n: n \\in \\mathbb{N} \\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ganze Zahlen

[[$\mathbb{Q}:=\left\{ \frac{p}{q}:p \in \mathbb{Z},q \in \mathbb{N} \right\}$
]{.math display="inline"
role="math"}[$\mathsf{\mathbb{Q}:=\left\{ \frac{p}{q}:p \in \mathbb{Z},q \in \mathbb{N} \right\}}$
]{.mathImpaired display="inline" role="math"}[\$\\mathbb{Q} := \\left\\{
\\frac{p}{q} : p \\in \\mathbb{Z}, q \\in \\mathbb{N}
\\right\\}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> rationale Zahlen

#### Satz 1.16. {style="margin-right: 0px;" dir="ltr"}

Sind [[$x,y \in \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{x,y \in \mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$x ,y \\in \\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[[\$x &lt;
y\$]{.math .inline} ]{.math display="inline" role="math"}[[\$x &lt;
y\$]{.math .inline} ]{.mathImpaired display="inline" role="math"}[\$x \<
y\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, so existiert ein
[[$r \in \mathbb{Q}$ ]{.math display="inline"
role="math"}[$\mathsf{r \in \mathbb{Q}}$ ]{.mathImpaired
display="inline" role="math"}[\$r \\in\\mathbb{Q}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> mit [[[\$x &lt; r &lt;
y\$]{.math .inline} ]{.math display="inline" role="math"}[[\$x &lt; r
&lt; y\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$x \< r \< y\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

**Beweis:**\
Wähle [[[\$q \\in \\mathbb{N}, q &gt; \\frac{1}{y-x}\$]{.math .inline}
]{.math display="inline" role="math"}[[\$q \\in \\mathbb{N}, q &gt;
\\frac{1}{y-x}\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$q \\in \\mathbb{N}, q \> \\frac{1}{y-x}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, dann [[[\$qy-qx &gt;
1\$]{.math .inline} ]{.math display="inline" role="math"}[[\$qy-qx &gt;
1\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$qy-qx \> 1\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Dann existiert (Beweis
später) ein [[$p \in \mathbb{Z}$ ]{.math display="inline"
role="math"}[$\mathsf{p \in \mathbb{Z}}$ ]{.mathImpaired
display="inline" role="math"}[\$p \\in \\mathbb{Z}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> mit [[[\$qx &lt; p &lt;
qy\$]{.math .inline} ]{.math display="inline" role="math"}[[\$qx &lt; p
&lt; qy\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$qx \< p \< qy\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, d.h. [[[\$x &lt;
\\frac{p}{q} &lt; y\$]{.math .inline} ]{.math display="inline"
role="math"}[[\$x &lt; \\frac{p}{q} &lt; y\$]{.math .inline}
]{.mathImpaired display="inline" role="math"}[\$x \< \\frac{p}{q} \<
y\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

*Nachweis der Existenz eines solchen [[$p$ ]{.math display="inline"
role="math"}[$\mathsf{p}$ ]{.mathImpaired display="inline"
role="math"}[\$p\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->:\
*Setze [[$M:=\mathbb{Z} \cap ( - \infty,qx\rbrack$ ]{.math
display="inline"
role="math"}[$\mathsf{M:=\mathbb{Z} \cap ( - \infty,qx\rbrack}$
]{.mathImpaired display="inline" role="math"}[\$M := \\mathbb{Z} \\cap
(- \\infty , qx\]\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> nach oben beschränkt.\
[[$s:=\sup M$ ]{.math display="inline" role="math"}[$\mathsf{s:=\sup M}$
]{.mathImpaired display="inline" role="math"}[\$s:= \\sup
M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
Wähle [[$n \in M$ ]{.math display="inline"
role="math"}[$\mathsf{n \in M}$ ]{.mathImpaired display="inline"
role="math"}[\$n\\in M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> mit [[[\$n &gt; s-
1\$]{.math .inline} ]{.math display="inline" role="math"}[[\$n &gt; s-
1\$]{.math .inline} ]{.mathImpaired display="inline" role="math"}[\$n \>
s- 1\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Setze
[[$p:=n + 1 \in \mathbb{Z}$ ]{.math display="inline"
role="math"}[$\mathsf{p:=n + 1 \in \mathbb{Z}}$ ]{.mathImpaired
display="inline" role="math"}[\$p :=n+1 \\in \\mathbb{Z}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->; ferner [[[\$p &gt;
s\$]{.math .inline} ]{.math display="inline" role="math"}[[\$p &gt;
s\$]{.math .inline} ]{.mathImpaired display="inline" role="math"}[\$p \>
s\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
[[$\left. \Rightarrow p \notin M \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. \Rightarrow p \notin M \right.}$
]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow p \\notin
M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->; wegen
[[$p \in \mathbb{Z}$ ]{.math display="inline"
role="math"}[$\mathsf{p \in \mathbb{Z}}$ ]{.mathImpaired
display="inline" role="math"}[\$p \\in \\mathbb{Z}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> also
[[$p \notin ( - \infty,qx\rbrack$ ]{.math display="inline"
role="math"}[$\mathsf{p \notin ( - \infty,qx\rbrack}$ ]{.mathImpaired
display="inline" role="math"}[\$p \\notin (- \\infty
,qx\]\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, d.h.
[[[\$p&gt;qx\$]{.math .inline} ]{.math display="inline"
role="math"}[[\$p&gt;qx\$]{.math .inline} ]{.mathImpaired
display="inline" role="math"}[\$p\>qx\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
Ferner [[[\$p =n+1 \\leq qx+1 &lt; q y\$]{.math .inline} ]{.math
display="inline" role="math"}[[\$p =n+1 \\leq qx+1 &lt; q y\$]{.math
.inline} ]{.mathImpaired display="inline" role="math"}[\$p =n+1 \\leq
qx+1 \< q y\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
[[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
display="inline" role="math"}[\$\\square\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

1.5. Einige Formeln (Notationen) {style="margin-right: 0px;" dir="ltr"}
--------------------------------

\(1) Für [[$a \in \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{a \in \mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$a \\in \\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[[\$n \\in
\\mathbb{N} : a\^n := a \\cdot a \\dotsm a\$]{.math .inline} ]{.math
display="inline" role="math"}[[\$n \\in \\mathbb{N} : a\^n := a \\cdot a
\\dotsm a\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$n \\in \\mathbb{N} : a\^n := a \\cdot a \\dotsm
a\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (*n* mal)

> Präzise mit vollständiger Induktion:\
> Definiere [[$a^{1}:=a$ ]{.math display="inline"
> role="math"}[$\mathsf{a^{1}:=a}$ ]{.mathImpaired display="inline"
> role="math"}[\$a\^1 := a\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> Sei [[$a^{n}$ ]{.math display="inline" role="math"}[$\mathsf{a^{n}}$
> ]{.mathImpaired display="inline" role="math"}[\$a\^n\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> für ein
> [[$n \in \mathbb{N}$ ]{.math display="inline"
> role="math"}[$\mathsf{n \in \mathbb{N}}$ ]{.mathImpaired
> display="inline" role="math"}[\$n \\in \\mathbb{N}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> bereits definiert.\
> Dann [[$a^{n + 1}:=a^{n} \cdot a$ ]{.math display="inline"
> role="math"}[$\mathsf{a^{n + 1}:=a^{n} \cdot a}$ ]{.mathImpaired
> display="inline" role="math"}[\$a\^{n+1} := a\^n \\cdot
> a\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> Daraus: übliche Rechenregeln für Potenzen.
>
> Falls [[$a \neq 0,n \in \mathbb{N}:a^{- n}:=\frac{1}{a^{n}}$ ]{.math
> display="inline"
> role="math"}[$\mathsf{a \neq 0,n \in \mathbb{N}:a^{- n}:=\frac{1}{a^{n}}}$
> ]{.mathImpaired display="inline" role="math"}[\$a \\neq 0, n \\in
> \\mathbb{N} : a\^{-n} := \\frac{1}{a\^n}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> Für alle [[$a \in \mathbb{R}:a^{0}:=1$ ]{.math display="inline"
> role="math"}[$\mathsf{a \in \mathbb{R}:a^{0}:=1}$ ]{.mathImpaired
> display="inline" role="math"}[\$a \\in \\mathbb{R} : a\^0 :=
> 1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> Damit: [[$a^{n}$ ]{.math display="inline"
> role="math"}[$\mathsf{a^{n}}$ ]{.mathImpaired display="inline"
> role="math"}[\$a\^n\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> (für [[$a \neq 0$
> ]{.math display="inline" role="math"}[$\mathsf{a \neq 0}$
> ]{.mathImpaired display="inline" role="math"}[\$a \\neq
> 0\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->) für alle
> [[$n \in \mathbb{Z}$ ]{.math display="inline"
> role="math"}[$\mathsf{n \in \mathbb{Z}}$ ]{.mathImpaired
> display="inline" role="math"}[\$n \\in \\mathbb{Z}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> definiert.

\(2) Für [[[\$n \\in \\mathbb{N} : n! := 1 \\cdot 2 \\cdot 3 \\dotsm
n\$]{.math .inline} ]{.math display="inline" role="math"}[[\$n \\in
\\mathbb{N} : n! := 1 \\cdot 2 \\cdot 3 \\dotsm n\$]{.math .inline}
]{.mathImpaired display="inline" role="math"}[\$n \\in \\mathbb{N} : n!
:= 1 \\cdot 2 \\cdot 3 \\dotsm n\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

> Präzise: [[$0!:=1$ ]{.math display="inline"
> role="math"}[$\mathsf{0!:=1}$ ]{.mathImpaired display="inline"
> role="math"}[\$0! := 1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->; falls [[$n!$ ]{.math
> display="inline" role="math"}[$\mathsf{n!}$ ]{.mathImpaired
> display="inline" role="math"}[\$n!\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> bereits definiert für
> ein [[$n \in \mathbb{N}_{0}:(n + 1)!:=n! \cdot (n + 1)$ ]{.math
> display="inline"
> role="math"}[$\mathsf{n \in \mathbb{N}_{0}:(n + 1)!:=n! \cdot (n + 1)}$
> ]{.mathImpaired display="inline" role="math"}[\$n \\in \\mathbb{N}\_0:
> (n+1)! := n! \\cdot (n+1)\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> Damit ist [[$n!$ ]{.math display="inline" role="math"}[$\mathsf{n!}$
> ]{.mathImpaired display="inline" role="math"}[\$n!\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> definiert für alle
> [[$n \in \mathbb{N}_{0}$ ]{.math display="inline"
> role="math"}[$\mathsf{n \in \mathbb{N}_{0}}$ ]{.mathImpaired
> display="inline" role="math"}[\$n \\in \\mathbb{N}\_0\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->.

((Seite 14))

\(3) Für [[$n \in \mathbb{N}_{0},k \in \mathbb{N}_{0},k \leq n$ ]{.math
display="inline"
role="math"}[$\mathsf{n \in \mathbb{N}_{0},k \in \mathbb{N}_{0},k \leq n}$
]{.mathImpaired display="inline" role="math"}[\$n \\in \\mathbb{N}\_0
, k \\in \\mathbb{N}\_0, k \\leq n\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->:

> [[$\left( \frac{n}{k} \right):=\frac{n!}{k!(n - k)!}$ ]{.math
> display="inline"
> role="math"}[$\mathsf{\left( \frac{n}{k} \right):=\frac{n!}{k!(n - k)!}}$
> ]{.mathImpaired display="inline" role="math"}[\$\\binom{n}{k} :=
> \\frac{n!}{k!(n-k)!}\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
> (Binomialkoeffizienten)\
> Es gilt:
> [[$\left( \frac{n}{0} \right) = 1;\left( \frac{n}{n} \right) = 1$
> ]{.math display="inline"
> role="math"}[$\mathsf{\left( \frac{n}{0} \right) = 1;\left( \frac{n}{n} \right) = 1}$
> ]{.mathImpaired display="inline" role="math"}[\$\\binom{n}{0}=1;
> \\binom{n}{n}=1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> Ferner:
> [[$\left( \frac{n}{k} \right) + \left( \frac{n}{k - 1} \right) = \left( \frac{n + 1}{k} \right),1 \leq k \leq n$
> ]{.math display="inline"
> role="math"}[$\mathsf{\left( \frac{n}{k} \right) + \left( \frac{n}{k - 1} \right) = \left( \frac{n + 1}{k} \right),1 \leq k \leq n}$
> ]{.mathImpaired display="inline" role="math"}[\$\\binom{n}{k} +
> \\binom{n}{k-1} = \\binom{n+1}{k}, 1 \\leq k \\leq n\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

\(4) *Berouillische Ungleichung:*

> Für [[$x \in \mathbb{R},x \geq - 1$ ]{.math display="inline"
> role="math"}[$\mathsf{x \in \mathbb{R},x \geq - 1}$ ]{.mathImpaired
> display="inline" role="math"}[\$x \\in \\mathbb{R} , x \\geq -
> 1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> und
> [[$n \in \mathbb{N}$ ]{.math display="inline"
> role="math"}[$\mathsf{n \in \mathbb{N}}$ ]{.mathImpaired
> display="inline" role="math"}[\$n \\in \\mathbb{N}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> gilt:
>
> \
>
> ![1+x hoch n größer gleich 1+n mal
> x](Images/Bernouillische%20Ungleichung.svg "Bernouillische Ungleichung"){.toRemove}
>
> \
>
> **Beweis:**\
> [[$n = 1:(1 + x)^{1} = 1 + x = 1 + 1x$ ]{.math display="inline"
> role="math"}[$\mathsf{n = 1:(1 + x)^{1} = 1 + x = 1 + 1x}$
> ]{.mathImpaired display="inline" role="math"}[\$n=1: (1+x)\^1 = 1+x =
> 1+1x\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> Gelte die Behauptung für ein [[$n \in \mathbb{N}$ ]{.math
> display="inline" role="math"}[$\mathsf{n \in \mathbb{N}}$
> ]{.mathImpaired display="inline" role="math"}[\$n \\in
> \\mathbb{N}\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->;\
> [[$(1 + x)^{n + 1} = (1 + x)^{n} \cdot (1 + x) \geq (1 + nx)(1 + x) = 1 + (n + 1)x + nx^{2} \geq 1 + (n + 1)x$
> ]{.math display="inline"
> role="math"}[$\mathsf{(1 + x)^{n + 1} = (1 + x)^{n} \cdot (1 + x) \geq (1 + nx)(1 + x) = 1 + (n + 1)x + nx^{2} \geq 1 + (n + 1)x}$
> ]{.mathImpaired display="inline" role="math"}[\$(1+x)\^{n+1} =
> (1+x)\^n \\cdot (1+x) \\geq (1+nx)(1+x) = 1+ (n+1)x +nx\^2 \\geq
> 1+(n+1)x\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> [[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\square\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

\(5) Summenzeichen, Produktzeichen:

> Will definieren:
>
> [[$\sum\limits_{k = 1}^{n}a_{k}:=a_{1} + a_{2} + \ldots + a_{n}$
> ]{.math display="inline"
> role="math"}[$\mathsf{\sum\limits_{k = 1}^{n}a_{k}:=a_{1} + a_{2} + \ldots + a_{n}}$
> ]{.mathImpaired display="inline"
> role="math"}[\$\\sum\\limits\_{k=1}\^n a\_k := a\_1+a\_2+ \\ldots +
> a\_n\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> [[[\$\\prod\_{k=1}\^n a\_k := a\_1 \\cdot a\_2 \\dotsm a\_n\$]{.math
> .inline} ]{.math display="inline" role="math"}[[\$\\prod\_{k=1}\^n
> a\_k := a\_1 \\cdot a\_2 \\dotsm a\_n\$]{.math .inline}
> ]{.mathImpaired display="inline" role="math"}[\$\\prod\_{k=1}\^n a\_k
> := a\_1 \\cdot a\_2 \\dotsm a\_n\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> Präzise: setze [[$a_{1} \in \mathbb{R}$ ]{.math display="inline"
> role="math"}[$\mathsf{a_{1} \in \mathbb{R}}$ ]{.mathImpaired
> display="inline" role="math"}[\$a\_1 \\in \\mathbb{R}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, so setze
>
> [[$\sum_{k = 1}^{1}a_{k}:=a_{1}$ ]{.math display="inline"
> role="math"}[$\mathsf{\sum_{k = 1}^{1}a_{k}:=a_{1}}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\sum\_{k=1}\^1 a\_k :=
> a\_1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> [[$\prod\limits_{k = 1}^{1}a_{k}:=a_{1}$ ]{.math display="inline"
> role="math"}[$\mathsf{\prod\limits_{k = 1}^{1}a_{k}:=a_{1}}$
> ]{.mathImpaired display="inline"
> role="math"}[\$\\prod\\limits\_{k=1}\^1 a\_k := a\_1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> Sind für je [[$n$ ]{.math display="inline" role="math"}[$\mathsf{n}$
> ]{.mathImpaired display="inline" role="math"}[\$n\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> Zahlen
> [[$a_{1},\ldots,a_{n} \in \mathbb{R}$ ]{.math display="inline"
> role="math"}[$\mathsf{a_{1},\ldots,a_{n} \in \mathbb{R}}$
> ]{.mathImpaired display="inline" role="math"}[\$a\_1,\\ldots ,a\_n
> \\in \\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> bereits obige Ausdrücke
> definiert und sind [[$a_{1},\ldots a_{n + 1} \in \mathbb{R}$ ]{.math
> display="inline"
> role="math"}[$\mathsf{a_{1},\ldots a_{n + 1} \in \mathbb{R}}$
> ]{.mathImpaired display="inline" role="math"}[\$a\_1, \\ldots a\_{n+1}
> \\in \\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, so setze
>
> [[$\sum\limits_{k = 1}^{n + 1}a_{k}:=\left( \sum\limits_{k = 1}^{n} \right) + a_{n + 1}$
> ]{.math display="inline"
> role="math"}[$\mathsf{\sum\limits_{k = 1}^{n + 1}a_{k}:=\left( \sum\limits_{k = 1}^{n} \right) + a_{n + 1}}$
> ]{.mathImpaired display="inline"
> role="math"}[\$\\sum\\limits\_{k=1}\^{n+1} a\_k := \\left(
> \\sum\\limits\_{k=1}\^n \\right) + a\_{n+1}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> Produktzeichen analog.\
> Sind [[$p,q \in \mathbb{Z},p \leq q,a_{p},\ldots,a_{q} \in \mathbb{R}$
> ]{.math display="inline"
> role="math"}[$\mathsf{p,q \in \mathbb{Z},p \leq q,a_{p},\ldots,a_{q} \in \mathbb{R}}$
> ]{.mathImpaired display="inline" role="math"}[\$p,q \\in \\mathbb{Z},
> p \\leq q, a\_p, \\ldots , a\_q \\in \\mathbb{R}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, so definiere
>
> [[$\sum\limits_{k = p}^{q}a_{k}:=\sum\limits_{k = 1}^{q - p + 1}a_{p - 1 + k}$
> ]{.math display="inline"
> role="math"}[$\mathsf{\sum\limits_{k = p}^{q}a_{k}:=\sum\limits_{k = 1}^{q - p + 1}a_{p - 1 + k}}$
> ]{.mathImpaired display="inline"
> role="math"}[\$\\sum\\limits\_{k=p}\^q a\_k :=
> \\sum\\limits\_{k=1}\^{q-p+1} a\_{p-1+k}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> [[$\prod\limits_{k = p}^{q}a_{k}:=\prod\limits_{k = 1}^{q - p + 1}a_{p - 1 + k}$
> ]{.math display="inline"
> role="math"}[$\mathsf{\prod\limits_{k = p}^{q}a_{k}:=\prod\limits_{k = 1}^{q - p + 1}a_{p - 1 + k}}$
> ]{.mathImpaired display="inline"
> role="math"}[\$\\prod\\limits\_{k=p}\^{q} a\_k :=
> \\prod\\limits\_{k=1}\^{q-p+1} a\_{p-1+k}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> Schließlich für [[[\$p &gt; q\$]{.math .inline} ]{.math
> display="inline" role="math"}[[\$p &gt; q\$]{.math .inline}
> ]{.mathImpaired display="inline" role="math"}[\$p \> q\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->:
>
> [[$\sum_{k = p}^{q}a_{k}:=0,\prod_{k = p}^{q}a_{k}:=1$ ]{.math
> display="inline"
> role="math"}[$\mathsf{\sum_{k = p}^{q}a_{k}:=0,\prod_{k = p}^{q}a_{k}:=1}$
> ]{.mathImpaired display="inline" role="math"}[\$\\sum\_{k=p}\^q a\_k
> := 0, \\prod\_{k=p}\^q a\_k := 1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

((Seite15))

\(6) *Binomischer Lehrsatz:*

> Es seien [[$a,b \in \mathbb{R},n \in \mathbb{N}_{0}$ ]{.math
> display="inline"
> role="math"}[$\mathsf{a,b \in \mathbb{R},n \in \mathbb{N}_{0}}$
> ]{.mathImpaired display="inline" role="math"}[\$a,b \\in \\mathbb{R},
> n \\in \\mathbb{N}\_0\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->. Dann gilt:
>
> [[$(a + b)^{n} = \sum_{k = 0}^{n}\left( \frac{n}{k} \right)a^{n - k}b^{k}$
> ]{.math display="inline"
> role="math"}[$\mathsf{(a + b)^{n} = \sum_{k = 0}^{n}\left( \frac{n}{k} \right)a^{n - k}b^{k}}$
> ]{.mathImpaired display="inline" role="math"}[\$(a+b)\^n =
> \\sum\_{k=0}\^n \\binom{n}{k} a\^{n-k} b\^k\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

\(7) Es seien [[$a,b \in \mathbb{R},n \in \mathbb{N}_{0}$ ]{.math
display="inline"
role="math"}[$\mathsf{a,b \in \mathbb{R},n \in \mathbb{N}_{0}}$
]{.mathImpaired display="inline" role="math"}[\$a,b \\in \\mathbb{R}, n
\\in \\mathbb{N}\_0\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Dann gilt:

> [[$a^{n + 1} - b^{n + 1} = (a - b)\sum\limits_{k = 0}^{n}a^{n - k}b^{k}$
> ]{.math display="inline"
> role="math"}[$\mathsf{a^{n + 1} - b^{n + 1} = (a - b)\sum\limits_{k = 0}^{n}a^{n - k}b^{k}}$
> ]{.mathImpaired display="inline" role="math"}[\$a\^{n+1} - b\^{n+1} =
> (a-b) \\sum\\limits\_{k=0}\^n a\^{n-k} b\^k\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

1.6. Wurzeln {style="margin-right: 0px;" dir="ltr"}
------------

Will nun [[$\sqrt[n]{}$ ]{.math display="inline"
role="math"}[$\mathsf{\sqrt[n]{}}$ ]{.mathImpaired display="inline"
role="math"}[\$\\sqrt\[n\]{ }\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> einführen.

### Lemma 1.17.

Für [[$x,y \in \mathbb{R},x,y \geq 0$ ]{.math display="inline"
role="math"}[$\mathsf{x,y \in \mathbb{R},x,y \geq 0}$ ]{.mathImpaired
display="inline" role="math"}[\$x ,y \\in \\mathbb{R} , x,y \\geq
0\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[$n \in \mathbb{N}$
]{.math display="inline" role="math"}[$\mathsf{n \in \mathbb{N}}$
]{.mathImpaired display="inline" role="math"}[\$n \\in
\\mathbb{N}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> gilt:

[[$\left. x \leq y\Leftrightarrow x^{n} \leq y^{n} \right.$ ]{.math
display="inline"
role="math"}[$\mathsf{\left. x \leq y\Leftrightarrow x^{n} \leq y^{n} \right.}$
]{.mathImpaired display="inline" role="math"}[\$x \\leq y
\\Leftrightarrow x\^n \\leq y\^n\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

### Satz und Definition 1.18.

Es sei [[$a \geq 0$ ]{.math display="inline"
role="math"}[$\mathsf{a \geq 0}$ ]{.mathImpaired display="inline"
role="math"}[\$a \\geq 0\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[$n \in \mathbb{N}$
]{.math display="inline" role="math"}[$\mathsf{n \in \mathbb{N}}$
]{.mathImpaired display="inline" role="math"}[\$n \\in
\\mathbb{N}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

*Behauptung:* Es existiert genau ein [[$x \in \mathbb{R},x \geq 0$
]{.math display="inline"
role="math"}[$\mathsf{x \in \mathbb{R},x \geq 0}$ ]{.mathImpaired
display="inline" role="math"}[\$x \\in \\mathbb{R}, x \\geq
0\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> mit [[$x^{n} = a$ ]{.math
display="inline" role="math"}[$\mathsf{x^{n} = a}$ ]{.mathImpaired
display="inline" role="math"}[\$x\^n=a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Dieses [[$x$ ]{.math
display="inline" role="math"}[$\mathsf{x}$ ]{.mathImpaired
display="inline" role="math"}[\$x\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißt [[$n$ ]{.math
display="inline" role="math"}[$\mathsf{n}$ ]{.mathImpaired
display="inline" role="math"}[\$n\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->-te Wurzel aus
[[$a,x = :\sqrt[n]{a}$ ]{.math display="inline"
role="math"}[$\mathsf{a,x = :\sqrt[n]{a}}$ ]{.mathImpaired
display="inline" role="math"}[\$a, x=: \\sqrt\[n\]{a}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
Speziell für [[$n = 2:\sqrt{a}:=\sqrt[2]{a}$ ]{.math display="inline"
role="math"}[$\mathsf{n = 2:\sqrt{a}:=\sqrt[2]{a}}$ ]{.mathImpaired
display="inline" role="math"}[\$n=2: \\sqrt{a} :=
\\sqrt\[2\]{a}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

**Beweis:** Eindeutigkeit nach obigem Lemma. Die Existenz: mit
Zwischenwertsatz für stetige Funktionen [\\\\7.11](file://\\7.11).

### Bemerkung 1.19.

-   [[$\sqrt{2} \notin \mathbb{Q}$ ]{.math display="inline"
    role="math"}[$\mathsf{\sqrt{2} \notin \mathbb{Q}}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\sqrt{2} \\notin
    \\mathbb{Q}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

**Beweis:** *Annahme:* [[$\sqrt{2} \in \mathbb{Q}$ ]{.math
display="inline" role="math"}[$\mathsf{\sqrt{2} \in \mathbb{Q}}$
]{.mathImpaired display="inline" role="math"}[\$\\sqrt{2} \\in
\\mathbb{Q}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, d.h. es gibt
[[$p,q \in \mathbb{N},p,q$ ]{.math display="inline"
role="math"}[$\mathsf{p,q \in \mathbb{N},p,q}$ ]{.mathImpaired
display="inline" role="math"}[\$p,q \\in \\mathbb{N},
p,q\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> teilerfremd, mit
[[$\sqrt{2} = \frac{p}{q}$ ]{.math display="inline"
role="math"}[$\mathsf{\sqrt{2} = \frac{p}{q}}$ ]{.mathImpaired
display="inline" role="math"}[\$\\sqrt{2} = \\frac{p}{q}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->; dann
[[$2 = \frac{p^{2}}{q^{2}}$ ]{.math display="inline"
role="math"}[$\mathsf{2 = \frac{p^{2}}{q^{2}}}$ ]{.mathImpaired
display="inline" role="math"}[\$2= \\frac{p\^2}{q\^2}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, also

[[$p^{2} = 2q^{2}$ ]{.math display="inline"
role="math"}[$\mathsf{p^{2} = 2q^{2}}$ ]{.mathImpaired display="inline"
role="math"}[\$p\^2 = 2q\^2\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

[[$\left. \Rightarrow p^{2} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. \Rightarrow p^{2} \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$\\Rightarrow p\^2\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist durch 2 teilbar.\
[[$\left. \Rightarrow p \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. \Rightarrow p \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$\\Rightarrow p\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist durch 2 teilbar.\
[[$\left. \Rightarrow p^{2} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. \Rightarrow p^{2} \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$\\Rightarrow p\^2\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist durch 4 teilbar.\
[[$\left. \Rightarrow q^{2} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. \Rightarrow q^{2} \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$\\Rightarrow q\^2\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist durch 2 teilbar.\
[[$\left. \Rightarrow q \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. \Rightarrow q \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$\\Rightarrow q\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist durch 2 teilbar.\
[[$\left. \Rightarrow p,q \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. \Rightarrow p,q \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$\\Rightarrow p,q\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> beide durch 2 teilbar;
[[$\Rightarrow$ ]{.math display="inline"
role="math"}[$\mathsf{\Rightarrow}$ ]{.mathImpaired display="inline"
role="math"}[\$\\Rightarrow\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> Widerspruch zu \"[[$p,q$
]{.math display="inline" role="math"}[$\mathsf{p,q}$ ]{.mathImpaired
display="inline" role="math"}[\$p,q\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> teilerfremd\".

-   Nach unserer Definition ist [[$\sqrt[n]{a} \geq 0$ ]{.math
    display="inline" role="math"}[$\mathsf{\sqrt[n]{a} \geq 0}$
    ]{.mathImpaired display="inline" role="math"}[\$\\sqrt\[n\]{a} \\geq
    0\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> (für [[$a \geq 0$
    ]{.math display="inline" role="math"}[$\mathsf{a \geq 0}$
    ]{.mathImpaired display="inline" role="math"}[\$a \\geq
    0\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->)
-   **Achtung**: wir ziehen nur Wurzeln aus Zahlen [[[\$&gt; 0\$]{.math
    .inline} ]{.math display="inline" role="math"}[[\$&gt; 0\$]{.math
    .inline} ]{.mathImpaired display="inline" role="math"}[\$\>
    0\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    Bsp: [[$\sqrt{4} = 2$ ]{.math display="inline"
    role="math"}[$\mathsf{\sqrt{4} = 2}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\sqrt{4} =2\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->; die Gleichung
    [[$x^{2} = 4$ ]{.math display="inline"
    role="math"}[$\mathsf{x^{2} = 4}$ ]{.mathImpaired display="inline"
    role="math"}[\$x\^2=4\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> hat **zwei** Lösungen
    2 und [[$- 2$ ]{.math display="inline" role="math"}[$\mathsf{- 2}$
    ]{.mathImpaired display="inline" role="math"}[\$-2\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->; als **Wurzel**
    wählen wir die Lösung [[$\geq 0$ ]{.math display="inline"
    role="math"}[$\mathsf{\geq 0}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\geq 0\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> aus.
-   [[$\sqrt{a^{2}} = |a|$ ]{.math display="inline"
    role="math"}[$\mathsf{\sqrt{a^{2}} = |a|}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\sqrt{a\^2} = \|a\|\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

((Seite16))

1.7. Potenzen mit rationalen Exponenten
---------------------------------------

Es sei [[\$ a 0\$ ]{.math display="inline" role="math"}[\$ a 0\$
]{.mathImpaired display="inline" role="math"}[\$ a \\geq
0\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[[\$r \\in
\\mathbb{Q}, r&gt;0\$]{.math .inline} ]{.math display="inline"
role="math"}[[\$r \\in \\mathbb{Q}, r&gt;0\$]{.math .inline}
]{.mathImpaired display="inline" role="math"}[\$r \\in \\mathbb{Q},
r\>0\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Also [[$r = \frac{m}{n}$
]{.math display="inline" role="math"}[$\mathsf{r = \frac{m}{n}}$
]{.mathImpaired display="inline" role="math"}[\$r=
\\frac{m}{n}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> mit
[[$m,n \in \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{m,n \in \mathbb{N}}$ ]{.mathImpaired
display="inline" role="math"}[\$m,n \\in \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

Wir *wollen* definieren:

[[$a^{r}:=(\sqrt[n]{a})^{m}$ ]{.math display="inline"
role="math"}[$\mathsf{a^{r}:=(\sqrt[n]{a})^{m}}$ ]{.mathImpaired
display="inline" role="math"}[\$a\^r := ( \\sqrt\[n\]{a}
)\^m\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

Problem: Ist [[$r = \frac{p}{q}$ ]{.math display="inline"
role="math"}[$\mathsf{r = \frac{p}{q}}$ ]{.mathImpaired display="inline"
role="math"}[\$r= \\frac{p}{q}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine weitere Darstellung
von [[$r$ ]{.math display="inline" role="math"}[$\mathsf{r}$
]{.mathImpaired display="inline" role="math"}[\$r\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, gilt dann

[[$(\sqrt[n]{a})^{m} = (\sqrt[q]{a})^{p}$ ]{.math display="inline"
role="math"}[$\mathsf{(\sqrt[n]{a})^{m} = (\sqrt[q]{a})^{p}}$
]{.mathImpaired display="inline" role="math"}[\$( \\sqrt\[n\]{a} )\^m =
( \\sqrt\[q\]{a} )\^p\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->?

Ja! Denn: setze

[[$x:=(\sqrt[n]{a})^{m},y:=(\sqrt[q]{a})^{p}$ ]{.math display="inline"
role="math"}[$\mathsf{x:=(\sqrt[n]{a})^{m},y:=(\sqrt[q]{a})^{p}}$
]{.mathImpaired display="inline" role="math"}[\$x := ( \\sqrt\[n\]{a}
)\^m, y := ( \\sqrt\[q\]{a} )\^p\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

Dann

[[$x^{q} = \lbrack(\sqrt[n]{a})^{m}\rbrack^{q} = (\sqrt[n]{a})^{mq} = (\sqrt[n]{a})^{np} = \lbrack(\sqrt[n]{a})^{n}\rbrack^{p} = a^{p}$
]{.math display="inline"
role="math"}[$\mathsf{x^{q} = \lbrack(\sqrt[n]{a})^{m}\rbrack^{q} = (\sqrt[n]{a})^{mq} = (\sqrt[n]{a})^{np} = \lbrack(\sqrt[n]{a})^{n}\rbrack^{p} = a^{p}}$
]{.mathImpaired display="inline" role="math"}[\$x\^q= \[( \\sqrt\[n\]{a}
)\^m \]\^q = ( \\sqrt\[n\]{a} )\^{mq} = ( \\sqrt\[n\]{a} )\^{np} = \[ (
\\sqrt\[n\]{a} )\^n \]\^p = a\^p\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

Analog für [[$y^{p}$ ]{.math display="inline"
role="math"}[$\mathsf{y^{p}}$ ]{.mathImpaired display="inline"
role="math"}[\$y\^p\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
d.h. [[$x^{q} = y^{q}$ ]{.math display="inline"
role="math"}[$\mathsf{x^{q} = y^{q}}$ ]{.mathImpaired display="inline"
role="math"}[\$x\^q=y\^q\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Nach Hilfssatz also
[[$x = y$ ]{.math display="inline" role="math"}[$\mathsf{x = y}$
]{.mathImpaired display="inline" role="math"}[\$x=y\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
Also obige Definition in Ordnung.\
Es gelten die bekannten Rechenregeln.

Ist [[[\$a&gt;0, r \\in \\mathbb{Q}, r&lt;0\$]{.math .inline} ]{.math
display="inline" role="math"}[[\$a&gt;0, r \\in \\mathbb{Q},
r&lt;0\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$a\>0, r \\in \\mathbb{Q}, r\<0\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, so setze
[[$a^{r}:=\frac{1}{a^{- r}}$ ]{.math display="inline"
role="math"}[$\mathsf{a^{r}:=\frac{1}{a^{- r}}}$ ]{.mathImpaired
display="inline" role="math"}[\$a\^r :=
\\frac{1}{a\^{-r}}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

((Seite17))

((Seite18))\

2. Folgen, Konvergenz 
======================

2.1. Definition der Folgen
--------------------------

### Definition 2.1.

Sei [[$X$ ]{.math display="inline" role="math"}[$\mathsf{X}$
]{.mathImpaired display="inline" role="math"}[\$X\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine beliebige Menge,
[[$X \neq \varnothing$ ]{.math display="inline"
role="math"}[$\mathsf{X \neq \varnothing}$ ]{.mathImpaired
display="inline" role="math"}[\$X \\neq \\emptyset\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

Eine Funktion [[$\left. a:\mathbb{N}\rightarrow X \right.$ ]{.math
display="inline"
role="math"}[$\mathsf{\left. a:\mathbb{N}\rightarrow X \right.}$
]{.mathImpaired display="inline" role="math"}[\$a: \\mathbb{N}
\\rightarrow X\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißt *Folge in* [[$X$
]{.math display="inline" role="math"}[$\mathsf{X}$ ]{.mathImpaired
display="inline" role="math"}[\$X\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

Schreibweise:

> [[$\forall n \in \mathbb{N}a_{n}:=a(n)n$ ]{.math display="inline"
> role="math"}[$\mathsf{\forall n \in \mathbb{N}a_{n}:=a(n)n}$
> ]{.mathImpaired display="inline" role="math"}[\$\\forall n \\in
> \\mathbb{N} a\_n := a(n) n\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->-tes Folgenglied
>
> [[$(a_{n})_{n \in \mathbb{N}}$ ]{.math display="inline"
> role="math"}[$\mathsf{(a_{n})_{n \in \mathbb{N}}}$ ]{.mathImpaired
> display="inline" role="math"}[\$(a\_n)\_{n \\in
> \\mathbb{N}}\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> oder
> [[$(a_{n})_{n = 1}^{\infty}$ ]{.math display="inline"
> role="math"}[$\mathsf{(a_{n})_{n = 1}^{\infty}}$ ]{.mathImpaired
> display="inline" role="math"}[\$(a\_n)\_{n=1}\^\\infty\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> oder [[$(a_{n})$
> ]{.math display="inline" role="math"}[$\mathsf{(a_{n})}$
> ]{.mathImpaired display="inline" role="math"}[\$(a\_n)\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> oder (a\_1,a\_2,a\_3,
> \\ldots )\$\$ statt [[$a$ ]{.math display="inline"
> role="math"}[$\mathsf{a}$ ]{.mathImpaired display="inline"
> role="math"}[\$a\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->.

Ist [[$X = \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{X = \mathbb{R}}$ ]{.mathImpaired display="inline"
role="math"}[\$X = \\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, so spricht man von
*reellen Folgen*.

### Bemerkung 2.2. {dir="ltr"}

Ist [[$p \in \mathbb{Z}$ ]{.math display="inline"
role="math"}[$\mathsf{p \in \mathbb{Z}}$ ]{.mathImpaired
display="inline" role="math"}[\$p \\in \\mathbb{Z}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und
[[$\left. a:\{ p,p + 1,p + 2,\ldots\}\rightarrow X \right.$ ]{.math
display="inline"
role="math"}[$\mathsf{\left. a:\{ p,p + 1,p + 2,\ldots\}\rightarrow X \right.}$
]{.mathImpaired display="inline" role="math"}[\$a : \\{ p,p+1,p+2,
\\ldots \\} \\rightarrow X\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine Funktion, so spricht
man ebenfalls von einer Folge [[$X$ ]{.math display="inline"
role="math"}[$\mathsf{X}$ ]{.mathImpaired display="inline"
role="math"}[\$X\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

Bezeichnung: [[$(a_{n})_{n = p}^{\infty}$ ]{.math display="inline"
role="math"}[$\mathsf{(a_{n})_{n = p}^{\infty}}$ ]{.mathImpaired
display="inline" role="math"}[\$(a\_n)\_{n=p}\^\\infty\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> oder [[[\$( a\_p
,a\_{p+\^} , \\ldots )\$]{.math .inline} ]{.math display="inline"
role="math"}[[\$( a\_p ,a\_{p+\^} , \\ldots )\$]{.math .inline}
]{.mathImpaired display="inline" role="math"}[\$( a\_p ,a\_{p+\^} ,
\\ldots )\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

### Beispiel 2.3. {dir="ltr"}

-   <div>

    [[$a_{n}:=\frac{1}{n}$ ]{.math display="inline"
    role="math"}[$\mathsf{a_{n}:=\frac{1}{n}}$ ]{.mathImpaired
    display="inline" role="math"}[\$a\_n := \\frac{1}{n}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> für alle
    [[$n \in \mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{n \in \mathbb{N}}$ ]{.mathImpaired
    display="inline" role="math"}[\$n \\in \\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, also\
    [[$(a_{n})_{n \in \mathbb{N}} = (1,\frac{1}{2},\frac{1}{3},\ldots)$
    ]{.math display="inline"
    role="math"}[$\mathsf{(a_{n})_{n \in \mathbb{N}} = (1,\frac{1}{2},\frac{1}{3},\ldots)}$
    ]{.mathImpaired display="inline" role="math"}[\$(a\_n)\_{n \\in
    \\mathbb{N}} = (1, \\frac{1}{2}, \\frac{1}{3}, \\ldots
    )\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

    </div>

-   <div>

    [[$\forall n \in \mathbb{N}a_{2n}:=0,a_{2n - 1}:=1$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\forall n \in \mathbb{N}a_{2n}:=0,a_{2n - 1}:=1}$
    ]{.mathImpaired display="inline" role="math"}[\$\\forall n \\in
    \\mathbb{N} a\_{2n} := 0, a\_{2n-1} :=1\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    also [[$(a_{n})_{n \in \mathbb{N}} = (1,0,1,0,\ldots)$ ]{.math
    display="inline"
    role="math"}[$\mathsf{(a_{n})_{n \in \mathbb{N}} = (1,0,1,0,\ldots)}$
    ]{.mathImpaired display="inline" role="math"}[\$(a\_n)\_{n \\in
    \\mathbb{N}} = (1,0,1,0, \\ldots )\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

    </div>

-   <div>

    [[$\forall n \in \mathbb{N}a_{n}:=( - 1)^{n}$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\forall n \in \mathbb{N}a_{n}:=( - 1)^{n}}$
    ]{.mathImpaired display="inline" role="math"}[\$\\forall n \\in
    \\mathbb{N} a\_n := (-1)\^n\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    also [[$(a_{n})_{n \in \mathbb{N}} = ( - 1,1, - 1,1,\ldots)$ ]{.math
    display="inline"
    role="math"}[$\mathsf{(a_{n})_{n \in \mathbb{N}} = ( - 1,1, - 1,1,\ldots)}$
    ]{.mathImpaired display="inline" role="math"}[\$(a\_n)\_{n \\in 
    \\mathbb{N}} = (-1,1,-1,1, \\ldots )\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

    </div>

### Definition 2.4.

Sei [[$X$ ]{.math display="inline" role="math"}[$\mathsf{X}$
]{.mathImpaired display="inline" role="math"}[\$X\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine beliebige Menge,
[[$X \neq \varnothing$ ]{.math display="inline"
role="math"}[$\mathsf{X \neq \varnothing}$ ]{.mathImpaired
display="inline" role="math"}[\$X \\neq \\emptyset\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

1.  [[$X$ ]{.math display="inline" role="math"}[$\mathsf{X}$
    ]{.mathImpaired display="inline" role="math"}[\$X\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist* endlich*, wenn
    eine surjektive Abbildung
    [[$\left. \phi:\{ 1,\ldots,n\}\rightarrow X \right.$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\left. \phi:\{ 1,\ldots,n\}\rightarrow X \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\phi : \\{ 1,
    \\ldots ,n \\} \\rightarrow X\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> existiert.
2.  [[$X$ ]{.math display="inline" role="math"}[$\mathsf{X}$
    ]{.mathImpaired display="inline" role="math"}[\$X\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> heißt *abzählbar*,
    wenn [[$X$ ]{.math display="inline" role="math"}[$\mathsf{X}$
    ]{.mathImpaired display="inline" role="math"}[\$X\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> endlich ist *oder*
    eine surjektive Abbildung
    [[$\left. \phi:\mathbb{N}\rightarrow X \right.$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\left. \phi:\mathbb{N}\rightarrow X \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\phi : \\mathbb{N}
    \\rightarrow X\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> existiert. (D.h. wenn
    [[$X$ ]{.math display="inline" role="math"}[$\mathsf{X}$
    ]{.mathImpaired display="inline" role="math"}[\$X\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> endlich ist oder eine
    Folge [[$(a_{n})_{n \in \mathbb{N}}$ ]{.math display="inline"
    role="math"}[$\mathsf{(a_{n})_{n \in \mathbb{N}}}$ ]{.mathImpaired
    display="inline" role="math"}[\$(a\_n)\_{n \\in
    \\mathbb{N}}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> in [[$X$ ]{.math
    display="inline" role="math"}[$\mathsf{X}$ ]{.mathImpaired
    display="inline" role="math"}[\$X\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> existiert mit
    [[$\{ a_{1},a_{2},a_{3},\ldots\} = X$ ]{.math display="inline"
    role="math"}[$\mathsf{\{ a_{1},a_{2},a_{3},\ldots\} = X}$
    ]{.mathImpaired display="inline" role="math"}[\$\\{ a\_1,a\_2,a\_3,
    \\ldots \\} =X\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.\
    oder: die Elemente von [[$X$ ]{.math display="inline"
    role="math"}[$\mathsf{X}$ ]{.mathImpaired display="inline"
    role="math"}[\$X\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> können mit
    [[$\{ 1,\ldots,n\}$ ]{.math display="inline"
    role="math"}[$\mathsf{\{ 1,\ldots,n\}}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\{ 1, \\ldots ,n
    \\}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> oder mit
    [[$\mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> *durchnummeriert*
    werden.)
3.  [[$X$ ]{.math display="inline" role="math"}[$\mathsf{X}$
    ]{.mathImpaired display="inline" role="math"}[\$X\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> heißt
    *überabzählbar*, wenn [[$X$ ]{.math display="inline"
    role="math"}[$\mathsf{X}$ ]{.mathImpaired display="inline"
    role="math"}[\$X\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nicht abzählbar ist.

### Beispiel 2.5.

-   [[$\mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist abzählbar, denn
    [[$\mathbb{N} = \{ a_{1},a_{2},a_{3},\ldots\}$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\mathbb{N} = \{ a_{1},a_{2},a_{3},\ldots\}}$
    ]{.mathImpaired display="inline" role="math"}[\$\\mathbb{N}= \\{
    a\_1,a\_2,a\_3, \\ldots \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
    mit [[$\forall n \in \mathbb{N}a_{n}:=n$ ]{.math display="inline"
    role="math"}[$\mathsf{\forall n \in \mathbb{N}a_{n}:=n}$
    ]{.mathImpaired display="inline" role="math"}[\$\\forall n \\in
    \\mathbb{N} a\_n := n\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.
-   [[$\mathbb{Z}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{Z}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{Z}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist abzählbar.\
    Definiere etwa: [[$a_{1}:=0,a_{2}:=1,a_{3}:= - 1,a_{4}:=2,\ldots$
    ]{.math display="inline"
    role="math"}[$\mathsf{a_{1}:=0,a_{2}:=1,a_{3}:= - 1,a_{4}:=2,\ldots}$
    ]{.mathImpaired display="inline" role="math"}[\$a\_1:=0, a\_2:=1,
    a\_3:=-1, a\_4:=2, \\ldots\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

((Seite 19))

-   [[$\mathbb{Q}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{Q}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{Q}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist abzählbar.\
    [[$\Rightarrow$ ]{.math display="inline"
    role="math"}[$\mathsf{\Rightarrow}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\Rightarrow\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> Unendliches Rechteck\
    \
      1                                                                                                                                                                                                                                            2                                                                                                                                                                                                                                            3                                                                                                                                                                                                                                            4                                                                                                                                                                                                                                            [[$\ldots$ ]{.math display="inline" role="math"}[$\mathsf{\ldots}$ ]{.mathImpaired display="inline" role="math"}[\$\\ldots\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->
      -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
      [[$\frac{1}{2}$ ]{.math display="inline" role="math"}[$\mathsf{\frac{1}{2}}$ ]{.mathImpaired display="inline" role="math"}[\$\\frac{1}{2}\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->   [[$\frac{2}{2}$ ]{.math display="inline" role="math"}[$\mathsf{\frac{2}{2}}$ ]{.mathImpaired display="inline" role="math"}[\$\\frac{2}{2}\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->   [[$\frac{3}{2}$ ]{.math display="inline" role="math"}[$\mathsf{\frac{3}{2}}$ ]{.mathImpaired display="inline" role="math"}[\$\\frac{3}{2}\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->   [[$\frac{4}{2}$ ]{.math display="inline" role="math"}[$\mathsf{\frac{4}{2}}$ ]{.mathImpaired display="inline" role="math"}[\$\\frac{4}{2}\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->   [[$\ldots$ ]{.math display="inline" role="math"}[$\mathsf{\ldots}$ ]{.mathImpaired display="inline" role="math"}[\$\\ldots\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->
      [[$\vdots$ ]{.math display="inline" role="math"}[$\mathsf{\vdots}$ ]{.mathImpaired display="inline" role="math"}[\$\\vdots\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->                  [[$\vdots$ ]{.math display="inline" role="math"}[$\mathsf{\vdots}$ ]{.mathImpaired display="inline" role="math"}[\$\\vdots\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->                  [[$\vdots$ ]{.math display="inline" role="math"}[$\mathsf{\vdots}$ ]{.mathImpaired display="inline" role="math"}[\$\\vdots\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->                  [[$\vdots$ ]{.math display="inline" role="math"}[$\mathsf{\vdots}$ ]{.mathImpaired display="inline" role="math"}[\$\\vdots\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->                  [[$\ddots$ ]{.math display="inline" role="math"}[$\mathsf{\ddots}$ ]{.mathImpaired display="inline" role="math"}[\$\\ddots\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->

    Dann setze [[$b_{1}:=0,b_{2}:=a_{1},b_{3}:= - a_{1},\ldots$ ]{.math
    display="inline"
    role="math"}[$\mathsf{b_{1}:=0,b_{2}:=a_{1},b_{3}:= - a_{1},\ldots}$
    ]{.mathImpaired display="inline" role="math"}[\$b\_1:=0, b\_2:=a\_1,
    b\_3:=-a\_1, \\ldots\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, um auch die
    negativen Zahlen durchnummerieren zu können.
-   [[$\mathbb{R}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{R}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{R}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist *überabzählbar*.
    ([[$\Rightarrow$ ]{.math display="inline"
    role="math"}[$\mathsf{\Rightarrow}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\Rightarrow\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> es gibt auch viel
    mehr irrationale Zahlen als rationale)

Ab jetzt seien alle Folgen *reelle* Folgen.

### Definition 2.6.

Sei [[$(a_{n})$ ]{.math display="inline" role="math"}[$\mathsf{(a_{n})}$
]{.mathImpaired display="inline" role="math"}[\$(a\_n)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine reelle Folge.
[[$(a_{n})$ ]{.math display="inline" role="math"}[$\mathsf{(a_{n})}$
]{.mathImpaired display="inline" role="math"}[\$(a\_n)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißt *nach oben bzw.
unten beschränkt*, wenn die Menge [[$M = \{ a_{1},a_{2},a_{3}\ldots\}$
]{.math display="inline"
role="math"}[$\mathsf{M = \{ a_{1},a_{2},a_{3}\ldots\}}$ ]{.mathImpaired
display="inline" role="math"}[\$M= \\{ a\_1,a\_2,a\_3 \\ldots
\\}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> nach oben bzw. unten
beschränkt ist. In diesem Fall:
[[$\sup(a_{n})_{n \in \mathbb{N}}:=\sup M$ ]{.math display="inline"
role="math"}[$\mathsf{\sup(a_{n})_{n \in \mathbb{N}}:=\sup M}$
]{.mathImpaired display="inline" role="math"}[\$\\sup (a\_n)\_{n \\in 
\\mathbb{N}}:= \\sup M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
Analog für die andere Seite.

[[$(a_{n})$ ]{.math display="inline" role="math"}[$\mathsf{(a_{n})}$
]{.mathImpaired display="inline" role="math"}[\$(a\_n)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißt *beschränkt*, wenn
[[$(a_{n})$ ]{.math display="inline" role="math"}[$\mathsf{(a_{n})}$
]{.mathImpaired display="inline" role="math"}[\$(a\_n)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> nach oben und nach unten
beschränkt ist.

2.2. Konvergenz
---------------

Der begriff *Konvergenz* ist der zentrale Begriff der Analysis. Wir
betrachten zunächst die Konvergenz reeller Folgen.

Sei [[$(a_{n})$ ]{.math display="inline" role="math"}[$\mathsf{(a_{n})}$
]{.mathImpaired display="inline" role="math"}[\$(a\_n)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine Folge in
[[$\mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{\mathbb{R}}$ ]{.mathImpaired display="inline"
role="math"}[\$\\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[$a \in \mathbb{R}$
]{.math display="inline" role="math"}[$\mathsf{a \in \mathbb{R}}$
]{.mathImpaired display="inline" role="math"}[\$a \\in
\\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Was soll
\"[[$\left. a_{n}\rightarrow a \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. a_{n}\rightarrow a \right.}$
]{.mathImpaired display="inline" role="math"}[\$a\_n \\rightarrow
a\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> für [[[\$n \\righttarrow
\\infty\$]{.math .inline} ]{.math display="inline" role="math"}[[\$n
\\righttarrow \\infty\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$n \\righttarrow \\infty\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\" bedeuten?

1\. Schritt: \"Die Folgenglieder [[$a_{n}$ ]{.math display="inline"
role="math"}[$\mathsf{a_{n}}$ ]{.mathImpaired display="inline"
role="math"}[\$a\_n\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> kommen [[$a$ ]{.math
display="inline" role="math"}[$\mathsf{a}$ ]{.mathImpaired
display="inline" role="math"}[\$a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> beliebig nahe oder
[[$|a_{n} - a|$ ]{.math display="inline"
role="math"}[$\mathsf{|a_{n} - a|}$ ]{.mathImpaired display="inline"
role="math"}[\$\|a\_n-a\|\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> wird beliebig klein, wenn
[[$n$ ]{.math display="inline" role="math"}[$\mathsf{n}$ ]{.mathImpaired
display="inline" role="math"}[\$n\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> groß wird\".

2\. Schritt: So sollte zum Beispiel gelten:

> [[[\$\| a\_n-a\| &lt; \\frac{1}{1000}\$]{.math .inline} ]{.math
> display="inline" role="math"}[[\$\| a\_n-a\| &lt;
> \\frac{1}{1000}\$]{.math .inline} ]{.mathImpaired display="inline"
> role="math"}[\$\| a\_n-a\| \< \\frac{1}{1000}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> Nur: für welche [[$n$ ]{.math display="inline"
> role="math"}[$\mathsf{n}$ ]{.mathImpaired display="inline"
> role="math"}[\$n\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->?
>
> Idee: ab einem gewissen Index [[$n_{0}$ ]{.math display="inline"
> role="math"}[$\mathsf{n_{0}}$ ]{.mathImpaired display="inline"
> role="math"}[\$n\_0\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> soll für alle
> [[[\$n&gt;n\_0\$]{.math .inline} ]{.math display="inline"
> role="math"}[[\$n&gt;n\_0\$]{.math .inline} ]{.mathImpaired
> display="inline" role="math"}[\$n\>n\_0\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> die obige Ungleichung
> gelten.\
> Ebenso sollte es ein [[$n_{1} \in \mathbb{N}$ ]{.math display="inline"
> role="math"}[$\mathsf{n_{1} \in \mathbb{N}}$ ]{.mathImpaired
> display="inline" role="math"}[\$n\_1 \\in \\mathbb{N}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> geben mit [[[\$\|
> a\_n-a\| &lt; 10\^{-6}\$]{.math .inline} ]{.math display="inline"
> role="math"}[[\$\| a\_n-a\| &lt; 10\^{-6}\$]{.math .inline}
> ]{.mathImpaired display="inline" role="math"}[\$\| a\_n-a\| \<
> 10\^{-6}\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> für alle
> [[$n \geq n_{1}$ ]{.math display="inline"
> role="math"}[$\mathsf{n \geq n_{1}}$ ]{.mathImpaired display="inline"
> role="math"}[\$n \\geq n\_1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->.

3\. Schritt: Ist [[[\$\\epsilon &gt; 0\$]{.math .inline} ]{.math
display="inline" role="math"}[[\$\\epsilon &gt; 0\$]{.math .inline}
]{.mathImpaired display="inline" role="math"}[\$\\epsilon \>
0\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (und [[$\epsilon$ ]{.math
display="inline" role="math"}[$\mathsf{\epsilon}$ ]{.mathImpaired
display="inline" role="math"}[\$\\epsilon\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> belibig klein), so sollte
es stets ein [[$n_{0} = n_{0}(\epsilon) \in \mathbb{N}$ ]{.math
display="inline"
role="math"}[$\mathsf{n_{0} = n_{0}(\epsilon) \in \mathbb{N}}$
]{.mathImpaired display="inline" role="math"}[\$n\_0 = n\_0( \\epsilon )
\\in \\mathbb{N}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> geben, mit

> [[[\$\| a\_n-a\| &lt; \\epsilon\$]{.math .inline} ]{.math
> display="inline" role="math"}[[\$\| a\_n-a\| &lt; \\epsilon\$]{.math
> .inline} ]{.mathImpaired display="inline" role="math"}[\$\| a\_n-a\|
> \< \\epsilon\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> für alle
> [[$n \geq n_{0}$ ]{.math display="inline"
> role="math"}[$\mathsf{n \geq n_{0}}$ ]{.mathImpaired display="inline"
> role="math"}[\$n \\geq n\_0\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

Diese Überlegungen führen uns zu folgender

### Definition 2.7. {dir="ltr"}

1.  Die Folge [[$(a_{n})$ ]{.math display="inline"
    role="math"}[$\mathsf{(a_{n})}$ ]{.mathImpaired display="inline"
    role="math"}[\$(a\_n)\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> heißt konvergent
    gegen [[$a$ ]{.math display="inline" role="math"}[$\mathsf{a}$
    ]{.mathImpaired display="inline" role="math"}[\$a\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, wenn gilt:\
    [[[\$\\forall \\epsilon &gt; 0 \\exists n\_0 \\in \\mathbb{N}
    \\forall n \\geq n\_0 \|a\_n-a\| &lt; \\epsilon\$]{.math .inline}
    ]{.math display="inline" role="math"}[[\$\\forall \\epsilon &gt; 0
    \\exists n\_0 \\in \\mathbb{N} \\forall n \\geq n\_0 \|a\_n-a\| &lt;
    \\epsilon\$]{.math .inline} ]{.mathImpaired display="inline"
    role="math"}[\$\\forall \\epsilon \> 0 \\exists n\_0 \\in
    \\mathbb{N} \\forall n \\geq n\_0 \|a\_n-a\| \<
    \\epsilon\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    In diesem Fall heißt [[$a$ ]{.math display="inline"
    role="math"}[$\mathsf{a}$ ]{.mathImpaired display="inline"
    role="math"}[\$a\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> Grenzwert (Limes) von
    [[$(a_{n})$ ]{.math display="inline" role="math"}[$\mathsf{(a_{n})}$
    ]{.mathImpaired display="inline"
    role="math"}[\$(a\_n)\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.\
    Bezeichnung: [[$a = \lim_{n\leftarrow\infty}a_{n}$ ]{.math
    display="inline"
    role="math"}[$\mathsf{a = \lim_{n\leftarrow\infty}a_{n}}$
    ]{.mathImpaired display="inline" role="math"}[\$a=
    \\lim\_{n\\leftarrow\\infty} a\_n\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> oder:
    [[$\left. a_{n}\rightarrow a \right.$ ]{.math display="inline"
    role="math"}[$\mathsf{\left. a_{n}\rightarrow a \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$a\_n \\rightarrow
    a\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> für
    [[$\left. n\rightarrow\infty \right.$ ]{.math display="inline"
    role="math"}[$\mathsf{\left. n\rightarrow\infty \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$n \\rightarrow
    \\infty\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.

((Seite20))

1.  Eine Folge [[$(a_{n})$ ]{.math display="inline"
    role="math"}[$\mathsf{(a_{n})}$ ]{.mathImpaired display="inline"
    role="math"}[\$( a\_n )\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> heißt *konvergent*,
    wenn es ein [[$a \in \mathbb{R}$ ]{.math display="inline"
    role="math"}[$\mathsf{a \in \mathbb{R}}$ ]{.mathImpaired
    display="inline" role="math"}[\$a \\in \\mathbb{R}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> gibt derart, dass
    [[$(a_{n})$ ]{.math display="inline" role="math"}[$\mathsf{(a_{n})}$
    ]{.mathImpaired display="inline"
    role="math"}[\$(a\_n)\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> gegen [[$a$ ]{.math
    display="inline" role="math"}[$\mathsf{a}$ ]{.mathImpaired
    display="inline" role="math"}[\$a\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> konvergiert.
2.  Eine Folge [[$(a_{n})$ ]{.math display="inline"
    role="math"}[$\mathsf{(a_{n})}$ ]{.mathImpaired display="inline"
    role="math"}[\$(a\_n)\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> heißt *divergent*,
    wenn sie nicht konvergent ist.

\

\

<!--EndOfImpairedSection-->
:::

::: {#Content.xhtml#blind .blind}
<!--StartOfBlindSection-->

Höhere Mathematik für Informatiker {#Content.xhtml#toc_0}
==================================

Inoffizielles Skriptum zur Vorlesung Höhere Mathematik für Informatiker
basierend auf Vorlesungen an der Universität Karlsruhe (TH) 2000 \--
2004

\

![](Images/title_1.png "Titelbild"){.imageOthers}

\

((Seitei))

##### Anmerkungen des Autors: {#Content.xhtml#toc_1}

Dieses Werk ist unter einem Creative Commons
Namensnennung-NichtKommerziell-Weitergabe unter gleichen\
Bedingungen Lizenzvertrag lizensiert. Um die Lizenz anzusehen, gehen Sie
bitte zu <http://creativecommons.org/licenses/by-nc-sa/2.0/de/> oder
schicken Sie einen Brief an Creative Commons, 559 Nathan Abbott Way,
Stanford, California 94305, USA.

###### WICHTIGER HINWEIS: {#Content.xhtml#toc_2}

Dies ist KEIN offiziell autorisiertes Skript der genannten Dozenten!
Entsprechend erhebt der Mitschrieb und die enthaltenen Ergänzungen
keinen Anspruch auf Vollständigkeit und Korrektheit!

###### Von der Website: {#Content.xhtml#toc_3}

Das \"inoffizielle Skript\" entstand in Zusammenarbeit mit [Markus
Westphal](http://www.markuswestphal.de/), [Christian
Senger](http://www.sengernet.de/) und anderen Kommilitonen. Es basiert
auf meinem Mitschrieb der Vorlesung von [Prof.
Plum](http://www.math.kit.edu/iana2/~plum/) 2000/2001 an der Universität
Karlsruhe (TH) (heute: KIT). Kombiniert wurde er mit Teilen aus der
Vorlesung von [Dr. Kunstmann](http://www.math.kit.edu/iana3/~kunstmann/)
2002/2003 und aus den Vorlesungen von [Dr.
Schmoeger](http://www.math.kit.edu/iana3/~schmoeger/) 2001/2002 und
2003/2004.\
Sowohl die Konzeption als auch das Manuskript der genannten Vorlesungen
stammen allein von [Dr.
Schmoeger](http://www.math.kit.edu/iana3/~schmoeger/).

Wer ebenfalls Interesse daran hat, die aktuelle HM-Vorlesung in die
bestehenden Quellen einzuarbeiten oder gerne die Lesbarkeit und das
Erscheinungsbild verbessern und weitere Skizzen einfügen möchte: eine
eMail an `<post AT danielwinkler.de>` genügt. 

Wir erheben keinen Anspruch auf Vollständigkeit und Korrektheit!

##### Anmerkungen des Umsetzers: {#Content.xhtml#toc_4}

Da die Vorlage keine farbigen Graphiken enthält, entspricht dieses
Dokument De Facto einer Umsetzung der Schwarz-Weiß-Version des Skriptes.
Das Skript wird möglichst nah am Original umgesetzt, mithilfe aller
verfügbaren Werkzeuge des Editors.

Schlüsselwörter wie \"Beispiel\" und \"Lemma\", welche in der Vorlage
farbig markiert sind, sind es hier ebenfalls, in den vergleichbaren
Farben.\

Dieses Dokument ist vorläufig nur eine Testversion um den Editor an
einem Umsetzungsbeispiel anzuwenden.

###### Bisherige Probleme dieser Umsetzung: {#Content.xhtml#toc_5}

-   Bilder sind zurzeit als Rastergraphik eingebettet, obwohl die
    Quellen im vektoriellen EPS-Format vorliegen.
-   Konsistenz der Notation muss noch gefunden werden.

((Seiteii))

(Inhaltsverzeichnis) {#Content.xhtml#toc_6}
====================

((Seitevi))

(Tabellenverzeichnis) {#Content.xhtml#toc_7}
=====================

 Dieses Werk ist unter einem Creative Commons
Namensnennung\--Nicht-Kommerziell\--Weitergabe unter gleichen
Bedingungen\-\--Lizenzvertrag lizensiert. Um die Lizenz anzusehen, gehen
Sie bitte zu <http://creativecommons.org/licenses/by-nc-sa/2.0/de/> oder
schicken Sie einen Brief an Creative Commons, 559 Nathan Abbott Way,
Stanford, California 94305, USA.

\

![](Images/cc_2.png "Lizensangabe: Creative Commons"){.imageOthers}

Dieses Skriptum erhebt keinen Anspruch auf Vollständigkeit und
Korrektheit. Einige Beweise, die in den Saalübungen geführt wurden, sind
nicht enthalten.

Kommentare, Fehler, Patches und Vorschläge bitte an
[post\@danielwinkler.de](mailto:post@danielwinkler.de%7D%7B%7D%7B%7D%7Bpost@danielwinkler.de) senden.
Bei Fehlern bitte **nicht** die Seitenzahl sondern die Nummer des
Satzes, der Abbildung etc. sowie die Revisionsnummern angeben.

Die aktuelle Version dieses Dokuments sowie die Quelldateien hierzu sind
unter der Web-Adresse\
[http://www.danielwinkler.de/hm/](http://www.danielwinkler.de/hm/%20) zu
finden.

Dieses inoffizielle Skriptum basiert auf dem Mitschrieb von Daniel
Winkler zu den Vorlesungen an der Universität\
Karlsruhe (heute: Karlsruher Institut für Technologie, KIT) in den
Jahren 2000 und 2001 von Prof. M. Plum. Kombiniert wurde er durch Markus
Westphal und Sebastian Reichelt mit Material aus den Vorlesungen in den
Jahren 2002 bis 2004 von HDoz. Dr. P. Kunstmann und AOR Dr. Ch.
Shmoeger.

Sowohl die Konzeption als auch das Manuskript der genannten
Vorlesungen stammen allein von AOR Dr. Ch. Schmoeger.

Weitere Korrekturen und Ergänzungen wurden eingebracht von Julian
Dibbelt, Martin Röhricht, Christian Senger, Norbert Silberhorn, Johannes
Singler und Richard Walter.

  Teil     Rev.
  -------- ------
  Layout   282
  HM 1     289
  HM 2     291
  Anhang   256

((Seitevii))

*Don\'t panic!*\

((Seiteviii))

\

Teil I. Eindimensionale Analsysis {#Content.xhtml#toc_8 align="center"}
=================================

((Seite1))

((Seite2))

0. Vorbemerkungen {#Content.xhtml#toc_9}
=================

0.1. Mengen {#Content.xhtml#toc_10}
-----------

Eine *Menge* ist nach Cantor eine Zusammenfassung [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> von bestimmten
wohlunterschiedenen Objekten unserer Anschauung oder unseres Denkens
(welche Elemente von [[$M$ ]{.math display="inline"
role="math"}[$\mathsf{M}$ ]{.mathImpaired display="inline"
role="math"}[\$M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> genannt werden) zu einem
Ganzen.

**Notation**: geschweifte Klammern [[$\{\}$ ]{.math display="inline"
role="math"}[$\mathsf{\{\}}$ ]{.mathImpaired display="inline"
role="math"}[\$\\left\\{ \\right\\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

#### Beispiel 0.1. Notationen: {#Content.xhtml#toc_11}

-   <font size="1">[[$M = \{ 1,2,3\}$ ]{.math display="inline"
    role="math"}[$\mathsf{M = \{ 1,2,3\}}$ ]{.mathImpaired
    display="inline" role="math"}[\$M = \\{ 1,2,3 \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--></font>
-   <font size="1">[[$M = \{ x:x{\mspace{6mu}\text{ist\ Vielfaches\ von}\mspace{6mu}}7\}$
    ]{.math display="inline"
    role="math"}[$\mathsf{M = \{ x:x{\mspace{6mu}\text{ist\ Vielfaches\ von}\mspace{6mu}}7\}}$
    ]{.mathImpaired display="inline" role="math"}[\$M = \\{ x: x \\text{
    ist Vielfaches von }7 \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> oder
    [[$\{ x \in N:x{\mspace{6mu}\text{Vielfaches\ von}\mspace{6mu}}7\}$
    ]{.math display="inline"
    role="math"}[$\mathsf{\{ x \in N:x{\mspace{6mu}\text{Vielfaches\ von}\mspace{6mu}}7\}}$
    ]{.mathImpaired display="inline" role="math"}[\$\\{ x \\in N: x
    \\text{ Vielfaches von }7 \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--></font>

Weitere Grundnotation: Doppelpunkt zur Kennzeichnung von *Definitionen*.

#### <font color="#008000">Beispiel</font> 0.2. {#Content.xhtml#toc_12}

Wollen die Funktion [[$f$ ]{.math display="inline"
role="math"}[$\mathsf{f}$ ]{.mathImpaired display="inline"
role="math"}[\$f\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> definieren. Schreibe
(z.B.) [[$f(x):=x^{2}$ ]{.math display="inline"
role="math"}[$\mathsf{f(x):=x^{2}}$ ]{.mathImpaired display="inline"
role="math"}[\$f(x):=x\^2\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Nur bei einer
Neudefinition, nicht bei einer Gleichung. Oder
[[$\left. a:=15,f{\mspace{6mu}\text{heißt\ injektiv}\mspace{6mu}}:\Leftrightarrow{\mspace{6mu}\text{Für\ alle}\mspace{6mu}}a,\widetilde{a} \in M{\mspace{6mu}\text{mit}\mspace{6mu}}a \neq \widetilde{a} \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. a:=15,f{\mspace{6mu}\text{heißt\ injektiv}\mspace{6mu}}:\Leftrightarrow{\mspace{6mu}\text{Für\ alle}\mspace{6mu}}a,\widetilde{a} \in M{\mspace{6mu}\text{mit}\mspace{6mu}}a \neq \widetilde{a} \right.}$
]{.mathImpaired display="inline" role="math"}[\$a:=15, f \\text{ heißt
injektiv } : \\Leftrightarrow \\text{ Für alle } a, \\tilde{a} \\in M
\\text{ mit } a \\neq \\tilde{a}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> gilt\...

[[$a \in M$ ]{.math display="inline" role="math"}[$\mathsf{a \in M}$
]{.mathImpaired display="inline" role="math"}[\$a \\in M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (oder [[$M \ni a$ ]{.math
display="inline" role="math"}[$\mathsf{M \ni a}$ ]{.mathImpaired
display="inline" role="math"}[\$M \\ni a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->): [[$a$ ]{.math
display="inline" role="math"}[$\mathsf{a}$ ]{.mathImpaired
display="inline" role="math"}[\$a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist Element von [[$M$
]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->; [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> enthält [[$a$ ]{.math
display="inline" role="math"}[$\mathsf{a}$ ]{.mathImpaired
display="inline" role="math"}[\$a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
[[$a \notin M$ ]{.math display="inline"
role="math"}[$\mathsf{a \notin M}$ ]{.mathImpaired display="inline"
role="math"}[\$a \\notin M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (oder [[$M a$ ]{.math
display="inline" role="math"}[$\mathsf{M a}$ ]{.mathImpaired
display="inline" role="math"}[\$M \\notni a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->): analog s.o.\
[[$M = N$ ]{.math display="inline" role="math"}[$\mathsf{M = N}$
]{.mathImpaired display="inline" role="math"}[\$M = N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->: [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> enthält die selben
Elemente wie [[$N$ ]{.math display="inline" role="math"}[$\mathsf{N}$
]{.mathImpaired display="inline" role="math"}[\$N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
[[$M \neq N$ ]{.math display="inline" role="math"}[$\mathsf{M \neq N}$
]{.mathImpaired display="inline" role="math"}[\$M \\neq
N\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->: analog s.o.\
[[$M \subset N$ ]{.math display="inline"
role="math"}[$\mathsf{M \subset N}$ ]{.mathImpaired display="inline"
role="math"}[\$M \\subset N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (oder [[$M \subseteq N$
]{.math display="inline" role="math"}[$\mathsf{M \subseteq N}$
]{.mathImpaired display="inline" role="math"}[\$M \\subseteq
N\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->): [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist Tielmenge von [[$N$
]{.math display="inline" role="math"}[$\mathsf{N}$ ]{.mathImpaired
display="inline" role="math"}[\$N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, d.h. jedes Element von
[[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist auch ein Element von
[[$N$ ]{.math display="inline" role="math"}[$\mathsf{N}$ ]{.mathImpaired
display="inline" role="math"}[\$N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->; Gleichheit der Mengen
ist erlaubt.\
[[$N \supset M$ ]{.math display="inline"
role="math"}[$\mathsf{N \supset M}$ ]{.mathImpaired display="inline"
role="math"}[\$N \\supset M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (oder [[$N \supseteq M$
]{.math display="inline" role="math"}[$\mathsf{N \supseteq M}$
]{.mathImpaired display="inline" role="math"}[\$N \\supseteq
M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->): [[$N$ ]{.math
display="inline" role="math"}[$\mathsf{N}$ ]{.mathImpaired
display="inline" role="math"}[\$N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist Obermenge von [[$M$
]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->; analog\
[[$M \subsetneqq N$ ]{.math display="inline"
role="math"}[$\mathsf{M \subsetneqq N}$ ]{.mathImpaired display="inline"
role="math"}[\$M \\subsetneqq N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->: [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist echte Teilmenge von
[[$N$ ]{.math display="inline" role="math"}[$\mathsf{N}$ ]{.mathImpaired
display="inline" role="math"}[\$N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->; [[$M \neq N$ ]{.math
display="inline" role="math"}[$\mathsf{M \neq N}$ ]{.mathImpaired
display="inline" role="math"}[\$M \\neq N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
[[$\varnothing$ ]{.math display="inline"
role="math"}[$\mathsf{\varnothing}$ ]{.mathImpaired display="inline"
role="math"}[\$\\emptyset\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->: leere Menge

[[$M \cup N = \{ a:a \in M{\mspace{6mu}\text{oder}\mspace{6mu}}a \in N\}$
]{.math display="inline"
role="math"}[$\mathsf{M \cup N = \{ a:a \in M{\mspace{6mu}\text{oder}\mspace{6mu}}a \in N\}}$
]{.mathImpaired display="inline" role="math"}[\$M \\cup N = \\{ a: a
\\in M \\text{ oder } a \\in N\\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (Vereinigungsmenge)\
[[$M \cap N = \{ a:a \in M{\text{~und}\mspace{6mu}}a \in N\}$ ]{.math
display="inline"
role="math"}[$\mathsf{M \cap N = \{ a:a \in M{\text{~und}\mspace{6mu}}a \in N\}}$
]{.mathImpaired display="inline" role="math"}[\$M \\cap N = \\{ a: a
\\in M \\text{ und } a \\in N\\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (Schnittmenge)\
[[$M\backslash N = \{ a:a \in M{\mspace{6mu}\text{und}\mspace{6mu}}a \notin N\}$
]{.math display="inline"
role="math"}[$\mathsf{M\backslash N = \{ a:a \in M{\mspace{6mu}\text{und}\mspace{6mu}}a \notin N\}}$
]{.mathImpaired display="inline" role="math"}[\$M \\setminus N = \\{ a:
a \\in M \\text{ und } a \\notin N\\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (Komplementmenge)

[[$M,N$ ]{.math display="inline" role="math"}[$\mathsf{M,N}$
]{.mathImpaired display="inline" role="math"}[\$M,N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißen disjunkt, wenn
[[$M \cap N = \varnothing$ ]{.math display="inline"
role="math"}[$\mathsf{M \cap N = \varnothing}$ ]{.mathImpaired
display="inline" role="math"}[\$M \\cap N = \\emptyset\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
[[$P(M) = \{ N:N \subset M\}$ ]{.math display="inline"
role="math"}[$\mathsf{P(M) = \{ N:N \subset M\}}$ ]{.mathImpaired
display="inline" role="math"}[\$P(M) = \\{N: N\\subset
M\\}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->: Potenzmenge von [[$M$
]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (Menge aller Teilmengen)

Beispiel 0.3.

Beispiel für die Potenzmenge von [[$M = \{ 1,2\}$ ]{.math
display="inline" role="math"}[$\mathsf{M = \{ 1,2\}}$ ]{.mathImpaired
display="inline" role="math"}[\$M= \\{1,2\\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->:\
[[$P(M) = \{\{ 1,2\},\{ 1\},\{ 2\},\varnothing\}$ ]{.math
display="inline"
role="math"}[$\mathsf{P(M) = \{\{ 1,2\},\{ 1\},\{ 2\},\varnothing\}}$
]{.mathImpaired display="inline" role="math"}[\$P(M) = \\{ \\{ 1,2 \\} ,
\\{ 1 \\} , \\{ 2 \\} , \\emptyset \\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

0.2. Abbildungen {#Content.xhtml#toc_13}
----------------

Seien [[$M,N$ ]{.math display="inline" role="math"}[$\mathsf{M,N}$
]{.mathImpaired display="inline" role="math"}[\$M,N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> Mengen. Eine *Abbildung*
oder *Funktion* [[$f$ ]{.math display="inline" role="math"}[$\mathsf{f}$
]{.mathImpaired display="inline" role="math"}[\$f\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> von [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> nach [[$N$ ]{.math
display="inline" role="math"}[$\mathsf{N}$ ]{.mathImpaired
display="inline" role="math"}[\$N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist eine Vorschrift, die
jedem Element [[$a \in M$ ]{.math display="inline"
role="math"}[$\mathsf{a \in M}$ ]{.mathImpaired display="inline"
role="math"}[\$a \\in M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> in eindeutiger Weise ein
[[$f(a) \in N$ ]{.math display="inline"
role="math"}[$\mathsf{f(a) \in N}$ ]{.mathImpaired display="inline"
role="math"}[\$f(a) \\in N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> zuordnet.

**Notation:** [[$\left. f:M\rightarrow N,a\rightarrow f(a) \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. f:M\rightarrow N,a\rightarrow f(a) \right.}$
]{.mathImpaired display="inline" role="math"}[\$f: M \\rightarrow N, a
\\rightarrow f(a)\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

### <font color="#008000">Beispiel</font> 0.4.

\

[[$M = N = \mathbb{R},f:\left\{ \begin{array}{l}
\left. \mathbb{R}\leftarrow\mathbb{R} \right. \\
\left. x\mapsto x^{2} \right. \\
\end{array} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{M = N = \mathbb{R},f:\left\{ \begin{array}{l}
\left. \mathbb{R}\leftarrow\mathbb{R} \right. \\
\left. x\mapsto x^{2} \right. \\
\end{array} \right.}$ ]{.mathImpaired display="inline" role="math"}[\$M
= N = \\mathbb{R}, f: \\begin{cases} \\mathbb{R} \\leftarrow \\mathbb{R}
\\\\ x \\mapsto x\^2 \\end{cases}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\

![Eine Abbildung von Real nach Real, macht x zu x
quadrat](Images/Beispiel%200.4..svg "Beispiel 0.4."){.toRemove}

\
[[$\left. f_{1}:M_{1}\rightarrow N_{1} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. f_{1}:M_{1}\rightarrow N_{1} \right.}$
]{.mathImpaired display="inline" role="math"}[\$f\_1: M\_1 \\rightarrow
N\_1\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und
[[$\left. f_{2}:M_{2}\rightarrow N_{2} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. f_{2}:M_{2}\rightarrow N_{2} \right.}$
]{.mathImpaired display="inline" role="math"}[\$f\_2: M\_2 \\rightarrow
N\_2\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heissen *gleich* (kurz
[[$f_{1}f_{2}$ ]{.math display="inline"
role="math"}[$\mathsf{f_{1}f_{2}}$ ]{.mathImpaired display="inline"
role="math"}[\$f\_1 f\_2\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->) (identisch), wenn
[[$M_{1} = M_{2},N_{1} = N_{2}$ ]{.math display="inline"
role="math"}[$\mathsf{M_{1} = M_{2},N_{1} = N_{2}}$ ]{.mathImpaired
display="inline" role="math"}[\$M\_1=M\_2, N\_1=N\_2\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und
[[$f_{1}(a) = f_{2}(a)$ ]{.math display="inline"
role="math"}[$\mathsf{f_{1}(a) = f_{2}(a)}$ ]{.mathImpaired
display="inline" role="math"}[\$f\_1(a)=f\_2(a)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> für alle [[$a \in M_{1}$
]{.math display="inline" role="math"}[$\mathsf{a \in M_{1}}$
]{.mathImpaired display="inline" role="math"}[\$a \\in
M\_1\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
\

[[$\left. f:M\rightarrow N \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. f:M\rightarrow N \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$f:M \\rightarrow N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heisst

-   *injektiv*, wenn für alle [[$a,\widetilde{a} \in M$ ]{.math
    display="inline" role="math"}[$\mathsf{a,\widetilde{a} \in M}$
    ]{.mathImpaired display="inline" role="math"}[\$a, \\tilde{a} \\in
    M\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> mit
    [[$a \neq \widetilde{a}$ ]{.math display="inline"
    role="math"}[$\mathsf{a \neq \widetilde{a}}$ ]{.mathImpaired
    display="inline" role="math"}[\$a \\neq \\tilde{a}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> gilt:
    [[$f(a) \neq f(\widetilde{a})$ ]{.math display="inline"
    role="math"}[$\mathsf{f(a) \neq f(\widetilde{a})}$ ]{.mathImpaired
    display="inline" role="math"}[\$f(a) \\neq
    f(\\tilde{a})\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->;
    ([[$\left. x\mapsto x \right.$ ]{.math display="inline"
    role="math"}[$\mathsf{\left. x\mapsto x \right.}$ ]{.mathImpaired
    display="inline" role="math"}[\$x \\mapsto x\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist injektiv,
    [[$\left. x\mapsto x^{2} \right.$ ]{.math display="inline"
    role="math"}[$\mathsf{\left. x\mapsto x^{2} \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$x \\mapsto
    x\^2\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nicht)
-   *surjektiv*, wenn für alle [[$\widetilde{a} \in M$ ]{.math
    display="inline" role="math"}[$\mathsf{\widetilde{a} \in M}$
    ]{.mathImpaired display="inline" role="math"}[\$\\tilde{a} \\in
    M\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ein [[$a \in M$
    ]{.math display="inline" role="math"}[$\mathsf{a \in M}$
    ]{.mathImpaired display="inline" role="math"}[\$a \\in
    M\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> existiert mit
    [[$f(a) = \widetilde{a}$ ]{.math display="inline"
    role="math"}[$\mathsf{f(a) = \widetilde{a}}$ ]{.mathImpaired
    display="inline" role="math"}[\$f(a)=\\tilde{a}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> (die Bildmenge wird
    voll ausgeschöpft)
-   *bijektiv*, wenn [[$f$ ]{.math display="inline"
    role="math"}[$\mathsf{f}$ ]{.mathImpaired display="inline"
    role="math"}[\$f\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> sowohl injektiv als
    aus surjektiv ist: eindeutige Zuordnung\

Für [[$M_{1} \subset M$ ]{.math display="inline"
role="math"}[$\mathsf{M_{1} \subset M}$ ]{.mathImpaired display="inline"
role="math"}[\$M\_1 \\subset M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heisst
[[$f(M_{1}) = f(a):a \in M_{1}$ ]{.math display="inline"
role="math"}[$\mathsf{f(M_{1}) = f(a):a \in M_{1}}$ ]{.mathImpaired
display="inline" role="math"}[\$f(M\_1) = f(a): a \\in
M\_1\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> Bildmenge von [[$M_{1}$
]{.math display="inline" role="math"}[$\mathsf{M_{1}}$ ]{.mathImpaired
display="inline" role="math"}[\$M\_1\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (unter [[$f$ ]{.math
display="inline" role="math"}[$\mathsf{f}$ ]{.mathImpaired
display="inline" role="math"}[\$f\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->).\
Für [[$N_{1} \subset N$ ]{.math display="inline"
role="math"}[$\mathsf{N_{1} \subset N}$ ]{.mathImpaired display="inline"
role="math"}[\$N\_1 \\subset N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heisst
[[$f^{- 1}(N_{1}) = a \in M:f(a) \in N_{1}$ ]{.math display="inline"
role="math"}[$\mathsf{f^{- 1}(N_{1}) = a \in M:f(a) \in N_{1}}$
]{.mathImpaired display="inline" role="math"}[\$f\^{-1}(N\_1) = a \\in M
: f(a) \\in N\_1\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> *Urbildmenge* von
[[$N_{1}$ ]{.math display="inline" role="math"}[$\mathsf{N_{1}}$
]{.mathImpaired display="inline" role="math"}[\$N\_1\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (unter [[$f$ ]{.math
display="inline" role="math"}[$\mathsf{f}$ ]{.mathImpaired
display="inline" role="math"}[\$f\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->).\
Sind [[$\left. f:M\rightarrow N \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. f:M\rightarrow N \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$f:M \\rightarrow N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und
[[$\left. g:N\rightarrow P \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. g:N\rightarrow P \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$g: N \\rightarrow P\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> Abbildungen, so heisst
die Abbildung

[[$g \circ f:\left\{ \begin{array}{l}
\left. M\leftarrow P \right. \\
\left. a\mapsto g(f(a)) \right. \\
\end{array} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{g \circ f:\left\{ \begin{array}{l}
\left. M\leftarrow P \right. \\
\left. a\mapsto g(f(a)) \right. \\
\end{array} \right.}$ ]{.mathImpaired display="inline" role="math"}[\$g
\\circ f : \\begin{cases} M \\leftarrow P \\\\ a \\mapsto g(f(a))
\\end{cases}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\

![g kreis
f](Images/Beispiel%20Hintereinanderausfuehrung.svg "Beispiel Hintereinanderausfuehrung"){.toRemove}

\

*Hintereinanderausführung* von [[$f$ ]{.math display="inline"
role="math"}[$\mathsf{f}$ ]{.mathImpaired display="inline"
role="math"}[\$f\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[$g$ ]{.math
display="inline" role="math"}[$\mathsf{g}$ ]{.mathImpaired
display="inline" role="math"}[\$g\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

0.3 Aussagen
------------

Unter einer *Aussage* verstehen wir ein sprachliches oder gedankliches
Gefüge, welches entweder wahr oder falsch ist.

##### Beispiel 0.5.

-   \"4 ist eine gerade Zahl\" ist eine wahre Aussage.
-   \"Bananen sind kugelförmig\" ist eine falsche Aussage.
-   \"Nachts ist es kälter als draussen\" ist keine Aussage.
-   \"Es gibt unendlich viele Sterne\" ist eine Aussage, die wahr oder
    falsch sein kann.

Sind [[$A,B$ ]{.math display="inline" role="math"}[$\mathsf{A,B}$
]{.mathImpaired display="inline" role="math"}[\$A,B\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> Aussagen, so sind die
Aussagen
[[$\left. \neg A,A \land B,A \vee B,A\dot{\vee}B,A\Rightarrow B,A\Leftrightarrow B \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. \neg A,A \land B,A \vee B,A\dot{\vee}B,A\Rightarrow B,A\Leftrightarrow B \right.}$
]{.mathImpaired display="inline" role="math"}[\$\\neg A, A \\wedge B, A
\\vee B, A \\dot{\\vee} B, A \\Rightarrow B, A \\Leftrightarrow
B\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> erklärt durch:

-   [[$\neg A$ ]{.math display="inline" role="math"}[$\mathsf{\neg A}$
    ]{.mathImpaired display="inline" role="math"}[\$\\neg
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: [[$A$ ]{.math
    display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
    display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist falsch (Negation)
-   [[$A \land B$ ]{.math display="inline"
    role="math"}[$\mathsf{A \land B}$ ]{.mathImpaired display="inline"
    role="math"}[\$A \\wedge B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: [[$A$ ]{.math
    display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
    display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> und [[$B$ ]{.math
    display="inline" role="math"}[$\mathsf{B}$ ]{.mathImpaired
    display="inline" role="math"}[\$B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> sind beide wahr (und)
-   [[$A \vee B$ ]{.math display="inline"
    role="math"}[$\mathsf{A \vee B}$ ]{.mathImpaired display="inline"
    role="math"}[\$A \\vee B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: [[$A$ ]{.math
    display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
    display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> oder [[$B$ ]{.math
    display="inline" role="math"}[$\mathsf{B}$ ]{.mathImpaired
    display="inline" role="math"}[\$B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist wahr (oder)
-   [[$A\dot{\vee}B$ ]{.math display="inline"
    role="math"}[$\mathsf{A\dot{\vee}B}$ ]{.mathImpaired
    display="inline" role="math"}[\$A \\dot{\\vee} B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: entweder [[$A$
    ]{.math display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
    display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> oder [[$B$ ]{.math
    display="inline" role="math"}[$\mathsf{B}$ ]{.mathImpaired
    display="inline" role="math"}[\$B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist wahr (excl. oder)
-   [[$AB$ ]{.math display="inline" role="math"}[$\mathsf{AB}$
    ]{.mathImpaired display="inline" role="math"}[\$A B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: aus [[$A$ ]{.math
    display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
    display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> folgt [[$B$ ]{.math
    display="inline" role="math"}[$\mathsf{B}$ ]{.mathImpaired
    display="inline" role="math"}[\$B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->; wenn [[$A$ ]{.math
    display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
    display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> wahr ist, dann ist
    auch [[$B$ ]{.math display="inline" role="math"}[$\mathsf{B}$
    ]{.mathImpaired display="inline" role="math"}[\$B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> wahr (Implikation)\
    (ist immer wahr, wenn [[$A$ ]{.math display="inline"
    role="math"}[$\mathsf{A}$ ]{.mathImpaired display="inline"
    role="math"}[\$A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> falsch ist; ist
    nur dann falsch, wenn [[$B$ ]{.math display="inline"
    role="math"}[$\mathsf{B}$ ]{.mathImpaired display="inline"
    role="math"}[\$B\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> falsch ist)\
    Bsp: \"Wenn Bananen kugelförmig sind, ist 4 gerade.\" ist eine wahre
    Aussage.
-   [[$\left. A\Leftrightarrow B \right.$ ]{.math display="inline"
    role="math"}[$\mathsf{\left. A\Leftrightarrow B \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$A \\Leftrightarrow
    B\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: [[$A$ ]{.math
    display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
    display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist genau dann wahr,
    wenn [[$B$ ]{.math display="inline" role="math"}[$\mathsf{B}$
    ]{.mathImpaired display="inline" role="math"}[\$B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> wahr ist.
    (Äquivalenz)

Sei [[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$
]{.mathImpaired display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine Menge und [[$E$
]{.math display="inline" role="math"}[$\mathsf{E}$ ]{.mathImpaired
display="inline" role="math"}[\$E\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine Eigenschaft, die ein
Element [[$a \in M$ ]{.math display="inline"
role="math"}[$\mathsf{a \in M}$ ]{.mathImpaired display="inline"
role="math"}[\$a \\in M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> haben kann. Dann sind
folgende Aussagen machbar:

-   [[$\forall_{a \in M}a$ ]{.math display="inline"
    role="math"}[$\mathsf{\forall_{a \in M}a}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\forall\_{a \\in M}
    a\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> hat die Eigenschaft
    [[$E$ ]{.math display="inline" role="math"}[$\mathsf{E}$
    ]{.mathImpaired display="inline" role="math"}[\$E\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: jedes [[$a \in M$
    ]{.math display="inline" role="math"}[$\mathsf{a \in M}$
    ]{.mathImpaired display="inline" role="math"}[\$a \\in
    M\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> hat die Eigenschaft
    [[$E$ ]{.math display="inline" role="math"}[$\mathsf{E}$
    ]{.mathImpaired display="inline" role="math"}[\$E\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ([[$\forall$ ]{.math
    display="inline" role="math"}[$\mathsf{\forall}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\forall\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> heisst *All-Quantor*)

((Seite4))

-   [[$\exists_{a \in M}a$ ]{.math display="inline"
    role="math"}[$\mathsf{\exists_{a \in M}a}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\exists\_{a \\in M}
    a\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> hat die Eigenschaft
    [[$E$ ]{.math display="inline" role="math"}[$\mathsf{E}$
    ]{.mathImpaired display="inline" role="math"}[\$E\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: es existiert ein
    [[$a \in M$ ]{.math display="inline" role="math"}[$\mathsf{a \in M}$
    ]{.mathImpaired display="inline" role="math"}[\$a \\in
    M\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> mit der Eigenschaft
    [[$E$ ]{.math display="inline" role="math"}[$\mathsf{E}$
    ]{.mathImpaired display="inline" role="math"}[\$E\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ([[$\exists$ ]{.math
    display="inline" role="math"}[$\mathsf{\exists}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\exists\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> heisst
    *Existenzquantor*)
-   [[$\exists_{a \in M}^{1}a$ ]{.math display="inline"
    role="math"}[$\mathsf{\exists_{a \in M}^{1}a}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\exists\^1\_{a \\in M}
    a\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> hat die Eigenschaft
    [[$E$ ]{.math display="inline" role="math"}[$\mathsf{E}$
    ]{.mathImpaired display="inline" role="math"}[\$E\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: es existiert *genau
    ein* [[$a \in M$ ]{.math display="inline"
    role="math"}[$\mathsf{a \in M}$ ]{.mathImpaired display="inline"
    role="math"}[\$a \\in M\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> mit der Eigenschaft
    [[$E$ ]{.math display="inline" role="math"}[$\mathsf{E}$
    ]{.mathImpaired display="inline" role="math"}[\$E\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

Grundsätzliches Ziel der Mathematik: Möglichst viele nichttriviale
Aussagen über gewisse Objekte. Ein solches gedankliches Gebäude kann
nicht aus dem \"Nichts\" kommen. Start des mathematischen Denkens:
Grundannahmen, *Axiome*, die nicht bewiesen werden können.

Insbesondere brauchen wir Axiome, die uns die *Zahlen* liefern.

Möglichkeiten:

-   Peano-*Axiome* liefern die natürlichen Zahlen [[$\mathbb{N}$ ]{.math
    display="inline" role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, daraus lassen sich
    ganze Zahlen und rationale Zahlen *konstruieren*. Ein weiteres Axiom
    lierfert die reellen Zahlen [[$\mathbb{R}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{R}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{R}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, woraus auch die
    komplexen Zahlen konstruierbar sind.
-   Wir können die Axiome sofort auf der Ebene der reellen Zahlen
    fordern. Das wollen wir auch im Folgenden tun.

((Seite5))

((Seite6))

1. Zahlen
=========

1.1 Reelle Zahlen
-----------------

Axiomatische Forderung: Es gibt eine Menge [[$\mathbb{R}$ ]{.math
display="inline" role="math"}[$\mathsf{\mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$\\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, genannt die Menge der
reellen Zahlen, mit folgenden Eigenschaften:

1.2. Axiome der reellen Zahlen
------------------------------

### 1.2.1. Körperaxiome 

In [[$\mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{\mathbb{R}}$ ]{.mathImpaired display="inline"
role="math"}[\$\\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> seien zwei Verknüpfungen
[[$+ , \cdot$ ]{.math display="inline" role="math"}[$\mathsf{+ , \cdot}$
]{.mathImpaired display="inline" role="math"}[\$+,\\cdot\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> gegeben, die jedem Paar
[[$a,b \in \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{a,b \in \mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$a, b \\in \\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> genau ein
[[$a + b \in \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{a + b \in \mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$a+b \\in \\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und ein
[[$a \cdot b \in \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{a \cdot b \in \mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$a \\cdot b \\in
\\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> zuordnen. Dabei sollte
gelten:

**A1: Assoziativgesetz der Addition**

![Die Addition ist
assoziativ](Images/Assoziativgesetz%20der%20Addition.svg "Assoziativgesetz der Addition"){.toRemove}

**A2: neutrales Element der Addition\
**[[$\exists 0 \in \mathbb{R}\forall a \in \mathbb{R}a + 0 = a$ ]{.math
display="inline"
role="math"}[$\mathsf{\exists 0 \in \mathbb{R}\forall a \in \mathbb{R}a + 0 = a}$
]{.mathImpaired display="inline" role="math"}[\$\\exists 0 \\in
\\mathbb{R} \\forall a \\in \\mathbb{R} a+0=a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

**A3: inverses Element der Addition\
**[[$\forall a \in \mathbb{R}\exists( - a) \in \mathbb{R}a + ( - a) = 0$
]{.math display="inline"
role="math"}[$\mathsf{\forall a \in \mathbb{R}\exists( - a) \in \mathbb{R}a + ( - a) = 0}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a \\in
\\mathbb{R} \\exists (-a) \\in \\mathbb{R} a+ (-a) =0\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

**A4: Kommutativgesetz der Addition\
**[[$\forall a,b \in \mathbb{R}a + b = b + a$ ]{.math display="inline"
role="math"}[$\mathsf{\forall a,b \in \mathbb{R}a + b = b + a}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b \\in
\\mathbb{R} a+b=b+a\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
\

A1 bis A4 ergibt: ([[$\mathbb{R}, +$ ]{.math display="inline"
role="math"}[$\mathsf{\mathbb{R}, +}$ ]{.mathImpaired display="inline"
role="math"}[\$\\mathbb{R}, +\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->) ist eine *kommutative
Gruppe*.\

**A5: Assoziativgesetz der Multiplikation\
**[[$\forall a,b,c \in \mathbb{R}(a \cdot b) \cdot c = a \cdot (b \cdot c)$
]{.math display="inline"
role="math"}[$\mathsf{\forall a,b,c \in \mathbb{R}(a \cdot b) \cdot c = a \cdot (b \cdot c)}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b,c \\in
\\mathbb{R} (a \\cdot b) \\cdot c = a \\cdot (b \\cdot
c)\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

**A6: neutrales Element der Multiplikation\
**[[$\exists 1 \in \mathbb{R}\forall a \in \mathbb{R}a \cdot 1 = a,1 \neq 0$
]{.math display="inline"
role="math"}[$\mathsf{\exists 1 \in \mathbb{R}\forall a \in \mathbb{R}a \cdot 1 = a,1 \neq 0}$
]{.mathImpaired display="inline" role="math"}[\$\\exists 1 \\in
\\mathbb{R} \\forall a \\in \\mathbb{R} a \\cdot 1=a, 1 \\neq
0\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

**A7: inverses Element der Multiplikation\
**[[$\forall a \in \mathbb{R}\backslash\{ 0\}\exists a^{- 1} \in \mathbb{R}a \cdot a^{- 1} = 1$
]{.math display="inline"
role="math"}[$\mathsf{\forall a \in \mathbb{R}\backslash\{ 0\}\exists a^{- 1} \in \mathbb{R}a \cdot a^{- 1} = 1}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a \\in
\\mathbb{R} \\setminus \\{0\\} \\exists a\^{-1} \\in \\mathbb{R} a
\\cdot a\^{-1}=1\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

**A8: Kommutitativgesetz der Multiplikation\
**[[$\forall a,b \in \mathbb{R}a \cdot b = b \cdot a$ ]{.math
display="inline"
role="math"}[$\mathsf{\forall a,b \in \mathbb{R}a \cdot b = b \cdot a}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b \\in
\\mathbb{R} a \\cdot b=b \\cdot a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

A5 bis A8 ergibt: ([[$\mathbb{R}\backslash\{ 0\}, \cdot$ ]{.math
display="inline"
role="math"}[$\mathsf{\mathbb{R}\backslash\{ 0\}, \cdot}$
]{.mathImpaired display="inline" role="math"}[\$\\mathbb{R} \\setminus
\\{ 0 \\}, \\cdot\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->) ist eine *kommutative
Gruppe*.\

**A9: Distributivgesetz\
**[[$\forall a,b,c \in \mathbb{R}a \cdot (b + c) = a \cdot b + a \cdot c$
]{.math display="inline"
role="math"}[$\mathsf{\forall a,b,c \in \mathbb{R}a \cdot (b + c) = a \cdot b + a \cdot c}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b,c \\in
\\mathbb{R} a \\cdot (b+c) = a \\cdot b + a \\cdot c\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

A1 bis A9 ergibt: [[$(\mathbb{R}, + , \cdot )$ ]{.math display="inline"
role="math"}[$\mathsf{(\mathbb{R}, + , \cdot )}$ ]{.mathImpaired
display="inline" role="math"}[\$( \\mathbb{R},+, \\cdot
)\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist ein *Körper*.

Alle bekannten Regeln der Grundrechenarten lassen sich aus A1 bis A9
herleiten und seien von nun an bekannt.

Schreibweise:

Für [[$a,b \in \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{a,b \in \mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$a,b \\in\\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->:\
[[$ab:=a \cdot b$ ]{.math display="inline"
role="math"}[$\mathsf{ab:=a \cdot b}$ ]{.mathImpaired display="inline"
role="math"}[\$ab := a \\cdot b\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
[[$a - b:=a + ( - b)$ ]{.math display="inline"
role="math"}[$\mathsf{a - b:=a + ( - b)}$ ]{.mathImpaired
display="inline" role="math"}[\$a-b := a + (-b)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
falls [[$a \neq 0:=\frac{a}{b}:=ba^{- 1}$ ]{.math display="inline"
role="math"}[$\mathsf{a \neq 0:=\frac{a}{b}:=ba^{- 1}}$ ]{.mathImpaired
display="inline" role="math"}[\$a \\neq 0 := \\frac{a}{b} :=
ba\^{-1}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

#### Biespiel 1.1.

1.  Das Nullement 0 ist eindeutig:\
    Sei [[$\widetilde{0}$ ]{.math display="inline"
    role="math"}[$\mathsf{\widetilde{0}}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\tilde{0}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> weiteres Element mit
    [[$\forall a \in \mathbb{R}a + \widetilde{0} = a$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\forall a \in \mathbb{R}a + \widetilde{0} = a}$
    ]{.mathImpaired display="inline" role="math"}[\$\\forall a \\in
    \\mathbb{R} a+ \\tilde{0} =a\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    Dann: [[$\widetilde{0} = \widetilde{0}0 = 0\widetilde{0} = 0$
    ]{.math display="inline"
    role="math"}[$\mathsf{\widetilde{0} = \widetilde{0}0 = 0\widetilde{0} = 0}$
    ]{.mathImpaired display="inline" role="math"}[\$\\tilde{0} =
    \\tilde{0}0 = 0 \\tilde{0} = 0\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
2.  [[$\forall a \in \mathbb{R}a \cdot 0 = 0$ ]{.math display="inline"
    role="math"}[$\mathsf{\forall a \in \mathbb{R}a \cdot 0 = 0}$
    ]{.mathImpaired display="inline" role="math"}[\$\\forall a \\in
    \\mathbb{R} a \\cdot 0 =0\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->:\
    [[$a \cdot 0 = a \cdot (0 + 0) = a \cdot 0 + a \cdot 0\quad| - (a \cdot 0)$
    ]{.math display="inline"
    role="math"}[$\mathsf{a \cdot 0 = a \cdot (0 + 0) = a \cdot 0 + a \cdot 0\quad| - (a \cdot 0)}$
    ]{.mathImpaired display="inline" role="math"}[\$a \\cdot 0 = a
    \\cdot (0+0) = a \\cdot 0 + a \\cdot 0 \\quad \\vert -(a \\cdot
    0)\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$0 = a \cdot 0$ ]{.math display="inline"
    role="math"}[$\mathsf{0 = a \cdot 0}$ ]{.mathImpaired
    display="inline" role="math"}[\$0= a \\cdot 0\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
3.  [[$\forall a \in \mathbb{R}a^{2} = ( - a)^{2}({\text{wobei:}\mspace{6mu}}a^{2} = a \cdot a)$
    ]{.math display="inline"
    role="math"}[$\mathsf{\forall a \in \mathbb{R}a^{2} = ( - a)^{2}({\text{wobei:}\mspace{6mu}}a^{2} = a \cdot a)}$
    ]{.mathImpaired display="inline" role="math"}[\$\\forall a \\in
    \\mathbb{R} a\^2 = (-a)\^2 ( \\text{wobei: } a\^2 = a \\cdot
    a)\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->:\
    [[$a^{2} = a \cdot a = a \cdot (a + a - a) = a \cdot (a + a) + a \cdot ( - a)$
    ]{.math display="inline"
    role="math"}[$\mathsf{a^{2} = a \cdot a = a \cdot (a + a - a) = a \cdot (a + a) + a \cdot ( - a)}$
    ]{.mathImpaired display="inline" role="math"}[\$a\^2 = a \\cdot a =
    a \\cdot (a+a-a) = a\\cdot (a+a)+a \\cdot (-a)\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$= a \cdot (a + a) + ( - a) \cdot (a + a - a) = a \cdot (a + a) + ( - a) \cdot (a + a) + ( - a) \cdot ( - a)$
    ]{.math display="inline"
    role="math"}[$\mathsf{= a \cdot (a + a) + ( - a) \cdot (a + a - a) = a \cdot (a + a) + ( - a) \cdot (a + a) + ( - a) \cdot ( - a)}$
    ]{.mathImpaired display="inline" role="math"}[\$= a \\cdot (a+a) +
    (-a) \\cdot (a+a-a) = a \\cdot (a+a) + (-a) \\cdot (a+a)+ (-a)
    \\cdot (-a)\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$= (a + a) \cdot (a - a) + ( - a)^{2} = (a + a) \cdot 0 + ( - a)^{2} = ( - a)2$
    ]{.math display="inline"
    role="math"}[$\mathsf{= (a + a) \cdot (a - a) + ( - a)^{2} = (a + a) \cdot 0 + ( - a)^{2} = ( - a)2}$
    ]{.mathImpaired display="inline" role="math"}[\$= (a+a) \\cdot
    (a-a) + (-a)\^2 = (a+a) \\cdot 0 + (-a)\^2 = (-a)2\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

### 1.2.2 Anordnungsaxiome

In [[$\mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{\mathbb{R}}$ ]{.mathImpaired display="inline"
role="math"}[\$\\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist eine Relation
[[$\leq$ ]{.math display="inline" role="math"}[$\mathsf{\leq}$
]{.mathImpaired display="inline" role="math"}[\$\\leq\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> gegeben, für die gilt:

**A10**\
[[$\forall a,b \in \mathbb{R}\lbrack a \leq b \vee b \leq a\rbrack$
]{.math display="inline"
role="math"}[$\mathsf{\forall a,b \in \mathbb{R}\lbrack a \leq b \vee b \leq a\rbrack}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b
\\in \\mathbb{R} \[a \\leq b \\vee b \\leq a\]\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

**A11**\
[[$\left. \forall a,b \in \mathbb{R}\lbrack(a \leq b \land b \leq a)\Rightarrow a = b\rbrack \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. \forall a,b \in \mathbb{R}\lbrack(a \leq b \land b \leq a)\Rightarrow a = b\rbrack \right.}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b \\in
\\mathbb{R} \[(a \\leq b \\wedge b \\leq a) \\Rightarrow
a=b\]\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

((Seite8))

**A12**\
[[$\left. \forall a,b,c \in \mathbb{R}\lbrack(a \leq b \land b \leq c)\Rightarrow a \leq c\rbrack \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. \forall a,b,c \in \mathbb{R}\lbrack(a \leq b \land b \leq c)\Rightarrow a \leq c\rbrack \right.}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b,c \\in
\\mathbb{R}  \[(a \\leq b \\wedge b \\leq c) \\Rightarrow a \\leq
c\]\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

[[$\left. \Rightarrow\mathbb{R} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. \Rightarrow\mathbb{R} \right.}$
]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow
\\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist eine total geordnete
Menge.

**A13**\
[[$\left. \forall a,b,c \in \mathbb{R}\lbrack(a \leq b)\Rightarrow(a + c \leq b + c)\rbrack \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. \forall a,b,c \in \mathbb{R}\lbrack(a \leq b)\Rightarrow(a + c \leq b + c)\rbrack \right.}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b,c \\in
\\mathbb{R} \[(a \\leq b) \\Rightarrow (a+c \\leq b+c)\]\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

**A14**\
[[$\left. \forall a,b,c \in \mathbb{R}\lbrack(a \leq b \land 0 \leq c)\Rightarrow a \cdot \leq b \cdot c\rbrack \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. \forall a,b,c \in \mathbb{R}\lbrack(a \leq b \land 0 \leq c)\Rightarrow a \cdot \leq b \cdot c\rbrack \right.}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b,c \\in
\\mathbb{R} \[(a \\leq b \\wedge 0 \\leq c) \\Rightarrow a \\cdot \\leq
b \\cdot c\]\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

Schreibweisen: [[$\forall a,b \in \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{\forall a,b \in \mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$\\forall a,b \\in
\\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

-   [[$\left. b \geq a:\Leftrightarrow a \leq b \right.$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\left. b \geq a:\Leftrightarrow a \leq b \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$b \\geq a :
    \\Leftrightarrow a \\leq b\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
-   [[[\$a &lt; b : \\Leftrightarrow (a \\leq b \\wedge a \\neq
    b)\$]{.math .inline} ]{.math display="inline" role="math"}[[\$a &lt;
    b : \\Leftrightarrow (a \\leq b \\wedge a \\neq b)\$]{.math .inline}
    ]{.mathImpaired display="inline" role="math"}[\$a \< b :
    \\Leftrightarrow (a \\leq b \\wedge a \\neq b)\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
-   [[[\$b &gt; a: \\Leftrightarrow a &lt; b\$]{.math .inline} ]{.math
    display="inline" role="math"}[[\$b &gt; a: \\Leftrightarrow a &lt;
    b\$]{.math .inline} ]{.mathImpaired display="inline"
    role="math"}[\$b \> a: \\Leftrightarrow a \< b\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

Alle bekannten Regeln für Ungleichungen lassen sich aus A1 bis A14
herleiten und seien von nun an bekannt.

Beispiel 1.2.

1.  [[$\left. \forall a,b,c \in \mathbb{R}\lbrack a \leq b \land c \leq 0)\Rightarrow a \cdot c \leq b \cdot c\rbrack \right.$
    ]{.math display="inline"
    role="math"}[$\mathsf{\left. \forall a,b,c \in \mathbb{R}\lbrack a \leq b \land c \leq 0)\Rightarrow a \cdot c \leq b \cdot c\rbrack \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\forall a,b,c \\in
    \\mathbb{R} \[a \\leq b \\wedge c \\leq 0) \\Rightarrow a \\cdot c
    \\leq b\\cdot c\]\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    **Beweis:**\
    [[$\left. c \leq 0\Rightarrow 0 \leq - c \right.$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\left. c \leq 0\Rightarrow 0 \leq - c \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$c \\leq 0
    \\Rightarrow 0 \\leq -c\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$\left. \Rightarrow a \cdot ( - c) \leq b \cdot ( - c) \right.$
    ]{.math display="inline"
    role="math"}[$\mathsf{\left. \Rightarrow a \cdot ( - c) \leq b \cdot ( - c) \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow a
    \\cdot (-c) \\leq b \\cdot (-c)\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$\left. \Rightarrow bc \leq ac \right.$ ]{.math display="inline"
    role="math"}[$\mathsf{\left. \Rightarrow bc \leq ac \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow bc
    \\leq ac\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\square\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
2.  [[[\$\\forall a,b,c \\in \\mathbb{R} \[(a \\leq b \\wedge c&gt;0)
    \\Rightarrow a \\cdot c \\leq b \\cdot c\]\$]{.math .inline} ]{.math
    display="inline" role="math"}[[\$\\forall a,b,c \\in \\mathbb{R}
    \[(a \\leq b \\wedge c&gt;0) \\Rightarrow a \\cdot c \\leq b \\cdot
    c\]\$]{.math .inline} ]{.mathImpaired display="inline"
    role="math"}[\$\\forall a,b,c \\in \\mathbb{R} \[(a \\leq b \\wedge
    c\>0) \\Rightarrow a \\cdot c \\leq b \\cdot c\]\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

Betrag einer reellen Zahl:\
[[$\forall a \in \mathbb{R}|a|:=\left\{ \begin{array}{lc}
{a{\mspace{6mu}\text{falls}\mspace{6mu}}a \geq 0} & \\
{- a{\mspace{6mu}\text{falls}\mspace{6mu}}a} & {lt;0} \\
\end{array} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\forall a \in \mathbb{R}|a|:=\left\{ \begin{array}{lc}
{a{\mspace{6mu}\text{falls}\mspace{6mu}}a \geq 0} & \\
{- a{\mspace{6mu}\text{falls}\mspace{6mu}}a} & {lt;0} \\
\end{array} \right.}$ ]{.mathImpaired display="inline"
role="math"}[\$\\forall a \\in \\mathbb{R} \|a\| := \\begin{cases} a
\\text{ falls } a \\geq 0 \\\\ -a \\text{ falls } a \< 0
\\end{cases}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\

[[$|a|$ ]{.math display="inline" role="math"}[$\mathsf{|a|}$
]{.mathImpaired display="inline" role="math"}[\$\|a\|\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->: Abstand von [[$a$
]{.math display="inline" role="math"}[$\mathsf{a}$ ]{.mathImpaired
display="inline" role="math"}[\$a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> zur 0\
[[$|a - b|$ ]{.math display="inline" role="math"}[$\mathsf{|a - b|}$
]{.mathImpaired display="inline" role="math"}[\$\|a-b\|\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->: Abstand von [[$a$
]{.math display="inline" role="math"}[$\mathsf{a}$ ]{.mathImpaired
display="inline" role="math"}[\$a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[$b$ ]{.math
display="inline" role="math"}[$\mathsf{b}$ ]{.mathImpaired
display="inline" role="math"}[\$b\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

1.  [[$|a| \geq 0$ ]{.math display="inline"
    role="math"}[$\mathsf{|a| \geq 0}$ ]{.mathImpaired display="inline"
    role="math"}[\$\|a\| \\geq 0\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
2.  [[$\left. |a| = 0\Leftrightarrow a = 0 \right.$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\left. |a| = 0\Leftrightarrow a = 0 \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\|a\| = 0
    \\Leftrightarrow a=0\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
3.  [[$|a| = | - a|$ ]{.math display="inline"
    role="math"}[$\mathsf{|a| = | - a|}$ ]{.mathImpaired
    display="inline" role="math"}[\$\|a\| = \|-a\|\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
4.  [[$|a \cdot b| = |a| \cdot |b|$ ]{.math display="inline"
    role="math"}[$\mathsf{|a \cdot b| = |a| \cdot |b|}$ ]{.mathImpaired
    display="inline" role="math"}[\$\|a \\cdot b\| = \|a\| \\cdot
    \|b\|\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
5.  [[$a \leq |a|, - a \leq |a|$ ]{.math display="inline"
    role="math"}[$\mathsf{a \leq |a|, - a \leq |a|}$ ]{.mathImpaired
    display="inline" role="math"}[\$a \\leq \|a\|, -a \\leq
    \|a\|\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
6.  Dreiecksungleichung:\
    [[$|a + b| \leq |a| + |b|$ ]{.math display="inline"
    role="math"}[$\mathsf{|a + b| \leq |a| + |b|}$ ]{.mathImpaired
    display="inline" role="math"}[\$\|a+b\| \\leq \|a\| +
    \|b\|\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
7.  [[$||a| - |b|| \leq |a - b|$ ]{.math display="inline"
    role="math"}[$\mathsf{||a| - |b|| \leq |a - b|}$ ]{.mathImpaired
    display="inline" role="math"}[\$\| \|a\|-\|b\| \| \\leq
    \|a-b\|\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

((Seite9))

**Beweis:** zu 6.

1\. Fall: [[$a + b \geq 0$ ]{.math display="inline"
role="math"}[$\mathsf{a + b \geq 0}$ ]{.mathImpaired display="inline"
role="math"}[\$a+b \\geq 0\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Dann:\
[[$|a + b| = a + b \leq |a| + b \leq |a| + |b|$ ]{.math display="inline"
role="math"}[$\mathsf{|a + b| = a + b \leq |a| + b \leq |a| + |b|}$
]{.mathImpaired display="inline" role="math"}[\$\|a+b\| = a+b \\leq
\|a\|+b \\leq \|a\|+\|b\|\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

2\. Fall: [[[\$a+b &lt; 0\$]{.math .inline} ]{.math display="inline"
role="math"}[[\$a+b &lt; 0\$]{.math .inline} ]{.mathImpaired
display="inline" role="math"}[\$a+b \< 0\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Dann:\
[[$|a + b| = - (a + b) = ( - a) + ( - b) \leq |a| + |b|$ ]{.math
display="inline"
role="math"}[$\mathsf{|a + b| = - (a + b) = ( - a) + ( - b) \leq |a| + |b|}$
]{.mathImpaired display="inline" role="math"}[\$\|a+b\| = -(a+b) =
(-a)+(-b) \\leq \|a\|+\|b\|\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

### Definition 1.3.

Sei [[$M \subset \mathbb{R},M \neq \varnothing$ ]{.math display="inline"
role="math"}[$\mathsf{M \subset \mathbb{R},M \neq \varnothing}$
]{.mathImpaired display="inline" role="math"}[\$M \\subset \\mathbb{R},
M \\neq \\emptyset\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißt *nach oben
Beschränkt\
*[[$\left. :\Leftrightarrow\exists\gamma \in \mathbb{R}\forall x \in Mx \leq \gamma \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. :\Leftrightarrow\exists\gamma \in \mathbb{R}\forall x \in Mx \leq \gamma \right.}$
]{.mathImpaired display="inline" role="math"}[\$: \\Leftrightarrow
\\exists \\gamma \\in \\mathbb{R} \\forall x \\in M x \\leq
\\gamma\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

[[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißt *nach unten
beschränkt*\
[[$\left. :\Leftrightarrow\exists\gamma \in \mathbb{R}\forall x \in Mx \geq \gamma \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. :\Leftrightarrow\exists\gamma \in \mathbb{R}\forall x \in Mx \geq \gamma \right.}$
]{.mathImpaired display="inline" role="math"}[\$: \\Leftrightarrow
\\exists \\gamma \\in \\mathbb{R} \\forall x \\in M x \\geq
\\gamma\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

In diesem Fall heißt [[$\gamma$ ]{.math display="inline"
role="math"}[$\mathsf{\gamma}$ ]{.mathImpaired display="inline"
role="math"}[\$\\gamma\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> obere Schranke (bzw.
untere Schranke) von [[$M$ ]{.math display="inline"
role="math"}[$\mathsf{M}$ ]{.mathImpaired display="inline"
role="math"}[\$M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

Ist [[$\gamma$ ]{.math display="inline" role="math"}[$\mathsf{\gamma}$
]{.mathImpaired display="inline" role="math"}[\$\\gamma\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine obere Schranke von
[[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und gilt für *jede*
weitere obere Schranke [[$\widetilde{\gamma}$ ]{.math display="inline"
role="math"}[$\mathsf{\widetilde{\gamma}}$ ]{.mathImpaired
display="inline" role="math"}[\$\\tilde{\\gamma}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> von [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> :
[[$\gamma \leq \widetilde{\gamma}$ ]{.math display="inline"
role="math"}[$\mathsf{\gamma \leq \widetilde{\gamma}}$ ]{.mathImpaired
display="inline" role="math"}[\$\\gamma \\leq
\\tilde{\\gamma}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, (d.h. [[$\gamma$ ]{.math
display="inline" role="math"}[$\mathsf{\gamma}$ ]{.mathImpaired
display="inline" role="math"}[\$\\gamma\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist *kleinste* obere
Schranke von [[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$
]{.mathImpaired display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->), so heißt [[$\gamma$
]{.math display="inline" role="math"}[$\mathsf{\gamma}$ ]{.mathImpaired
display="inline" role="math"}[\$\\gamma\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> das *Supremum* von [[$M$
]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

Ist [[$\gamma$ ]{.math display="inline" role="math"}[$\mathsf{\gamma}$
]{.mathImpaired display="inline" role="math"}[\$\\gamma\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine untere Schranke von
[[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und gilt für *jede*
weitere untere Schranke [[$\widetilde{\gamma}$ ]{.math display="inline"
role="math"}[$\mathsf{\widetilde{\gamma}}$ ]{.mathImpaired
display="inline" role="math"}[\$\\tilde{\\gamma}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> von [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> :
[[$\gamma \geq \widetilde{\gamma}$ ]{.math display="inline"
role="math"}[$\mathsf{\gamma \geq \widetilde{\gamma}}$ ]{.mathImpaired
display="inline" role="math"}[\$\\gamma \\geq
\\tilde{\\gamma}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, (d.h. [[$\gamma$ ]{.math
display="inline" role="math"}[$\mathsf{\gamma}$ ]{.mathImpaired
display="inline" role="math"}[\$\\gamma\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist *größte* untere
Schranke von [[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$
]{.mathImpaired display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->), so heißt [[$\gamma$
]{.math display="inline" role="math"}[$\mathsf{\gamma}$ ]{.mathImpaired
display="inline" role="math"}[\$\\gamma\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> das *Infimum* von [[$M$
]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

Falls [[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$
]{.mathImpaired display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eni Supremum hat, so ist
nach A11 dieses eindeutig bestimmt. (Infimum analog)

Bezeichnung: [[$\sup M,\inf M$ ]{.math display="inline"
role="math"}[$\mathsf{\sup M,\inf M}$ ]{.mathImpaired display="inline"
role="math"}[\$\\sup M, \\inf M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

Existiert [[$\sup M$ ]{.math display="inline"
role="math"}[$\mathsf{\sup M}$ ]{.mathImpaired display="inline"
role="math"}[\$\\sup M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und gilt [[$\sup M \in M$
]{.math display="inline" role="math"}[$\mathsf{\sup M \in M}$
]{.mathImpaired display="inline" role="math"}[\$\\sup M \\in
M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, so heißt [[$\sup M$
]{.math display="inline" role="math"}[$\mathsf{\sup M}$ ]{.mathImpaired
display="inline" role="math"}[\$\\sup M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> auch *Maximum* von [[$M$
]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (Bezeichnung [[$\max M$
]{.math display="inline" role="math"}[$\mathsf{\max M}$ ]{.mathImpaired
display="inline" role="math"}[\$\\max M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->).

Existiert [[$\inf M$ ]{.math display="inline"
role="math"}[$\mathsf{\inf M}$ ]{.mathImpaired display="inline"
role="math"}[\$\\inf M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und gilt [[$\inf M \in M$
]{.math display="inline" role="math"}[$\mathsf{\inf M \in M}$
]{.mathImpaired display="inline" role="math"}[\$\\inf M \\in
M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, so heißt [[$\inf M$
]{.math display="inline" role="math"}[$\mathsf{\inf M}$ ]{.mathImpaired
display="inline" role="math"}[\$\\inf M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> auch *Minimum* von [[$M$
]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (Bezeichnung [[$\min M$
]{.math display="inline" role="math"}[$\mathsf{\min M}$ ]{.mathImpaired
display="inline" role="math"}[\$\\min M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->).

### Beispiel 1.4. Intervalle

Seien [[[\$a,b \\in \\mathbb{R}, a &lt; b\$]{.math .inline} ]{.math
display="inline" role="math"}[[\$a,b \\in \\mathbb{R}, a &lt; b\$]{.math
.inline} ]{.mathImpaired display="inline" role="math"}[\$a,b \\in
\\mathbb{R}, a \< b\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

-   [[[\$(a,b) := \\{ x \\in \\mathbb{R} : a &lt; x &lt; b \\}\$]{.math
    .inline} ]{.math display="inline" role="math"}[[\$(a,b) := \\{ x
    \\in \\mathbb{R} : a &lt; x &lt; b \\}\$]{.math .inline}
    ]{.mathImpaired display="inline" role="math"}[\$(a,b) := \\{ x \\in
    \\mathbb{R} : a \< x \< b \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> (offenes Intervall)
-   [[$\lbrack a,b\rbrack:=\{ x \in \mathbb{R}:a \leq x \leq b\}$
    ]{.math display="inline"
    role="math"}[$\mathsf{\lbrack a,b\rbrack:=\{ x \in \mathbb{R}:a \leq x \leq b\}}$
    ]{.mathImpaired display="inline" role="math"}[\$\[a,b\] := \\{ x
    \\in \\mathbb{R} : a \\leq x \\leq b \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> (abgeschlossenes
    Intervall)
-   [[[\$(a,b\] := \\{ x \\in \\mathbb{R} : a &lt; x \\leq b
    \\}\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$(a,b\] := \\{ x \\in \\mathbb{R} : a &lt; x \\leq b
    \\}\$]{.math .inline} ]{.mathImpaired display="inline"
    role="math"}[\$(a,b\] := \\{ x \\in \\mathbb{R} : a \< x \\leq b
    \\}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> (halboffenes
    Intervall)
-   [[$\lbrack a,\infty):=\{ x \in \mathbb{R}:a \leq x\}$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\lbrack a,\infty):=\{ x \in \mathbb{R}:a \leq x\}}$
    ]{.mathImpaired display="inline" role="math"}[\$\[ a, \\infty ) :=
    \\{ x \\in \\mathbb{R} : a \\leq x \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
-   [[[\$(a, \\infty ) := \\{ x \\in \\mathbb{R} : a &lt; x \\}\$]{.math
    .inline} ]{.math display="inline" role="math"}[[\$(a, \\infty ) :=
    \\{ x \\in \\mathbb{R} : a &lt; x \\}\$]{.math .inline}
    ]{.mathImpaired display="inline" role="math"}[\$(a, \\infty ) := \\{
    x \\in \\mathbb{R} : a \< x \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
-   [[[\$(- \\infty, a) := \\{ x \\in \\mathbb{R} : x&lt;a \\}\$]{.math
    .inline} ]{.math display="inline" role="math"}[[\$(- \\infty, a) :=
    \\{ x \\in \\mathbb{R} : x&lt;a \\}\$]{.math .inline}
    ]{.mathImpaired display="inline" role="math"}[\$(- \\infty, a) :=
    \\{ x \\in \\mathbb{R} : x\<a \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
-   [[$( - \infty,a\rbrack:=\{ x \in \mathbb{R}:x \leq a\}$ ]{.math
    display="inline"
    role="math"}[$\mathsf{( - \infty,a\rbrack:=\{ x \in \mathbb{R}:x \leq a\}}$
    ]{.mathImpaired display="inline" role="math"}[\$(- \\infty, a\] :=
    \\{ x \\in \\mathbb{R} : x \\leq a \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
-   [[$( - \infty,\infty):=\mathbb{R}$ ]{.math display="inline"
    role="math"}[$\mathsf{( - \infty,\infty):=\mathbb{R}}$
    ]{.mathImpaired display="inline" role="math"}[\$(- \\infty, \\infty
    ) := \\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

### Beispiel 1.5. Beispiele von Mengen und deren Schranken:

> \(1) [[$M = (1,2)$ ]{.math display="inline"
> role="math"}[$\mathsf{M = (1,2)}$ ]{.mathImpaired display="inline"
> role="math"}[\$M=(1,2)\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> obere Schranken: alle Zahlen [[$\geq 2$ ]{.math display="inline"
> role="math"}[$\mathsf{\geq 2}$ ]{.mathImpaired display="inline"
> role="math"}[\$\\geq 2\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> [[$\sup M = 2,2 \notin M$ ]{.math display="inline"
> role="math"}[$\mathsf{\sup M = 2,2 \notin M}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\sup M=2, 2 \\notin M\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, daher existiert das
> Maximum von [[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$
> ]{.mathImpaired display="inline" role="math"}[\$M\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> nicht.
>
> untere Schranken: alle Zahlen [[$\leq 1$ ]{.math display="inline"
> role="math"}[$\mathsf{\leq 1}$ ]{.mathImpaired display="inline"
> role="math"}[\$\\leq 1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> [[$\inf M = 1,1 \notin M$ ]{.math display="inline"
> role="math"}[$\mathsf{\inf M = 1,1 \notin M}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\inf M=1, 1 \\notin M\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, daher existiert
> das Minimum von [[$M$ ]{.math display="inline"
> role="math"}[$\mathsf{M}$ ]{.mathImpaired display="inline"
> role="math"}[\$M\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> nicht.

((Seite 10))

> \(2) [[$M = (1,2\rbrack$ ]{.math display="inline"
> role="math"}[$\mathsf{M = (1,2\rbrack}$ ]{.mathImpaired display="inline"
> role="math"}[\$M=(1,2\]\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> obere Schranken: alle Zahlen [[$\geq 2$ ]{.math display="inline"
> role="math"}[$\mathsf{\geq 2}$ ]{.mathImpaired display="inline"
> role="math"}[\$\\geq 2\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> [[$\left. \sup M = 2,2 \in M\Rightarrow\max M = 2 \right.$ ]{.math
> display="inline"
> role="math"}[$\mathsf{\left. \sup M = 2,2 \in M\Rightarrow\max M = 2 \right.}$
> ]{.mathImpaired display="inline" role="math"}[\$\\sup M=2, 2 \\in M
> \\Rightarrow \\max M=2\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->.
>
> untere Schranken: alle Zahlen [[$\leq 1$ ]{.math display="inline"
> role="math"}[$\mathsf{\leq 1}$ ]{.mathImpaired display="inline"
> role="math"}[\$\\leq 1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> [[$\inf M = 1,1 \notin M$ ]{.math display="inline"
> role="math"}[$\mathsf{\inf M = 1,1 \notin M}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\inf M=1, 1 \\notin M\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, daher existiert
> das Minimum von [[$M$ ]{.math display="inline"
> role="math"}[$\mathsf{M}$ ]{.mathImpaired display="inline"
> role="math"}[\$M\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> nicht.
>
> \(3) [[$M = \lbrack 2,\infty)$ ]{.math display="inline"
> role="math"}[$\mathsf{M = \lbrack 2,\infty)}$ ]{.mathImpaired
> display="inline" role="math"}[\$M=\[2, \\infty )\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> [[$\inf M = 2;2 \in M,{\mspace{6mu}\text{also}\mspace{6mu}}\min M = 2$
> ]{.math display="inline"
> role="math"}[$\mathsf{\inf M = 2;2 \in M,{\mspace{6mu}\text{also}\mspace{6mu}}\min M = 2}$
> ]{.mathImpaired display="inline" role="math"}[\$\\inf M=2; 2 \\in M,
> \\text{ also } \\min M=2\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> [[$\sup M$ ]{.math display="inline" role="math"}[$\mathsf{\sup M}$
> ]{.mathImpaired display="inline" role="math"}[\$\\sup
> M\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> existiert nicht

**A15\
**Ist [[$M \subset \mathbb{R},M \neq \varnothing,M$ ]{.math
display="inline"
role="math"}[$\mathsf{M \subset \mathbb{R},M \neq \varnothing,M}$
]{.mathImpaired display="inline" role="math"}[\$M \\subset \\mathbb{R},
M \\neq \\emptyset, M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> nach oben beschränkt, so
existiert [[$\sup M$ ]{.math display="inline"
role="math"}[$\mathsf{\sup M}$ ]{.mathImpaired display="inline"
role="math"}[\$\\sup M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

### Satz 1.6. {dir="ltr"}

Ist [[$M \subset \mathbb{R},M \neq \varnothing,M$ ]{.math
display="inline"
role="math"}[$\mathsf{M \subset \mathbb{R},M \neq \varnothing,M}$
]{.mathImpaired display="inline" role="math"}[\$M \\subset \\mathbb{R},
M \\neq \\emptyset, M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> nach unten beschränkt, so
existiert [[$\inf M$ ]{.math display="inline"
role="math"}[$\mathsf{\inf M}$ ]{.mathImpaired display="inline"
role="math"}[\$\\inf M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

**Beweis:** Betrachte [[$- M:=\{ - x,x, \in M\}$ ]{.math
display="inline" role="math"}[$\mathsf{- M:=\{ - x,x, \in M\}}$
]{.mathImpaired display="inline" role="math"}[\$-M := \\{ -x,x, \\in M
\\}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> statt [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. [[ ]{.math
display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
display="inline" role="math"}[\$\\square\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

### Definition 1.7. {dir="ltr"}

Sei [[$M \subset \mathbb{R},M \neq \varnothing$ ]{.math display="inline"
role="math"}[$\mathsf{M \subset \mathbb{R},M \neq \varnothing}$
]{.mathImpaired display="inline" role="math"}[\$M \\subset \\mathbb{R},
M \\neq \\emptyset\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
[[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißt *beschränkt*, wenn
[[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> nach oben und nach unten
beschränkt ist.

Es gilt: [[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$
]{.mathImpaired display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> beschränkt
[[[\$\\Leftrightarrow \\exists c &gt; 0 \\forall x \\in M \|x\| \\leq
c\$]{.math .inline} ]{.math display="inline"
role="math"}[[\$\\Leftrightarrow \\exists c &gt; 0 \\forall x \\in M
\|x\| \\leq c\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$\\Leftrightarrow \\exists c \> 0 \\forall x \\in M \|x\|
\\leq c\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

### Satz 1.8. {dir="ltr"}

Sei [[$B \subset A \subset \mathbb{R},B \neq \varnothing$ ]{.math
display="inline"
role="math"}[$\mathsf{B \subset A \subset \mathbb{R},B \neq \varnothing}$
]{.mathImpaired display="inline" role="math"}[\$B \\subset A \\subset
\\mathbb{R}, B \\neq \\emptyset\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, dann gilt:

1.  <div>

    Ist [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> beschränkt, so gilt
    [[$\inf A \leq \sup A$ ]{.math display="inline"
    role="math"}[$\mathsf{\inf A \leq \sup A}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\inf A \\leq \\sup
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

    </div>

2.  <div>

    Ist [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nach oben beschränkt,
    so ist auch [[$B$ ]{.math display="inline" role="math"}[$\mathsf{B}$
    ]{.mathImpaired display="inline" role="math"}[\$B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nach oben beschränkt,
    und [[$\sup B \leq \sup A$ ]{.math display="inline"
    role="math"}[$\mathsf{\sup B \leq \sup A}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\sup B \\leq \\sup
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    Ist [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nach unten
    beschränkt, so ist auch [[$B$ ]{.math display="inline"
    role="math"}[$\mathsf{B}$ ]{.mathImpaired display="inline"
    role="math"}[\$B\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nach unten
    beschränkt, und [[$\inf B \geq \inf A$ ]{.math display="inline"
    role="math"}[$\mathsf{\inf B \geq \inf A}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\inf B \\geq \\inf
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

    </div>

3.  <div>

    Ist [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nach oben beschränkt
    und [[$\gamma$ ]{.math display="inline"
    role="math"}[$\mathsf{\gamma}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\gamma\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> eine obere Schranke
    von [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, so gilt:\
    [[[\$\\gamma = \\sup A \\Leftrightarrow \\forall \\epsilon &gt; 0
    \\exists x \\in A x &gt; \\gamma - \\epsilon\$]{.math .inline}
    ]{.math display="inline" role="math"}[[\$\\gamma = \\sup A
    \\Leftrightarrow \\forall \\epsilon &gt; 0 \\exists x \\in A x &gt;
    \\gamma - \\epsilon\$]{.math .inline} ]{.mathImpaired
    display="inline" role="math"}[\$\\gamma = \\sup A \\Leftrightarrow
    \\forall \\epsilon \> 0 \\exists x \\in A x \> \\gamma -
    \\epsilon\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    Ist [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nach unten beschränkt
    und [[$\gamma$ ]{.math display="inline"
    role="math"}[$\mathsf{\gamma}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\gamma\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> eine untere Schranke
    von [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, so gilt:\
    [[[\$\\gamma = \\inf A \\Leftrightarrow \\forall \\epsilon &gt; 0
    \\exists x \\in A x &lt; \\gamma + \\epsilon\$]{.math .inline}
    ]{.math display="inline" role="math"}[[\$\\gamma = \\inf A
    \\Leftrightarrow \\forall \\epsilon &gt; 0 \\exists x \\in A x &lt;
    \\gamma + \\epsilon\$]{.math .inline} ]{.mathImpaired
    display="inline" role="math"}[\$\\gamma = \\inf A \\Leftrightarrow
    \\forall \\epsilon \> 0 \\exists x \\in A x \< \\gamma +
    \\epsilon\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

    </div>

**Beweis:**\

1.  Wähle [[$x \in A$ ]{.math display="inline"
    role="math"}[$\mathsf{x \in A}$ ]{.mathImpaired display="inline"
    role="math"}[\$x \\in A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. Da [[$\sup A$
    ]{.math display="inline" role="math"}[$\mathsf{\sup A}$
    ]{.mathImpaired display="inline" role="math"}[\$\\sup
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> obere Schranke von
    [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, gilt:
    [[$x \leq \sup A$ ]{.math display="inline"
    role="math"}[$\mathsf{x \leq \sup A}$ ]{.mathImpaired
    display="inline" role="math"}[\$x \\leq \\sup A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    Da [[$\inf A$ ]{.math display="inline"
    role="math"}[$\mathsf{\inf A}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\inf A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> untere Schranke von
    [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, gilt:
    [[$x \geq \inf A$ ]{.math display="inline"
    role="math"}[$\mathsf{x \geq \inf A}$ ]{.mathImpaired
    display="inline" role="math"}[\$x \\geq \\inf A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$\left. \Rightarrow\inf A \leq \sup A \right.$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\left. \Rightarrow\inf A \leq \sup A \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow \\inf A
    \\leq \\sup A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
2.  (obere Zeile):  [[$\sup A$ ]{.math display="inline"
    role="math"}[$\mathsf{\sup A}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\sup A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist obere Schranke
    von [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, also (wegen
    [[$B \subset A$ ]{.math display="inline"
    role="math"}[$\mathsf{B \subset A}$ ]{.mathImpaired display="inline"
    role="math"}[\$B \\subset A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->) auch von [[$B$
    ]{.math display="inline" role="math"}[$\mathsf{B}$ ]{.mathImpaired
    display="inline" role="math"}[\$B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. Da [[$\sup B$
    ]{.math display="inline" role="math"}[$\mathsf{\sup B}$
    ]{.mathImpaired display="inline" role="math"}[\$\\sup
    B\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> *kleinste* obere
    Schranke von [[$B$ ]{.math display="inline"
    role="math"}[$\mathsf{B}$ ]{.mathImpaired display="inline"
    role="math"}[\$B\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, folgt
    [[$\sup B \leq \sup A$ ]{.math display="inline"
    role="math"}[$\mathsf{\sup B \leq \sup A}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\sup B \\leq \\sup
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.
3.  (obere Zeile):\
    \"[[$\Rightarrow$ ]{.math display="inline"
    role="math"}[$\mathsf{\Rightarrow}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\Rightarrow\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\": Sei
    [[$\gamma = \sup A$ ]{.math display="inline"
    role="math"}[$\mathsf{\gamma = \sup A}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\gamma = \\sup A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, und sei
    [[[\$\\epsilon &gt;0\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$\\epsilon &gt;0\$]{.math .inline} ]{.mathImpaired
    display="inline" role="math"}[\$\\epsilon \>0\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. Da [[[\$\\gamma -
    \\epsilon &lt; \\gamma\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$\\gamma - \\epsilon &lt; \\gamma\$]{.math .inline}
    ]{.mathImpaired display="inline" role="math"}[\$\\gamma - \\epsilon
    \< \\gamma\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, ist
    [[$\gamma - \epsilon$ ]{.math display="inline"
    role="math"}[$\mathsf{\gamma - \epsilon}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\gamma - \\epsilon\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> keine obere Schranke
    von [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. Also existiert ein
    [[$x \in A$ ]{.math display="inline" role="math"}[$\mathsf{x \in A}$
    ]{.mathImpaired display="inline" role="math"}[\$x \\in
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> mit [[[\$x &gt;
    \\gamma - \\epsilon\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$x &gt; \\gamma - \\epsilon\$]{.math .inline}
    ]{.mathImpaired display="inline" role="math"}[\$x \> \\gamma -
    \\epsilon\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    \"[[$\Leftarrow$ ]{.math display="inline"
    role="math"}[$\mathsf{\Leftarrow}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\Leftarrow\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\": Es gelte
    [[[\$\\forall \\epsilon &gt; 0 \\exists x \\in A x &gt; \\gamma -
    \\epsilon\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$\\forall \\epsilon &gt; 0 \\exists x \\in A x &gt;
    \\gamma - \\epsilon\$]{.math .inline} ]{.mathImpaired
    display="inline" role="math"}[\$\\forall \\epsilon \> 0 \\exists x
    \\in A x \> \\gamma - \\epsilon\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. Wäre [[$\gamma$
    ]{.math display="inline" role="math"}[$\mathsf{\gamma}$
    ]{.mathImpaired display="inline"
    role="math"}[\$\\gamma\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nicht das Supremum
    von [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, so existiert eine
    kleinere obere Schranke [[$\widetilde{\gamma}$ ]{.math
    display="inline" role="math"}[$\mathsf{\widetilde{\gamma}}$
    ]{.mathImpaired display="inline"
    role="math"}[\$\\tilde{\\gamma}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> von [[$A$ ]{.math
    display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
    display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. (also
    [[[\$\\tilde{\\gamma} &lt; \\gamma\$]{.math .inline} ]{.math
    display="inline" role="math"}[[\$\\tilde{\\gamma} &lt;
    \\gamma\$]{.math .inline} ]{.mathImpaired display="inline"
    role="math"}[\$\\tilde{\\gamma} \< \\gamma\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->).\
    Setze [[[\$\\epsilon := \\gamma - \\tilde{\\gamma} &gt;0\$]{.math
    .inline} ]{.math display="inline" role="math"}[[\$\\epsilon :=
    \\gamma - \\tilde{\\gamma} &gt;0\$]{.math .inline} ]{.mathImpaired
    display="inline" role="math"}[\$\\epsilon := \\gamma -
    \\tilde{\\gamma} \>0\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. Nach Voraussetzung
    existiert ein [[$x \in A$ ]{.math display="inline"
    role="math"}[$\mathsf{x \in A}$ ]{.mathImpaired display="inline"
    role="math"}[\$x \\in A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> mit [[[\$x &gt;
    \\gamma - \\epsilon = \\gamma - (\\gamma - \\tilde{\\gamma} ) =
    \\tilde{\\gamma}\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$x &gt; \\gamma - \\epsilon = \\gamma - (\\gamma -
    \\tilde{\\gamma} ) = \\tilde{\\gamma}\$]{.math .inline}
    ]{.mathImpaired display="inline" role="math"}[\$x \> \\gamma -
    \\epsilon = \\gamma - (\\gamma - \\tilde{\\gamma} ) =
    \\tilde{\\gamma}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$\left. \Rightarrow\widetilde{\gamma} \right.$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\left. \Rightarrow\widetilde{\gamma} \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow
    \\tilde{\\gamma}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist keine obere
    Schranke von [[$A$ ]{.math display="inline"
    role="math"}[$\mathsf{A}$ ]{.mathImpaired display="inline"
    role="math"}[\$A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. [[$\Rightarrow$
    ]{.math display="inline" role="math"}[$\mathsf{\Rightarrow}$
    ]{.mathImpaired display="inline"
    role="math"}[\$\\Rightarrow\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> Widerspruch.
    ([[[\$\\Lightning\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$\\Lightning\$]{.math .inline} ]{.mathImpaired
    display="inline" role="math"}[\$\\Lightning\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->)\
    [[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\square\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

((Seite11))

1.3. Natürliche Zahlen
----------------------

### Definition 1.9.

[[$A \subset \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{A \subset \mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$A \\subset \\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißt *Induktionsmenge*
(IM), wenn gilt:

1.  [[$1 \in A$ ]{.math display="inline" role="math"}[$\mathsf{1 \in A}$
    ]{.mathImpaired display="inline" role="math"}[\$1 \\in
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
2.  [[$\forall x \in Ax + 1 \in A$ ]{.math display="inline"
    role="math"}[$\mathsf{\forall x \in Ax + 1 \in A}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\forall x \\in A x+1 \\in
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

### Beispiel 1.10.

[[$\mathbb{R},\lbrack!,\infty),\{ 1\} \cup \lbrack 2,\infty)$ ]{.math
display="inline"
role="math"}[$\mathsf{\mathbb{R},\lbrack!,\infty),\{ 1\} \cup \lbrack 2,\infty)}$
]{.mathImpaired display="inline" role="math"}[\$\\mathbb{R}, \[!,
\\infty ), \\{ 1 \\} \\cup \[2, \\infty )\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> sind Induktionsmengen.\
[[$\{ 1\} \cup (2,\infty)$ ]{.math display="inline"
role="math"}[$\mathsf{\{ 1\} \cup (2,\infty)}$ ]{.mathImpaired
display="inline" role="math"}[\$\\{ 1 \\} \\cup (2, \\infty
)\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist keine
Induktionsmenge.

### Definition 1.11.

Die Menge [[$\mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired display="inline"
role="math"}[\$\\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

[[$:=\{ x \in \mathbb{R}:x \in A{\mspace{6mu}\text{für\ jede\ Induktionsmenge}\mspace{6mu}}A\}$
]{.math display="inline"
role="math"}[$\mathsf{:=\{ x \in \mathbb{R}:x \in A{\mspace{6mu}\text{für\ jede\ Induktionsmenge}\mspace{6mu}}A\}}$
]{.mathImpaired display="inline" role="math"}[\$:= \\{ x \\in 
\\mathbb{R} : x \\in A \\text{ für jede Induktionsmenge } A
\\}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
[[$=$ ]{.math display="inline" role="math"}[$\mathsf{=}$ ]{.mathImpaired
display="inline" role="math"}[\$=\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> Durschnitt aller
Induktionsmengen\
[[$\bigcap\limits_{A{\mspace{6mu}\text{IM}}}A$ ]{.math display="inline"
role="math"}[$\mathsf{\bigcap\limits_{A{\mspace{6mu}\text{IM}}}A}$
]{.mathImpaired display="inline" role="math"}[\$\\bigcap\\limits\_{A
\\text{ IM}} A\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

heißt *Menge der natürlichen Zahlen*.

### Satz 1.12.

1.  Ist [[$A \subset \mathbb{R}$ ]{.math display="inline"
    role="math"}[$\mathsf{A \subset \mathbb{R}}$ ]{.mathImpaired
    display="inline" role="math"}[\$A \\subset
    \\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> eine Induktionsmenge,
    dann gilt [[$\mathbb{N} \subset A$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{N} \subset A}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\mathbb{N} \\subset
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
2.  [[$\mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist eine
    Induktionsmenge.
3.  [[$\mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist nicht nach oben
    beschränkt.
4.  [[[\$\\forall x \\in \\mathbb{R} \\exists n \\in  \\mathbb{N} n &gt;
    x\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$\\forall x \\in \\mathbb{R} \\exists n \\in 
    \\mathbb{N} n &gt; x\$]{.math .inline} ]{.mathImpaired
    display="inline" role="math"}[\$\\forall x \\in \\mathbb{R} \\exists
    n \\in  \\mathbb{N} n \> x\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

**Beweis:**

1.  Klar nach Definition von [[$N$ ]{.math display="inline"
    role="math"}[$\mathsf{N}$ ]{.mathImpaired display="inline"
    role="math"}[\$N\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.
2.  Da [[$1 \in A$ ]{.math display="inline"
    role="math"}[$\mathsf{1 \in A}$ ]{.mathImpaired display="inline"
    role="math"}[\$1 \\in A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> für jede
    Induktionsmenge [[$A \subset \mathbb{R}$ ]{.math display="inline"
    role="math"}[$\mathsf{A \subset \mathbb{R}}$ ]{.mathImpaired
    display="inline" role="math"}[\$A \\subset 
    \\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, gilt auch
    [[$1 \in \bigcap\limits_{A{\mspace{6mu}\text{IM}}}A = \mathbb{N}$
    ]{.math display="inline"
    role="math"}[$\mathsf{1 \in \bigcap\limits_{A{\mspace{6mu}\text{IM}}}A = \mathbb{N}}$
    ]{.mathImpaired display="inline" role="math"}[\$1 \\in
    \\bigcap\\limits\_{A \\text{ IM}} A = \\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.\
    Sei
    [[$x \in \mathbb{N} = \bigcap\limits_{A{\mspace{6mu}\text{IM}}}A$
    ]{.math display="inline"
    role="math"}[$\mathsf{x \in \mathbb{N} = \bigcap\limits_{A{\mspace{6mu}\text{IM}}}A}$
    ]{.mathImpaired display="inline" role="math"}[\$x \\in \\mathbb{N} =
    \\bigcap\\limits\_{A \\text{ IM}} A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. Also [[$x \in A$
    ]{.math display="inline" role="math"}[$\mathsf{x \in A}$
    ]{.mathImpaired display="inline" role="math"}[\$x \\in
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> für jede
    Induktionsmenge [[$A$ ]{.math display="inline"
    role="math"}[$\mathsf{A}$ ]{.mathImpaired display="inline"
    role="math"}[\$A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.\
    Da [[$x + 1 \in A$ ]{.math display="inline"
    role="math"}[$\mathsf{x + 1 \in A}$ ]{.mathImpaired display="inline"
    role="math"}[\$x+1 \\in A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> für jede
    Induktionsmenge [[$A$ ]{.math display="inline"
    role="math"}[$\mathsf{A}$ ]{.mathImpaired display="inline"
    role="math"}[\$A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, ist
    [[$x + 1 \in \bigcap\limits_{A{\mspace{6mu}\text{IM}}}A = \mathbb{N}$
    ]{.math display="inline"
    role="math"}[$\mathsf{x + 1 \in \bigcap\limits_{A{\mspace{6mu}\text{IM}}}A = \mathbb{N}}$
    ]{.mathImpaired display="inline" role="math"}[\$x+1 \\in
    \\bigcap\\limits\_{A \\text{ IM}} A = \\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$\left. \Rightarrow\mathbb{N} \right.$ ]{.math display="inline"
    role="math"}[$\mathsf{\left. \Rightarrow\mathbb{N} \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow
    \\mathbb{N}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist Induktionsmenge.
3.  *Annahme*: [[$\mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist nach oben
    beschränkt. Nach A15 existiert also ein [[$s:=\sup\mathbb{N}$
    ]{.math display="inline" role="math"}[$\mathsf{s:=\sup\mathbb{N}}$
    ]{.mathImpaired display="inline" role="math"}[\$s := \\sup
    \\mathbb{N}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.\
    [[$\left. \Rightarrow s - 1 \right.$ ]{.math display="inline"
    role="math"}[$\mathsf{\left. \Rightarrow s - 1 \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow
    s-1\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist keine obere
    Schranke von [[$\mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.\
    [[[\$\\Rightarrow \\exists x \\in \\mathbb{N} x &gt; s-1\$]{.math
    .inline} ]{.math display="inline" role="math"}[[\$\\Rightarrow
    \\exists x \\in \\mathbb{N} x &gt; s-1\$]{.math .inline}
    ]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow
    \\exists x \\in \\mathbb{N} x \> s-1\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->; da [[$\mathbb{N}$
    ]{.math display="inline" role="math"}[$\mathsf{\mathbb{N}}$
    ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> Induktionsmenge ist,
    gilt [[$x + 1 \in \mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{x + 1 \in \mathbb{N}}$ ]{.mathImpaired
    display="inline" role="math"}[\$x+1 \\in \\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, andererseits
    [[[\$x+1 &gt; s\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$x+1 &gt; s\$]{.math .inline} ]{.mathImpaired
    display="inline" role="math"}[\$x+1 \> s\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$\Rightarrow$ ]{.math display="inline"
    role="math"}[$\mathsf{\Rightarrow}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\Rightarrow\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> Widerspruch, da [[$s$
    ]{.math display="inline" role="math"}[$\mathsf{s}$ ]{.mathImpaired
    display="inline" role="math"}[\$s\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> obere Schranke von
    [[$\mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.
4.  folgt aus 3..

[[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
display="inline" role="math"}[\$\\square\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

((Seite12))

1.4. Prinzip der vollständigen Induktion
----------------------------------------

### Satz 1.13.

Ist [[$A \subset \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{A \subset \mathbb{N}}$ ]{.mathImpaired
display="inline" role="math"}[\$A \\subset \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[$A$ ]{.math
display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
display="inline" role="math"}[\$A\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> Induktionsmenge, so ist
[[$A = \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{A = \mathbb{N}}$ ]{.mathImpaired display="inline"
role="math"}[\$A = \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

Beweis:\
[[$\mathbb{N} \subset \widetilde{A}$ ]{.math display="inline"
role="math"}[$\mathsf{\mathbb{N} \subset \widetilde{A}}$ ]{.mathImpaired
display="inline" role="math"}[\$\\mathbb{N} \\subset
\\tilde{A}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> für jede Induktionsmenge
[[$\widetilde{A}$ ]{.math display="inline"
role="math"}[$\mathsf{\widetilde{A}}$ ]{.mathImpaired display="inline"
role="math"}[\$\\tilde{A}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, insbesondere
[[$\mathbb{N} \subset A$ ]{.math display="inline"
role="math"}[$\mathsf{\mathbb{N} \subset A}$ ]{.mathImpaired
display="inline" role="math"}[\$\\mathbb{N} \\subset A\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Außerdem ist
[[$A \subset \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{A \subset \mathbb{N}}$ ]{.mathImpaired
display="inline" role="math"}[\$A \\subset \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> nach Voraussetzung, also
[[$A = \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{A = \mathbb{N}}$ ]{.mathImpaired display="inline"
role="math"}[\$A= \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
[[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
display="inline" role="math"}[\$\\square\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

### 1.4.1 Beweisverfahren durch Induktion

Für jedes [[$n \in \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{n \in \mathbb{N}}$ ]{.mathImpaired
display="inline" role="math"}[\$n \\in \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> sei eine Aussage [[$A(n)$
]{.math display="inline" role="math"}[$\mathsf{A(n)}$ ]{.mathImpaired
display="inline" role="math"}[\$A(n)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> definiert. Es gelte:

1.  [[$A(1)$ ]{.math display="inline" role="math"}[$\mathsf{A(1)}$
    ]{.mathImpaired display="inline" role="math"}[\$A(1)\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist wahr.
2.  [[$\left. \forall n \in \mathbb{N}\lbrack A(n){\mspace{6mu}\text{wahr}\mspace{6mu}}\Rightarrow A(n + 1){\mspace{6mu}\text{wahr}}\rbrack \right.$
    ]{.math display="inline"
    role="math"}[$\mathsf{\left. \forall n \in \mathbb{N}\lbrack A(n){\mspace{6mu}\text{wahr}\mspace{6mu}}\Rightarrow A(n + 1){\mspace{6mu}\text{wahr}}\rbrack \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\forall n \\in
    \\mathbb{N} \[ A(n) \\text{ wahr } \\Rightarrow A(n+1) \\text{
    wahr}\]\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

Dann gilt: [[$\forall n \in \mathbb{N}A(n)$ ]{.math display="inline"
role="math"}[$\mathsf{\forall n \in \mathbb{N}A(n)}$ ]{.mathImpaired
display="inline" role="math"}[\$\\forall n \\in \\mathbb{N}
A(n)\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist wahr.

Denn: Setze
[[$A:=\{ n \in \mathbb{N}:A(n){\mspace{6mu}\text{ist\ wahr}}\}$ ]{.math
display="inline"
role="math"}[$\mathsf{A:=\{ n \in \mathbb{N}:A(n){\mspace{6mu}\text{ist\ wahr}}\}}$
]{.mathImpaired display="inline" role="math"}[\$A:= \\{ n \\in
\\mathbb{N} : A(n) \\text{ ist wahr} \\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
Nach 1. gilt: [[$1 \in A$ ]{.math display="inline"
role="math"}[$\mathsf{1 \in A}$ ]{.mathImpaired display="inline"
role="math"}[\$1 \\in A\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->; nach 2. gilt
[[$\forall n \in \mathbb{N}n + 1 \in A$ ]{.math display="inline"
role="math"}[$\mathsf{\forall n \in \mathbb{N}n + 1 \in A}$
]{.mathImpaired display="inline" role="math"}[\$\\forall n \\in
\\mathbb{N} n+1 \\in A\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
Also [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> Induktionsmenge; ferner
[[$A \subset \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{A \subset \mathbb{N}}$ ]{.mathImpaired
display="inline" role="math"}[\$A \\subset \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Also ist nach Prinzip
der vollständigen Induktion: [[$A = \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{A = \mathbb{N}}$ ]{.mathImpaired display="inline"
role="math"}[\$A= \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, d.h. [[$A(n)$ ]{.math
display="inline" role="math"}[$\mathsf{A(n)}$ ]{.mathImpaired
display="inline" role="math"}[\$A(n)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> wahr für alle
[[$n \in \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{n \in \mathbb{N}}$ ]{.mathImpaired
display="inline" role="math"}[\$n \\in \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

#### Beispiel 1.14.

\(1) *Behauptung:* [[$\forall n \in \mathbb{N}n \geq 1$ ]{.math
display="inline"
role="math"}[$\mathsf{\forall n \in \mathbb{N}n \geq 1}$ ]{.mathImpaired
display="inline" role="math"}[\$\\forall n \\in \\mathbb{N} n \\geq
1\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

> **Beweis**: induktiv\
> [[$A(n)$ ]{.math display="inline" role="math"}[$\mathsf{A(n)}$
> ]{.mathImpaired display="inline" role="math"}[\$A(n)\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> sei die Aussage
> \"[[$n \geq 1$ ]{.math display="inline"
> role="math"}[$\mathsf{n \geq 1}$ ]{.mathImpaired display="inline"
> role="math"}[\$n \\geq 1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\".\
> [[$A(1)$ ]{.math display="inline" role="math"}[$\mathsf{A(1)}$
> ]{.mathImpaired display="inline" role="math"}[\$A(1)\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> ist wahr, da
> [[$1 \geq 1$ ]{.math display="inline" role="math"}[$\mathsf{1 \geq 1}$
> ]{.mathImpaired display="inline" role="math"}[\$1 \\geq
> 1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->.\
> Sei [[$A(n)$ ]{.math display="inline" role="math"}[$\mathsf{A(n)}$
> ]{.mathImpaired display="inline" role="math"}[\$A(n)\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> wahr, also [[$n \geq 1$
> ]{.math display="inline" role="math"}[$\mathsf{n \geq 1}$
> ]{.mathImpaired display="inline" role="math"}[\$n \\geq
> 1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->. Dann
> [[$n + 1 \geq 1 + 1 \geq 1 + 0 = 1$ ]{.math display="inline"
> role="math"}[$\mathsf{n + 1 \geq 1 + 1 \geq 1 + 0 = 1}$
> ]{.mathImpaired display="inline" role="math"}[\$n+1 \\geq 1+1 \\geq
> 1+0 =1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> d.h. also \$\$A(n+1)
> ist auch wahr für alle [[$n \in \mathbb{N}$ ]{.math display="inline"
> role="math"}[$\mathsf{n \in \mathbb{N}}$ ]{.mathImpaired
> display="inline" role="math"}[\$n \\in \\mathbb{N}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, d.n.
> [[$\forall n \in \mathbb{N}n \geq 1$ ]{.math display="inline"
> role="math"}[$\mathsf{\forall n \in \mathbb{N}n \geq 1}$
> ]{.mathImpaired display="inline" role="math"}[\$\\forall n \\in
> \\mathbb{N} n \\geq 1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->.\
> [[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\square\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

\(2) Es sei [[$m \in \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{m \in \mathbb{N}}$ ]{.mathImpaired
display="inline" role="math"}[\$m \\in \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[$x \in \mathbb{R}$
]{.math display="inline" role="math"}[$\mathsf{x \in \mathbb{R}}$
]{.mathImpaired display="inline" role="math"}[\$x \\in
\\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> mit [[[\$m &lt; x &lt; x+
1\$]{.math .inline} ]{.math display="inline" role="math"}[[\$m &lt; x
&lt; x+ 1\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$m \< x \< x+ 1\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
*Behauptung*: [[$x \notin \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{x \notin \mathbb{N}}$ ]{.mathImpaired
display="inline" role="math"}[\$x \\notin \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

> **Beweis**:\
> [[$A:=(\mathbb{N} \cap \lbrack 1,m\rbrack) \cup \lbrack m + 1,\infty)$
> ]{.math display="inline"
> role="math"}[$\mathsf{A:=(\mathbb{N} \cap \lbrack 1,m\rbrack) \cup \lbrack m + 1,\infty)}$
> ]{.mathImpaired display="inline" role="math"}[\$A := ( \\mathbb{N}
> \\cap \[1,m\]) \\cup \[m+1, \\infty )\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> ist Induktionsmenge.
> (Bew. selbst)\
> [[$\left. \Rightarrow\mathbb{N} \subset A \right.$ ]{.math
> display="inline"
> role="math"}[$\mathsf{\left. \Rightarrow\mathbb{N} \subset A \right.}$
> ]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow
> \\mathbb{N} \\subset A\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> *Annahme*: [[$x \in \mathbb{N}$ ]{.math display="inline"
> role="math"}[$\mathsf{x \in \mathbb{N}}$ ]{.mathImpaired
> display="inline" role="math"}[\$x \\in \\mathbb{N}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, denn (wegen
> [[$\mathbb{N} \subset A$ ]{.math display="inline"
> role="math"}[$\mathsf{\mathbb{N} \subset A}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\mathbb{N} \\subset A\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->): [[$x \in A$ ]{.math
> display="inline" role="math"}[$\mathsf{x \in A}$ ]{.mathImpaired
> display="inline" role="math"}[\$x \\in A\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, d.h. insbesondere
> [[$x \leq m$ ]{.math display="inline" role="math"}[$\mathsf{x \leq m}$
> ]{.mathImpaired display="inline" role="math"}[\$x \\leq
> m\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> odere [[$x \geq m + 1$
> ]{.math display="inline" role="math"}[$\mathsf{x \geq m + 1}$
> ]{.mathImpaired display="inline" role="math"}[\$x \\geq
> m+1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> [[$\Rightarrow$ ]{.math display="inline"
> role="math"}[$\mathsf{\Rightarrow}$ ]{.mathImpaired display="inline"
> role="math"}[\$\\Rightarrow\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> Widerspruch zur Annahme
> (echt kleiner etc.)\
> [[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\square\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

\(3) *Behauptung:* [[$1 + 2 + 3 + \ldots + n = \frac{n(n + 1)}{2}$
]{.math display="inline"
role="math"}[$\mathsf{1 + 2 + 3 + \ldots + n = \frac{n(n + 1)}{2}}$
]{.mathImpaired display="inline" role="math"}[\$1+2+3+ \\ldots +n =
\\frac{n(n+1)}{2}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

((Seite 13))

> **Beweis:**\
> (1) Stimmt für [[$n = 1$ ]{.math display="inline"
> role="math"}[$\mathsf{n = 1}$ ]{.mathImpaired display="inline"
> role="math"}[\$n=1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> da
> [[$1 = \frac{1(1 + 1)}{2}$ ]{.math display="inline"
> role="math"}[$\mathsf{1 = \frac{1(1 + 1)}{2}}$ ]{.mathImpaired
> display="inline" role="math"}[\$1= \\frac{1(1+1)}{2}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> (2) Gelte die Behauptung für ein beliebiges [[$n \in \mathbb{N}$
> ]{.math display="inline" role="math"}[$\mathsf{n \in \mathbb{N}}$
> ]{.mathImpaired display="inline" role="math"}[\$n \\in
> \\mathbb{N}\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->. Dann\
> [[$1 + 2 + 3 + \ldots + n + (n + 1) = \frac{n(n + 1)}{2} + (n + 1)$
> ]{.math display="inline"
> role="math"}[$\mathsf{1 + 2 + 3 + \ldots + n + (n + 1) = \frac{n(n + 1)}{2} + (n + 1)}$
> ]{.mathImpaired display="inline" role="math"}[\$1+2+3+ \\ldots
> +n+(n+1) = \\frac{n(n+1)}{2} + (n+1)\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> \$\$= (n+1)( \\frac{n}{2} +1) = \\frac{(n+1)(n+2)}{2}\
> [[$\Rightarrow$ ]{.math display="inline"
> role="math"}[$\mathsf{\Rightarrow}$ ]{.mathImpaired display="inline"
> role="math"}[\$\\Rightarrow\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> Behauptung gilt für
> [[$n + 1$ ]{.math display="inline" role="math"}[$\mathsf{n + 1}$
> ]{.mathImpaired display="inline" role="math"}[\$n+1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> [[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\square\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

#### Definition 1.15. {style="margin-right: 0px;" dir="ltr"}

[[$\mathbb{N}_{0}:=\mathbb{N} \cup \{ 0\}$ ]{.math display="inline"
role="math"}[$\mathsf{\mathbb{N}_{0}:=\mathbb{N} \cup \{ 0\}}$
]{.mathImpaired display="inline" role="math"}[\$\\mathbb{N}\_0 :=
\\mathbb{N} \\cup \\{ 0 \\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

[[$\mathbb{Z}:=\mathbb{N} \cup \{ - n:n \in \mathbb{N}\}$ ]{.math
display="inline"
role="math"}[$\mathsf{\mathbb{Z}:=\mathbb{N} \cup \{ - n:n \in \mathbb{N}\}}$
]{.mathImpaired display="inline" role="math"}[\$\\mathbb{Z} :=
\\mathbb{N} \\cup \\{ -n: n \\in \\mathbb{N} \\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ganze Zahlen

[[$\mathbb{Q}:=\left\{ \frac{p}{q}:p \in \mathbb{Z},q \in \mathbb{N} \right\}$
]{.math display="inline"
role="math"}[$\mathsf{\mathbb{Q}:=\left\{ \frac{p}{q}:p \in \mathbb{Z},q \in \mathbb{N} \right\}}$
]{.mathImpaired display="inline" role="math"}[\$\\mathbb{Q} := \\left\\{
\\frac{p}{q} : p \\in \\mathbb{Z}, q \\in \\mathbb{N}
\\right\\}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> rationale Zahlen

#### Satz 1.16. {style="margin-right: 0px;" dir="ltr"}

Sind [[$x,y \in \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{x,y \in \mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$x ,y \\in \\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[[\$x &lt;
y\$]{.math .inline} ]{.math display="inline" role="math"}[[\$x &lt;
y\$]{.math .inline} ]{.mathImpaired display="inline" role="math"}[\$x \<
y\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, so existiert ein
[[$r \in \mathbb{Q}$ ]{.math display="inline"
role="math"}[$\mathsf{r \in \mathbb{Q}}$ ]{.mathImpaired
display="inline" role="math"}[\$r \\in\\mathbb{Q}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> mit [[[\$x &lt; r &lt;
y\$]{.math .inline} ]{.math display="inline" role="math"}[[\$x &lt; r
&lt; y\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$x \< r \< y\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

**Beweis:**\
Wähle [[[\$q \\in \\mathbb{N}, q &gt; \\frac{1}{y-x}\$]{.math .inline}
]{.math display="inline" role="math"}[[\$q \\in \\mathbb{N}, q &gt;
\\frac{1}{y-x}\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$q \\in \\mathbb{N}, q \> \\frac{1}{y-x}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, dann [[[\$qy-qx &gt;
1\$]{.math .inline} ]{.math display="inline" role="math"}[[\$qy-qx &gt;
1\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$qy-qx \> 1\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Dann existiert (Beweis
später) ein [[$p \in \mathbb{Z}$ ]{.math display="inline"
role="math"}[$\mathsf{p \in \mathbb{Z}}$ ]{.mathImpaired
display="inline" role="math"}[\$p \\in \\mathbb{Z}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> mit [[[\$qx &lt; p &lt;
qy\$]{.math .inline} ]{.math display="inline" role="math"}[[\$qx &lt; p
&lt; qy\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$qx \< p \< qy\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, d.h. [[[\$x &lt;
\\frac{p}{q} &lt; y\$]{.math .inline} ]{.math display="inline"
role="math"}[[\$x &lt; \\frac{p}{q} &lt; y\$]{.math .inline}
]{.mathImpaired display="inline" role="math"}[\$x \< \\frac{p}{q} \<
y\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

*Nachweis der Existenz eines solchen [[$p$ ]{.math display="inline"
role="math"}[$\mathsf{p}$ ]{.mathImpaired display="inline"
role="math"}[\$p\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->:\
*Setze [[$M:=\mathbb{Z} \cap ( - \infty,qx\rbrack$ ]{.math
display="inline"
role="math"}[$\mathsf{M:=\mathbb{Z} \cap ( - \infty,qx\rbrack}$
]{.mathImpaired display="inline" role="math"}[\$M := \\mathbb{Z} \\cap
(- \\infty , qx\]\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> nach oben beschränkt.\
[[$s:=\sup M$ ]{.math display="inline" role="math"}[$\mathsf{s:=\sup M}$
]{.mathImpaired display="inline" role="math"}[\$s:= \\sup
M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
Wähle [[$n \in M$ ]{.math display="inline"
role="math"}[$\mathsf{n \in M}$ ]{.mathImpaired display="inline"
role="math"}[\$n\\in M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> mit [[[\$n &gt; s-
1\$]{.math .inline} ]{.math display="inline" role="math"}[[\$n &gt; s-
1\$]{.math .inline} ]{.mathImpaired display="inline" role="math"}[\$n \>
s- 1\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Setze
[[$p:=n + 1 \in \mathbb{Z}$ ]{.math display="inline"
role="math"}[$\mathsf{p:=n + 1 \in \mathbb{Z}}$ ]{.mathImpaired
display="inline" role="math"}[\$p :=n+1 \\in \\mathbb{Z}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->; ferner [[[\$p &gt;
s\$]{.math .inline} ]{.math display="inline" role="math"}[[\$p &gt;
s\$]{.math .inline} ]{.mathImpaired display="inline" role="math"}[\$p \>
s\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
[[$\left. \Rightarrow p \notin M \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. \Rightarrow p \notin M \right.}$
]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow p \\notin
M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->; wegen
[[$p \in \mathbb{Z}$ ]{.math display="inline"
role="math"}[$\mathsf{p \in \mathbb{Z}}$ ]{.mathImpaired
display="inline" role="math"}[\$p \\in \\mathbb{Z}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> also
[[$p \notin ( - \infty,qx\rbrack$ ]{.math display="inline"
role="math"}[$\mathsf{p \notin ( - \infty,qx\rbrack}$ ]{.mathImpaired
display="inline" role="math"}[\$p \\notin (- \\infty
,qx\]\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, d.h.
[[[\$p&gt;qx\$]{.math .inline} ]{.math display="inline"
role="math"}[[\$p&gt;qx\$]{.math .inline} ]{.mathImpaired
display="inline" role="math"}[\$p\>qx\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
Ferner [[[\$p =n+1 \\leq qx+1 &lt; q y\$]{.math .inline} ]{.math
display="inline" role="math"}[[\$p =n+1 \\leq qx+1 &lt; q y\$]{.math
.inline} ]{.mathImpaired display="inline" role="math"}[\$p =n+1 \\leq
qx+1 \< q y\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
[[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
display="inline" role="math"}[\$\\square\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

1.5. Einige Formeln (Notationen) {style="margin-right: 0px;" dir="ltr"}
--------------------------------

\(1) Für [[$a \in \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{a \in \mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$a \\in \\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[[\$n \\in
\\mathbb{N} : a\^n := a \\cdot a \\dotsm a\$]{.math .inline} ]{.math
display="inline" role="math"}[[\$n \\in \\mathbb{N} : a\^n := a \\cdot a
\\dotsm a\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$n \\in \\mathbb{N} : a\^n := a \\cdot a \\dotsm
a\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (*n* mal)

> Präzise mit vollständiger Induktion:\
> Definiere [[$a^{1}:=a$ ]{.math display="inline"
> role="math"}[$\mathsf{a^{1}:=a}$ ]{.mathImpaired display="inline"
> role="math"}[\$a\^1 := a\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> Sei [[$a^{n}$ ]{.math display="inline" role="math"}[$\mathsf{a^{n}}$
> ]{.mathImpaired display="inline" role="math"}[\$a\^n\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> für ein
> [[$n \in \mathbb{N}$ ]{.math display="inline"
> role="math"}[$\mathsf{n \in \mathbb{N}}$ ]{.mathImpaired
> display="inline" role="math"}[\$n \\in \\mathbb{N}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> bereits definiert.\
> Dann [[$a^{n + 1}:=a^{n} \cdot a$ ]{.math display="inline"
> role="math"}[$\mathsf{a^{n + 1}:=a^{n} \cdot a}$ ]{.mathImpaired
> display="inline" role="math"}[\$a\^{n+1} := a\^n \\cdot
> a\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> Daraus: übliche Rechenregeln für Potenzen.
>
> Falls [[$a \neq 0,n \in \mathbb{N}:a^{- n}:=\frac{1}{a^{n}}$ ]{.math
> display="inline"
> role="math"}[$\mathsf{a \neq 0,n \in \mathbb{N}:a^{- n}:=\frac{1}{a^{n}}}$
> ]{.mathImpaired display="inline" role="math"}[\$a \\neq 0, n \\in
> \\mathbb{N} : a\^{-n} := \\frac{1}{a\^n}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> Für alle [[$a \in \mathbb{R}:a^{0}:=1$ ]{.math display="inline"
> role="math"}[$\mathsf{a \in \mathbb{R}:a^{0}:=1}$ ]{.mathImpaired
> display="inline" role="math"}[\$a \\in \\mathbb{R} : a\^0 :=
> 1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> Damit: [[$a^{n}$ ]{.math display="inline"
> role="math"}[$\mathsf{a^{n}}$ ]{.mathImpaired display="inline"
> role="math"}[\$a\^n\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> (für [[$a \neq 0$
> ]{.math display="inline" role="math"}[$\mathsf{a \neq 0}$
> ]{.mathImpaired display="inline" role="math"}[\$a \\neq
> 0\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->) für alle
> [[$n \in \mathbb{Z}$ ]{.math display="inline"
> role="math"}[$\mathsf{n \in \mathbb{Z}}$ ]{.mathImpaired
> display="inline" role="math"}[\$n \\in \\mathbb{Z}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> definiert.

\(2) Für [[[\$n \\in \\mathbb{N} : n! := 1 \\cdot 2 \\cdot 3 \\dotsm
n\$]{.math .inline} ]{.math display="inline" role="math"}[[\$n \\in
\\mathbb{N} : n! := 1 \\cdot 2 \\cdot 3 \\dotsm n\$]{.math .inline}
]{.mathImpaired display="inline" role="math"}[\$n \\in \\mathbb{N} : n!
:= 1 \\cdot 2 \\cdot 3 \\dotsm n\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

> Präzise: [[$0!:=1$ ]{.math display="inline"
> role="math"}[$\mathsf{0!:=1}$ ]{.mathImpaired display="inline"
> role="math"}[\$0! := 1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->; falls [[$n!$ ]{.math
> display="inline" role="math"}[$\mathsf{n!}$ ]{.mathImpaired
> display="inline" role="math"}[\$n!\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> bereits definiert für
> ein [[$n \in \mathbb{N}_{0}:(n + 1)!:=n! \cdot (n + 1)$ ]{.math
> display="inline"
> role="math"}[$\mathsf{n \in \mathbb{N}_{0}:(n + 1)!:=n! \cdot (n + 1)}$
> ]{.mathImpaired display="inline" role="math"}[\$n \\in \\mathbb{N}\_0:
> (n+1)! := n! \\cdot (n+1)\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> Damit ist [[$n!$ ]{.math display="inline" role="math"}[$\mathsf{n!}$
> ]{.mathImpaired display="inline" role="math"}[\$n!\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> definiert für alle
> [[$n \in \mathbb{N}_{0}$ ]{.math display="inline"
> role="math"}[$\mathsf{n \in \mathbb{N}_{0}}$ ]{.mathImpaired
> display="inline" role="math"}[\$n \\in \\mathbb{N}\_0\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->.

((Seite 14))

\(3) Für [[$n \in \mathbb{N}_{0},k \in \mathbb{N}_{0},k \leq n$ ]{.math
display="inline"
role="math"}[$\mathsf{n \in \mathbb{N}_{0},k \in \mathbb{N}_{0},k \leq n}$
]{.mathImpaired display="inline" role="math"}[\$n \\in \\mathbb{N}\_0
, k \\in \\mathbb{N}\_0, k \\leq n\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->:

> [[$\left( \frac{n}{k} \right):=\frac{n!}{k!(n - k)!}$ ]{.math
> display="inline"
> role="math"}[$\mathsf{\left( \frac{n}{k} \right):=\frac{n!}{k!(n - k)!}}$
> ]{.mathImpaired display="inline" role="math"}[\$\\binom{n}{k} :=
> \\frac{n!}{k!(n-k)!}\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
> (Binomialkoeffizienten)\
> Es gilt:
> [[$\left( \frac{n}{0} \right) = 1;\left( \frac{n}{n} \right) = 1$
> ]{.math display="inline"
> role="math"}[$\mathsf{\left( \frac{n}{0} \right) = 1;\left( \frac{n}{n} \right) = 1}$
> ]{.mathImpaired display="inline" role="math"}[\$\\binom{n}{0}=1;
> \\binom{n}{n}=1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> Ferner:
> [[$\left( \frac{n}{k} \right) + \left( \frac{n}{k - 1} \right) = \left( \frac{n + 1}{k} \right),1 \leq k \leq n$
> ]{.math display="inline"
> role="math"}[$\mathsf{\left( \frac{n}{k} \right) + \left( \frac{n}{k - 1} \right) = \left( \frac{n + 1}{k} \right),1 \leq k \leq n}$
> ]{.mathImpaired display="inline" role="math"}[\$\\binom{n}{k} +
> \\binom{n}{k-1} = \\binom{n+1}{k}, 1 \\leq k \\leq n\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

\(4) *Berouillische Ungleichung:*

> Für [[$x \in \mathbb{R},x \geq - 1$ ]{.math display="inline"
> role="math"}[$\mathsf{x \in \mathbb{R},x \geq - 1}$ ]{.mathImpaired
> display="inline" role="math"}[\$x \\in \\mathbb{R} , x \\geq -
> 1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> und
> [[$n \in \mathbb{N}$ ]{.math display="inline"
> role="math"}[$\mathsf{n \in \mathbb{N}}$ ]{.mathImpaired
> display="inline" role="math"}[\$n \\in \\mathbb{N}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> gilt:
>
> \
>
> ![1+x hoch n größer gleich 1+n mal
> x](Images/Bernouillische%20Ungleichung.svg "Bernouillische Ungleichung"){.toRemove}
>
> \
>
> **Beweis:**\
> [[$n = 1:(1 + x)^{1} = 1 + x = 1 + 1x$ ]{.math display="inline"
> role="math"}[$\mathsf{n = 1:(1 + x)^{1} = 1 + x = 1 + 1x}$
> ]{.mathImpaired display="inline" role="math"}[\$n=1: (1+x)\^1 = 1+x =
> 1+1x\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> Gelte die Behauptung für ein [[$n \in \mathbb{N}$ ]{.math
> display="inline" role="math"}[$\mathsf{n \in \mathbb{N}}$
> ]{.mathImpaired display="inline" role="math"}[\$n \\in
> \\mathbb{N}\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->;\
> [[$(1 + x)^{n + 1} = (1 + x)^{n} \cdot (1 + x) \geq (1 + nx)(1 + x) = 1 + (n + 1)x + nx^{2} \geq 1 + (n + 1)x$
> ]{.math display="inline"
> role="math"}[$\mathsf{(1 + x)^{n + 1} = (1 + x)^{n} \cdot (1 + x) \geq (1 + nx)(1 + x) = 1 + (n + 1)x + nx^{2} \geq 1 + (n + 1)x}$
> ]{.mathImpaired display="inline" role="math"}[\$(1+x)\^{n+1} =
> (1+x)\^n \\cdot (1+x) \\geq (1+nx)(1+x) = 1+ (n+1)x +nx\^2 \\geq
> 1+(n+1)x\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> [[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\square\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

\(5) Summenzeichen, Produktzeichen:

> Will definieren:
>
> [[$\sum\limits_{k = 1}^{n}a_{k}:=a_{1} + a_{2} + \ldots + a_{n}$
> ]{.math display="inline"
> role="math"}[$\mathsf{\sum\limits_{k = 1}^{n}a_{k}:=a_{1} + a_{2} + \ldots + a_{n}}$
> ]{.mathImpaired display="inline"
> role="math"}[\$\\sum\\limits\_{k=1}\^n a\_k := a\_1+a\_2+ \\ldots +
> a\_n\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> [[[\$\\prod\_{k=1}\^n a\_k := a\_1 \\cdot a\_2 \\dotsm a\_n\$]{.math
> .inline} ]{.math display="inline" role="math"}[[\$\\prod\_{k=1}\^n
> a\_k := a\_1 \\cdot a\_2 \\dotsm a\_n\$]{.math .inline}
> ]{.mathImpaired display="inline" role="math"}[\$\\prod\_{k=1}\^n a\_k
> := a\_1 \\cdot a\_2 \\dotsm a\_n\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> Präzise: setze [[$a_{1} \in \mathbb{R}$ ]{.math display="inline"
> role="math"}[$\mathsf{a_{1} \in \mathbb{R}}$ ]{.mathImpaired
> display="inline" role="math"}[\$a\_1 \\in \\mathbb{R}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, so setze
>
> [[$\sum_{k = 1}^{1}a_{k}:=a_{1}$ ]{.math display="inline"
> role="math"}[$\mathsf{\sum_{k = 1}^{1}a_{k}:=a_{1}}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\sum\_{k=1}\^1 a\_k :=
> a\_1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> [[$\prod\limits_{k = 1}^{1}a_{k}:=a_{1}$ ]{.math display="inline"
> role="math"}[$\mathsf{\prod\limits_{k = 1}^{1}a_{k}:=a_{1}}$
> ]{.mathImpaired display="inline"
> role="math"}[\$\\prod\\limits\_{k=1}\^1 a\_k := a\_1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> Sind für je [[$n$ ]{.math display="inline" role="math"}[$\mathsf{n}$
> ]{.mathImpaired display="inline" role="math"}[\$n\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> Zahlen
> [[$a_{1},\ldots,a_{n} \in \mathbb{R}$ ]{.math display="inline"
> role="math"}[$\mathsf{a_{1},\ldots,a_{n} \in \mathbb{R}}$
> ]{.mathImpaired display="inline" role="math"}[\$a\_1,\\ldots ,a\_n
> \\in \\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> bereits obige Ausdrücke
> definiert und sind [[$a_{1},\ldots a_{n + 1} \in \mathbb{R}$ ]{.math
> display="inline"
> role="math"}[$\mathsf{a_{1},\ldots a_{n + 1} \in \mathbb{R}}$
> ]{.mathImpaired display="inline" role="math"}[\$a\_1, \\ldots a\_{n+1}
> \\in \\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, so setze
>
> [[$\sum\limits_{k = 1}^{n + 1}a_{k}:=\left( \sum\limits_{k = 1}^{n} \right) + a_{n + 1}$
> ]{.math display="inline"
> role="math"}[$\mathsf{\sum\limits_{k = 1}^{n + 1}a_{k}:=\left( \sum\limits_{k = 1}^{n} \right) + a_{n + 1}}$
> ]{.mathImpaired display="inline"
> role="math"}[\$\\sum\\limits\_{k=1}\^{n+1} a\_k := \\left(
> \\sum\\limits\_{k=1}\^n \\right) + a\_{n+1}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> Produktzeichen analog.\
> Sind [[$p,q \in \mathbb{Z},p \leq q,a_{p},\ldots,a_{q} \in \mathbb{R}$
> ]{.math display="inline"
> role="math"}[$\mathsf{p,q \in \mathbb{Z},p \leq q,a_{p},\ldots,a_{q} \in \mathbb{R}}$
> ]{.mathImpaired display="inline" role="math"}[\$p,q \\in \\mathbb{Z},
> p \\leq q, a\_p, \\ldots , a\_q \\in \\mathbb{R}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, so definiere
>
> [[$\sum\limits_{k = p}^{q}a_{k}:=\sum\limits_{k = 1}^{q - p + 1}a_{p - 1 + k}$
> ]{.math display="inline"
> role="math"}[$\mathsf{\sum\limits_{k = p}^{q}a_{k}:=\sum\limits_{k = 1}^{q - p + 1}a_{p - 1 + k}}$
> ]{.mathImpaired display="inline"
> role="math"}[\$\\sum\\limits\_{k=p}\^q a\_k :=
> \\sum\\limits\_{k=1}\^{q-p+1} a\_{p-1+k}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> [[$\prod\limits_{k = p}^{q}a_{k}:=\prod\limits_{k = 1}^{q - p + 1}a_{p - 1 + k}$
> ]{.math display="inline"
> role="math"}[$\mathsf{\prod\limits_{k = p}^{q}a_{k}:=\prod\limits_{k = 1}^{q - p + 1}a_{p - 1 + k}}$
> ]{.mathImpaired display="inline"
> role="math"}[\$\\prod\\limits\_{k=p}\^{q} a\_k :=
> \\prod\\limits\_{k=1}\^{q-p+1} a\_{p-1+k}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> Schließlich für [[[\$p &gt; q\$]{.math .inline} ]{.math
> display="inline" role="math"}[[\$p &gt; q\$]{.math .inline}
> ]{.mathImpaired display="inline" role="math"}[\$p \> q\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->:
>
> [[$\sum_{k = p}^{q}a_{k}:=0,\prod_{k = p}^{q}a_{k}:=1$ ]{.math
> display="inline"
> role="math"}[$\mathsf{\sum_{k = p}^{q}a_{k}:=0,\prod_{k = p}^{q}a_{k}:=1}$
> ]{.mathImpaired display="inline" role="math"}[\$\\sum\_{k=p}\^q a\_k
> := 0, \\prod\_{k=p}\^q a\_k := 1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

((Seite15))

\(6) *Binomischer Lehrsatz:*

> Es seien [[$a,b \in \mathbb{R},n \in \mathbb{N}_{0}$ ]{.math
> display="inline"
> role="math"}[$\mathsf{a,b \in \mathbb{R},n \in \mathbb{N}_{0}}$
> ]{.mathImpaired display="inline" role="math"}[\$a,b \\in \\mathbb{R},
> n \\in \\mathbb{N}\_0\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->. Dann gilt:
>
> [[$(a + b)^{n} = \sum_{k = 0}^{n}\left( \frac{n}{k} \right)a^{n - k}b^{k}$
> ]{.math display="inline"
> role="math"}[$\mathsf{(a + b)^{n} = \sum_{k = 0}^{n}\left( \frac{n}{k} \right)a^{n - k}b^{k}}$
> ]{.mathImpaired display="inline" role="math"}[\$(a+b)\^n =
> \\sum\_{k=0}\^n \\binom{n}{k} a\^{n-k} b\^k\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

\(7) Es seien [[$a,b \in \mathbb{R},n \in \mathbb{N}_{0}$ ]{.math
display="inline"
role="math"}[$\mathsf{a,b \in \mathbb{R},n \in \mathbb{N}_{0}}$
]{.mathImpaired display="inline" role="math"}[\$a,b \\in \\mathbb{R}, n
\\in \\mathbb{N}\_0\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Dann gilt:

> [[$a^{n + 1} - b^{n + 1} = (a - b)\sum\limits_{k = 0}^{n}a^{n - k}b^{k}$
> ]{.math display="inline"
> role="math"}[$\mathsf{a^{n + 1} - b^{n + 1} = (a - b)\sum\limits_{k = 0}^{n}a^{n - k}b^{k}}$
> ]{.mathImpaired display="inline" role="math"}[\$a\^{n+1} - b\^{n+1} =
> (a-b) \\sum\\limits\_{k=0}\^n a\^{n-k} b\^k\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

1.6. Wurzeln {style="margin-right: 0px;" dir="ltr"}
------------

Will nun [[$\sqrt[n]{}$ ]{.math display="inline"
role="math"}[$\mathsf{\sqrt[n]{}}$ ]{.mathImpaired display="inline"
role="math"}[\$\\sqrt\[n\]{ }\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> einführen.

### Lemma 1.17.

Für [[$x,y \in \mathbb{R},x,y \geq 0$ ]{.math display="inline"
role="math"}[$\mathsf{x,y \in \mathbb{R},x,y \geq 0}$ ]{.mathImpaired
display="inline" role="math"}[\$x ,y \\in \\mathbb{R} , x,y \\geq
0\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[$n \in \mathbb{N}$
]{.math display="inline" role="math"}[$\mathsf{n \in \mathbb{N}}$
]{.mathImpaired display="inline" role="math"}[\$n \\in
\\mathbb{N}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> gilt:

[[$\left. x \leq y\Leftrightarrow x^{n} \leq y^{n} \right.$ ]{.math
display="inline"
role="math"}[$\mathsf{\left. x \leq y\Leftrightarrow x^{n} \leq y^{n} \right.}$
]{.mathImpaired display="inline" role="math"}[\$x \\leq y
\\Leftrightarrow x\^n \\leq y\^n\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

### Satz und Definition 1.18.

Es sei [[$a \geq 0$ ]{.math display="inline"
role="math"}[$\mathsf{a \geq 0}$ ]{.mathImpaired display="inline"
role="math"}[\$a \\geq 0\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[$n \in \mathbb{N}$
]{.math display="inline" role="math"}[$\mathsf{n \in \mathbb{N}}$
]{.mathImpaired display="inline" role="math"}[\$n \\in
\\mathbb{N}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

*Behauptung:* Es existiert genau ein [[$x \in \mathbb{R},x \geq 0$
]{.math display="inline"
role="math"}[$\mathsf{x \in \mathbb{R},x \geq 0}$ ]{.mathImpaired
display="inline" role="math"}[\$x \\in \\mathbb{R}, x \\geq
0\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> mit [[$x^{n} = a$ ]{.math
display="inline" role="math"}[$\mathsf{x^{n} = a}$ ]{.mathImpaired
display="inline" role="math"}[\$x\^n=a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Dieses [[$x$ ]{.math
display="inline" role="math"}[$\mathsf{x}$ ]{.mathImpaired
display="inline" role="math"}[\$x\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißt [[$n$ ]{.math
display="inline" role="math"}[$\mathsf{n}$ ]{.mathImpaired
display="inline" role="math"}[\$n\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->-te Wurzel aus
[[$a,x = :\sqrt[n]{a}$ ]{.math display="inline"
role="math"}[$\mathsf{a,x = :\sqrt[n]{a}}$ ]{.mathImpaired
display="inline" role="math"}[\$a, x=: \\sqrt\[n\]{a}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
Speziell für [[$n = 2:\sqrt{a}:=\sqrt[2]{a}$ ]{.math display="inline"
role="math"}[$\mathsf{n = 2:\sqrt{a}:=\sqrt[2]{a}}$ ]{.mathImpaired
display="inline" role="math"}[\$n=2: \\sqrt{a} :=
\\sqrt\[2\]{a}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

**Beweis:** Eindeutigkeit nach obigem Lemma. Die Existenz: mit
Zwischenwertsatz für stetige Funktionen [\\\\7.11](file://\\7.11).

### Bemerkung 1.19.

-   [[$\sqrt{2} \notin \mathbb{Q}$ ]{.math display="inline"
    role="math"}[$\mathsf{\sqrt{2} \notin \mathbb{Q}}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\sqrt{2} \\notin
    \\mathbb{Q}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

**Beweis:** *Annahme:* [[$\sqrt{2} \in \mathbb{Q}$ ]{.math
display="inline" role="math"}[$\mathsf{\sqrt{2} \in \mathbb{Q}}$
]{.mathImpaired display="inline" role="math"}[\$\\sqrt{2} \\in
\\mathbb{Q}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, d.h. es gibt
[[$p,q \in \mathbb{N},p,q$ ]{.math display="inline"
role="math"}[$\mathsf{p,q \in \mathbb{N},p,q}$ ]{.mathImpaired
display="inline" role="math"}[\$p,q \\in \\mathbb{N},
p,q\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> teilerfremd, mit
[[$\sqrt{2} = \frac{p}{q}$ ]{.math display="inline"
role="math"}[$\mathsf{\sqrt{2} = \frac{p}{q}}$ ]{.mathImpaired
display="inline" role="math"}[\$\\sqrt{2} = \\frac{p}{q}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->; dann
[[$2 = \frac{p^{2}}{q^{2}}$ ]{.math display="inline"
role="math"}[$\mathsf{2 = \frac{p^{2}}{q^{2}}}$ ]{.mathImpaired
display="inline" role="math"}[\$2= \\frac{p\^2}{q\^2}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, also

[[$p^{2} = 2q^{2}$ ]{.math display="inline"
role="math"}[$\mathsf{p^{2} = 2q^{2}}$ ]{.mathImpaired display="inline"
role="math"}[\$p\^2 = 2q\^2\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

[[$\left. \Rightarrow p^{2} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. \Rightarrow p^{2} \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$\\Rightarrow p\^2\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist durch 2 teilbar.\
[[$\left. \Rightarrow p \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. \Rightarrow p \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$\\Rightarrow p\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist durch 2 teilbar.\
[[$\left. \Rightarrow p^{2} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. \Rightarrow p^{2} \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$\\Rightarrow p\^2\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist durch 4 teilbar.\
[[$\left. \Rightarrow q^{2} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. \Rightarrow q^{2} \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$\\Rightarrow q\^2\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist durch 2 teilbar.\
[[$\left. \Rightarrow q \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. \Rightarrow q \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$\\Rightarrow q\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist durch 2 teilbar.\
[[$\left. \Rightarrow p,q \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. \Rightarrow p,q \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$\\Rightarrow p,q\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> beide durch 2 teilbar;
[[$\Rightarrow$ ]{.math display="inline"
role="math"}[$\mathsf{\Rightarrow}$ ]{.mathImpaired display="inline"
role="math"}[\$\\Rightarrow\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> Widerspruch zu \"[[$p,q$
]{.math display="inline" role="math"}[$\mathsf{p,q}$ ]{.mathImpaired
display="inline" role="math"}[\$p,q\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> teilerfremd\".

-   Nach unserer Definition ist [[$\sqrt[n]{a} \geq 0$ ]{.math
    display="inline" role="math"}[$\mathsf{\sqrt[n]{a} \geq 0}$
    ]{.mathImpaired display="inline" role="math"}[\$\\sqrt\[n\]{a} \\geq
    0\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> (für [[$a \geq 0$
    ]{.math display="inline" role="math"}[$\mathsf{a \geq 0}$
    ]{.mathImpaired display="inline" role="math"}[\$a \\geq
    0\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->)
-   **Achtung**: wir ziehen nur Wurzeln aus Zahlen [[[\$&gt; 0\$]{.math
    .inline} ]{.math display="inline" role="math"}[[\$&gt; 0\$]{.math
    .inline} ]{.mathImpaired display="inline" role="math"}[\$\>
    0\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    Bsp: [[$\sqrt{4} = 2$ ]{.math display="inline"
    role="math"}[$\mathsf{\sqrt{4} = 2}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\sqrt{4} =2\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->; die Gleichung
    [[$x^{2} = 4$ ]{.math display="inline"
    role="math"}[$\mathsf{x^{2} = 4}$ ]{.mathImpaired display="inline"
    role="math"}[\$x\^2=4\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> hat **zwei** Lösungen
    2 und [[$- 2$ ]{.math display="inline" role="math"}[$\mathsf{- 2}$
    ]{.mathImpaired display="inline" role="math"}[\$-2\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->; als **Wurzel**
    wählen wir die Lösung [[$\geq 0$ ]{.math display="inline"
    role="math"}[$\mathsf{\geq 0}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\geq 0\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> aus.
-   [[$\sqrt{a^{2}} = |a|$ ]{.math display="inline"
    role="math"}[$\mathsf{\sqrt{a^{2}} = |a|}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\sqrt{a\^2} = \|a\|\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

((Seite16))

1.7. Potenzen mit rationalen Exponenten
---------------------------------------

Es sei [[\$ a 0\$ ]{.math display="inline" role="math"}[\$ a 0\$
]{.mathImpaired display="inline" role="math"}[\$ a \\geq
0\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[[\$r \\in
\\mathbb{Q}, r&gt;0\$]{.math .inline} ]{.math display="inline"
role="math"}[[\$r \\in \\mathbb{Q}, r&gt;0\$]{.math .inline}
]{.mathImpaired display="inline" role="math"}[\$r \\in \\mathbb{Q},
r\>0\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Also [[$r = \frac{m}{n}$
]{.math display="inline" role="math"}[$\mathsf{r = \frac{m}{n}}$
]{.mathImpaired display="inline" role="math"}[\$r=
\\frac{m}{n}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> mit
[[$m,n \in \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{m,n \in \mathbb{N}}$ ]{.mathImpaired
display="inline" role="math"}[\$m,n \\in \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

Wir *wollen* definieren:

[[$a^{r}:=(\sqrt[n]{a})^{m}$ ]{.math display="inline"
role="math"}[$\mathsf{a^{r}:=(\sqrt[n]{a})^{m}}$ ]{.mathImpaired
display="inline" role="math"}[\$a\^r := ( \\sqrt\[n\]{a}
)\^m\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

Problem: Ist [[$r = \frac{p}{q}$ ]{.math display="inline"
role="math"}[$\mathsf{r = \frac{p}{q}}$ ]{.mathImpaired display="inline"
role="math"}[\$r= \\frac{p}{q}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine weitere Darstellung
von [[$r$ ]{.math display="inline" role="math"}[$\mathsf{r}$
]{.mathImpaired display="inline" role="math"}[\$r\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, gilt dann

[[$(\sqrt[n]{a})^{m} = (\sqrt[q]{a})^{p}$ ]{.math display="inline"
role="math"}[$\mathsf{(\sqrt[n]{a})^{m} = (\sqrt[q]{a})^{p}}$
]{.mathImpaired display="inline" role="math"}[\$( \\sqrt\[n\]{a} )\^m =
( \\sqrt\[q\]{a} )\^p\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->?

Ja! Denn: setze

[[$x:=(\sqrt[n]{a})^{m},y:=(\sqrt[q]{a})^{p}$ ]{.math display="inline"
role="math"}[$\mathsf{x:=(\sqrt[n]{a})^{m},y:=(\sqrt[q]{a})^{p}}$
]{.mathImpaired display="inline" role="math"}[\$x := ( \\sqrt\[n\]{a}
)\^m, y := ( \\sqrt\[q\]{a} )\^p\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

Dann

[[$x^{q} = \lbrack(\sqrt[n]{a})^{m}\rbrack^{q} = (\sqrt[n]{a})^{mq} = (\sqrt[n]{a})^{np} = \lbrack(\sqrt[n]{a})^{n}\rbrack^{p} = a^{p}$
]{.math display="inline"
role="math"}[$\mathsf{x^{q} = \lbrack(\sqrt[n]{a})^{m}\rbrack^{q} = (\sqrt[n]{a})^{mq} = (\sqrt[n]{a})^{np} = \lbrack(\sqrt[n]{a})^{n}\rbrack^{p} = a^{p}}$
]{.mathImpaired display="inline" role="math"}[\$x\^q= \[( \\sqrt\[n\]{a}
)\^m \]\^q = ( \\sqrt\[n\]{a} )\^{mq} = ( \\sqrt\[n\]{a} )\^{np} = \[ (
\\sqrt\[n\]{a} )\^n \]\^p = a\^p\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

Analog für [[$y^{p}$ ]{.math display="inline"
role="math"}[$\mathsf{y^{p}}$ ]{.mathImpaired display="inline"
role="math"}[\$y\^p\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
d.h. [[$x^{q} = y^{q}$ ]{.math display="inline"
role="math"}[$\mathsf{x^{q} = y^{q}}$ ]{.mathImpaired display="inline"
role="math"}[\$x\^q=y\^q\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Nach Hilfssatz also
[[$x = y$ ]{.math display="inline" role="math"}[$\mathsf{x = y}$
]{.mathImpaired display="inline" role="math"}[\$x=y\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
Also obige Definition in Ordnung.\
Es gelten die bekannten Rechenregeln.

Ist [[[\$a&gt;0, r \\in \\mathbb{Q}, r&lt;0\$]{.math .inline} ]{.math
display="inline" role="math"}[[\$a&gt;0, r \\in \\mathbb{Q},
r&lt;0\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$a\>0, r \\in \\mathbb{Q}, r\<0\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, so setze
[[$a^{r}:=\frac{1}{a^{- r}}$ ]{.math display="inline"
role="math"}[$\mathsf{a^{r}:=\frac{1}{a^{- r}}}$ ]{.mathImpaired
display="inline" role="math"}[\$a\^r :=
\\frac{1}{a\^{-r}}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

((Seite17))

((Seite18))\

2. Folgen, Konvergenz 
======================

2.1. Definition der Folgen
--------------------------

### Definition 2.1.

Sei [[$X$ ]{.math display="inline" role="math"}[$\mathsf{X}$
]{.mathImpaired display="inline" role="math"}[\$X\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine beliebige Menge,
[[$X \neq \varnothing$ ]{.math display="inline"
role="math"}[$\mathsf{X \neq \varnothing}$ ]{.mathImpaired
display="inline" role="math"}[\$X \\neq \\emptyset\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

Eine Funktion [[$\left. a:\mathbb{N}\rightarrow X \right.$ ]{.math
display="inline"
role="math"}[$\mathsf{\left. a:\mathbb{N}\rightarrow X \right.}$
]{.mathImpaired display="inline" role="math"}[\$a: \\mathbb{N}
\\rightarrow X\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißt *Folge in* [[$X$
]{.math display="inline" role="math"}[$\mathsf{X}$ ]{.mathImpaired
display="inline" role="math"}[\$X\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

Schreibweise:

> [[$\forall n \in \mathbb{N}a_{n}:=a(n)n$ ]{.math display="inline"
> role="math"}[$\mathsf{\forall n \in \mathbb{N}a_{n}:=a(n)n}$
> ]{.mathImpaired display="inline" role="math"}[\$\\forall n \\in
> \\mathbb{N} a\_n := a(n) n\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->-tes Folgenglied
>
> [[$(a_{n})_{n \in \mathbb{N}}$ ]{.math display="inline"
> role="math"}[$\mathsf{(a_{n})_{n \in \mathbb{N}}}$ ]{.mathImpaired
> display="inline" role="math"}[\$(a\_n)\_{n \\in
> \\mathbb{N}}\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> oder
> [[$(a_{n})_{n = 1}^{\infty}$ ]{.math display="inline"
> role="math"}[$\mathsf{(a_{n})_{n = 1}^{\infty}}$ ]{.mathImpaired
> display="inline" role="math"}[\$(a\_n)\_{n=1}\^\\infty\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> oder [[$(a_{n})$
> ]{.math display="inline" role="math"}[$\mathsf{(a_{n})}$
> ]{.mathImpaired display="inline" role="math"}[\$(a\_n)\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> oder (a\_1,a\_2,a\_3,
> \\ldots )\$\$ statt [[$a$ ]{.math display="inline"
> role="math"}[$\mathsf{a}$ ]{.mathImpaired display="inline"
> role="math"}[\$a\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->.

Ist [[$X = \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{X = \mathbb{R}}$ ]{.mathImpaired display="inline"
role="math"}[\$X = \\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, so spricht man von
*reellen Folgen*.

### Bemerkung 2.2. {dir="ltr"}

Ist [[$p \in \mathbb{Z}$ ]{.math display="inline"
role="math"}[$\mathsf{p \in \mathbb{Z}}$ ]{.mathImpaired
display="inline" role="math"}[\$p \\in \\mathbb{Z}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und
[[$\left. a:\{ p,p + 1,p + 2,\ldots\}\rightarrow X \right.$ ]{.math
display="inline"
role="math"}[$\mathsf{\left. a:\{ p,p + 1,p + 2,\ldots\}\rightarrow X \right.}$
]{.mathImpaired display="inline" role="math"}[\$a : \\{ p,p+1,p+2,
\\ldots \\} \\rightarrow X\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine Funktion, so spricht
man ebenfalls von einer Folge [[$X$ ]{.math display="inline"
role="math"}[$\mathsf{X}$ ]{.mathImpaired display="inline"
role="math"}[\$X\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

Bezeichnung: [[$(a_{n})_{n = p}^{\infty}$ ]{.math display="inline"
role="math"}[$\mathsf{(a_{n})_{n = p}^{\infty}}$ ]{.mathImpaired
display="inline" role="math"}[\$(a\_n)\_{n=p}\^\\infty\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> oder [[[\$( a\_p
,a\_{p+\^} , \\ldots )\$]{.math .inline} ]{.math display="inline"
role="math"}[[\$( a\_p ,a\_{p+\^} , \\ldots )\$]{.math .inline}
]{.mathImpaired display="inline" role="math"}[\$( a\_p ,a\_{p+\^} ,
\\ldots )\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

### Beispiel 2.3. {dir="ltr"}

-   <div>

    [[$a_{n}:=\frac{1}{n}$ ]{.math display="inline"
    role="math"}[$\mathsf{a_{n}:=\frac{1}{n}}$ ]{.mathImpaired
    display="inline" role="math"}[\$a\_n := \\frac{1}{n}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> für alle
    [[$n \in \mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{n \in \mathbb{N}}$ ]{.mathImpaired
    display="inline" role="math"}[\$n \\in \\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, also\
    [[$(a_{n})_{n \in \mathbb{N}} = (1,\frac{1}{2},\frac{1}{3},\ldots)$
    ]{.math display="inline"
    role="math"}[$\mathsf{(a_{n})_{n \in \mathbb{N}} = (1,\frac{1}{2},\frac{1}{3},\ldots)}$
    ]{.mathImpaired display="inline" role="math"}[\$(a\_n)\_{n \\in
    \\mathbb{N}} = (1, \\frac{1}{2}, \\frac{1}{3}, \\ldots
    )\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

    </div>

-   <div>

    [[$\forall n \in \mathbb{N}a_{2n}:=0,a_{2n - 1}:=1$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\forall n \in \mathbb{N}a_{2n}:=0,a_{2n - 1}:=1}$
    ]{.mathImpaired display="inline" role="math"}[\$\\forall n \\in
    \\mathbb{N} a\_{2n} := 0, a\_{2n-1} :=1\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    also [[$(a_{n})_{n \in \mathbb{N}} = (1,0,1,0,\ldots)$ ]{.math
    display="inline"
    role="math"}[$\mathsf{(a_{n})_{n \in \mathbb{N}} = (1,0,1,0,\ldots)}$
    ]{.mathImpaired display="inline" role="math"}[\$(a\_n)\_{n \\in
    \\mathbb{N}} = (1,0,1,0, \\ldots )\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

    </div>

-   <div>

    [[$\forall n \in \mathbb{N}a_{n}:=( - 1)^{n}$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\forall n \in \mathbb{N}a_{n}:=( - 1)^{n}}$
    ]{.mathImpaired display="inline" role="math"}[\$\\forall n \\in
    \\mathbb{N} a\_n := (-1)\^n\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    also [[$(a_{n})_{n \in \mathbb{N}} = ( - 1,1, - 1,1,\ldots)$ ]{.math
    display="inline"
    role="math"}[$\mathsf{(a_{n})_{n \in \mathbb{N}} = ( - 1,1, - 1,1,\ldots)}$
    ]{.mathImpaired display="inline" role="math"}[\$(a\_n)\_{n \\in 
    \\mathbb{N}} = (-1,1,-1,1, \\ldots )\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

    </div>

### Definition 2.4.

Sei [[$X$ ]{.math display="inline" role="math"}[$\mathsf{X}$
]{.mathImpaired display="inline" role="math"}[\$X\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine beliebige Menge,
[[$X \neq \varnothing$ ]{.math display="inline"
role="math"}[$\mathsf{X \neq \varnothing}$ ]{.mathImpaired
display="inline" role="math"}[\$X \\neq \\emptyset\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

1.  [[$X$ ]{.math display="inline" role="math"}[$\mathsf{X}$
    ]{.mathImpaired display="inline" role="math"}[\$X\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist* endlich*, wenn
    eine surjektive Abbildung
    [[$\left. \phi:\{ 1,\ldots,n\}\rightarrow X \right.$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\left. \phi:\{ 1,\ldots,n\}\rightarrow X \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\phi : \\{ 1,
    \\ldots ,n \\} \\rightarrow X\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> existiert.
2.  [[$X$ ]{.math display="inline" role="math"}[$\mathsf{X}$
    ]{.mathImpaired display="inline" role="math"}[\$X\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> heißt *abzählbar*,
    wenn [[$X$ ]{.math display="inline" role="math"}[$\mathsf{X}$
    ]{.mathImpaired display="inline" role="math"}[\$X\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> endlich ist *oder*
    eine surjektive Abbildung
    [[$\left. \phi:\mathbb{N}\rightarrow X \right.$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\left. \phi:\mathbb{N}\rightarrow X \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\phi : \\mathbb{N}
    \\rightarrow X\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> existiert. (D.h. wenn
    [[$X$ ]{.math display="inline" role="math"}[$\mathsf{X}$
    ]{.mathImpaired display="inline" role="math"}[\$X\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> endlich ist oder eine
    Folge [[$(a_{n})_{n \in \mathbb{N}}$ ]{.math display="inline"
    role="math"}[$\mathsf{(a_{n})_{n \in \mathbb{N}}}$ ]{.mathImpaired
    display="inline" role="math"}[\$(a\_n)\_{n \\in
    \\mathbb{N}}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> in [[$X$ ]{.math
    display="inline" role="math"}[$\mathsf{X}$ ]{.mathImpaired
    display="inline" role="math"}[\$X\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> existiert mit
    [[$\{ a_{1},a_{2},a_{3},\ldots\} = X$ ]{.math display="inline"
    role="math"}[$\mathsf{\{ a_{1},a_{2},a_{3},\ldots\} = X}$
    ]{.mathImpaired display="inline" role="math"}[\$\\{ a\_1,a\_2,a\_3,
    \\ldots \\} =X\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.\
    oder: die Elemente von [[$X$ ]{.math display="inline"
    role="math"}[$\mathsf{X}$ ]{.mathImpaired display="inline"
    role="math"}[\$X\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> können mit
    [[$\{ 1,\ldots,n\}$ ]{.math display="inline"
    role="math"}[$\mathsf{\{ 1,\ldots,n\}}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\{ 1, \\ldots ,n
    \\}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> oder mit
    [[$\mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> *durchnummeriert*
    werden.)
3.  [[$X$ ]{.math display="inline" role="math"}[$\mathsf{X}$
    ]{.mathImpaired display="inline" role="math"}[\$X\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> heißt
    *überabzählbar*, wenn [[$X$ ]{.math display="inline"
    role="math"}[$\mathsf{X}$ ]{.mathImpaired display="inline"
    role="math"}[\$X\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nicht abzählbar ist.

### Beispiel 2.5.

-   [[$\mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist abzählbar, denn
    [[$\mathbb{N} = \{ a_{1},a_{2},a_{3},\ldots\}$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\mathbb{N} = \{ a_{1},a_{2},a_{3},\ldots\}}$
    ]{.mathImpaired display="inline" role="math"}[\$\\mathbb{N}= \\{
    a\_1,a\_2,a\_3, \\ldots \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
    mit [[$\forall n \in \mathbb{N}a_{n}:=n$ ]{.math display="inline"
    role="math"}[$\mathsf{\forall n \in \mathbb{N}a_{n}:=n}$
    ]{.mathImpaired display="inline" role="math"}[\$\\forall n \\in
    \\mathbb{N} a\_n := n\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.
-   [[$\mathbb{Z}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{Z}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{Z}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist abzählbar.\
    Definiere etwa: [[$a_{1}:=0,a_{2}:=1,a_{3}:= - 1,a_{4}:=2,\ldots$
    ]{.math display="inline"
    role="math"}[$\mathsf{a_{1}:=0,a_{2}:=1,a_{3}:= - 1,a_{4}:=2,\ldots}$
    ]{.mathImpaired display="inline" role="math"}[\$a\_1:=0, a\_2:=1,
    a\_3:=-1, a\_4:=2, \\ldots\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

((Seite 19))

-   [[$\mathbb{Q}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{Q}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{Q}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist abzählbar.\
    [[$\Rightarrow$ ]{.math display="inline"
    role="math"}[$\mathsf{\Rightarrow}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\Rightarrow\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> Unendliches Rechteck\
    \
      1                                                                                                                                                                                                                                            2                                                                                                                                                                                                                                            3                                                                                                                                                                                                                                            4                                                                                                                                                                                                                                            [[$\ldots$ ]{.math display="inline" role="math"}[$\mathsf{\ldots}$ ]{.mathImpaired display="inline" role="math"}[\$\\ldots\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->
      -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
      [[$\frac{1}{2}$ ]{.math display="inline" role="math"}[$\mathsf{\frac{1}{2}}$ ]{.mathImpaired display="inline" role="math"}[\$\\frac{1}{2}\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->   [[$\frac{2}{2}$ ]{.math display="inline" role="math"}[$\mathsf{\frac{2}{2}}$ ]{.mathImpaired display="inline" role="math"}[\$\\frac{2}{2}\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->   [[$\frac{3}{2}$ ]{.math display="inline" role="math"}[$\mathsf{\frac{3}{2}}$ ]{.mathImpaired display="inline" role="math"}[\$\\frac{3}{2}\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->   [[$\frac{4}{2}$ ]{.math display="inline" role="math"}[$\mathsf{\frac{4}{2}}$ ]{.mathImpaired display="inline" role="math"}[\$\\frac{4}{2}\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->   [[$\ldots$ ]{.math display="inline" role="math"}[$\mathsf{\ldots}$ ]{.mathImpaired display="inline" role="math"}[\$\\ldots\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->
      [[$\vdots$ ]{.math display="inline" role="math"}[$\mathsf{\vdots}$ ]{.mathImpaired display="inline" role="math"}[\$\\vdots\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->                  [[$\vdots$ ]{.math display="inline" role="math"}[$\mathsf{\vdots}$ ]{.mathImpaired display="inline" role="math"}[\$\\vdots\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->                  [[$\vdots$ ]{.math display="inline" role="math"}[$\mathsf{\vdots}$ ]{.mathImpaired display="inline" role="math"}[\$\\vdots\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->                  [[$\vdots$ ]{.math display="inline" role="math"}[$\mathsf{\vdots}$ ]{.mathImpaired display="inline" role="math"}[\$\\vdots\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->                  [[$\ddots$ ]{.math display="inline" role="math"}[$\mathsf{\ddots}$ ]{.mathImpaired display="inline" role="math"}[\$\\ddots\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->

    Dann setze [[$b_{1}:=0,b_{2}:=a_{1},b_{3}:= - a_{1},\ldots$ ]{.math
    display="inline"
    role="math"}[$\mathsf{b_{1}:=0,b_{2}:=a_{1},b_{3}:= - a_{1},\ldots}$
    ]{.mathImpaired display="inline" role="math"}[\$b\_1:=0, b\_2:=a\_1,
    b\_3:=-a\_1, \\ldots\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, um auch die
    negativen Zahlen durchnummerieren zu können.
-   [[$\mathbb{R}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{R}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{R}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist *überabzählbar*.
    ([[$\Rightarrow$ ]{.math display="inline"
    role="math"}[$\mathsf{\Rightarrow}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\Rightarrow\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> es gibt auch viel
    mehr irrationale Zahlen als rationale)

Ab jetzt seien alle Folgen *reelle* Folgen.

### Definition 2.6.

Sei [[$(a_{n})$ ]{.math display="inline" role="math"}[$\mathsf{(a_{n})}$
]{.mathImpaired display="inline" role="math"}[\$(a\_n)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine reelle Folge.
[[$(a_{n})$ ]{.math display="inline" role="math"}[$\mathsf{(a_{n})}$
]{.mathImpaired display="inline" role="math"}[\$(a\_n)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißt *nach oben bzw.
unten beschränkt*, wenn die Menge [[$M = \{ a_{1},a_{2},a_{3}\ldots\}$
]{.math display="inline"
role="math"}[$\mathsf{M = \{ a_{1},a_{2},a_{3}\ldots\}}$ ]{.mathImpaired
display="inline" role="math"}[\$M= \\{ a\_1,a\_2,a\_3 \\ldots
\\}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> nach oben bzw. unten
beschränkt ist. In diesem Fall:
[[$\sup(a_{n})_{n \in \mathbb{N}}:=\sup M$ ]{.math display="inline"
role="math"}[$\mathsf{\sup(a_{n})_{n \in \mathbb{N}}:=\sup M}$
]{.mathImpaired display="inline" role="math"}[\$\\sup (a\_n)\_{n \\in 
\\mathbb{N}}:= \\sup M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
Analog für die andere Seite.

[[$(a_{n})$ ]{.math display="inline" role="math"}[$\mathsf{(a_{n})}$
]{.mathImpaired display="inline" role="math"}[\$(a\_n)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißt *beschränkt*, wenn
[[$(a_{n})$ ]{.math display="inline" role="math"}[$\mathsf{(a_{n})}$
]{.mathImpaired display="inline" role="math"}[\$(a\_n)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> nach oben und nach unten
beschränkt ist.

2.2. Konvergenz
---------------

Der begriff *Konvergenz* ist der zentrale Begriff der Analysis. Wir
betrachten zunächst die Konvergenz reeller Folgen.

Sei [[$(a_{n})$ ]{.math display="inline" role="math"}[$\mathsf{(a_{n})}$
]{.mathImpaired display="inline" role="math"}[\$(a\_n)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine Folge in
[[$\mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{\mathbb{R}}$ ]{.mathImpaired display="inline"
role="math"}[\$\\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[$a \in \mathbb{R}$
]{.math display="inline" role="math"}[$\mathsf{a \in \mathbb{R}}$
]{.mathImpaired display="inline" role="math"}[\$a \\in
\\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Was soll
\"[[$\left. a_{n}\rightarrow a \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. a_{n}\rightarrow a \right.}$
]{.mathImpaired display="inline" role="math"}[\$a\_n \\rightarrow
a\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> für [[[\$n \\righttarrow
\\infty\$]{.math .inline} ]{.math display="inline" role="math"}[[\$n
\\righttarrow \\infty\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$n \\righttarrow \\infty\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\" bedeuten?

1\. Schritt: \"Die Folgenglieder [[$a_{n}$ ]{.math display="inline"
role="math"}[$\mathsf{a_{n}}$ ]{.mathImpaired display="inline"
role="math"}[\$a\_n\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> kommen [[$a$ ]{.math
display="inline" role="math"}[$\mathsf{a}$ ]{.mathImpaired
display="inline" role="math"}[\$a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> beliebig nahe oder
[[$|a_{n} - a|$ ]{.math display="inline"
role="math"}[$\mathsf{|a_{n} - a|}$ ]{.mathImpaired display="inline"
role="math"}[\$\|a\_n-a\|\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> wird beliebig klein, wenn
[[$n$ ]{.math display="inline" role="math"}[$\mathsf{n}$ ]{.mathImpaired
display="inline" role="math"}[\$n\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> groß wird\".

2\. Schritt: So sollte zum Beispiel gelten:

> [[[\$\| a\_n-a\| &lt; \\frac{1}{1000}\$]{.math .inline} ]{.math
> display="inline" role="math"}[[\$\| a\_n-a\| &lt;
> \\frac{1}{1000}\$]{.math .inline} ]{.mathImpaired display="inline"
> role="math"}[\$\| a\_n-a\| \< \\frac{1}{1000}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> Nur: für welche [[$n$ ]{.math display="inline"
> role="math"}[$\mathsf{n}$ ]{.mathImpaired display="inline"
> role="math"}[\$n\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->?
>
> Idee: ab einem gewissen Index [[$n_{0}$ ]{.math display="inline"
> role="math"}[$\mathsf{n_{0}}$ ]{.mathImpaired display="inline"
> role="math"}[\$n\_0\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> soll für alle
> [[[\$n&gt;n\_0\$]{.math .inline} ]{.math display="inline"
> role="math"}[[\$n&gt;n\_0\$]{.math .inline} ]{.mathImpaired
> display="inline" role="math"}[\$n\>n\_0\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> die obige Ungleichung
> gelten.\
> Ebenso sollte es ein [[$n_{1} \in \mathbb{N}$ ]{.math display="inline"
> role="math"}[$\mathsf{n_{1} \in \mathbb{N}}$ ]{.mathImpaired
> display="inline" role="math"}[\$n\_1 \\in \\mathbb{N}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> geben mit [[[\$\|
> a\_n-a\| &lt; 10\^{-6}\$]{.math .inline} ]{.math display="inline"
> role="math"}[[\$\| a\_n-a\| &lt; 10\^{-6}\$]{.math .inline}
> ]{.mathImpaired display="inline" role="math"}[\$\| a\_n-a\| \<
> 10\^{-6}\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> für alle
> [[$n \geq n_{1}$ ]{.math display="inline"
> role="math"}[$\mathsf{n \geq n_{1}}$ ]{.mathImpaired display="inline"
> role="math"}[\$n \\geq n\_1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->.

3\. Schritt: Ist [[[\$\\epsilon &gt; 0\$]{.math .inline} ]{.math
display="inline" role="math"}[[\$\\epsilon &gt; 0\$]{.math .inline}
]{.mathImpaired display="inline" role="math"}[\$\\epsilon \>
0\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (und [[$\epsilon$ ]{.math
display="inline" role="math"}[$\mathsf{\epsilon}$ ]{.mathImpaired
display="inline" role="math"}[\$\\epsilon\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> belibig klein), so sollte
es stets ein [[$n_{0} = n_{0}(\epsilon) \in \mathbb{N}$ ]{.math
display="inline"
role="math"}[$\mathsf{n_{0} = n_{0}(\epsilon) \in \mathbb{N}}$
]{.mathImpaired display="inline" role="math"}[\$n\_0 = n\_0( \\epsilon )
\\in \\mathbb{N}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> geben, mit

> [[[\$\| a\_n-a\| &lt; \\epsilon\$]{.math .inline} ]{.math
> display="inline" role="math"}[[\$\| a\_n-a\| &lt; \\epsilon\$]{.math
> .inline} ]{.mathImpaired display="inline" role="math"}[\$\| a\_n-a\|
> \< \\epsilon\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> für alle
> [[$n \geq n_{0}$ ]{.math display="inline"
> role="math"}[$\mathsf{n \geq n_{0}}$ ]{.mathImpaired display="inline"
> role="math"}[\$n \\geq n\_0\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

Diese Überlegungen führen uns zu folgender

### Definition 2.7. {dir="ltr"}

1.  Die Folge [[$(a_{n})$ ]{.math display="inline"
    role="math"}[$\mathsf{(a_{n})}$ ]{.mathImpaired display="inline"
    role="math"}[\$(a\_n)\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> heißt konvergent
    gegen [[$a$ ]{.math display="inline" role="math"}[$\mathsf{a}$
    ]{.mathImpaired display="inline" role="math"}[\$a\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, wenn gilt:\
    [[[\$\\forall \\epsilon &gt; 0 \\exists n\_0 \\in \\mathbb{N}
    \\forall n \\geq n\_0 \|a\_n-a\| &lt; \\epsilon\$]{.math .inline}
    ]{.math display="inline" role="math"}[[\$\\forall \\epsilon &gt; 0
    \\exists n\_0 \\in \\mathbb{N} \\forall n \\geq n\_0 \|a\_n-a\| &lt;
    \\epsilon\$]{.math .inline} ]{.mathImpaired display="inline"
    role="math"}[\$\\forall \\epsilon \> 0 \\exists n\_0 \\in
    \\mathbb{N} \\forall n \\geq n\_0 \|a\_n-a\| \<
    \\epsilon\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    In diesem Fall heißt [[$a$ ]{.math display="inline"
    role="math"}[$\mathsf{a}$ ]{.mathImpaired display="inline"
    role="math"}[\$a\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> Grenzwert (Limes) von
    [[$(a_{n})$ ]{.math display="inline" role="math"}[$\mathsf{(a_{n})}$
    ]{.mathImpaired display="inline"
    role="math"}[\$(a\_n)\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.\
    Bezeichnung: [[$a = \lim_{n\leftarrow\infty}a_{n}$ ]{.math
    display="inline"
    role="math"}[$\mathsf{a = \lim_{n\leftarrow\infty}a_{n}}$
    ]{.mathImpaired display="inline" role="math"}[\$a=
    \\lim\_{n\\leftarrow\\infty} a\_n\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> oder:
    [[$\left. a_{n}\rightarrow a \right.$ ]{.math display="inline"
    role="math"}[$\mathsf{\left. a_{n}\rightarrow a \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$a\_n \\rightarrow
    a\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> für
    [[$\left. n\rightarrow\infty \right.$ ]{.math display="inline"
    role="math"}[$\mathsf{\left. n\rightarrow\infty \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$n \\rightarrow
    \\infty\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.

((Seite20))

1.  Eine Folge [[$(a_{n})$ ]{.math display="inline"
    role="math"}[$\mathsf{(a_{n})}$ ]{.mathImpaired display="inline"
    role="math"}[\$( a\_n )\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> heißt *konvergent*,
    wenn es ein [[$a \in \mathbb{R}$ ]{.math display="inline"
    role="math"}[$\mathsf{a \in \mathbb{R}}$ ]{.mathImpaired
    display="inline" role="math"}[\$a \\in \\mathbb{R}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> gibt derart, dass
    [[$(a_{n})$ ]{.math display="inline" role="math"}[$\mathsf{(a_{n})}$
    ]{.mathImpaired display="inline"
    role="math"}[\$(a\_n)\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> gegen [[$a$ ]{.math
    display="inline" role="math"}[$\mathsf{a}$ ]{.mathImpaired
    display="inline" role="math"}[\$a\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> konvergiert.
2.  Eine Folge [[$(a_{n})$ ]{.math display="inline"
    role="math"}[$\mathsf{(a_{n})}$ ]{.mathImpaired display="inline"
    role="math"}[\$(a\_n)\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> heißt *divergent*,
    wenn sie nicht konvergent ist.

\

\

<!--EndOfBlindSection-->
:::

::: {#Content.xhtml#visible .visible}
<!--StartOfVisibleSection-->

Höhere Mathematik für Informatiker {#Content.xhtml#toc_0}
==================================

Inoffizielles Skriptum zur Vorlesung Höhere Mathematik für Informatiker
basierend auf Vorlesungen an der Universität Karlsruhe (TH) 2000 \--
2004

\

![](Images/title_1.png "Titelbild"){.imageOthers}

\

((Seitei))

##### Anmerkungen des Autors: {#Content.xhtml#toc_1}

Dieses Werk ist unter einem Creative Commons
Namensnennung-NichtKommerziell-Weitergabe unter gleichen\
Bedingungen Lizenzvertrag lizensiert. Um die Lizenz anzusehen, gehen Sie
bitte zu <http://creativecommons.org/licenses/by-nc-sa/2.0/de/> oder
schicken Sie einen Brief an Creative Commons, 559 Nathan Abbott Way,
Stanford, California 94305, USA.

###### WICHTIGER HINWEIS: {#Content.xhtml#toc_2}

Dies ist KEIN offiziell autorisiertes Skript der genannten Dozenten!
Entsprechend erhebt der Mitschrieb und die enthaltenen Ergänzungen
keinen Anspruch auf Vollständigkeit und Korrektheit!

###### Von der Website: {#Content.xhtml#toc_3}

Das \"inoffizielle Skript\" entstand in Zusammenarbeit mit [Markus
Westphal](http://www.markuswestphal.de/), [Christian
Senger](http://www.sengernet.de/) und anderen Kommilitonen. Es basiert
auf meinem Mitschrieb der Vorlesung von [Prof.
Plum](http://www.math.kit.edu/iana2/~plum/) 2000/2001 an der Universität
Karlsruhe (TH) (heute: KIT). Kombiniert wurde er mit Teilen aus der
Vorlesung von [Dr. Kunstmann](http://www.math.kit.edu/iana3/~kunstmann/)
2002/2003 und aus den Vorlesungen von [Dr.
Schmoeger](http://www.math.kit.edu/iana3/~schmoeger/) 2001/2002 und
2003/2004.\
Sowohl die Konzeption als auch das Manuskript der genannten Vorlesungen
stammen allein von [Dr.
Schmoeger](http://www.math.kit.edu/iana3/~schmoeger/).

Wer ebenfalls Interesse daran hat, die aktuelle HM-Vorlesung in die
bestehenden Quellen einzuarbeiten oder gerne die Lesbarkeit und das
Erscheinungsbild verbessern und weitere Skizzen einfügen möchte: eine
eMail an `<post AT danielwinkler.de>` genügt. 

Wir erheben keinen Anspruch auf Vollständigkeit und Korrektheit!

##### Anmerkungen des Umsetzers: {#Content.xhtml#toc_4}

Da die Vorlage keine farbigen Graphiken enthält, entspricht dieses
Dokument De Facto einer Umsetzung der Schwarz-Weiß-Version des Skriptes.
Das Skript wird möglichst nah am Original umgesetzt, mithilfe aller
verfügbaren Werkzeuge des Editors.

Schlüsselwörter wie \"Beispiel\" und \"Lemma\", welche in der Vorlage
farbig markiert sind, sind es hier ebenfalls, in den vergleichbaren
Farben.\

Dieses Dokument ist vorläufig nur eine Testversion um den Editor an
einem Umsetzungsbeispiel anzuwenden.

###### Bisherige Probleme dieser Umsetzung: {#Content.xhtml#toc_5}

-   Bilder sind zurzeit als Rastergraphik eingebettet, obwohl die
    Quellen im vektoriellen EPS-Format vorliegen.
-   Konsistenz der Notation muss noch gefunden werden.

((Seiteii))

(Inhaltsverzeichnis) {#Content.xhtml#toc_6}
====================

((Seitevi))

(Tabellenverzeichnis) {#Content.xhtml#toc_7}
=====================

 Dieses Werk ist unter einem Creative Commons
Namensnennung\--Nicht-Kommerziell\--Weitergabe unter gleichen
Bedingungen\-\--Lizenzvertrag lizensiert. Um die Lizenz anzusehen, gehen
Sie bitte zu <http://creativecommons.org/licenses/by-nc-sa/2.0/de/> oder
schicken Sie einen Brief an Creative Commons, 559 Nathan Abbott Way,
Stanford, California 94305, USA.

\

![](Images/cc_2.png "Lizensangabe: Creative Commons"){.imageOthers}

Dieses Skriptum erhebt keinen Anspruch auf Vollständigkeit und
Korrektheit. Einige Beweise, die in den Saalübungen geführt wurden, sind
nicht enthalten.

Kommentare, Fehler, Patches und Vorschläge bitte an
[post\@danielwinkler.de](mailto:post@danielwinkler.de%7D%7B%7D%7B%7D%7Bpost@danielwinkler.de) senden.
Bei Fehlern bitte **nicht** die Seitenzahl sondern die Nummer des
Satzes, der Abbildung etc. sowie die Revisionsnummern angeben.

Die aktuelle Version dieses Dokuments sowie die Quelldateien hierzu sind
unter der Web-Adresse\
[http://www.danielwinkler.de/hm/](http://www.danielwinkler.de/hm/%20) zu
finden.

Dieses inoffizielle Skriptum basiert auf dem Mitschrieb von Daniel
Winkler zu den Vorlesungen an der Universität\
Karlsruhe (heute: Karlsruher Institut für Technologie, KIT) in den
Jahren 2000 und 2001 von Prof. M. Plum. Kombiniert wurde er durch Markus
Westphal und Sebastian Reichelt mit Material aus den Vorlesungen in den
Jahren 2002 bis 2004 von HDoz. Dr. P. Kunstmann und AOR Dr. Ch.
Shmoeger.

Sowohl die Konzeption als auch das Manuskript der genannten
Vorlesungen stammen allein von AOR Dr. Ch. Schmoeger.

Weitere Korrekturen und Ergänzungen wurden eingebracht von Julian
Dibbelt, Martin Röhricht, Christian Senger, Norbert Silberhorn, Johannes
Singler und Richard Walter.

  Teil     Rev.
  -------- ------
  Layout   282
  HM 1     289
  HM 2     291
  Anhang   256

((Seitevii))

*Don\'t panic!*\

((Seiteviii))

\

Teil I. Eindimensionale Analsysis {#Content.xhtml#toc_8 align="center"}
=================================

((Seite1))

((Seite2))

0. Vorbemerkungen {#Content.xhtml#toc_9}
=================

0.1. Mengen {#Content.xhtml#toc_10}
-----------

Eine *Menge* ist nach Cantor eine Zusammenfassung [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> von bestimmten
wohlunterschiedenen Objekten unserer Anschauung oder unseres Denkens
(welche Elemente von [[$M$ ]{.math display="inline"
role="math"}[$\mathsf{M}$ ]{.mathImpaired display="inline"
role="math"}[\$M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> genannt werden) zu einem
Ganzen.

**Notation**: geschweifte Klammern [[$\{\}$ ]{.math display="inline"
role="math"}[$\mathsf{\{\}}$ ]{.mathImpaired display="inline"
role="math"}[\$\\left\\{ \\right\\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

#### Beispiel 0.1. Notationen: {#Content.xhtml#toc_11}

-   <font size="1">[[$M = \{ 1,2,3\}$ ]{.math display="inline"
    role="math"}[$\mathsf{M = \{ 1,2,3\}}$ ]{.mathImpaired
    display="inline" role="math"}[\$M = \\{ 1,2,3 \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--></font>
-   <font size="1">[[$M = \{ x:x{\mspace{6mu}\text{ist\ Vielfaches\ von}\mspace{6mu}}7\}$
    ]{.math display="inline"
    role="math"}[$\mathsf{M = \{ x:x{\mspace{6mu}\text{ist\ Vielfaches\ von}\mspace{6mu}}7\}}$
    ]{.mathImpaired display="inline" role="math"}[\$M = \\{ x: x \\text{
    ist Vielfaches von }7 \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> oder
    [[$\{ x \in N:x{\mspace{6mu}\text{Vielfaches\ von}\mspace{6mu}}7\}$
    ]{.math display="inline"
    role="math"}[$\mathsf{\{ x \in N:x{\mspace{6mu}\text{Vielfaches\ von}\mspace{6mu}}7\}}$
    ]{.mathImpaired display="inline" role="math"}[\$\\{ x \\in N: x
    \\text{ Vielfaches von }7 \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--></font>

Weitere Grundnotation: Doppelpunkt zur Kennzeichnung von *Definitionen*.

#### <font color="#008000">Beispiel</font> 0.2. {#Content.xhtml#toc_12}

Wollen die Funktion [[$f$ ]{.math display="inline"
role="math"}[$\mathsf{f}$ ]{.mathImpaired display="inline"
role="math"}[\$f\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> definieren. Schreibe
(z.B.) [[$f(x):=x^{2}$ ]{.math display="inline"
role="math"}[$\mathsf{f(x):=x^{2}}$ ]{.mathImpaired display="inline"
role="math"}[\$f(x):=x\^2\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Nur bei einer
Neudefinition, nicht bei einer Gleichung. Oder
[[$\left. a:=15,f{\mspace{6mu}\text{heißt\ injektiv}\mspace{6mu}}:\Leftrightarrow{\mspace{6mu}\text{Für\ alle}\mspace{6mu}}a,\widetilde{a} \in M{\mspace{6mu}\text{mit}\mspace{6mu}}a \neq \widetilde{a} \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. a:=15,f{\mspace{6mu}\text{heißt\ injektiv}\mspace{6mu}}:\Leftrightarrow{\mspace{6mu}\text{Für\ alle}\mspace{6mu}}a,\widetilde{a} \in M{\mspace{6mu}\text{mit}\mspace{6mu}}a \neq \widetilde{a} \right.}$
]{.mathImpaired display="inline" role="math"}[\$a:=15, f \\text{ heißt
injektiv } : \\Leftrightarrow \\text{ Für alle } a, \\tilde{a} \\in M
\\text{ mit } a \\neq \\tilde{a}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> gilt\...

[[$a \in M$ ]{.math display="inline" role="math"}[$\mathsf{a \in M}$
]{.mathImpaired display="inline" role="math"}[\$a \\in M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (oder [[$M \ni a$ ]{.math
display="inline" role="math"}[$\mathsf{M \ni a}$ ]{.mathImpaired
display="inline" role="math"}[\$M \\ni a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->): [[$a$ ]{.math
display="inline" role="math"}[$\mathsf{a}$ ]{.mathImpaired
display="inline" role="math"}[\$a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist Element von [[$M$
]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->; [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> enthält [[$a$ ]{.math
display="inline" role="math"}[$\mathsf{a}$ ]{.mathImpaired
display="inline" role="math"}[\$a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
[[$a \notin M$ ]{.math display="inline"
role="math"}[$\mathsf{a \notin M}$ ]{.mathImpaired display="inline"
role="math"}[\$a \\notin M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (oder [[$M a$ ]{.math
display="inline" role="math"}[$\mathsf{M a}$ ]{.mathImpaired
display="inline" role="math"}[\$M \\notni a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->): analog s.o.\
[[$M = N$ ]{.math display="inline" role="math"}[$\mathsf{M = N}$
]{.mathImpaired display="inline" role="math"}[\$M = N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->: [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> enthält die selben
Elemente wie [[$N$ ]{.math display="inline" role="math"}[$\mathsf{N}$
]{.mathImpaired display="inline" role="math"}[\$N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
[[$M \neq N$ ]{.math display="inline" role="math"}[$\mathsf{M \neq N}$
]{.mathImpaired display="inline" role="math"}[\$M \\neq
N\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->: analog s.o.\
[[$M \subset N$ ]{.math display="inline"
role="math"}[$\mathsf{M \subset N}$ ]{.mathImpaired display="inline"
role="math"}[\$M \\subset N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (oder [[$M \subseteq N$
]{.math display="inline" role="math"}[$\mathsf{M \subseteq N}$
]{.mathImpaired display="inline" role="math"}[\$M \\subseteq
N\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->): [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist Tielmenge von [[$N$
]{.math display="inline" role="math"}[$\mathsf{N}$ ]{.mathImpaired
display="inline" role="math"}[\$N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, d.h. jedes Element von
[[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist auch ein Element von
[[$N$ ]{.math display="inline" role="math"}[$\mathsf{N}$ ]{.mathImpaired
display="inline" role="math"}[\$N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->; Gleichheit der Mengen
ist erlaubt.\
[[$N \supset M$ ]{.math display="inline"
role="math"}[$\mathsf{N \supset M}$ ]{.mathImpaired display="inline"
role="math"}[\$N \\supset M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (oder [[$N \supseteq M$
]{.math display="inline" role="math"}[$\mathsf{N \supseteq M}$
]{.mathImpaired display="inline" role="math"}[\$N \\supseteq
M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->): [[$N$ ]{.math
display="inline" role="math"}[$\mathsf{N}$ ]{.mathImpaired
display="inline" role="math"}[\$N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist Obermenge von [[$M$
]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->; analog\
[[$M \subsetneqq N$ ]{.math display="inline"
role="math"}[$\mathsf{M \subsetneqq N}$ ]{.mathImpaired display="inline"
role="math"}[\$M \\subsetneqq N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->: [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist echte Teilmenge von
[[$N$ ]{.math display="inline" role="math"}[$\mathsf{N}$ ]{.mathImpaired
display="inline" role="math"}[\$N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->; [[$M \neq N$ ]{.math
display="inline" role="math"}[$\mathsf{M \neq N}$ ]{.mathImpaired
display="inline" role="math"}[\$M \\neq N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
[[$\varnothing$ ]{.math display="inline"
role="math"}[$\mathsf{\varnothing}$ ]{.mathImpaired display="inline"
role="math"}[\$\\emptyset\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->: leere Menge

[[$M \cup N = \{ a:a \in M{\mspace{6mu}\text{oder}\mspace{6mu}}a \in N\}$
]{.math display="inline"
role="math"}[$\mathsf{M \cup N = \{ a:a \in M{\mspace{6mu}\text{oder}\mspace{6mu}}a \in N\}}$
]{.mathImpaired display="inline" role="math"}[\$M \\cup N = \\{ a: a
\\in M \\text{ oder } a \\in N\\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (Vereinigungsmenge)\
[[$M \cap N = \{ a:a \in M{\text{~und}\mspace{6mu}}a \in N\}$ ]{.math
display="inline"
role="math"}[$\mathsf{M \cap N = \{ a:a \in M{\text{~und}\mspace{6mu}}a \in N\}}$
]{.mathImpaired display="inline" role="math"}[\$M \\cap N = \\{ a: a
\\in M \\text{ und } a \\in N\\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (Schnittmenge)\
[[$M\backslash N = \{ a:a \in M{\mspace{6mu}\text{und}\mspace{6mu}}a \notin N\}$
]{.math display="inline"
role="math"}[$\mathsf{M\backslash N = \{ a:a \in M{\mspace{6mu}\text{und}\mspace{6mu}}a \notin N\}}$
]{.mathImpaired display="inline" role="math"}[\$M \\setminus N = \\{ a:
a \\in M \\text{ und } a \\notin N\\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (Komplementmenge)

[[$M,N$ ]{.math display="inline" role="math"}[$\mathsf{M,N}$
]{.mathImpaired display="inline" role="math"}[\$M,N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißen disjunkt, wenn
[[$M \cap N = \varnothing$ ]{.math display="inline"
role="math"}[$\mathsf{M \cap N = \varnothing}$ ]{.mathImpaired
display="inline" role="math"}[\$M \\cap N = \\emptyset\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
[[$P(M) = \{ N:N \subset M\}$ ]{.math display="inline"
role="math"}[$\mathsf{P(M) = \{ N:N \subset M\}}$ ]{.mathImpaired
display="inline" role="math"}[\$P(M) = \\{N: N\\subset
M\\}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->: Potenzmenge von [[$M$
]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (Menge aller Teilmengen)

Beispiel 0.3.

Beispiel für die Potenzmenge von [[$M = \{ 1,2\}$ ]{.math
display="inline" role="math"}[$\mathsf{M = \{ 1,2\}}$ ]{.mathImpaired
display="inline" role="math"}[\$M= \\{1,2\\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->:\
[[$P(M) = \{\{ 1,2\},\{ 1\},\{ 2\},\varnothing\}$ ]{.math
display="inline"
role="math"}[$\mathsf{P(M) = \{\{ 1,2\},\{ 1\},\{ 2\},\varnothing\}}$
]{.mathImpaired display="inline" role="math"}[\$P(M) = \\{ \\{ 1,2 \\} ,
\\{ 1 \\} , \\{ 2 \\} , \\emptyset \\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

0.2. Abbildungen {#Content.xhtml#toc_13}
----------------

Seien [[$M,N$ ]{.math display="inline" role="math"}[$\mathsf{M,N}$
]{.mathImpaired display="inline" role="math"}[\$M,N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> Mengen. Eine *Abbildung*
oder *Funktion* [[$f$ ]{.math display="inline" role="math"}[$\mathsf{f}$
]{.mathImpaired display="inline" role="math"}[\$f\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> von [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> nach [[$N$ ]{.math
display="inline" role="math"}[$\mathsf{N}$ ]{.mathImpaired
display="inline" role="math"}[\$N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist eine Vorschrift, die
jedem Element [[$a \in M$ ]{.math display="inline"
role="math"}[$\mathsf{a \in M}$ ]{.mathImpaired display="inline"
role="math"}[\$a \\in M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> in eindeutiger Weise ein
[[$f(a) \in N$ ]{.math display="inline"
role="math"}[$\mathsf{f(a) \in N}$ ]{.mathImpaired display="inline"
role="math"}[\$f(a) \\in N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> zuordnet.

**Notation:** [[$\left. f:M\rightarrow N,a\rightarrow f(a) \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. f:M\rightarrow N,a\rightarrow f(a) \right.}$
]{.mathImpaired display="inline" role="math"}[\$f: M \\rightarrow N, a
\\rightarrow f(a)\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

### <font color="#008000">Beispiel</font> 0.4.

\

[[$M = N = \mathbb{R},f:\left\{ \begin{array}{l}
\left. \mathbb{R}\leftarrow\mathbb{R} \right. \\
\left. x\mapsto x^{2} \right. \\
\end{array} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{M = N = \mathbb{R},f:\left\{ \begin{array}{l}
\left. \mathbb{R}\leftarrow\mathbb{R} \right. \\
\left. x\mapsto x^{2} \right. \\
\end{array} \right.}$ ]{.mathImpaired display="inline" role="math"}[\$M
= N = \\mathbb{R}, f: \\begin{cases} \\mathbb{R} \\leftarrow \\mathbb{R}
\\\\ x \\mapsto x\^2 \\end{cases}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\

![Eine Abbildung von Real nach Real, macht x zu x
quadrat](Images/Beispiel%200.4..svg "Beispiel 0.4."){.toRemove}

\
[[$\left. f_{1}:M_{1}\rightarrow N_{1} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. f_{1}:M_{1}\rightarrow N_{1} \right.}$
]{.mathImpaired display="inline" role="math"}[\$f\_1: M\_1 \\rightarrow
N\_1\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und
[[$\left. f_{2}:M_{2}\rightarrow N_{2} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. f_{2}:M_{2}\rightarrow N_{2} \right.}$
]{.mathImpaired display="inline" role="math"}[\$f\_2: M\_2 \\rightarrow
N\_2\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heissen *gleich* (kurz
[[$f_{1}f_{2}$ ]{.math display="inline"
role="math"}[$\mathsf{f_{1}f_{2}}$ ]{.mathImpaired display="inline"
role="math"}[\$f\_1 f\_2\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->) (identisch), wenn
[[$M_{1} = M_{2},N_{1} = N_{2}$ ]{.math display="inline"
role="math"}[$\mathsf{M_{1} = M_{2},N_{1} = N_{2}}$ ]{.mathImpaired
display="inline" role="math"}[\$M\_1=M\_2, N\_1=N\_2\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und
[[$f_{1}(a) = f_{2}(a)$ ]{.math display="inline"
role="math"}[$\mathsf{f_{1}(a) = f_{2}(a)}$ ]{.mathImpaired
display="inline" role="math"}[\$f\_1(a)=f\_2(a)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> für alle [[$a \in M_{1}$
]{.math display="inline" role="math"}[$\mathsf{a \in M_{1}}$
]{.mathImpaired display="inline" role="math"}[\$a \\in
M\_1\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
\

[[$\left. f:M\rightarrow N \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. f:M\rightarrow N \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$f:M \\rightarrow N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heisst

-   *injektiv*, wenn für alle [[$a,\widetilde{a} \in M$ ]{.math
    display="inline" role="math"}[$\mathsf{a,\widetilde{a} \in M}$
    ]{.mathImpaired display="inline" role="math"}[\$a, \\tilde{a} \\in
    M\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> mit
    [[$a \neq \widetilde{a}$ ]{.math display="inline"
    role="math"}[$\mathsf{a \neq \widetilde{a}}$ ]{.mathImpaired
    display="inline" role="math"}[\$a \\neq \\tilde{a}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> gilt:
    [[$f(a) \neq f(\widetilde{a})$ ]{.math display="inline"
    role="math"}[$\mathsf{f(a) \neq f(\widetilde{a})}$ ]{.mathImpaired
    display="inline" role="math"}[\$f(a) \\neq
    f(\\tilde{a})\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->;
    ([[$\left. x\mapsto x \right.$ ]{.math display="inline"
    role="math"}[$\mathsf{\left. x\mapsto x \right.}$ ]{.mathImpaired
    display="inline" role="math"}[\$x \\mapsto x\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist injektiv,
    [[$\left. x\mapsto x^{2} \right.$ ]{.math display="inline"
    role="math"}[$\mathsf{\left. x\mapsto x^{2} \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$x \\mapsto
    x\^2\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nicht)
-   *surjektiv*, wenn für alle [[$\widetilde{a} \in M$ ]{.math
    display="inline" role="math"}[$\mathsf{\widetilde{a} \in M}$
    ]{.mathImpaired display="inline" role="math"}[\$\\tilde{a} \\in
    M\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ein [[$a \in M$
    ]{.math display="inline" role="math"}[$\mathsf{a \in M}$
    ]{.mathImpaired display="inline" role="math"}[\$a \\in
    M\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> existiert mit
    [[$f(a) = \widetilde{a}$ ]{.math display="inline"
    role="math"}[$\mathsf{f(a) = \widetilde{a}}$ ]{.mathImpaired
    display="inline" role="math"}[\$f(a)=\\tilde{a}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> (die Bildmenge wird
    voll ausgeschöpft)
-   *bijektiv*, wenn [[$f$ ]{.math display="inline"
    role="math"}[$\mathsf{f}$ ]{.mathImpaired display="inline"
    role="math"}[\$f\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> sowohl injektiv als
    aus surjektiv ist: eindeutige Zuordnung\

Für [[$M_{1} \subset M$ ]{.math display="inline"
role="math"}[$\mathsf{M_{1} \subset M}$ ]{.mathImpaired display="inline"
role="math"}[\$M\_1 \\subset M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heisst
[[$f(M_{1}) = f(a):a \in M_{1}$ ]{.math display="inline"
role="math"}[$\mathsf{f(M_{1}) = f(a):a \in M_{1}}$ ]{.mathImpaired
display="inline" role="math"}[\$f(M\_1) = f(a): a \\in
M\_1\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> Bildmenge von [[$M_{1}$
]{.math display="inline" role="math"}[$\mathsf{M_{1}}$ ]{.mathImpaired
display="inline" role="math"}[\$M\_1\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (unter [[$f$ ]{.math
display="inline" role="math"}[$\mathsf{f}$ ]{.mathImpaired
display="inline" role="math"}[\$f\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->).\
Für [[$N_{1} \subset N$ ]{.math display="inline"
role="math"}[$\mathsf{N_{1} \subset N}$ ]{.mathImpaired display="inline"
role="math"}[\$N\_1 \\subset N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heisst
[[$f^{- 1}(N_{1}) = a \in M:f(a) \in N_{1}$ ]{.math display="inline"
role="math"}[$\mathsf{f^{- 1}(N_{1}) = a \in M:f(a) \in N_{1}}$
]{.mathImpaired display="inline" role="math"}[\$f\^{-1}(N\_1) = a \\in M
: f(a) \\in N\_1\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> *Urbildmenge* von
[[$N_{1}$ ]{.math display="inline" role="math"}[$\mathsf{N_{1}}$
]{.mathImpaired display="inline" role="math"}[\$N\_1\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (unter [[$f$ ]{.math
display="inline" role="math"}[$\mathsf{f}$ ]{.mathImpaired
display="inline" role="math"}[\$f\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->).\
Sind [[$\left. f:M\rightarrow N \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. f:M\rightarrow N \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$f:M \\rightarrow N\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und
[[$\left. g:N\rightarrow P \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. g:N\rightarrow P \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$g: N \\rightarrow P\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> Abbildungen, so heisst
die Abbildung

[[$g \circ f:\left\{ \begin{array}{l}
\left. M\leftarrow P \right. \\
\left. a\mapsto g(f(a)) \right. \\
\end{array} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{g \circ f:\left\{ \begin{array}{l}
\left. M\leftarrow P \right. \\
\left. a\mapsto g(f(a)) \right. \\
\end{array} \right.}$ ]{.mathImpaired display="inline" role="math"}[\$g
\\circ f : \\begin{cases} M \\leftarrow P \\\\ a \\mapsto g(f(a))
\\end{cases}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\

![g kreis
f](Images/Beispiel%20Hintereinanderausfuehrung.svg "Beispiel Hintereinanderausfuehrung"){.toRemove}

\

*Hintereinanderausführung* von [[$f$ ]{.math display="inline"
role="math"}[$\mathsf{f}$ ]{.mathImpaired display="inline"
role="math"}[\$f\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[$g$ ]{.math
display="inline" role="math"}[$\mathsf{g}$ ]{.mathImpaired
display="inline" role="math"}[\$g\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

0.3 Aussagen
------------

Unter einer *Aussage* verstehen wir ein sprachliches oder gedankliches
Gefüge, welches entweder wahr oder falsch ist.

##### Beispiel 0.5.

-   \"4 ist eine gerade Zahl\" ist eine wahre Aussage.
-   \"Bananen sind kugelförmig\" ist eine falsche Aussage.
-   \"Nachts ist es kälter als draussen\" ist keine Aussage.
-   \"Es gibt unendlich viele Sterne\" ist eine Aussage, die wahr oder
    falsch sein kann.

Sind [[$A,B$ ]{.math display="inline" role="math"}[$\mathsf{A,B}$
]{.mathImpaired display="inline" role="math"}[\$A,B\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> Aussagen, so sind die
Aussagen
[[$\left. \neg A,A \land B,A \vee B,A\dot{\vee}B,A\Rightarrow B,A\Leftrightarrow B \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. \neg A,A \land B,A \vee B,A\dot{\vee}B,A\Rightarrow B,A\Leftrightarrow B \right.}$
]{.mathImpaired display="inline" role="math"}[\$\\neg A, A \\wedge B, A
\\vee B, A \\dot{\\vee} B, A \\Rightarrow B, A \\Leftrightarrow
B\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> erklärt durch:

-   [[$\neg A$ ]{.math display="inline" role="math"}[$\mathsf{\neg A}$
    ]{.mathImpaired display="inline" role="math"}[\$\\neg
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: [[$A$ ]{.math
    display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
    display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist falsch (Negation)
-   [[$A \land B$ ]{.math display="inline"
    role="math"}[$\mathsf{A \land B}$ ]{.mathImpaired display="inline"
    role="math"}[\$A \\wedge B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: [[$A$ ]{.math
    display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
    display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> und [[$B$ ]{.math
    display="inline" role="math"}[$\mathsf{B}$ ]{.mathImpaired
    display="inline" role="math"}[\$B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> sind beide wahr (und)
-   [[$A \vee B$ ]{.math display="inline"
    role="math"}[$\mathsf{A \vee B}$ ]{.mathImpaired display="inline"
    role="math"}[\$A \\vee B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: [[$A$ ]{.math
    display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
    display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> oder [[$B$ ]{.math
    display="inline" role="math"}[$\mathsf{B}$ ]{.mathImpaired
    display="inline" role="math"}[\$B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist wahr (oder)
-   [[$A\dot{\vee}B$ ]{.math display="inline"
    role="math"}[$\mathsf{A\dot{\vee}B}$ ]{.mathImpaired
    display="inline" role="math"}[\$A \\dot{\\vee} B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: entweder [[$A$
    ]{.math display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
    display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> oder [[$B$ ]{.math
    display="inline" role="math"}[$\mathsf{B}$ ]{.mathImpaired
    display="inline" role="math"}[\$B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist wahr (excl. oder)
-   [[$AB$ ]{.math display="inline" role="math"}[$\mathsf{AB}$
    ]{.mathImpaired display="inline" role="math"}[\$A B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: aus [[$A$ ]{.math
    display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
    display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> folgt [[$B$ ]{.math
    display="inline" role="math"}[$\mathsf{B}$ ]{.mathImpaired
    display="inline" role="math"}[\$B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->; wenn [[$A$ ]{.math
    display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
    display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> wahr ist, dann ist
    auch [[$B$ ]{.math display="inline" role="math"}[$\mathsf{B}$
    ]{.mathImpaired display="inline" role="math"}[\$B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> wahr (Implikation)\
    (ist immer wahr, wenn [[$A$ ]{.math display="inline"
    role="math"}[$\mathsf{A}$ ]{.mathImpaired display="inline"
    role="math"}[\$A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> falsch ist; ist
    nur dann falsch, wenn [[$B$ ]{.math display="inline"
    role="math"}[$\mathsf{B}$ ]{.mathImpaired display="inline"
    role="math"}[\$B\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> falsch ist)\
    Bsp: \"Wenn Bananen kugelförmig sind, ist 4 gerade.\" ist eine wahre
    Aussage.
-   [[$\left. A\Leftrightarrow B \right.$ ]{.math display="inline"
    role="math"}[$\mathsf{\left. A\Leftrightarrow B \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$A \\Leftrightarrow
    B\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: [[$A$ ]{.math
    display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
    display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist genau dann wahr,
    wenn [[$B$ ]{.math display="inline" role="math"}[$\mathsf{B}$
    ]{.mathImpaired display="inline" role="math"}[\$B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> wahr ist.
    (Äquivalenz)

Sei [[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$
]{.mathImpaired display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine Menge und [[$E$
]{.math display="inline" role="math"}[$\mathsf{E}$ ]{.mathImpaired
display="inline" role="math"}[\$E\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine Eigenschaft, die ein
Element [[$a \in M$ ]{.math display="inline"
role="math"}[$\mathsf{a \in M}$ ]{.mathImpaired display="inline"
role="math"}[\$a \\in M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> haben kann. Dann sind
folgende Aussagen machbar:

-   [[$\forall_{a \in M}a$ ]{.math display="inline"
    role="math"}[$\mathsf{\forall_{a \in M}a}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\forall\_{a \\in M}
    a\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> hat die Eigenschaft
    [[$E$ ]{.math display="inline" role="math"}[$\mathsf{E}$
    ]{.mathImpaired display="inline" role="math"}[\$E\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: jedes [[$a \in M$
    ]{.math display="inline" role="math"}[$\mathsf{a \in M}$
    ]{.mathImpaired display="inline" role="math"}[\$a \\in
    M\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> hat die Eigenschaft
    [[$E$ ]{.math display="inline" role="math"}[$\mathsf{E}$
    ]{.mathImpaired display="inline" role="math"}[\$E\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ([[$\forall$ ]{.math
    display="inline" role="math"}[$\mathsf{\forall}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\forall\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> heisst *All-Quantor*)

((Seite4))

-   [[$\exists_{a \in M}a$ ]{.math display="inline"
    role="math"}[$\mathsf{\exists_{a \in M}a}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\exists\_{a \\in M}
    a\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> hat die Eigenschaft
    [[$E$ ]{.math display="inline" role="math"}[$\mathsf{E}$
    ]{.mathImpaired display="inline" role="math"}[\$E\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: es existiert ein
    [[$a \in M$ ]{.math display="inline" role="math"}[$\mathsf{a \in M}$
    ]{.mathImpaired display="inline" role="math"}[\$a \\in
    M\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> mit der Eigenschaft
    [[$E$ ]{.math display="inline" role="math"}[$\mathsf{E}$
    ]{.mathImpaired display="inline" role="math"}[\$E\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ([[$\exists$ ]{.math
    display="inline" role="math"}[$\mathsf{\exists}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\exists\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> heisst
    *Existenzquantor*)
-   [[$\exists_{a \in M}^{1}a$ ]{.math display="inline"
    role="math"}[$\mathsf{\exists_{a \in M}^{1}a}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\exists\^1\_{a \\in M}
    a\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> hat die Eigenschaft
    [[$E$ ]{.math display="inline" role="math"}[$\mathsf{E}$
    ]{.mathImpaired display="inline" role="math"}[\$E\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->: es existiert *genau
    ein* [[$a \in M$ ]{.math display="inline"
    role="math"}[$\mathsf{a \in M}$ ]{.mathImpaired display="inline"
    role="math"}[\$a \\in M\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> mit der Eigenschaft
    [[$E$ ]{.math display="inline" role="math"}[$\mathsf{E}$
    ]{.mathImpaired display="inline" role="math"}[\$E\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

Grundsätzliches Ziel der Mathematik: Möglichst viele nichttriviale
Aussagen über gewisse Objekte. Ein solches gedankliches Gebäude kann
nicht aus dem \"Nichts\" kommen. Start des mathematischen Denkens:
Grundannahmen, *Axiome*, die nicht bewiesen werden können.

Insbesondere brauchen wir Axiome, die uns die *Zahlen* liefern.

Möglichkeiten:

-   Peano-*Axiome* liefern die natürlichen Zahlen [[$\mathbb{N}$ ]{.math
    display="inline" role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, daraus lassen sich
    ganze Zahlen und rationale Zahlen *konstruieren*. Ein weiteres Axiom
    lierfert die reellen Zahlen [[$\mathbb{R}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{R}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{R}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, woraus auch die
    komplexen Zahlen konstruierbar sind.
-   Wir können die Axiome sofort auf der Ebene der reellen Zahlen
    fordern. Das wollen wir auch im Folgenden tun.

((Seite5))

((Seite6))

1. Zahlen
=========

1.1 Reelle Zahlen
-----------------

Axiomatische Forderung: Es gibt eine Menge [[$\mathbb{R}$ ]{.math
display="inline" role="math"}[$\mathsf{\mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$\\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, genannt die Menge der
reellen Zahlen, mit folgenden Eigenschaften:

1.2. Axiome der reellen Zahlen
------------------------------

### 1.2.1. Körperaxiome 

In [[$\mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{\mathbb{R}}$ ]{.mathImpaired display="inline"
role="math"}[\$\\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> seien zwei Verknüpfungen
[[$+ , \cdot$ ]{.math display="inline" role="math"}[$\mathsf{+ , \cdot}$
]{.mathImpaired display="inline" role="math"}[\$+,\\cdot\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> gegeben, die jedem Paar
[[$a,b \in \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{a,b \in \mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$a, b \\in \\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> genau ein
[[$a + b \in \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{a + b \in \mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$a+b \\in \\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und ein
[[$a \cdot b \in \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{a \cdot b \in \mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$a \\cdot b \\in
\\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> zuordnen. Dabei sollte
gelten:

**A1: Assoziativgesetz der Addition**

![Die Addition ist
assoziativ](Images/Assoziativgesetz%20der%20Addition.svg "Assoziativgesetz der Addition"){.toRemove}

**A2: neutrales Element der Addition\
**[[$\exists 0 \in \mathbb{R}\forall a \in \mathbb{R}a + 0 = a$ ]{.math
display="inline"
role="math"}[$\mathsf{\exists 0 \in \mathbb{R}\forall a \in \mathbb{R}a + 0 = a}$
]{.mathImpaired display="inline" role="math"}[\$\\exists 0 \\in
\\mathbb{R} \\forall a \\in \\mathbb{R} a+0=a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

**A3: inverses Element der Addition\
**[[$\forall a \in \mathbb{R}\exists( - a) \in \mathbb{R}a + ( - a) = 0$
]{.math display="inline"
role="math"}[$\mathsf{\forall a \in \mathbb{R}\exists( - a) \in \mathbb{R}a + ( - a) = 0}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a \\in
\\mathbb{R} \\exists (-a) \\in \\mathbb{R} a+ (-a) =0\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

**A4: Kommutativgesetz der Addition\
**[[$\forall a,b \in \mathbb{R}a + b = b + a$ ]{.math display="inline"
role="math"}[$\mathsf{\forall a,b \in \mathbb{R}a + b = b + a}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b \\in
\\mathbb{R} a+b=b+a\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
\

A1 bis A4 ergibt: ([[$\mathbb{R}, +$ ]{.math display="inline"
role="math"}[$\mathsf{\mathbb{R}, +}$ ]{.mathImpaired display="inline"
role="math"}[\$\\mathbb{R}, +\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->) ist eine *kommutative
Gruppe*.\

**A5: Assoziativgesetz der Multiplikation\
**[[$\forall a,b,c \in \mathbb{R}(a \cdot b) \cdot c = a \cdot (b \cdot c)$
]{.math display="inline"
role="math"}[$\mathsf{\forall a,b,c \in \mathbb{R}(a \cdot b) \cdot c = a \cdot (b \cdot c)}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b,c \\in
\\mathbb{R} (a \\cdot b) \\cdot c = a \\cdot (b \\cdot
c)\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

**A6: neutrales Element der Multiplikation\
**[[$\exists 1 \in \mathbb{R}\forall a \in \mathbb{R}a \cdot 1 = a,1 \neq 0$
]{.math display="inline"
role="math"}[$\mathsf{\exists 1 \in \mathbb{R}\forall a \in \mathbb{R}a \cdot 1 = a,1 \neq 0}$
]{.mathImpaired display="inline" role="math"}[\$\\exists 1 \\in
\\mathbb{R} \\forall a \\in \\mathbb{R} a \\cdot 1=a, 1 \\neq
0\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

**A7: inverses Element der Multiplikation\
**[[$\forall a \in \mathbb{R}\backslash\{ 0\}\exists a^{- 1} \in \mathbb{R}a \cdot a^{- 1} = 1$
]{.math display="inline"
role="math"}[$\mathsf{\forall a \in \mathbb{R}\backslash\{ 0\}\exists a^{- 1} \in \mathbb{R}a \cdot a^{- 1} = 1}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a \\in
\\mathbb{R} \\setminus \\{0\\} \\exists a\^{-1} \\in \\mathbb{R} a
\\cdot a\^{-1}=1\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

**A8: Kommutitativgesetz der Multiplikation\
**[[$\forall a,b \in \mathbb{R}a \cdot b = b \cdot a$ ]{.math
display="inline"
role="math"}[$\mathsf{\forall a,b \in \mathbb{R}a \cdot b = b \cdot a}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b \\in
\\mathbb{R} a \\cdot b=b \\cdot a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

A5 bis A8 ergibt: ([[$\mathbb{R}\backslash\{ 0\}, \cdot$ ]{.math
display="inline"
role="math"}[$\mathsf{\mathbb{R}\backslash\{ 0\}, \cdot}$
]{.mathImpaired display="inline" role="math"}[\$\\mathbb{R} \\setminus
\\{ 0 \\}, \\cdot\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->) ist eine *kommutative
Gruppe*.\

**A9: Distributivgesetz\
**[[$\forall a,b,c \in \mathbb{R}a \cdot (b + c) = a \cdot b + a \cdot c$
]{.math display="inline"
role="math"}[$\mathsf{\forall a,b,c \in \mathbb{R}a \cdot (b + c) = a \cdot b + a \cdot c}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b,c \\in
\\mathbb{R} a \\cdot (b+c) = a \\cdot b + a \\cdot c\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

A1 bis A9 ergibt: [[$(\mathbb{R}, + , \cdot )$ ]{.math display="inline"
role="math"}[$\mathsf{(\mathbb{R}, + , \cdot )}$ ]{.mathImpaired
display="inline" role="math"}[\$( \\mathbb{R},+, \\cdot
)\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist ein *Körper*.

Alle bekannten Regeln der Grundrechenarten lassen sich aus A1 bis A9
herleiten und seien von nun an bekannt.

Schreibweise:

Für [[$a,b \in \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{a,b \in \mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$a,b \\in\\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->:\
[[$ab:=a \cdot b$ ]{.math display="inline"
role="math"}[$\mathsf{ab:=a \cdot b}$ ]{.mathImpaired display="inline"
role="math"}[\$ab := a \\cdot b\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
[[$a - b:=a + ( - b)$ ]{.math display="inline"
role="math"}[$\mathsf{a - b:=a + ( - b)}$ ]{.mathImpaired
display="inline" role="math"}[\$a-b := a + (-b)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
falls [[$a \neq 0:=\frac{a}{b}:=ba^{- 1}$ ]{.math display="inline"
role="math"}[$\mathsf{a \neq 0:=\frac{a}{b}:=ba^{- 1}}$ ]{.mathImpaired
display="inline" role="math"}[\$a \\neq 0 := \\frac{a}{b} :=
ba\^{-1}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

#### Biespiel 1.1.

1.  Das Nullement 0 ist eindeutig:\
    Sei [[$\widetilde{0}$ ]{.math display="inline"
    role="math"}[$\mathsf{\widetilde{0}}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\tilde{0}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> weiteres Element mit
    [[$\forall a \in \mathbb{R}a + \widetilde{0} = a$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\forall a \in \mathbb{R}a + \widetilde{0} = a}$
    ]{.mathImpaired display="inline" role="math"}[\$\\forall a \\in
    \\mathbb{R} a+ \\tilde{0} =a\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    Dann: [[$\widetilde{0} = \widetilde{0}0 = 0\widetilde{0} = 0$
    ]{.math display="inline"
    role="math"}[$\mathsf{\widetilde{0} = \widetilde{0}0 = 0\widetilde{0} = 0}$
    ]{.mathImpaired display="inline" role="math"}[\$\\tilde{0} =
    \\tilde{0}0 = 0 \\tilde{0} = 0\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
2.  [[$\forall a \in \mathbb{R}a \cdot 0 = 0$ ]{.math display="inline"
    role="math"}[$\mathsf{\forall a \in \mathbb{R}a \cdot 0 = 0}$
    ]{.mathImpaired display="inline" role="math"}[\$\\forall a \\in
    \\mathbb{R} a \\cdot 0 =0\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->:\
    [[$a \cdot 0 = a \cdot (0 + 0) = a \cdot 0 + a \cdot 0\quad| - (a \cdot 0)$
    ]{.math display="inline"
    role="math"}[$\mathsf{a \cdot 0 = a \cdot (0 + 0) = a \cdot 0 + a \cdot 0\quad| - (a \cdot 0)}$
    ]{.mathImpaired display="inline" role="math"}[\$a \\cdot 0 = a
    \\cdot (0+0) = a \\cdot 0 + a \\cdot 0 \\quad \\vert -(a \\cdot
    0)\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$0 = a \cdot 0$ ]{.math display="inline"
    role="math"}[$\mathsf{0 = a \cdot 0}$ ]{.mathImpaired
    display="inline" role="math"}[\$0= a \\cdot 0\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
3.  [[$\forall a \in \mathbb{R}a^{2} = ( - a)^{2}({\text{wobei:}\mspace{6mu}}a^{2} = a \cdot a)$
    ]{.math display="inline"
    role="math"}[$\mathsf{\forall a \in \mathbb{R}a^{2} = ( - a)^{2}({\text{wobei:}\mspace{6mu}}a^{2} = a \cdot a)}$
    ]{.mathImpaired display="inline" role="math"}[\$\\forall a \\in
    \\mathbb{R} a\^2 = (-a)\^2 ( \\text{wobei: } a\^2 = a \\cdot
    a)\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->:\
    [[$a^{2} = a \cdot a = a \cdot (a + a - a) = a \cdot (a + a) + a \cdot ( - a)$
    ]{.math display="inline"
    role="math"}[$\mathsf{a^{2} = a \cdot a = a \cdot (a + a - a) = a \cdot (a + a) + a \cdot ( - a)}$
    ]{.mathImpaired display="inline" role="math"}[\$a\^2 = a \\cdot a =
    a \\cdot (a+a-a) = a\\cdot (a+a)+a \\cdot (-a)\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$= a \cdot (a + a) + ( - a) \cdot (a + a - a) = a \cdot (a + a) + ( - a) \cdot (a + a) + ( - a) \cdot ( - a)$
    ]{.math display="inline"
    role="math"}[$\mathsf{= a \cdot (a + a) + ( - a) \cdot (a + a - a) = a \cdot (a + a) + ( - a) \cdot (a + a) + ( - a) \cdot ( - a)}$
    ]{.mathImpaired display="inline" role="math"}[\$= a \\cdot (a+a) +
    (-a) \\cdot (a+a-a) = a \\cdot (a+a) + (-a) \\cdot (a+a)+ (-a)
    \\cdot (-a)\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$= (a + a) \cdot (a - a) + ( - a)^{2} = (a + a) \cdot 0 + ( - a)^{2} = ( - a)2$
    ]{.math display="inline"
    role="math"}[$\mathsf{= (a + a) \cdot (a - a) + ( - a)^{2} = (a + a) \cdot 0 + ( - a)^{2} = ( - a)2}$
    ]{.mathImpaired display="inline" role="math"}[\$= (a+a) \\cdot
    (a-a) + (-a)\^2 = (a+a) \\cdot 0 + (-a)\^2 = (-a)2\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

### 1.2.2 Anordnungsaxiome

In [[$\mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{\mathbb{R}}$ ]{.mathImpaired display="inline"
role="math"}[\$\\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist eine Relation
[[$\leq$ ]{.math display="inline" role="math"}[$\mathsf{\leq}$
]{.mathImpaired display="inline" role="math"}[\$\\leq\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> gegeben, für die gilt:

**A10**\
[[$\forall a,b \in \mathbb{R}\lbrack a \leq b \vee b \leq a\rbrack$
]{.math display="inline"
role="math"}[$\mathsf{\forall a,b \in \mathbb{R}\lbrack a \leq b \vee b \leq a\rbrack}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b
\\in \\mathbb{R} \[a \\leq b \\vee b \\leq a\]\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

**A11**\
[[$\left. \forall a,b \in \mathbb{R}\lbrack(a \leq b \land b \leq a)\Rightarrow a = b\rbrack \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. \forall a,b \in \mathbb{R}\lbrack(a \leq b \land b \leq a)\Rightarrow a = b\rbrack \right.}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b \\in
\\mathbb{R} \[(a \\leq b \\wedge b \\leq a) \\Rightarrow
a=b\]\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

((Seite8))

**A12**\
[[$\left. \forall a,b,c \in \mathbb{R}\lbrack(a \leq b \land b \leq c)\Rightarrow a \leq c\rbrack \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. \forall a,b,c \in \mathbb{R}\lbrack(a \leq b \land b \leq c)\Rightarrow a \leq c\rbrack \right.}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b,c \\in
\\mathbb{R}  \[(a \\leq b \\wedge b \\leq c) \\Rightarrow a \\leq
c\]\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

[[$\left. \Rightarrow\mathbb{R} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. \Rightarrow\mathbb{R} \right.}$
]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow
\\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist eine total geordnete
Menge.

**A13**\
[[$\left. \forall a,b,c \in \mathbb{R}\lbrack(a \leq b)\Rightarrow(a + c \leq b + c)\rbrack \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. \forall a,b,c \in \mathbb{R}\lbrack(a \leq b)\Rightarrow(a + c \leq b + c)\rbrack \right.}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b,c \\in
\\mathbb{R} \[(a \\leq b) \\Rightarrow (a+c \\leq b+c)\]\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

**A14**\
[[$\left. \forall a,b,c \in \mathbb{R}\lbrack(a \leq b \land 0 \leq c)\Rightarrow a \cdot \leq b \cdot c\rbrack \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. \forall a,b,c \in \mathbb{R}\lbrack(a \leq b \land 0 \leq c)\Rightarrow a \cdot \leq b \cdot c\rbrack \right.}$
]{.mathImpaired display="inline" role="math"}[\$\\forall a,b,c \\in
\\mathbb{R} \[(a \\leq b \\wedge 0 \\leq c) \\Rightarrow a \\cdot \\leq
b \\cdot c\]\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

Schreibweisen: [[$\forall a,b \in \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{\forall a,b \in \mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$\\forall a,b \\in
\\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

-   [[$\left. b \geq a:\Leftrightarrow a \leq b \right.$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\left. b \geq a:\Leftrightarrow a \leq b \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$b \\geq a :
    \\Leftrightarrow a \\leq b\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
-   [[[\$a &lt; b : \\Leftrightarrow (a \\leq b \\wedge a \\neq
    b)\$]{.math .inline} ]{.math display="inline" role="math"}[[\$a &lt;
    b : \\Leftrightarrow (a \\leq b \\wedge a \\neq b)\$]{.math .inline}
    ]{.mathImpaired display="inline" role="math"}[\$a \< b :
    \\Leftrightarrow (a \\leq b \\wedge a \\neq b)\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
-   [[[\$b &gt; a: \\Leftrightarrow a &lt; b\$]{.math .inline} ]{.math
    display="inline" role="math"}[[\$b &gt; a: \\Leftrightarrow a &lt;
    b\$]{.math .inline} ]{.mathImpaired display="inline"
    role="math"}[\$b \> a: \\Leftrightarrow a \< b\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

Alle bekannten Regeln für Ungleichungen lassen sich aus A1 bis A14
herleiten und seien von nun an bekannt.

Beispiel 1.2.

1.  [[$\left. \forall a,b,c \in \mathbb{R}\lbrack a \leq b \land c \leq 0)\Rightarrow a \cdot c \leq b \cdot c\rbrack \right.$
    ]{.math display="inline"
    role="math"}[$\mathsf{\left. \forall a,b,c \in \mathbb{R}\lbrack a \leq b \land c \leq 0)\Rightarrow a \cdot c \leq b \cdot c\rbrack \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\forall a,b,c \\in
    \\mathbb{R} \[a \\leq b \\wedge c \\leq 0) \\Rightarrow a \\cdot c
    \\leq b\\cdot c\]\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    **Beweis:**\
    [[$\left. c \leq 0\Rightarrow 0 \leq - c \right.$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\left. c \leq 0\Rightarrow 0 \leq - c \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$c \\leq 0
    \\Rightarrow 0 \\leq -c\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$\left. \Rightarrow a \cdot ( - c) \leq b \cdot ( - c) \right.$
    ]{.math display="inline"
    role="math"}[$\mathsf{\left. \Rightarrow a \cdot ( - c) \leq b \cdot ( - c) \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow a
    \\cdot (-c) \\leq b \\cdot (-c)\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$\left. \Rightarrow bc \leq ac \right.$ ]{.math display="inline"
    role="math"}[$\mathsf{\left. \Rightarrow bc \leq ac \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow bc
    \\leq ac\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\square\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
2.  [[[\$\\forall a,b,c \\in \\mathbb{R} \[(a \\leq b \\wedge c&gt;0)
    \\Rightarrow a \\cdot c \\leq b \\cdot c\]\$]{.math .inline} ]{.math
    display="inline" role="math"}[[\$\\forall a,b,c \\in \\mathbb{R}
    \[(a \\leq b \\wedge c&gt;0) \\Rightarrow a \\cdot c \\leq b \\cdot
    c\]\$]{.math .inline} ]{.mathImpaired display="inline"
    role="math"}[\$\\forall a,b,c \\in \\mathbb{R} \[(a \\leq b \\wedge
    c\>0) \\Rightarrow a \\cdot c \\leq b \\cdot c\]\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

Betrag einer reellen Zahl:\
[[$\forall a \in \mathbb{R}|a|:=\left\{ \begin{array}{lc}
{a{\mspace{6mu}\text{falls}\mspace{6mu}}a \geq 0} & \\
{- a{\mspace{6mu}\text{falls}\mspace{6mu}}a} & {lt;0} \\
\end{array} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\forall a \in \mathbb{R}|a|:=\left\{ \begin{array}{lc}
{a{\mspace{6mu}\text{falls}\mspace{6mu}}a \geq 0} & \\
{- a{\mspace{6mu}\text{falls}\mspace{6mu}}a} & {lt;0} \\
\end{array} \right.}$ ]{.mathImpaired display="inline"
role="math"}[\$\\forall a \\in \\mathbb{R} \|a\| := \\begin{cases} a
\\text{ falls } a \\geq 0 \\\\ -a \\text{ falls } a \< 0
\\end{cases}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\

[[$|a|$ ]{.math display="inline" role="math"}[$\mathsf{|a|}$
]{.mathImpaired display="inline" role="math"}[\$\|a\|\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->: Abstand von [[$a$
]{.math display="inline" role="math"}[$\mathsf{a}$ ]{.mathImpaired
display="inline" role="math"}[\$a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> zur 0\
[[$|a - b|$ ]{.math display="inline" role="math"}[$\mathsf{|a - b|}$
]{.mathImpaired display="inline" role="math"}[\$\|a-b\|\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->: Abstand von [[$a$
]{.math display="inline" role="math"}[$\mathsf{a}$ ]{.mathImpaired
display="inline" role="math"}[\$a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[$b$ ]{.math
display="inline" role="math"}[$\mathsf{b}$ ]{.mathImpaired
display="inline" role="math"}[\$b\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

1.  [[$|a| \geq 0$ ]{.math display="inline"
    role="math"}[$\mathsf{|a| \geq 0}$ ]{.mathImpaired display="inline"
    role="math"}[\$\|a\| \\geq 0\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
2.  [[$\left. |a| = 0\Leftrightarrow a = 0 \right.$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\left. |a| = 0\Leftrightarrow a = 0 \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\|a\| = 0
    \\Leftrightarrow a=0\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
3.  [[$|a| = | - a|$ ]{.math display="inline"
    role="math"}[$\mathsf{|a| = | - a|}$ ]{.mathImpaired
    display="inline" role="math"}[\$\|a\| = \|-a\|\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
4.  [[$|a \cdot b| = |a| \cdot |b|$ ]{.math display="inline"
    role="math"}[$\mathsf{|a \cdot b| = |a| \cdot |b|}$ ]{.mathImpaired
    display="inline" role="math"}[\$\|a \\cdot b\| = \|a\| \\cdot
    \|b\|\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
5.  [[$a \leq |a|, - a \leq |a|$ ]{.math display="inline"
    role="math"}[$\mathsf{a \leq |a|, - a \leq |a|}$ ]{.mathImpaired
    display="inline" role="math"}[\$a \\leq \|a\|, -a \\leq
    \|a\|\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
6.  Dreiecksungleichung:\
    [[$|a + b| \leq |a| + |b|$ ]{.math display="inline"
    role="math"}[$\mathsf{|a + b| \leq |a| + |b|}$ ]{.mathImpaired
    display="inline" role="math"}[\$\|a+b\| \\leq \|a\| +
    \|b\|\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
7.  [[$||a| - |b|| \leq |a - b|$ ]{.math display="inline"
    role="math"}[$\mathsf{||a| - |b|| \leq |a - b|}$ ]{.mathImpaired
    display="inline" role="math"}[\$\| \|a\|-\|b\| \| \\leq
    \|a-b\|\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

((Seite9))

**Beweis:** zu 6.

1\. Fall: [[$a + b \geq 0$ ]{.math display="inline"
role="math"}[$\mathsf{a + b \geq 0}$ ]{.mathImpaired display="inline"
role="math"}[\$a+b \\geq 0\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Dann:\
[[$|a + b| = a + b \leq |a| + b \leq |a| + |b|$ ]{.math display="inline"
role="math"}[$\mathsf{|a + b| = a + b \leq |a| + b \leq |a| + |b|}$
]{.mathImpaired display="inline" role="math"}[\$\|a+b\| = a+b \\leq
\|a\|+b \\leq \|a\|+\|b\|\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

2\. Fall: [[[\$a+b &lt; 0\$]{.math .inline} ]{.math display="inline"
role="math"}[[\$a+b &lt; 0\$]{.math .inline} ]{.mathImpaired
display="inline" role="math"}[\$a+b \< 0\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Dann:\
[[$|a + b| = - (a + b) = ( - a) + ( - b) \leq |a| + |b|$ ]{.math
display="inline"
role="math"}[$\mathsf{|a + b| = - (a + b) = ( - a) + ( - b) \leq |a| + |b|}$
]{.mathImpaired display="inline" role="math"}[\$\|a+b\| = -(a+b) =
(-a)+(-b) \\leq \|a\|+\|b\|\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

### Definition 1.3.

Sei [[$M \subset \mathbb{R},M \neq \varnothing$ ]{.math display="inline"
role="math"}[$\mathsf{M \subset \mathbb{R},M \neq \varnothing}$
]{.mathImpaired display="inline" role="math"}[\$M \\subset \\mathbb{R},
M \\neq \\emptyset\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißt *nach oben
Beschränkt\
*[[$\left. :\Leftrightarrow\exists\gamma \in \mathbb{R}\forall x \in Mx \leq \gamma \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. :\Leftrightarrow\exists\gamma \in \mathbb{R}\forall x \in Mx \leq \gamma \right.}$
]{.mathImpaired display="inline" role="math"}[\$: \\Leftrightarrow
\\exists \\gamma \\in \\mathbb{R} \\forall x \\in M x \\leq
\\gamma\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

[[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißt *nach unten
beschränkt*\
[[$\left. :\Leftrightarrow\exists\gamma \in \mathbb{R}\forall x \in Mx \geq \gamma \right.$
]{.math display="inline"
role="math"}[$\mathsf{\left. :\Leftrightarrow\exists\gamma \in \mathbb{R}\forall x \in Mx \geq \gamma \right.}$
]{.mathImpaired display="inline" role="math"}[\$: \\Leftrightarrow
\\exists \\gamma \\in \\mathbb{R} \\forall x \\in M x \\geq
\\gamma\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

In diesem Fall heißt [[$\gamma$ ]{.math display="inline"
role="math"}[$\mathsf{\gamma}$ ]{.mathImpaired display="inline"
role="math"}[\$\\gamma\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> obere Schranke (bzw.
untere Schranke) von [[$M$ ]{.math display="inline"
role="math"}[$\mathsf{M}$ ]{.mathImpaired display="inline"
role="math"}[\$M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

Ist [[$\gamma$ ]{.math display="inline" role="math"}[$\mathsf{\gamma}$
]{.mathImpaired display="inline" role="math"}[\$\\gamma\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine obere Schranke von
[[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und gilt für *jede*
weitere obere Schranke [[$\widetilde{\gamma}$ ]{.math display="inline"
role="math"}[$\mathsf{\widetilde{\gamma}}$ ]{.mathImpaired
display="inline" role="math"}[\$\\tilde{\\gamma}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> von [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> :
[[$\gamma \leq \widetilde{\gamma}$ ]{.math display="inline"
role="math"}[$\mathsf{\gamma \leq \widetilde{\gamma}}$ ]{.mathImpaired
display="inline" role="math"}[\$\\gamma \\leq
\\tilde{\\gamma}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, (d.h. [[$\gamma$ ]{.math
display="inline" role="math"}[$\mathsf{\gamma}$ ]{.mathImpaired
display="inline" role="math"}[\$\\gamma\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist *kleinste* obere
Schranke von [[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$
]{.mathImpaired display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->), so heißt [[$\gamma$
]{.math display="inline" role="math"}[$\mathsf{\gamma}$ ]{.mathImpaired
display="inline" role="math"}[\$\\gamma\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> das *Supremum* von [[$M$
]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

Ist [[$\gamma$ ]{.math display="inline" role="math"}[$\mathsf{\gamma}$
]{.mathImpaired display="inline" role="math"}[\$\\gamma\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine untere Schranke von
[[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und gilt für *jede*
weitere untere Schranke [[$\widetilde{\gamma}$ ]{.math display="inline"
role="math"}[$\mathsf{\widetilde{\gamma}}$ ]{.mathImpaired
display="inline" role="math"}[\$\\tilde{\\gamma}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> von [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> :
[[$\gamma \geq \widetilde{\gamma}$ ]{.math display="inline"
role="math"}[$\mathsf{\gamma \geq \widetilde{\gamma}}$ ]{.mathImpaired
display="inline" role="math"}[\$\\gamma \\geq
\\tilde{\\gamma}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, (d.h. [[$\gamma$ ]{.math
display="inline" role="math"}[$\mathsf{\gamma}$ ]{.mathImpaired
display="inline" role="math"}[\$\\gamma\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist *größte* untere
Schranke von [[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$
]{.mathImpaired display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->), so heißt [[$\gamma$
]{.math display="inline" role="math"}[$\mathsf{\gamma}$ ]{.mathImpaired
display="inline" role="math"}[\$\\gamma\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> das *Infimum* von [[$M$
]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

Falls [[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$
]{.mathImpaired display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eni Supremum hat, so ist
nach A11 dieses eindeutig bestimmt. (Infimum analog)

Bezeichnung: [[$\sup M,\inf M$ ]{.math display="inline"
role="math"}[$\mathsf{\sup M,\inf M}$ ]{.mathImpaired display="inline"
role="math"}[\$\\sup M, \\inf M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

Existiert [[$\sup M$ ]{.math display="inline"
role="math"}[$\mathsf{\sup M}$ ]{.mathImpaired display="inline"
role="math"}[\$\\sup M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und gilt [[$\sup M \in M$
]{.math display="inline" role="math"}[$\mathsf{\sup M \in M}$
]{.mathImpaired display="inline" role="math"}[\$\\sup M \\in
M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, so heißt [[$\sup M$
]{.math display="inline" role="math"}[$\mathsf{\sup M}$ ]{.mathImpaired
display="inline" role="math"}[\$\\sup M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> auch *Maximum* von [[$M$
]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (Bezeichnung [[$\max M$
]{.math display="inline" role="math"}[$\mathsf{\max M}$ ]{.mathImpaired
display="inline" role="math"}[\$\\max M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->).

Existiert [[$\inf M$ ]{.math display="inline"
role="math"}[$\mathsf{\inf M}$ ]{.mathImpaired display="inline"
role="math"}[\$\\inf M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und gilt [[$\inf M \in M$
]{.math display="inline" role="math"}[$\mathsf{\inf M \in M}$
]{.mathImpaired display="inline" role="math"}[\$\\inf M \\in
M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, so heißt [[$\inf M$
]{.math display="inline" role="math"}[$\mathsf{\inf M}$ ]{.mathImpaired
display="inline" role="math"}[\$\\inf M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> auch *Minimum* von [[$M$
]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (Bezeichnung [[$\min M$
]{.math display="inline" role="math"}[$\mathsf{\min M}$ ]{.mathImpaired
display="inline" role="math"}[\$\\min M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->).

### Beispiel 1.4. Intervalle

Seien [[[\$a,b \\in \\mathbb{R}, a &lt; b\$]{.math .inline} ]{.math
display="inline" role="math"}[[\$a,b \\in \\mathbb{R}, a &lt; b\$]{.math
.inline} ]{.mathImpaired display="inline" role="math"}[\$a,b \\in
\\mathbb{R}, a \< b\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

-   [[[\$(a,b) := \\{ x \\in \\mathbb{R} : a &lt; x &lt; b \\}\$]{.math
    .inline} ]{.math display="inline" role="math"}[[\$(a,b) := \\{ x
    \\in \\mathbb{R} : a &lt; x &lt; b \\}\$]{.math .inline}
    ]{.mathImpaired display="inline" role="math"}[\$(a,b) := \\{ x \\in
    \\mathbb{R} : a \< x \< b \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> (offenes Intervall)
-   [[$\lbrack a,b\rbrack:=\{ x \in \mathbb{R}:a \leq x \leq b\}$
    ]{.math display="inline"
    role="math"}[$\mathsf{\lbrack a,b\rbrack:=\{ x \in \mathbb{R}:a \leq x \leq b\}}$
    ]{.mathImpaired display="inline" role="math"}[\$\[a,b\] := \\{ x
    \\in \\mathbb{R} : a \\leq x \\leq b \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> (abgeschlossenes
    Intervall)
-   [[[\$(a,b\] := \\{ x \\in \\mathbb{R} : a &lt; x \\leq b
    \\}\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$(a,b\] := \\{ x \\in \\mathbb{R} : a &lt; x \\leq b
    \\}\$]{.math .inline} ]{.mathImpaired display="inline"
    role="math"}[\$(a,b\] := \\{ x \\in \\mathbb{R} : a \< x \\leq b
    \\}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> (halboffenes
    Intervall)
-   [[$\lbrack a,\infty):=\{ x \in \mathbb{R}:a \leq x\}$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\lbrack a,\infty):=\{ x \in \mathbb{R}:a \leq x\}}$
    ]{.mathImpaired display="inline" role="math"}[\$\[ a, \\infty ) :=
    \\{ x \\in \\mathbb{R} : a \\leq x \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
-   [[[\$(a, \\infty ) := \\{ x \\in \\mathbb{R} : a &lt; x \\}\$]{.math
    .inline} ]{.math display="inline" role="math"}[[\$(a, \\infty ) :=
    \\{ x \\in \\mathbb{R} : a &lt; x \\}\$]{.math .inline}
    ]{.mathImpaired display="inline" role="math"}[\$(a, \\infty ) := \\{
    x \\in \\mathbb{R} : a \< x \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
-   [[[\$(- \\infty, a) := \\{ x \\in \\mathbb{R} : x&lt;a \\}\$]{.math
    .inline} ]{.math display="inline" role="math"}[[\$(- \\infty, a) :=
    \\{ x \\in \\mathbb{R} : x&lt;a \\}\$]{.math .inline}
    ]{.mathImpaired display="inline" role="math"}[\$(- \\infty, a) :=
    \\{ x \\in \\mathbb{R} : x\<a \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
-   [[$( - \infty,a\rbrack:=\{ x \in \mathbb{R}:x \leq a\}$ ]{.math
    display="inline"
    role="math"}[$\mathsf{( - \infty,a\rbrack:=\{ x \in \mathbb{R}:x \leq a\}}$
    ]{.mathImpaired display="inline" role="math"}[\$(- \\infty, a\] :=
    \\{ x \\in \\mathbb{R} : x \\leq a \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
-   [[$( - \infty,\infty):=\mathbb{R}$ ]{.math display="inline"
    role="math"}[$\mathsf{( - \infty,\infty):=\mathbb{R}}$
    ]{.mathImpaired display="inline" role="math"}[\$(- \\infty, \\infty
    ) := \\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

### Beispiel 1.5. Beispiele von Mengen und deren Schranken:

> \(1) [[$M = (1,2)$ ]{.math display="inline"
> role="math"}[$\mathsf{M = (1,2)}$ ]{.mathImpaired display="inline"
> role="math"}[\$M=(1,2)\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> obere Schranken: alle Zahlen [[$\geq 2$ ]{.math display="inline"
> role="math"}[$\mathsf{\geq 2}$ ]{.mathImpaired display="inline"
> role="math"}[\$\\geq 2\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> [[$\sup M = 2,2 \notin M$ ]{.math display="inline"
> role="math"}[$\mathsf{\sup M = 2,2 \notin M}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\sup M=2, 2 \\notin M\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, daher existiert das
> Maximum von [[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$
> ]{.mathImpaired display="inline" role="math"}[\$M\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> nicht.
>
> untere Schranken: alle Zahlen [[$\leq 1$ ]{.math display="inline"
> role="math"}[$\mathsf{\leq 1}$ ]{.mathImpaired display="inline"
> role="math"}[\$\\leq 1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> [[$\inf M = 1,1 \notin M$ ]{.math display="inline"
> role="math"}[$\mathsf{\inf M = 1,1 \notin M}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\inf M=1, 1 \\notin M\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, daher existiert
> das Minimum von [[$M$ ]{.math display="inline"
> role="math"}[$\mathsf{M}$ ]{.mathImpaired display="inline"
> role="math"}[\$M\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> nicht.

((Seite 10))

> \(2) [[$M = (1,2\rbrack$ ]{.math display="inline"
> role="math"}[$\mathsf{M = (1,2\rbrack}$ ]{.mathImpaired display="inline"
> role="math"}[\$M=(1,2\]\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> obere Schranken: alle Zahlen [[$\geq 2$ ]{.math display="inline"
> role="math"}[$\mathsf{\geq 2}$ ]{.mathImpaired display="inline"
> role="math"}[\$\\geq 2\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> [[$\left. \sup M = 2,2 \in M\Rightarrow\max M = 2 \right.$ ]{.math
> display="inline"
> role="math"}[$\mathsf{\left. \sup M = 2,2 \in M\Rightarrow\max M = 2 \right.}$
> ]{.mathImpaired display="inline" role="math"}[\$\\sup M=2, 2 \\in M
> \\Rightarrow \\max M=2\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->.
>
> untere Schranken: alle Zahlen [[$\leq 1$ ]{.math display="inline"
> role="math"}[$\mathsf{\leq 1}$ ]{.mathImpaired display="inline"
> role="math"}[\$\\leq 1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> [[$\inf M = 1,1 \notin M$ ]{.math display="inline"
> role="math"}[$\mathsf{\inf M = 1,1 \notin M}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\inf M=1, 1 \\notin M\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, daher existiert
> das Minimum von [[$M$ ]{.math display="inline"
> role="math"}[$\mathsf{M}$ ]{.mathImpaired display="inline"
> role="math"}[\$M\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> nicht.
>
> \(3) [[$M = \lbrack 2,\infty)$ ]{.math display="inline"
> role="math"}[$\mathsf{M = \lbrack 2,\infty)}$ ]{.mathImpaired
> display="inline" role="math"}[\$M=\[2, \\infty )\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> [[$\inf M = 2;2 \in M,{\mspace{6mu}\text{also}\mspace{6mu}}\min M = 2$
> ]{.math display="inline"
> role="math"}[$\mathsf{\inf M = 2;2 \in M,{\mspace{6mu}\text{also}\mspace{6mu}}\min M = 2}$
> ]{.mathImpaired display="inline" role="math"}[\$\\inf M=2; 2 \\in M,
> \\text{ also } \\min M=2\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> [[$\sup M$ ]{.math display="inline" role="math"}[$\mathsf{\sup M}$
> ]{.mathImpaired display="inline" role="math"}[\$\\sup
> M\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> existiert nicht

**A15\
**Ist [[$M \subset \mathbb{R},M \neq \varnothing,M$ ]{.math
display="inline"
role="math"}[$\mathsf{M \subset \mathbb{R},M \neq \varnothing,M}$
]{.mathImpaired display="inline" role="math"}[\$M \\subset \\mathbb{R},
M \\neq \\emptyset, M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> nach oben beschränkt, so
existiert [[$\sup M$ ]{.math display="inline"
role="math"}[$\mathsf{\sup M}$ ]{.mathImpaired display="inline"
role="math"}[\$\\sup M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

### Satz 1.6. {dir="ltr"}

Ist [[$M \subset \mathbb{R},M \neq \varnothing,M$ ]{.math
display="inline"
role="math"}[$\mathsf{M \subset \mathbb{R},M \neq \varnothing,M}$
]{.mathImpaired display="inline" role="math"}[\$M \\subset \\mathbb{R},
M \\neq \\emptyset, M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> nach unten beschränkt, so
existiert [[$\inf M$ ]{.math display="inline"
role="math"}[$\mathsf{\inf M}$ ]{.mathImpaired display="inline"
role="math"}[\$\\inf M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

**Beweis:** Betrachte [[$- M:=\{ - x,x, \in M\}$ ]{.math
display="inline" role="math"}[$\mathsf{- M:=\{ - x,x, \in M\}}$
]{.mathImpaired display="inline" role="math"}[\$-M := \\{ -x,x, \\in M
\\}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> statt [[$M$ ]{.math
display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. [[ ]{.math
display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
display="inline" role="math"}[\$\\square\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

### Definition 1.7. {dir="ltr"}

Sei [[$M \subset \mathbb{R},M \neq \varnothing$ ]{.math display="inline"
role="math"}[$\mathsf{M \subset \mathbb{R},M \neq \varnothing}$
]{.mathImpaired display="inline" role="math"}[\$M \\subset \\mathbb{R},
M \\neq \\emptyset\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
[[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißt *beschränkt*, wenn
[[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$ ]{.mathImpaired
display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> nach oben und nach unten
beschränkt ist.

Es gilt: [[$M$ ]{.math display="inline" role="math"}[$\mathsf{M}$
]{.mathImpaired display="inline" role="math"}[\$M\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> beschränkt
[[[\$\\Leftrightarrow \\exists c &gt; 0 \\forall x \\in M \|x\| \\leq
c\$]{.math .inline} ]{.math display="inline"
role="math"}[[\$\\Leftrightarrow \\exists c &gt; 0 \\forall x \\in M
\|x\| \\leq c\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$\\Leftrightarrow \\exists c \> 0 \\forall x \\in M \|x\|
\\leq c\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

### Satz 1.8. {dir="ltr"}

Sei [[$B \subset A \subset \mathbb{R},B \neq \varnothing$ ]{.math
display="inline"
role="math"}[$\mathsf{B \subset A \subset \mathbb{R},B \neq \varnothing}$
]{.mathImpaired display="inline" role="math"}[\$B \\subset A \\subset
\\mathbb{R}, B \\neq \\emptyset\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, dann gilt:

1.  <div>

    Ist [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> beschränkt, so gilt
    [[$\inf A \leq \sup A$ ]{.math display="inline"
    role="math"}[$\mathsf{\inf A \leq \sup A}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\inf A \\leq \\sup
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

    </div>

2.  <div>

    Ist [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nach oben beschränkt,
    so ist auch [[$B$ ]{.math display="inline" role="math"}[$\mathsf{B}$
    ]{.mathImpaired display="inline" role="math"}[\$B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nach oben beschränkt,
    und [[$\sup B \leq \sup A$ ]{.math display="inline"
    role="math"}[$\mathsf{\sup B \leq \sup A}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\sup B \\leq \\sup
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    Ist [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nach unten
    beschränkt, so ist auch [[$B$ ]{.math display="inline"
    role="math"}[$\mathsf{B}$ ]{.mathImpaired display="inline"
    role="math"}[\$B\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nach unten
    beschränkt, und [[$\inf B \geq \inf A$ ]{.math display="inline"
    role="math"}[$\mathsf{\inf B \geq \inf A}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\inf B \\geq \\inf
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

    </div>

3.  <div>

    Ist [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nach oben beschränkt
    und [[$\gamma$ ]{.math display="inline"
    role="math"}[$\mathsf{\gamma}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\gamma\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> eine obere Schranke
    von [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, so gilt:\
    [[[\$\\gamma = \\sup A \\Leftrightarrow \\forall \\epsilon &gt; 0
    \\exists x \\in A x &gt; \\gamma - \\epsilon\$]{.math .inline}
    ]{.math display="inline" role="math"}[[\$\\gamma = \\sup A
    \\Leftrightarrow \\forall \\epsilon &gt; 0 \\exists x \\in A x &gt;
    \\gamma - \\epsilon\$]{.math .inline} ]{.mathImpaired
    display="inline" role="math"}[\$\\gamma = \\sup A \\Leftrightarrow
    \\forall \\epsilon \> 0 \\exists x \\in A x \> \\gamma -
    \\epsilon\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    Ist [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nach unten beschränkt
    und [[$\gamma$ ]{.math display="inline"
    role="math"}[$\mathsf{\gamma}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\gamma\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> eine untere Schranke
    von [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, so gilt:\
    [[[\$\\gamma = \\inf A \\Leftrightarrow \\forall \\epsilon &gt; 0
    \\exists x \\in A x &lt; \\gamma + \\epsilon\$]{.math .inline}
    ]{.math display="inline" role="math"}[[\$\\gamma = \\inf A
    \\Leftrightarrow \\forall \\epsilon &gt; 0 \\exists x \\in A x &lt;
    \\gamma + \\epsilon\$]{.math .inline} ]{.mathImpaired
    display="inline" role="math"}[\$\\gamma = \\inf A \\Leftrightarrow
    \\forall \\epsilon \> 0 \\exists x \\in A x \< \\gamma +
    \\epsilon\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

    </div>

**Beweis:**\

1.  Wähle [[$x \in A$ ]{.math display="inline"
    role="math"}[$\mathsf{x \in A}$ ]{.mathImpaired display="inline"
    role="math"}[\$x \\in A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. Da [[$\sup A$
    ]{.math display="inline" role="math"}[$\mathsf{\sup A}$
    ]{.mathImpaired display="inline" role="math"}[\$\\sup
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> obere Schranke von
    [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, gilt:
    [[$x \leq \sup A$ ]{.math display="inline"
    role="math"}[$\mathsf{x \leq \sup A}$ ]{.mathImpaired
    display="inline" role="math"}[\$x \\leq \\sup A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    Da [[$\inf A$ ]{.math display="inline"
    role="math"}[$\mathsf{\inf A}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\inf A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> untere Schranke von
    [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, gilt:
    [[$x \geq \inf A$ ]{.math display="inline"
    role="math"}[$\mathsf{x \geq \inf A}$ ]{.mathImpaired
    display="inline" role="math"}[\$x \\geq \\inf A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$\left. \Rightarrow\inf A \leq \sup A \right.$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\left. \Rightarrow\inf A \leq \sup A \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow \\inf A
    \\leq \\sup A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
2.  (obere Zeile):  [[$\sup A$ ]{.math display="inline"
    role="math"}[$\mathsf{\sup A}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\sup A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist obere Schranke
    von [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, also (wegen
    [[$B \subset A$ ]{.math display="inline"
    role="math"}[$\mathsf{B \subset A}$ ]{.mathImpaired display="inline"
    role="math"}[\$B \\subset A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->) auch von [[$B$
    ]{.math display="inline" role="math"}[$\mathsf{B}$ ]{.mathImpaired
    display="inline" role="math"}[\$B\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. Da [[$\sup B$
    ]{.math display="inline" role="math"}[$\mathsf{\sup B}$
    ]{.mathImpaired display="inline" role="math"}[\$\\sup
    B\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> *kleinste* obere
    Schranke von [[$B$ ]{.math display="inline"
    role="math"}[$\mathsf{B}$ ]{.mathImpaired display="inline"
    role="math"}[\$B\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, folgt
    [[$\sup B \leq \sup A$ ]{.math display="inline"
    role="math"}[$\mathsf{\sup B \leq \sup A}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\sup B \\leq \\sup
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.
3.  (obere Zeile):\
    \"[[$\Rightarrow$ ]{.math display="inline"
    role="math"}[$\mathsf{\Rightarrow}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\Rightarrow\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\": Sei
    [[$\gamma = \sup A$ ]{.math display="inline"
    role="math"}[$\mathsf{\gamma = \sup A}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\gamma = \\sup A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, und sei
    [[[\$\\epsilon &gt;0\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$\\epsilon &gt;0\$]{.math .inline} ]{.mathImpaired
    display="inline" role="math"}[\$\\epsilon \>0\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. Da [[[\$\\gamma -
    \\epsilon &lt; \\gamma\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$\\gamma - \\epsilon &lt; \\gamma\$]{.math .inline}
    ]{.mathImpaired display="inline" role="math"}[\$\\gamma - \\epsilon
    \< \\gamma\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, ist
    [[$\gamma - \epsilon$ ]{.math display="inline"
    role="math"}[$\mathsf{\gamma - \epsilon}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\gamma - \\epsilon\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> keine obere Schranke
    von [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. Also existiert ein
    [[$x \in A$ ]{.math display="inline" role="math"}[$\mathsf{x \in A}$
    ]{.mathImpaired display="inline" role="math"}[\$x \\in
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> mit [[[\$x &gt;
    \\gamma - \\epsilon\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$x &gt; \\gamma - \\epsilon\$]{.math .inline}
    ]{.mathImpaired display="inline" role="math"}[\$x \> \\gamma -
    \\epsilon\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    \"[[$\Leftarrow$ ]{.math display="inline"
    role="math"}[$\mathsf{\Leftarrow}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\Leftarrow\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\": Es gelte
    [[[\$\\forall \\epsilon &gt; 0 \\exists x \\in A x &gt; \\gamma -
    \\epsilon\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$\\forall \\epsilon &gt; 0 \\exists x \\in A x &gt;
    \\gamma - \\epsilon\$]{.math .inline} ]{.mathImpaired
    display="inline" role="math"}[\$\\forall \\epsilon \> 0 \\exists x
    \\in A x \> \\gamma - \\epsilon\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. Wäre [[$\gamma$
    ]{.math display="inline" role="math"}[$\mathsf{\gamma}$
    ]{.mathImpaired display="inline"
    role="math"}[\$\\gamma\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nicht das Supremum
    von [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
    ]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, so existiert eine
    kleinere obere Schranke [[$\widetilde{\gamma}$ ]{.math
    display="inline" role="math"}[$\mathsf{\widetilde{\gamma}}$
    ]{.mathImpaired display="inline"
    role="math"}[\$\\tilde{\\gamma}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> von [[$A$ ]{.math
    display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
    display="inline" role="math"}[\$A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. (also
    [[[\$\\tilde{\\gamma} &lt; \\gamma\$]{.math .inline} ]{.math
    display="inline" role="math"}[[\$\\tilde{\\gamma} &lt;
    \\gamma\$]{.math .inline} ]{.mathImpaired display="inline"
    role="math"}[\$\\tilde{\\gamma} \< \\gamma\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->).\
    Setze [[[\$\\epsilon := \\gamma - \\tilde{\\gamma} &gt;0\$]{.math
    .inline} ]{.math display="inline" role="math"}[[\$\\epsilon :=
    \\gamma - \\tilde{\\gamma} &gt;0\$]{.math .inline} ]{.mathImpaired
    display="inline" role="math"}[\$\\epsilon := \\gamma -
    \\tilde{\\gamma} \>0\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. Nach Voraussetzung
    existiert ein [[$x \in A$ ]{.math display="inline"
    role="math"}[$\mathsf{x \in A}$ ]{.mathImpaired display="inline"
    role="math"}[\$x \\in A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> mit [[[\$x &gt;
    \\gamma - \\epsilon = \\gamma - (\\gamma - \\tilde{\\gamma} ) =
    \\tilde{\\gamma}\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$x &gt; \\gamma - \\epsilon = \\gamma - (\\gamma -
    \\tilde{\\gamma} ) = \\tilde{\\gamma}\$]{.math .inline}
    ]{.mathImpaired display="inline" role="math"}[\$x \> \\gamma -
    \\epsilon = \\gamma - (\\gamma - \\tilde{\\gamma} ) =
    \\tilde{\\gamma}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$\left. \Rightarrow\widetilde{\gamma} \right.$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\left. \Rightarrow\widetilde{\gamma} \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow
    \\tilde{\\gamma}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist keine obere
    Schranke von [[$A$ ]{.math display="inline"
    role="math"}[$\mathsf{A}$ ]{.mathImpaired display="inline"
    role="math"}[\$A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. [[$\Rightarrow$
    ]{.math display="inline" role="math"}[$\mathsf{\Rightarrow}$
    ]{.mathImpaired display="inline"
    role="math"}[\$\\Rightarrow\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> Widerspruch.
    ([[[\$\\Lightning\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$\\Lightning\$]{.math .inline} ]{.mathImpaired
    display="inline" role="math"}[\$\\Lightning\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->)\
    [[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\square\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

((Seite11))

1.3. Natürliche Zahlen
----------------------

### Definition 1.9.

[[$A \subset \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{A \subset \mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$A \\subset \\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißt *Induktionsmenge*
(IM), wenn gilt:

1.  [[$1 \in A$ ]{.math display="inline" role="math"}[$\mathsf{1 \in A}$
    ]{.mathImpaired display="inline" role="math"}[\$1 \\in
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
2.  [[$\forall x \in Ax + 1 \in A$ ]{.math display="inline"
    role="math"}[$\mathsf{\forall x \in Ax + 1 \in A}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\forall x \\in A x+1 \\in
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

### Beispiel 1.10.

[[$\mathbb{R},\lbrack!,\infty),\{ 1\} \cup \lbrack 2,\infty)$ ]{.math
display="inline"
role="math"}[$\mathsf{\mathbb{R},\lbrack!,\infty),\{ 1\} \cup \lbrack 2,\infty)}$
]{.mathImpaired display="inline" role="math"}[\$\\mathbb{R}, \[!,
\\infty ), \\{ 1 \\} \\cup \[2, \\infty )\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> sind Induktionsmengen.\
[[$\{ 1\} \cup (2,\infty)$ ]{.math display="inline"
role="math"}[$\mathsf{\{ 1\} \cup (2,\infty)}$ ]{.mathImpaired
display="inline" role="math"}[\$\\{ 1 \\} \\cup (2, \\infty
)\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist keine
Induktionsmenge.

### Definition 1.11.

Die Menge [[$\mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired display="inline"
role="math"}[\$\\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

[[$:=\{ x \in \mathbb{R}:x \in A{\mspace{6mu}\text{für\ jede\ Induktionsmenge}\mspace{6mu}}A\}$
]{.math display="inline"
role="math"}[$\mathsf{:=\{ x \in \mathbb{R}:x \in A{\mspace{6mu}\text{für\ jede\ Induktionsmenge}\mspace{6mu}}A\}}$
]{.mathImpaired display="inline" role="math"}[\$:= \\{ x \\in 
\\mathbb{R} : x \\in A \\text{ für jede Induktionsmenge } A
\\}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
[[$=$ ]{.math display="inline" role="math"}[$\mathsf{=}$ ]{.mathImpaired
display="inline" role="math"}[\$=\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> Durschnitt aller
Induktionsmengen\
[[$\bigcap\limits_{A{\mspace{6mu}\text{IM}}}A$ ]{.math display="inline"
role="math"}[$\mathsf{\bigcap\limits_{A{\mspace{6mu}\text{IM}}}A}$
]{.mathImpaired display="inline" role="math"}[\$\\bigcap\\limits\_{A
\\text{ IM}} A\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

heißt *Menge der natürlichen Zahlen*.

### Satz 1.12.

1.  Ist [[$A \subset \mathbb{R}$ ]{.math display="inline"
    role="math"}[$\mathsf{A \subset \mathbb{R}}$ ]{.mathImpaired
    display="inline" role="math"}[\$A \\subset
    \\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> eine Induktionsmenge,
    dann gilt [[$\mathbb{N} \subset A$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{N} \subset A}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\mathbb{N} \\subset
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
2.  [[$\mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist eine
    Induktionsmenge.
3.  [[$\mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist nicht nach oben
    beschränkt.
4.  [[[\$\\forall x \\in \\mathbb{R} \\exists n \\in  \\mathbb{N} n &gt;
    x\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$\\forall x \\in \\mathbb{R} \\exists n \\in 
    \\mathbb{N} n &gt; x\$]{.math .inline} ]{.mathImpaired
    display="inline" role="math"}[\$\\forall x \\in \\mathbb{R} \\exists
    n \\in  \\mathbb{N} n \> x\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

**Beweis:**

1.  Klar nach Definition von [[$N$ ]{.math display="inline"
    role="math"}[$\mathsf{N}$ ]{.mathImpaired display="inline"
    role="math"}[\$N\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.
2.  Da [[$1 \in A$ ]{.math display="inline"
    role="math"}[$\mathsf{1 \in A}$ ]{.mathImpaired display="inline"
    role="math"}[\$1 \\in A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> für jede
    Induktionsmenge [[$A \subset \mathbb{R}$ ]{.math display="inline"
    role="math"}[$\mathsf{A \subset \mathbb{R}}$ ]{.mathImpaired
    display="inline" role="math"}[\$A \\subset 
    \\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, gilt auch
    [[$1 \in \bigcap\limits_{A{\mspace{6mu}\text{IM}}}A = \mathbb{N}$
    ]{.math display="inline"
    role="math"}[$\mathsf{1 \in \bigcap\limits_{A{\mspace{6mu}\text{IM}}}A = \mathbb{N}}$
    ]{.mathImpaired display="inline" role="math"}[\$1 \\in
    \\bigcap\\limits\_{A \\text{ IM}} A = \\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.\
    Sei
    [[$x \in \mathbb{N} = \bigcap\limits_{A{\mspace{6mu}\text{IM}}}A$
    ]{.math display="inline"
    role="math"}[$\mathsf{x \in \mathbb{N} = \bigcap\limits_{A{\mspace{6mu}\text{IM}}}A}$
    ]{.mathImpaired display="inline" role="math"}[\$x \\in \\mathbb{N} =
    \\bigcap\\limits\_{A \\text{ IM}} A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->. Also [[$x \in A$
    ]{.math display="inline" role="math"}[$\mathsf{x \in A}$
    ]{.mathImpaired display="inline" role="math"}[\$x \\in
    A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> für jede
    Induktionsmenge [[$A$ ]{.math display="inline"
    role="math"}[$\mathsf{A}$ ]{.mathImpaired display="inline"
    role="math"}[\$A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.\
    Da [[$x + 1 \in A$ ]{.math display="inline"
    role="math"}[$\mathsf{x + 1 \in A}$ ]{.mathImpaired display="inline"
    role="math"}[\$x+1 \\in A\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> für jede
    Induktionsmenge [[$A$ ]{.math display="inline"
    role="math"}[$\mathsf{A}$ ]{.mathImpaired display="inline"
    role="math"}[\$A\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, ist
    [[$x + 1 \in \bigcap\limits_{A{\mspace{6mu}\text{IM}}}A = \mathbb{N}$
    ]{.math display="inline"
    role="math"}[$\mathsf{x + 1 \in \bigcap\limits_{A{\mspace{6mu}\text{IM}}}A = \mathbb{N}}$
    ]{.mathImpaired display="inline" role="math"}[\$x+1 \\in
    \\bigcap\\limits\_{A \\text{ IM}} A = \\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$\left. \Rightarrow\mathbb{N} \right.$ ]{.math display="inline"
    role="math"}[$\mathsf{\left. \Rightarrow\mathbb{N} \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow
    \\mathbb{N}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist Induktionsmenge.
3.  *Annahme*: [[$\mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist nach oben
    beschränkt. Nach A15 existiert also ein [[$s:=\sup\mathbb{N}$
    ]{.math display="inline" role="math"}[$\mathsf{s:=\sup\mathbb{N}}$
    ]{.mathImpaired display="inline" role="math"}[\$s := \\sup
    \\mathbb{N}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.\
    [[$\left. \Rightarrow s - 1 \right.$ ]{.math display="inline"
    role="math"}[$\mathsf{\left. \Rightarrow s - 1 \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow
    s-1\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist keine obere
    Schranke von [[$\mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.\
    [[[\$\\Rightarrow \\exists x \\in \\mathbb{N} x &gt; s-1\$]{.math
    .inline} ]{.math display="inline" role="math"}[[\$\\Rightarrow
    \\exists x \\in \\mathbb{N} x &gt; s-1\$]{.math .inline}
    ]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow
    \\exists x \\in \\mathbb{N} x \> s-1\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->; da [[$\mathbb{N}$
    ]{.math display="inline" role="math"}[$\mathsf{\mathbb{N}}$
    ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> Induktionsmenge ist,
    gilt [[$x + 1 \in \mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{x + 1 \in \mathbb{N}}$ ]{.mathImpaired
    display="inline" role="math"}[\$x+1 \\in \\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, andererseits
    [[[\$x+1 &gt; s\$]{.math .inline} ]{.math display="inline"
    role="math"}[[\$x+1 &gt; s\$]{.math .inline} ]{.mathImpaired
    display="inline" role="math"}[\$x+1 \> s\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    [[$\Rightarrow$ ]{.math display="inline"
    role="math"}[$\mathsf{\Rightarrow}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\Rightarrow\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> Widerspruch, da [[$s$
    ]{.math display="inline" role="math"}[$\mathsf{s}$ ]{.mathImpaired
    display="inline" role="math"}[\$s\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> obere Schranke von
    [[$\mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.
4.  folgt aus 3..

[[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
display="inline" role="math"}[\$\\square\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

((Seite12))

1.4. Prinzip der vollständigen Induktion
----------------------------------------

### Satz 1.13.

Ist [[$A \subset \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{A \subset \mathbb{N}}$ ]{.mathImpaired
display="inline" role="math"}[\$A \\subset \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[$A$ ]{.math
display="inline" role="math"}[$\mathsf{A}$ ]{.mathImpaired
display="inline" role="math"}[\$A\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> Induktionsmenge, so ist
[[$A = \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{A = \mathbb{N}}$ ]{.mathImpaired display="inline"
role="math"}[\$A = \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

Beweis:\
[[$\mathbb{N} \subset \widetilde{A}$ ]{.math display="inline"
role="math"}[$\mathsf{\mathbb{N} \subset \widetilde{A}}$ ]{.mathImpaired
display="inline" role="math"}[\$\\mathbb{N} \\subset
\\tilde{A}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> für jede Induktionsmenge
[[$\widetilde{A}$ ]{.math display="inline"
role="math"}[$\mathsf{\widetilde{A}}$ ]{.mathImpaired display="inline"
role="math"}[\$\\tilde{A}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, insbesondere
[[$\mathbb{N} \subset A$ ]{.math display="inline"
role="math"}[$\mathsf{\mathbb{N} \subset A}$ ]{.mathImpaired
display="inline" role="math"}[\$\\mathbb{N} \\subset A\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Außerdem ist
[[$A \subset \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{A \subset \mathbb{N}}$ ]{.mathImpaired
display="inline" role="math"}[\$A \\subset \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> nach Voraussetzung, also
[[$A = \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{A = \mathbb{N}}$ ]{.mathImpaired display="inline"
role="math"}[\$A= \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
[[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
display="inline" role="math"}[\$\\square\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

### 1.4.1 Beweisverfahren durch Induktion

Für jedes [[$n \in \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{n \in \mathbb{N}}$ ]{.mathImpaired
display="inline" role="math"}[\$n \\in \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> sei eine Aussage [[$A(n)$
]{.math display="inline" role="math"}[$\mathsf{A(n)}$ ]{.mathImpaired
display="inline" role="math"}[\$A(n)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> definiert. Es gelte:

1.  [[$A(1)$ ]{.math display="inline" role="math"}[$\mathsf{A(1)}$
    ]{.mathImpaired display="inline" role="math"}[\$A(1)\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist wahr.
2.  [[$\left. \forall n \in \mathbb{N}\lbrack A(n){\mspace{6mu}\text{wahr}\mspace{6mu}}\Rightarrow A(n + 1){\mspace{6mu}\text{wahr}}\rbrack \right.$
    ]{.math display="inline"
    role="math"}[$\mathsf{\left. \forall n \in \mathbb{N}\lbrack A(n){\mspace{6mu}\text{wahr}\mspace{6mu}}\Rightarrow A(n + 1){\mspace{6mu}\text{wahr}}\rbrack \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\forall n \\in
    \\mathbb{N} \[ A(n) \\text{ wahr } \\Rightarrow A(n+1) \\text{
    wahr}\]\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

Dann gilt: [[$\forall n \in \mathbb{N}A(n)$ ]{.math display="inline"
role="math"}[$\mathsf{\forall n \in \mathbb{N}A(n)}$ ]{.mathImpaired
display="inline" role="math"}[\$\\forall n \\in \\mathbb{N}
A(n)\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist wahr.

Denn: Setze
[[$A:=\{ n \in \mathbb{N}:A(n){\mspace{6mu}\text{ist\ wahr}}\}$ ]{.math
display="inline"
role="math"}[$\mathsf{A:=\{ n \in \mathbb{N}:A(n){\mspace{6mu}\text{ist\ wahr}}\}}$
]{.mathImpaired display="inline" role="math"}[\$A:= \\{ n \\in
\\mathbb{N} : A(n) \\text{ ist wahr} \\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
Nach 1. gilt: [[$1 \in A$ ]{.math display="inline"
role="math"}[$\mathsf{1 \in A}$ ]{.mathImpaired display="inline"
role="math"}[\$1 \\in A\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->; nach 2. gilt
[[$\forall n \in \mathbb{N}n + 1 \in A$ ]{.math display="inline"
role="math"}[$\mathsf{\forall n \in \mathbb{N}n + 1 \in A}$
]{.mathImpaired display="inline" role="math"}[\$\\forall n \\in
\\mathbb{N} n+1 \\in A\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
Also [[$A$ ]{.math display="inline" role="math"}[$\mathsf{A}$
]{.mathImpaired display="inline" role="math"}[\$A\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> Induktionsmenge; ferner
[[$A \subset \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{A \subset \mathbb{N}}$ ]{.mathImpaired
display="inline" role="math"}[\$A \\subset \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Also ist nach Prinzip
der vollständigen Induktion: [[$A = \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{A = \mathbb{N}}$ ]{.mathImpaired display="inline"
role="math"}[\$A= \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, d.h. [[$A(n)$ ]{.math
display="inline" role="math"}[$\mathsf{A(n)}$ ]{.mathImpaired
display="inline" role="math"}[\$A(n)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> wahr für alle
[[$n \in \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{n \in \mathbb{N}}$ ]{.mathImpaired
display="inline" role="math"}[\$n \\in \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

#### Beispiel 1.14.

\(1) *Behauptung:* [[$\forall n \in \mathbb{N}n \geq 1$ ]{.math
display="inline"
role="math"}[$\mathsf{\forall n \in \mathbb{N}n \geq 1}$ ]{.mathImpaired
display="inline" role="math"}[\$\\forall n \\in \\mathbb{N} n \\geq
1\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

> **Beweis**: induktiv\
> [[$A(n)$ ]{.math display="inline" role="math"}[$\mathsf{A(n)}$
> ]{.mathImpaired display="inline" role="math"}[\$A(n)\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> sei die Aussage
> \"[[$n \geq 1$ ]{.math display="inline"
> role="math"}[$\mathsf{n \geq 1}$ ]{.mathImpaired display="inline"
> role="math"}[\$n \\geq 1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\".\
> [[$A(1)$ ]{.math display="inline" role="math"}[$\mathsf{A(1)}$
> ]{.mathImpaired display="inline" role="math"}[\$A(1)\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> ist wahr, da
> [[$1 \geq 1$ ]{.math display="inline" role="math"}[$\mathsf{1 \geq 1}$
> ]{.mathImpaired display="inline" role="math"}[\$1 \\geq
> 1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->.\
> Sei [[$A(n)$ ]{.math display="inline" role="math"}[$\mathsf{A(n)}$
> ]{.mathImpaired display="inline" role="math"}[\$A(n)\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> wahr, also [[$n \geq 1$
> ]{.math display="inline" role="math"}[$\mathsf{n \geq 1}$
> ]{.mathImpaired display="inline" role="math"}[\$n \\geq
> 1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->. Dann
> [[$n + 1 \geq 1 + 1 \geq 1 + 0 = 1$ ]{.math display="inline"
> role="math"}[$\mathsf{n + 1 \geq 1 + 1 \geq 1 + 0 = 1}$
> ]{.mathImpaired display="inline" role="math"}[\$n+1 \\geq 1+1 \\geq
> 1+0 =1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> d.h. also \$\$A(n+1)
> ist auch wahr für alle [[$n \in \mathbb{N}$ ]{.math display="inline"
> role="math"}[$\mathsf{n \in \mathbb{N}}$ ]{.mathImpaired
> display="inline" role="math"}[\$n \\in \\mathbb{N}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, d.n.
> [[$\forall n \in \mathbb{N}n \geq 1$ ]{.math display="inline"
> role="math"}[$\mathsf{\forall n \in \mathbb{N}n \geq 1}$
> ]{.mathImpaired display="inline" role="math"}[\$\\forall n \\in
> \\mathbb{N} n \\geq 1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->.\
> [[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\square\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

\(2) Es sei [[$m \in \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{m \in \mathbb{N}}$ ]{.mathImpaired
display="inline" role="math"}[\$m \\in \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[$x \in \mathbb{R}$
]{.math display="inline" role="math"}[$\mathsf{x \in \mathbb{R}}$
]{.mathImpaired display="inline" role="math"}[\$x \\in
\\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> mit [[[\$m &lt; x &lt; x+
1\$]{.math .inline} ]{.math display="inline" role="math"}[[\$m &lt; x
&lt; x+ 1\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$m \< x \< x+ 1\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
*Behauptung*: [[$x \notin \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{x \notin \mathbb{N}}$ ]{.mathImpaired
display="inline" role="math"}[\$x \\notin \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

> **Beweis**:\
> [[$A:=(\mathbb{N} \cap \lbrack 1,m\rbrack) \cup \lbrack m + 1,\infty)$
> ]{.math display="inline"
> role="math"}[$\mathsf{A:=(\mathbb{N} \cap \lbrack 1,m\rbrack) \cup \lbrack m + 1,\infty)}$
> ]{.mathImpaired display="inline" role="math"}[\$A := ( \\mathbb{N}
> \\cap \[1,m\]) \\cup \[m+1, \\infty )\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> ist Induktionsmenge.
> (Bew. selbst)\
> [[$\left. \Rightarrow\mathbb{N} \subset A \right.$ ]{.math
> display="inline"
> role="math"}[$\mathsf{\left. \Rightarrow\mathbb{N} \subset A \right.}$
> ]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow
> \\mathbb{N} \\subset A\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> *Annahme*: [[$x \in \mathbb{N}$ ]{.math display="inline"
> role="math"}[$\mathsf{x \in \mathbb{N}}$ ]{.mathImpaired
> display="inline" role="math"}[\$x \\in \\mathbb{N}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, denn (wegen
> [[$\mathbb{N} \subset A$ ]{.math display="inline"
> role="math"}[$\mathsf{\mathbb{N} \subset A}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\mathbb{N} \\subset A\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->): [[$x \in A$ ]{.math
> display="inline" role="math"}[$\mathsf{x \in A}$ ]{.mathImpaired
> display="inline" role="math"}[\$x \\in A\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, d.h. insbesondere
> [[$x \leq m$ ]{.math display="inline" role="math"}[$\mathsf{x \leq m}$
> ]{.mathImpaired display="inline" role="math"}[\$x \\leq
> m\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> odere [[$x \geq m + 1$
> ]{.math display="inline" role="math"}[$\mathsf{x \geq m + 1}$
> ]{.mathImpaired display="inline" role="math"}[\$x \\geq
> m+1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> [[$\Rightarrow$ ]{.math display="inline"
> role="math"}[$\mathsf{\Rightarrow}$ ]{.mathImpaired display="inline"
> role="math"}[\$\\Rightarrow\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> Widerspruch zur Annahme
> (echt kleiner etc.)\
> [[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\square\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

\(3) *Behauptung:* [[$1 + 2 + 3 + \ldots + n = \frac{n(n + 1)}{2}$
]{.math display="inline"
role="math"}[$\mathsf{1 + 2 + 3 + \ldots + n = \frac{n(n + 1)}{2}}$
]{.mathImpaired display="inline" role="math"}[\$1+2+3+ \\ldots +n =
\\frac{n(n+1)}{2}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

((Seite 13))

> **Beweis:**\
> (1) Stimmt für [[$n = 1$ ]{.math display="inline"
> role="math"}[$\mathsf{n = 1}$ ]{.mathImpaired display="inline"
> role="math"}[\$n=1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> da
> [[$1 = \frac{1(1 + 1)}{2}$ ]{.math display="inline"
> role="math"}[$\mathsf{1 = \frac{1(1 + 1)}{2}}$ ]{.mathImpaired
> display="inline" role="math"}[\$1= \\frac{1(1+1)}{2}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> (2) Gelte die Behauptung für ein beliebiges [[$n \in \mathbb{N}$
> ]{.math display="inline" role="math"}[$\mathsf{n \in \mathbb{N}}$
> ]{.mathImpaired display="inline" role="math"}[\$n \\in
> \\mathbb{N}\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->. Dann\
> [[$1 + 2 + 3 + \ldots + n + (n + 1) = \frac{n(n + 1)}{2} + (n + 1)$
> ]{.math display="inline"
> role="math"}[$\mathsf{1 + 2 + 3 + \ldots + n + (n + 1) = \frac{n(n + 1)}{2} + (n + 1)}$
> ]{.mathImpaired display="inline" role="math"}[\$1+2+3+ \\ldots
> +n+(n+1) = \\frac{n(n+1)}{2} + (n+1)\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> \$\$= (n+1)( \\frac{n}{2} +1) = \\frac{(n+1)(n+2)}{2}\
> [[$\Rightarrow$ ]{.math display="inline"
> role="math"}[$\mathsf{\Rightarrow}$ ]{.mathImpaired display="inline"
> role="math"}[\$\\Rightarrow\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> Behauptung gilt für
> [[$n + 1$ ]{.math display="inline" role="math"}[$\mathsf{n + 1}$
> ]{.mathImpaired display="inline" role="math"}[\$n+1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> [[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\square\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

#### Definition 1.15. {style="margin-right: 0px;" dir="ltr"}

[[$\mathbb{N}_{0}:=\mathbb{N} \cup \{ 0\}$ ]{.math display="inline"
role="math"}[$\mathsf{\mathbb{N}_{0}:=\mathbb{N} \cup \{ 0\}}$
]{.mathImpaired display="inline" role="math"}[\$\\mathbb{N}\_0 :=
\\mathbb{N} \\cup \\{ 0 \\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

[[$\mathbb{Z}:=\mathbb{N} \cup \{ - n:n \in \mathbb{N}\}$ ]{.math
display="inline"
role="math"}[$\mathsf{\mathbb{Z}:=\mathbb{N} \cup \{ - n:n \in \mathbb{N}\}}$
]{.mathImpaired display="inline" role="math"}[\$\\mathbb{Z} :=
\\mathbb{N} \\cup \\{ -n: n \\in \\mathbb{N} \\}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ganze Zahlen

[[$\mathbb{Q}:=\left\{ \frac{p}{q}:p \in \mathbb{Z},q \in \mathbb{N} \right\}$
]{.math display="inline"
role="math"}[$\mathsf{\mathbb{Q}:=\left\{ \frac{p}{q}:p \in \mathbb{Z},q \in \mathbb{N} \right\}}$
]{.mathImpaired display="inline" role="math"}[\$\\mathbb{Q} := \\left\\{
\\frac{p}{q} : p \\in \\mathbb{Z}, q \\in \\mathbb{N}
\\right\\}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> rationale Zahlen

#### Satz 1.16. {style="margin-right: 0px;" dir="ltr"}

Sind [[$x,y \in \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{x,y \in \mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$x ,y \\in \\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[[\$x &lt;
y\$]{.math .inline} ]{.math display="inline" role="math"}[[\$x &lt;
y\$]{.math .inline} ]{.mathImpaired display="inline" role="math"}[\$x \<
y\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, so existiert ein
[[$r \in \mathbb{Q}$ ]{.math display="inline"
role="math"}[$\mathsf{r \in \mathbb{Q}}$ ]{.mathImpaired
display="inline" role="math"}[\$r \\in\\mathbb{Q}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> mit [[[\$x &lt; r &lt;
y\$]{.math .inline} ]{.math display="inline" role="math"}[[\$x &lt; r
&lt; y\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$x \< r \< y\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

**Beweis:**\
Wähle [[[\$q \\in \\mathbb{N}, q &gt; \\frac{1}{y-x}\$]{.math .inline}
]{.math display="inline" role="math"}[[\$q \\in \\mathbb{N}, q &gt;
\\frac{1}{y-x}\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$q \\in \\mathbb{N}, q \> \\frac{1}{y-x}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, dann [[[\$qy-qx &gt;
1\$]{.math .inline} ]{.math display="inline" role="math"}[[\$qy-qx &gt;
1\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$qy-qx \> 1\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Dann existiert (Beweis
später) ein [[$p \in \mathbb{Z}$ ]{.math display="inline"
role="math"}[$\mathsf{p \in \mathbb{Z}}$ ]{.mathImpaired
display="inline" role="math"}[\$p \\in \\mathbb{Z}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> mit [[[\$qx &lt; p &lt;
qy\$]{.math .inline} ]{.math display="inline" role="math"}[[\$qx &lt; p
&lt; qy\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$qx \< p \< qy\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, d.h. [[[\$x &lt;
\\frac{p}{q} &lt; y\$]{.math .inline} ]{.math display="inline"
role="math"}[[\$x &lt; \\frac{p}{q} &lt; y\$]{.math .inline}
]{.mathImpaired display="inline" role="math"}[\$x \< \\frac{p}{q} \<
y\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

*Nachweis der Existenz eines solchen [[$p$ ]{.math display="inline"
role="math"}[$\mathsf{p}$ ]{.mathImpaired display="inline"
role="math"}[\$p\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->:\
*Setze [[$M:=\mathbb{Z} \cap ( - \infty,qx\rbrack$ ]{.math
display="inline"
role="math"}[$\mathsf{M:=\mathbb{Z} \cap ( - \infty,qx\rbrack}$
]{.mathImpaired display="inline" role="math"}[\$M := \\mathbb{Z} \\cap
(- \\infty , qx\]\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> nach oben beschränkt.\
[[$s:=\sup M$ ]{.math display="inline" role="math"}[$\mathsf{s:=\sup M}$
]{.mathImpaired display="inline" role="math"}[\$s:= \\sup
M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
Wähle [[$n \in M$ ]{.math display="inline"
role="math"}[$\mathsf{n \in M}$ ]{.mathImpaired display="inline"
role="math"}[\$n\\in M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> mit [[[\$n &gt; s-
1\$]{.math .inline} ]{.math display="inline" role="math"}[[\$n &gt; s-
1\$]{.math .inline} ]{.mathImpaired display="inline" role="math"}[\$n \>
s- 1\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Setze
[[$p:=n + 1 \in \mathbb{Z}$ ]{.math display="inline"
role="math"}[$\mathsf{p:=n + 1 \in \mathbb{Z}}$ ]{.mathImpaired
display="inline" role="math"}[\$p :=n+1 \\in \\mathbb{Z}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->; ferner [[[\$p &gt;
s\$]{.math .inline} ]{.math display="inline" role="math"}[[\$p &gt;
s\$]{.math .inline} ]{.mathImpaired display="inline" role="math"}[\$p \>
s\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
[[$\left. \Rightarrow p \notin M \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. \Rightarrow p \notin M \right.}$
]{.mathImpaired display="inline" role="math"}[\$\\Rightarrow p \\notin
M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->; wegen
[[$p \in \mathbb{Z}$ ]{.math display="inline"
role="math"}[$\mathsf{p \in \mathbb{Z}}$ ]{.mathImpaired
display="inline" role="math"}[\$p \\in \\mathbb{Z}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> also
[[$p \notin ( - \infty,qx\rbrack$ ]{.math display="inline"
role="math"}[$\mathsf{p \notin ( - \infty,qx\rbrack}$ ]{.mathImpaired
display="inline" role="math"}[\$p \\notin (- \\infty
,qx\]\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, d.h.
[[[\$p&gt;qx\$]{.math .inline} ]{.math display="inline"
role="math"}[[\$p&gt;qx\$]{.math .inline} ]{.mathImpaired
display="inline" role="math"}[\$p\>qx\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
Ferner [[[\$p =n+1 \\leq qx+1 &lt; q y\$]{.math .inline} ]{.math
display="inline" role="math"}[[\$p =n+1 \\leq qx+1 &lt; q y\$]{.math
.inline} ]{.mathImpaired display="inline" role="math"}[\$p =n+1 \\leq
qx+1 \< q y\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
[[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
display="inline" role="math"}[\$\\square\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

1.5. Einige Formeln (Notationen) {style="margin-right: 0px;" dir="ltr"}
--------------------------------

\(1) Für [[$a \in \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{a \in \mathbb{R}}$ ]{.mathImpaired
display="inline" role="math"}[\$a \\in \\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[[\$n \\in
\\mathbb{N} : a\^n := a \\cdot a \\dotsm a\$]{.math .inline} ]{.math
display="inline" role="math"}[[\$n \\in \\mathbb{N} : a\^n := a \\cdot a
\\dotsm a\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$n \\in \\mathbb{N} : a\^n := a \\cdot a \\dotsm
a\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (*n* mal)

> Präzise mit vollständiger Induktion:\
> Definiere [[$a^{1}:=a$ ]{.math display="inline"
> role="math"}[$\mathsf{a^{1}:=a}$ ]{.mathImpaired display="inline"
> role="math"}[\$a\^1 := a\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> Sei [[$a^{n}$ ]{.math display="inline" role="math"}[$\mathsf{a^{n}}$
> ]{.mathImpaired display="inline" role="math"}[\$a\^n\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> für ein
> [[$n \in \mathbb{N}$ ]{.math display="inline"
> role="math"}[$\mathsf{n \in \mathbb{N}}$ ]{.mathImpaired
> display="inline" role="math"}[\$n \\in \\mathbb{N}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> bereits definiert.\
> Dann [[$a^{n + 1}:=a^{n} \cdot a$ ]{.math display="inline"
> role="math"}[$\mathsf{a^{n + 1}:=a^{n} \cdot a}$ ]{.mathImpaired
> display="inline" role="math"}[\$a\^{n+1} := a\^n \\cdot
> a\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> Daraus: übliche Rechenregeln für Potenzen.
>
> Falls [[$a \neq 0,n \in \mathbb{N}:a^{- n}:=\frac{1}{a^{n}}$ ]{.math
> display="inline"
> role="math"}[$\mathsf{a \neq 0,n \in \mathbb{N}:a^{- n}:=\frac{1}{a^{n}}}$
> ]{.mathImpaired display="inline" role="math"}[\$a \\neq 0, n \\in
> \\mathbb{N} : a\^{-n} := \\frac{1}{a\^n}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> Für alle [[$a \in \mathbb{R}:a^{0}:=1$ ]{.math display="inline"
> role="math"}[$\mathsf{a \in \mathbb{R}:a^{0}:=1}$ ]{.mathImpaired
> display="inline" role="math"}[\$a \\in \\mathbb{R} : a\^0 :=
> 1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> Damit: [[$a^{n}$ ]{.math display="inline"
> role="math"}[$\mathsf{a^{n}}$ ]{.mathImpaired display="inline"
> role="math"}[\$a\^n\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> (für [[$a \neq 0$
> ]{.math display="inline" role="math"}[$\mathsf{a \neq 0}$
> ]{.mathImpaired display="inline" role="math"}[\$a \\neq
> 0\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->) für alle
> [[$n \in \mathbb{Z}$ ]{.math display="inline"
> role="math"}[$\mathsf{n \in \mathbb{Z}}$ ]{.mathImpaired
> display="inline" role="math"}[\$n \\in \\mathbb{Z}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> definiert.

\(2) Für [[[\$n \\in \\mathbb{N} : n! := 1 \\cdot 2 \\cdot 3 \\dotsm
n\$]{.math .inline} ]{.math display="inline" role="math"}[[\$n \\in
\\mathbb{N} : n! := 1 \\cdot 2 \\cdot 3 \\dotsm n\$]{.math .inline}
]{.mathImpaired display="inline" role="math"}[\$n \\in \\mathbb{N} : n!
:= 1 \\cdot 2 \\cdot 3 \\dotsm n\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

> Präzise: [[$0!:=1$ ]{.math display="inline"
> role="math"}[$\mathsf{0!:=1}$ ]{.mathImpaired display="inline"
> role="math"}[\$0! := 1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->; falls [[$n!$ ]{.math
> display="inline" role="math"}[$\mathsf{n!}$ ]{.mathImpaired
> display="inline" role="math"}[\$n!\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> bereits definiert für
> ein [[$n \in \mathbb{N}_{0}:(n + 1)!:=n! \cdot (n + 1)$ ]{.math
> display="inline"
> role="math"}[$\mathsf{n \in \mathbb{N}_{0}:(n + 1)!:=n! \cdot (n + 1)}$
> ]{.mathImpaired display="inline" role="math"}[\$n \\in \\mathbb{N}\_0:
> (n+1)! := n! \\cdot (n+1)\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> Damit ist [[$n!$ ]{.math display="inline" role="math"}[$\mathsf{n!}$
> ]{.mathImpaired display="inline" role="math"}[\$n!\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> definiert für alle
> [[$n \in \mathbb{N}_{0}$ ]{.math display="inline"
> role="math"}[$\mathsf{n \in \mathbb{N}_{0}}$ ]{.mathImpaired
> display="inline" role="math"}[\$n \\in \\mathbb{N}\_0\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->.

((Seite 14))

\(3) Für [[$n \in \mathbb{N}_{0},k \in \mathbb{N}_{0},k \leq n$ ]{.math
display="inline"
role="math"}[$\mathsf{n \in \mathbb{N}_{0},k \in \mathbb{N}_{0},k \leq n}$
]{.mathImpaired display="inline" role="math"}[\$n \\in \\mathbb{N}\_0
, k \\in \\mathbb{N}\_0, k \\leq n\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->:

> [[$\left( \frac{n}{k} \right):=\frac{n!}{k!(n - k)!}$ ]{.math
> display="inline"
> role="math"}[$\mathsf{\left( \frac{n}{k} \right):=\frac{n!}{k!(n - k)!}}$
> ]{.mathImpaired display="inline" role="math"}[\$\\binom{n}{k} :=
> \\frac{n!}{k!(n-k)!}\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
> (Binomialkoeffizienten)\
> Es gilt:
> [[$\left( \frac{n}{0} \right) = 1;\left( \frac{n}{n} \right) = 1$
> ]{.math display="inline"
> role="math"}[$\mathsf{\left( \frac{n}{0} \right) = 1;\left( \frac{n}{n} \right) = 1}$
> ]{.mathImpaired display="inline" role="math"}[\$\\binom{n}{0}=1;
> \\binom{n}{n}=1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> Ferner:
> [[$\left( \frac{n}{k} \right) + \left( \frac{n}{k - 1} \right) = \left( \frac{n + 1}{k} \right),1 \leq k \leq n$
> ]{.math display="inline"
> role="math"}[$\mathsf{\left( \frac{n}{k} \right) + \left( \frac{n}{k - 1} \right) = \left( \frac{n + 1}{k} \right),1 \leq k \leq n}$
> ]{.mathImpaired display="inline" role="math"}[\$\\binom{n}{k} +
> \\binom{n}{k-1} = \\binom{n+1}{k}, 1 \\leq k \\leq n\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

\(4) *Berouillische Ungleichung:*

> Für [[$x \in \mathbb{R},x \geq - 1$ ]{.math display="inline"
> role="math"}[$\mathsf{x \in \mathbb{R},x \geq - 1}$ ]{.mathImpaired
> display="inline" role="math"}[\$x \\in \\mathbb{R} , x \\geq -
> 1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> und
> [[$n \in \mathbb{N}$ ]{.math display="inline"
> role="math"}[$\mathsf{n \in \mathbb{N}}$ ]{.mathImpaired
> display="inline" role="math"}[\$n \\in \\mathbb{N}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> gilt:
>
> \
>
> ![1+x hoch n größer gleich 1+n mal
> x](Images/Bernouillische%20Ungleichung.svg "Bernouillische Ungleichung"){.toRemove}
>
> \
>
> **Beweis:**\
> [[$n = 1:(1 + x)^{1} = 1 + x = 1 + 1x$ ]{.math display="inline"
> role="math"}[$\mathsf{n = 1:(1 + x)^{1} = 1 + x = 1 + 1x}$
> ]{.mathImpaired display="inline" role="math"}[\$n=1: (1+x)\^1 = 1+x =
> 1+1x\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> Gelte die Behauptung für ein [[$n \in \mathbb{N}$ ]{.math
> display="inline" role="math"}[$\mathsf{n \in \mathbb{N}}$
> ]{.mathImpaired display="inline" role="math"}[\$n \\in
> \\mathbb{N}\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->;\
> [[$(1 + x)^{n + 1} = (1 + x)^{n} \cdot (1 + x) \geq (1 + nx)(1 + x) = 1 + (n + 1)x + nx^{2} \geq 1 + (n + 1)x$
> ]{.math display="inline"
> role="math"}[$\mathsf{(1 + x)^{n + 1} = (1 + x)^{n} \cdot (1 + x) \geq (1 + nx)(1 + x) = 1 + (n + 1)x + nx^{2} \geq 1 + (n + 1)x}$
> ]{.mathImpaired display="inline" role="math"}[\$(1+x)\^{n+1} =
> (1+x)\^n \\cdot (1+x) \\geq (1+nx)(1+x) = 1+ (n+1)x +nx\^2 \\geq
> 1+(n+1)x\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->\
> [[ ]{.math display="inline" role="math"}[$\mathsf{}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\square\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

\(5) Summenzeichen, Produktzeichen:

> Will definieren:
>
> [[$\sum\limits_{k = 1}^{n}a_{k}:=a_{1} + a_{2} + \ldots + a_{n}$
> ]{.math display="inline"
> role="math"}[$\mathsf{\sum\limits_{k = 1}^{n}a_{k}:=a_{1} + a_{2} + \ldots + a_{n}}$
> ]{.mathImpaired display="inline"
> role="math"}[\$\\sum\\limits\_{k=1}\^n a\_k := a\_1+a\_2+ \\ldots +
> a\_n\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> [[[\$\\prod\_{k=1}\^n a\_k := a\_1 \\cdot a\_2 \\dotsm a\_n\$]{.math
> .inline} ]{.math display="inline" role="math"}[[\$\\prod\_{k=1}\^n
> a\_k := a\_1 \\cdot a\_2 \\dotsm a\_n\$]{.math .inline}
> ]{.mathImpaired display="inline" role="math"}[\$\\prod\_{k=1}\^n a\_k
> := a\_1 \\cdot a\_2 \\dotsm a\_n\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> Präzise: setze [[$a_{1} \in \mathbb{R}$ ]{.math display="inline"
> role="math"}[$\mathsf{a_{1} \in \mathbb{R}}$ ]{.mathImpaired
> display="inline" role="math"}[\$a\_1 \\in \\mathbb{R}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, so setze
>
> [[$\sum_{k = 1}^{1}a_{k}:=a_{1}$ ]{.math display="inline"
> role="math"}[$\mathsf{\sum_{k = 1}^{1}a_{k}:=a_{1}}$ ]{.mathImpaired
> display="inline" role="math"}[\$\\sum\_{k=1}\^1 a\_k :=
> a\_1\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> [[$\prod\limits_{k = 1}^{1}a_{k}:=a_{1}$ ]{.math display="inline"
> role="math"}[$\mathsf{\prod\limits_{k = 1}^{1}a_{k}:=a_{1}}$
> ]{.mathImpaired display="inline"
> role="math"}[\$\\prod\\limits\_{k=1}\^1 a\_k := a\_1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> Sind für je [[$n$ ]{.math display="inline" role="math"}[$\mathsf{n}$
> ]{.mathImpaired display="inline" role="math"}[\$n\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> Zahlen
> [[$a_{1},\ldots,a_{n} \in \mathbb{R}$ ]{.math display="inline"
> role="math"}[$\mathsf{a_{1},\ldots,a_{n} \in \mathbb{R}}$
> ]{.mathImpaired display="inline" role="math"}[\$a\_1,\\ldots ,a\_n
> \\in \\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> bereits obige Ausdrücke
> definiert und sind [[$a_{1},\ldots a_{n + 1} \in \mathbb{R}$ ]{.math
> display="inline"
> role="math"}[$\mathsf{a_{1},\ldots a_{n + 1} \in \mathbb{R}}$
> ]{.mathImpaired display="inline" role="math"}[\$a\_1, \\ldots a\_{n+1}
> \\in \\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, so setze
>
> [[$\sum\limits_{k = 1}^{n + 1}a_{k}:=\left( \sum\limits_{k = 1}^{n} \right) + a_{n + 1}$
> ]{.math display="inline"
> role="math"}[$\mathsf{\sum\limits_{k = 1}^{n + 1}a_{k}:=\left( \sum\limits_{k = 1}^{n} \right) + a_{n + 1}}$
> ]{.mathImpaired display="inline"
> role="math"}[\$\\sum\\limits\_{k=1}\^{n+1} a\_k := \\left(
> \\sum\\limits\_{k=1}\^n \\right) + a\_{n+1}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> Produktzeichen analog.\
> Sind [[$p,q \in \mathbb{Z},p \leq q,a_{p},\ldots,a_{q} \in \mathbb{R}$
> ]{.math display="inline"
> role="math"}[$\mathsf{p,q \in \mathbb{Z},p \leq q,a_{p},\ldots,a_{q} \in \mathbb{R}}$
> ]{.mathImpaired display="inline" role="math"}[\$p,q \\in \\mathbb{Z},
> p \\leq q, a\_p, \\ldots , a\_q \\in \\mathbb{R}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->, so definiere
>
> [[$\sum\limits_{k = p}^{q}a_{k}:=\sum\limits_{k = 1}^{q - p + 1}a_{p - 1 + k}$
> ]{.math display="inline"
> role="math"}[$\mathsf{\sum\limits_{k = p}^{q}a_{k}:=\sum\limits_{k = 1}^{q - p + 1}a_{p - 1 + k}}$
> ]{.mathImpaired display="inline"
> role="math"}[\$\\sum\\limits\_{k=p}\^q a\_k :=
> \\sum\\limits\_{k=1}\^{q-p+1} a\_{p-1+k}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> [[$\prod\limits_{k = p}^{q}a_{k}:=\prod\limits_{k = 1}^{q - p + 1}a_{p - 1 + k}$
> ]{.math display="inline"
> role="math"}[$\mathsf{\prod\limits_{k = p}^{q}a_{k}:=\prod\limits_{k = 1}^{q - p + 1}a_{p - 1 + k}}$
> ]{.mathImpaired display="inline"
> role="math"}[\$\\prod\\limits\_{k=p}\^{q} a\_k :=
> \\prod\\limits\_{k=1}\^{q-p+1} a\_{p-1+k}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> Schließlich für [[[\$p &gt; q\$]{.math .inline} ]{.math
> display="inline" role="math"}[[\$p &gt; q\$]{.math .inline}
> ]{.mathImpaired display="inline" role="math"}[\$p \> q\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->:
>
> [[$\sum_{k = p}^{q}a_{k}:=0,\prod_{k = p}^{q}a_{k}:=1$ ]{.math
> display="inline"
> role="math"}[$\mathsf{\sum_{k = p}^{q}a_{k}:=0,\prod_{k = p}^{q}a_{k}:=1}$
> ]{.mathImpaired display="inline" role="math"}[\$\\sum\_{k=p}\^q a\_k
> := 0, \\prod\_{k=p}\^q a\_k := 1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

((Seite15))

\(6) *Binomischer Lehrsatz:*

> Es seien [[$a,b \in \mathbb{R},n \in \mathbb{N}_{0}$ ]{.math
> display="inline"
> role="math"}[$\mathsf{a,b \in \mathbb{R},n \in \mathbb{N}_{0}}$
> ]{.mathImpaired display="inline" role="math"}[\$a,b \\in \\mathbb{R},
> n \\in \\mathbb{N}\_0\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->. Dann gilt:
>
> [[$(a + b)^{n} = \sum_{k = 0}^{n}\left( \frac{n}{k} \right)a^{n - k}b^{k}$
> ]{.math display="inline"
> role="math"}[$\mathsf{(a + b)^{n} = \sum_{k = 0}^{n}\left( \frac{n}{k} \right)a^{n - k}b^{k}}$
> ]{.mathImpaired display="inline" role="math"}[\$(a+b)\^n =
> \\sum\_{k=0}\^n \\binom{n}{k} a\^{n-k} b\^k\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

\(7) Es seien [[$a,b \in \mathbb{R},n \in \mathbb{N}_{0}$ ]{.math
display="inline"
role="math"}[$\mathsf{a,b \in \mathbb{R},n \in \mathbb{N}_{0}}$
]{.mathImpaired display="inline" role="math"}[\$a,b \\in \\mathbb{R}, n
\\in \\mathbb{N}\_0\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Dann gilt:

> [[$a^{n + 1} - b^{n + 1} = (a - b)\sum\limits_{k = 0}^{n}a^{n - k}b^{k}$
> ]{.math display="inline"
> role="math"}[$\mathsf{a^{n + 1} - b^{n + 1} = (a - b)\sum\limits_{k = 0}^{n}a^{n - k}b^{k}}$
> ]{.mathImpaired display="inline" role="math"}[\$a\^{n+1} - b\^{n+1} =
> (a-b) \\sum\\limits\_{k=0}\^n a\^{n-k} b\^k\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

1.6. Wurzeln {style="margin-right: 0px;" dir="ltr"}
------------

Will nun [[$\sqrt[n]{}$ ]{.math display="inline"
role="math"}[$\mathsf{\sqrt[n]{}}$ ]{.mathImpaired display="inline"
role="math"}[\$\\sqrt\[n\]{ }\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> einführen.

### Lemma 1.17.

Für [[$x,y \in \mathbb{R},x,y \geq 0$ ]{.math display="inline"
role="math"}[$\mathsf{x,y \in \mathbb{R},x,y \geq 0}$ ]{.mathImpaired
display="inline" role="math"}[\$x ,y \\in \\mathbb{R} , x,y \\geq
0\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[$n \in \mathbb{N}$
]{.math display="inline" role="math"}[$\mathsf{n \in \mathbb{N}}$
]{.mathImpaired display="inline" role="math"}[\$n \\in
\\mathbb{N}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> gilt:

[[$\left. x \leq y\Leftrightarrow x^{n} \leq y^{n} \right.$ ]{.math
display="inline"
role="math"}[$\mathsf{\left. x \leq y\Leftrightarrow x^{n} \leq y^{n} \right.}$
]{.mathImpaired display="inline" role="math"}[\$x \\leq y
\\Leftrightarrow x\^n \\leq y\^n\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

### Satz und Definition 1.18.

Es sei [[$a \geq 0$ ]{.math display="inline"
role="math"}[$\mathsf{a \geq 0}$ ]{.mathImpaired display="inline"
role="math"}[\$a \\geq 0\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[$n \in \mathbb{N}$
]{.math display="inline" role="math"}[$\mathsf{n \in \mathbb{N}}$
]{.mathImpaired display="inline" role="math"}[\$n \\in
\\mathbb{N}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

*Behauptung:* Es existiert genau ein [[$x \in \mathbb{R},x \geq 0$
]{.math display="inline"
role="math"}[$\mathsf{x \in \mathbb{R},x \geq 0}$ ]{.mathImpaired
display="inline" role="math"}[\$x \\in \\mathbb{R}, x \\geq
0\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> mit [[$x^{n} = a$ ]{.math
display="inline" role="math"}[$\mathsf{x^{n} = a}$ ]{.mathImpaired
display="inline" role="math"}[\$x\^n=a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Dieses [[$x$ ]{.math
display="inline" role="math"}[$\mathsf{x}$ ]{.mathImpaired
display="inline" role="math"}[\$x\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißt [[$n$ ]{.math
display="inline" role="math"}[$\mathsf{n}$ ]{.mathImpaired
display="inline" role="math"}[\$n\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->-te Wurzel aus
[[$a,x = :\sqrt[n]{a}$ ]{.math display="inline"
role="math"}[$\mathsf{a,x = :\sqrt[n]{a}}$ ]{.mathImpaired
display="inline" role="math"}[\$a, x=: \\sqrt\[n\]{a}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
Speziell für [[$n = 2:\sqrt{a}:=\sqrt[2]{a}$ ]{.math display="inline"
role="math"}[$\mathsf{n = 2:\sqrt{a}:=\sqrt[2]{a}}$ ]{.mathImpaired
display="inline" role="math"}[\$n=2: \\sqrt{a} :=
\\sqrt\[2\]{a}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

**Beweis:** Eindeutigkeit nach obigem Lemma. Die Existenz: mit
Zwischenwertsatz für stetige Funktionen [\\\\7.11](file://\\7.11).

### Bemerkung 1.19.

-   [[$\sqrt{2} \notin \mathbb{Q}$ ]{.math display="inline"
    role="math"}[$\mathsf{\sqrt{2} \notin \mathbb{Q}}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\sqrt{2} \\notin
    \\mathbb{Q}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

**Beweis:** *Annahme:* [[$\sqrt{2} \in \mathbb{Q}$ ]{.math
display="inline" role="math"}[$\mathsf{\sqrt{2} \in \mathbb{Q}}$
]{.mathImpaired display="inline" role="math"}[\$\\sqrt{2} \\in
\\mathbb{Q}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, d.h. es gibt
[[$p,q \in \mathbb{N},p,q$ ]{.math display="inline"
role="math"}[$\mathsf{p,q \in \mathbb{N},p,q}$ ]{.mathImpaired
display="inline" role="math"}[\$p,q \\in \\mathbb{N},
p,q\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> teilerfremd, mit
[[$\sqrt{2} = \frac{p}{q}$ ]{.math display="inline"
role="math"}[$\mathsf{\sqrt{2} = \frac{p}{q}}$ ]{.mathImpaired
display="inline" role="math"}[\$\\sqrt{2} = \\frac{p}{q}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->; dann
[[$2 = \frac{p^{2}}{q^{2}}$ ]{.math display="inline"
role="math"}[$\mathsf{2 = \frac{p^{2}}{q^{2}}}$ ]{.mathImpaired
display="inline" role="math"}[\$2= \\frac{p\^2}{q\^2}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, also

[[$p^{2} = 2q^{2}$ ]{.math display="inline"
role="math"}[$\mathsf{p^{2} = 2q^{2}}$ ]{.mathImpaired display="inline"
role="math"}[\$p\^2 = 2q\^2\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

[[$\left. \Rightarrow p^{2} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. \Rightarrow p^{2} \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$\\Rightarrow p\^2\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist durch 2 teilbar.\
[[$\left. \Rightarrow p \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. \Rightarrow p \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$\\Rightarrow p\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist durch 2 teilbar.\
[[$\left. \Rightarrow p^{2} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. \Rightarrow p^{2} \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$\\Rightarrow p\^2\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist durch 4 teilbar.\
[[$\left. \Rightarrow q^{2} \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. \Rightarrow q^{2} \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$\\Rightarrow q\^2\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist durch 2 teilbar.\
[[$\left. \Rightarrow q \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. \Rightarrow q \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$\\Rightarrow q\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> ist durch 2 teilbar.\
[[$\left. \Rightarrow p,q \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. \Rightarrow p,q \right.}$ ]{.mathImpaired
display="inline" role="math"}[\$\\Rightarrow p,q\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> beide durch 2 teilbar;
[[$\Rightarrow$ ]{.math display="inline"
role="math"}[$\mathsf{\Rightarrow}$ ]{.mathImpaired display="inline"
role="math"}[\$\\Rightarrow\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> Widerspruch zu \"[[$p,q$
]{.math display="inline" role="math"}[$\mathsf{p,q}$ ]{.mathImpaired
display="inline" role="math"}[\$p,q\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> teilerfremd\".

-   Nach unserer Definition ist [[$\sqrt[n]{a} \geq 0$ ]{.math
    display="inline" role="math"}[$\mathsf{\sqrt[n]{a} \geq 0}$
    ]{.mathImpaired display="inline" role="math"}[\$\\sqrt\[n\]{a} \\geq
    0\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> (für [[$a \geq 0$
    ]{.math display="inline" role="math"}[$\mathsf{a \geq 0}$
    ]{.mathImpaired display="inline" role="math"}[\$a \\geq
    0\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->)
-   **Achtung**: wir ziehen nur Wurzeln aus Zahlen [[[\$&gt; 0\$]{.math
    .inline} ]{.math display="inline" role="math"}[[\$&gt; 0\$]{.math
    .inline} ]{.mathImpaired display="inline" role="math"}[\$\>
    0\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    Bsp: [[$\sqrt{4} = 2$ ]{.math display="inline"
    role="math"}[$\mathsf{\sqrt{4} = 2}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\sqrt{4} =2\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->; die Gleichung
    [[$x^{2} = 4$ ]{.math display="inline"
    role="math"}[$\mathsf{x^{2} = 4}$ ]{.mathImpaired display="inline"
    role="math"}[\$x\^2=4\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> hat **zwei** Lösungen
    2 und [[$- 2$ ]{.math display="inline" role="math"}[$\mathsf{- 2}$
    ]{.mathImpaired display="inline" role="math"}[\$-2\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->; als **Wurzel**
    wählen wir die Lösung [[$\geq 0$ ]{.math display="inline"
    role="math"}[$\mathsf{\geq 0}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\geq 0\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> aus.
-   [[$\sqrt{a^{2}} = |a|$ ]{.math display="inline"
    role="math"}[$\mathsf{\sqrt{a^{2}} = |a|}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\sqrt{a\^2} = \|a\|\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

((Seite16))

1.7. Potenzen mit rationalen Exponenten
---------------------------------------

Es sei [[\$ a 0\$ ]{.math display="inline" role="math"}[\$ a 0\$
]{.mathImpaired display="inline" role="math"}[\$ a \\geq
0\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[[\$r \\in
\\mathbb{Q}, r&gt;0\$]{.math .inline} ]{.math display="inline"
role="math"}[[\$r \\in \\mathbb{Q}, r&gt;0\$]{.math .inline}
]{.mathImpaired display="inline" role="math"}[\$r \\in \\mathbb{Q},
r\>0\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Also [[$r = \frac{m}{n}$
]{.math display="inline" role="math"}[$\mathsf{r = \frac{m}{n}}$
]{.mathImpaired display="inline" role="math"}[\$r=
\\frac{m}{n}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> mit
[[$m,n \in \mathbb{N}$ ]{.math display="inline"
role="math"}[$\mathsf{m,n \in \mathbb{N}}$ ]{.mathImpaired
display="inline" role="math"}[\$m,n \\in \\mathbb{N}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

Wir *wollen* definieren:

[[$a^{r}:=(\sqrt[n]{a})^{m}$ ]{.math display="inline"
role="math"}[$\mathsf{a^{r}:=(\sqrt[n]{a})^{m}}$ ]{.mathImpaired
display="inline" role="math"}[\$a\^r := ( \\sqrt\[n\]{a}
)\^m\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

Problem: Ist [[$r = \frac{p}{q}$ ]{.math display="inline"
role="math"}[$\mathsf{r = \frac{p}{q}}$ ]{.mathImpaired display="inline"
role="math"}[\$r= \\frac{p}{q}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine weitere Darstellung
von [[$r$ ]{.math display="inline" role="math"}[$\mathsf{r}$
]{.mathImpaired display="inline" role="math"}[\$r\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, gilt dann

[[$(\sqrt[n]{a})^{m} = (\sqrt[q]{a})^{p}$ ]{.math display="inline"
role="math"}[$\mathsf{(\sqrt[n]{a})^{m} = (\sqrt[q]{a})^{p}}$
]{.mathImpaired display="inline" role="math"}[\$( \\sqrt\[n\]{a} )\^m =
( \\sqrt\[q\]{a} )\^p\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->?

Ja! Denn: setze

[[$x:=(\sqrt[n]{a})^{m},y:=(\sqrt[q]{a})^{p}$ ]{.math display="inline"
role="math"}[$\mathsf{x:=(\sqrt[n]{a})^{m},y:=(\sqrt[q]{a})^{p}}$
]{.mathImpaired display="inline" role="math"}[\$x := ( \\sqrt\[n\]{a}
)\^m, y := ( \\sqrt\[q\]{a} )\^p\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->

Dann

[[$x^{q} = \lbrack(\sqrt[n]{a})^{m}\rbrack^{q} = (\sqrt[n]{a})^{mq} = (\sqrt[n]{a})^{np} = \lbrack(\sqrt[n]{a})^{n}\rbrack^{p} = a^{p}$
]{.math display="inline"
role="math"}[$\mathsf{x^{q} = \lbrack(\sqrt[n]{a})^{m}\rbrack^{q} = (\sqrt[n]{a})^{mq} = (\sqrt[n]{a})^{np} = \lbrack(\sqrt[n]{a})^{n}\rbrack^{p} = a^{p}}$
]{.mathImpaired display="inline" role="math"}[\$x\^q= \[( \\sqrt\[n\]{a}
)\^m \]\^q = ( \\sqrt\[n\]{a} )\^{mq} = ( \\sqrt\[n\]{a} )\^{np} = \[ (
\\sqrt\[n\]{a} )\^n \]\^p = a\^p\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

Analog für [[$y^{p}$ ]{.math display="inline"
role="math"}[$\mathsf{y^{p}}$ ]{.mathImpaired display="inline"
role="math"}[\$y\^p\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
d.h. [[$x^{q} = y^{q}$ ]{.math display="inline"
role="math"}[$\mathsf{x^{q} = y^{q}}$ ]{.mathImpaired display="inline"
role="math"}[\$x\^q=y\^q\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Nach Hilfssatz also
[[$x = y$ ]{.math display="inline" role="math"}[$\mathsf{x = y}$
]{.mathImpaired display="inline" role="math"}[\$x=y\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\
Also obige Definition in Ordnung.\
Es gelten die bekannten Rechenregeln.

Ist [[[\$a&gt;0, r \\in \\mathbb{Q}, r&lt;0\$]{.math .inline} ]{.math
display="inline" role="math"}[[\$a&gt;0, r \\in \\mathbb{Q},
r&lt;0\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$a\>0, r \\in \\mathbb{Q}, r\<0\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, so setze
[[$a^{r}:=\frac{1}{a^{- r}}$ ]{.math display="inline"
role="math"}[$\mathsf{a^{r}:=\frac{1}{a^{- r}}}$ ]{.mathImpaired
display="inline" role="math"}[\$a\^r :=
\\frac{1}{a\^{-r}}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

((Seite17))

((Seite18))\

2. Folgen, Konvergenz 
======================

2.1. Definition der Folgen
--------------------------

### Definition 2.1.

Sei [[$X$ ]{.math display="inline" role="math"}[$\mathsf{X}$
]{.mathImpaired display="inline" role="math"}[\$X\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine beliebige Menge,
[[$X \neq \varnothing$ ]{.math display="inline"
role="math"}[$\mathsf{X \neq \varnothing}$ ]{.mathImpaired
display="inline" role="math"}[\$X \\neq \\emptyset\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

Eine Funktion [[$\left. a:\mathbb{N}\rightarrow X \right.$ ]{.math
display="inline"
role="math"}[$\mathsf{\left. a:\mathbb{N}\rightarrow X \right.}$
]{.mathImpaired display="inline" role="math"}[\$a: \\mathbb{N}
\\rightarrow X\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißt *Folge in* [[$X$
]{.math display="inline" role="math"}[$\mathsf{X}$ ]{.mathImpaired
display="inline" role="math"}[\$X\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

Schreibweise:

> [[$\forall n \in \mathbb{N}a_{n}:=a(n)n$ ]{.math display="inline"
> role="math"}[$\mathsf{\forall n \in \mathbb{N}a_{n}:=a(n)n}$
> ]{.mathImpaired display="inline" role="math"}[\$\\forall n \\in
> \\mathbb{N} a\_n := a(n) n\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->-tes Folgenglied
>
> [[$(a_{n})_{n \in \mathbb{N}}$ ]{.math display="inline"
> role="math"}[$\mathsf{(a_{n})_{n \in \mathbb{N}}}$ ]{.mathImpaired
> display="inline" role="math"}[\$(a\_n)\_{n \\in
> \\mathbb{N}}\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> oder
> [[$(a_{n})_{n = 1}^{\infty}$ ]{.math display="inline"
> role="math"}[$\mathsf{(a_{n})_{n = 1}^{\infty}}$ ]{.mathImpaired
> display="inline" role="math"}[\$(a\_n)\_{n=1}\^\\infty\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> oder [[$(a_{n})$
> ]{.math display="inline" role="math"}[$\mathsf{(a_{n})}$
> ]{.mathImpaired display="inline" role="math"}[\$(a\_n)\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> oder (a\_1,a\_2,a\_3,
> \\ldots )\$\$ statt [[$a$ ]{.math display="inline"
> role="math"}[$\mathsf{a}$ ]{.mathImpaired display="inline"
> role="math"}[\$a\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->.

Ist [[$X = \mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{X = \mathbb{R}}$ ]{.mathImpaired display="inline"
role="math"}[\$X = \\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->, so spricht man von
*reellen Folgen*.

### Bemerkung 2.2. {dir="ltr"}

Ist [[$p \in \mathbb{Z}$ ]{.math display="inline"
role="math"}[$\mathsf{p \in \mathbb{Z}}$ ]{.mathImpaired
display="inline" role="math"}[\$p \\in \\mathbb{Z}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und
[[$\left. a:\{ p,p + 1,p + 2,\ldots\}\rightarrow X \right.$ ]{.math
display="inline"
role="math"}[$\mathsf{\left. a:\{ p,p + 1,p + 2,\ldots\}\rightarrow X \right.}$
]{.mathImpaired display="inline" role="math"}[\$a : \\{ p,p+1,p+2,
\\ldots \\} \\rightarrow X\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine Funktion, so spricht
man ebenfalls von einer Folge [[$X$ ]{.math display="inline"
role="math"}[$\mathsf{X}$ ]{.mathImpaired display="inline"
role="math"}[\$X\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

Bezeichnung: [[$(a_{n})_{n = p}^{\infty}$ ]{.math display="inline"
role="math"}[$\mathsf{(a_{n})_{n = p}^{\infty}}$ ]{.mathImpaired
display="inline" role="math"}[\$(a\_n)\_{n=p}\^\\infty\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> oder [[[\$( a\_p
,a\_{p+\^} , \\ldots )\$]{.math .inline} ]{.math display="inline"
role="math"}[[\$( a\_p ,a\_{p+\^} , \\ldots )\$]{.math .inline}
]{.mathImpaired display="inline" role="math"}[\$( a\_p ,a\_{p+\^} ,
\\ldots )\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

### Beispiel 2.3. {dir="ltr"}

-   <div>

    [[$a_{n}:=\frac{1}{n}$ ]{.math display="inline"
    role="math"}[$\mathsf{a_{n}:=\frac{1}{n}}$ ]{.mathImpaired
    display="inline" role="math"}[\$a\_n := \\frac{1}{n}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> für alle
    [[$n \in \mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{n \in \mathbb{N}}$ ]{.mathImpaired
    display="inline" role="math"}[\$n \\in \\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, also\
    [[$(a_{n})_{n \in \mathbb{N}} = (1,\frac{1}{2},\frac{1}{3},\ldots)$
    ]{.math display="inline"
    role="math"}[$\mathsf{(a_{n})_{n \in \mathbb{N}} = (1,\frac{1}{2},\frac{1}{3},\ldots)}$
    ]{.mathImpaired display="inline" role="math"}[\$(a\_n)\_{n \\in
    \\mathbb{N}} = (1, \\frac{1}{2}, \\frac{1}{3}, \\ldots
    )\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

    </div>

-   <div>

    [[$\forall n \in \mathbb{N}a_{2n}:=0,a_{2n - 1}:=1$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\forall n \in \mathbb{N}a_{2n}:=0,a_{2n - 1}:=1}$
    ]{.mathImpaired display="inline" role="math"}[\$\\forall n \\in
    \\mathbb{N} a\_{2n} := 0, a\_{2n-1} :=1\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    also [[$(a_{n})_{n \in \mathbb{N}} = (1,0,1,0,\ldots)$ ]{.math
    display="inline"
    role="math"}[$\mathsf{(a_{n})_{n \in \mathbb{N}} = (1,0,1,0,\ldots)}$
    ]{.mathImpaired display="inline" role="math"}[\$(a\_n)\_{n \\in
    \\mathbb{N}} = (1,0,1,0, \\ldots )\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

    </div>

-   <div>

    [[$\forall n \in \mathbb{N}a_{n}:=( - 1)^{n}$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\forall n \in \mathbb{N}a_{n}:=( - 1)^{n}}$
    ]{.mathImpaired display="inline" role="math"}[\$\\forall n \\in
    \\mathbb{N} a\_n := (-1)\^n\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    also [[$(a_{n})_{n \in \mathbb{N}} = ( - 1,1, - 1,1,\ldots)$ ]{.math
    display="inline"
    role="math"}[$\mathsf{(a_{n})_{n \in \mathbb{N}} = ( - 1,1, - 1,1,\ldots)}$
    ]{.mathImpaired display="inline" role="math"}[\$(a\_n)\_{n \\in 
    \\mathbb{N}} = (-1,1,-1,1, \\ldots )\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

    </div>

### Definition 2.4.

Sei [[$X$ ]{.math display="inline" role="math"}[$\mathsf{X}$
]{.mathImpaired display="inline" role="math"}[\$X\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine beliebige Menge,
[[$X \neq \varnothing$ ]{.math display="inline"
role="math"}[$\mathsf{X \neq \varnothing}$ ]{.mathImpaired
display="inline" role="math"}[\$X \\neq \\emptyset\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.

1.  [[$X$ ]{.math display="inline" role="math"}[$\mathsf{X}$
    ]{.mathImpaired display="inline" role="math"}[\$X\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist* endlich*, wenn
    eine surjektive Abbildung
    [[$\left. \phi:\{ 1,\ldots,n\}\rightarrow X \right.$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\left. \phi:\{ 1,\ldots,n\}\rightarrow X \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\phi : \\{ 1,
    \\ldots ,n \\} \\rightarrow X\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> existiert.
2.  [[$X$ ]{.math display="inline" role="math"}[$\mathsf{X}$
    ]{.mathImpaired display="inline" role="math"}[\$X\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> heißt *abzählbar*,
    wenn [[$X$ ]{.math display="inline" role="math"}[$\mathsf{X}$
    ]{.mathImpaired display="inline" role="math"}[\$X\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> endlich ist *oder*
    eine surjektive Abbildung
    [[$\left. \phi:\mathbb{N}\rightarrow X \right.$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\left. \phi:\mathbb{N}\rightarrow X \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$\\phi : \\mathbb{N}
    \\rightarrow X\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> existiert. (D.h. wenn
    [[$X$ ]{.math display="inline" role="math"}[$\mathsf{X}$
    ]{.mathImpaired display="inline" role="math"}[\$X\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> endlich ist oder eine
    Folge [[$(a_{n})_{n \in \mathbb{N}}$ ]{.math display="inline"
    role="math"}[$\mathsf{(a_{n})_{n \in \mathbb{N}}}$ ]{.mathImpaired
    display="inline" role="math"}[\$(a\_n)\_{n \\in
    \\mathbb{N}}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> in [[$X$ ]{.math
    display="inline" role="math"}[$\mathsf{X}$ ]{.mathImpaired
    display="inline" role="math"}[\$X\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> existiert mit
    [[$\{ a_{1},a_{2},a_{3},\ldots\} = X$ ]{.math display="inline"
    role="math"}[$\mathsf{\{ a_{1},a_{2},a_{3},\ldots\} = X}$
    ]{.mathImpaired display="inline" role="math"}[\$\\{ a\_1,a\_2,a\_3,
    \\ldots \\} =X\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.\
    oder: die Elemente von [[$X$ ]{.math display="inline"
    role="math"}[$\mathsf{X}$ ]{.mathImpaired display="inline"
    role="math"}[\$X\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> können mit
    [[$\{ 1,\ldots,n\}$ ]{.math display="inline"
    role="math"}[$\mathsf{\{ 1,\ldots,n\}}$ ]{.mathImpaired
    display="inline" role="math"}[\$\\{ 1, \\ldots ,n
    \\}\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> oder mit
    [[$\mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> *durchnummeriert*
    werden.)
3.  [[$X$ ]{.math display="inline" role="math"}[$\mathsf{X}$
    ]{.mathImpaired display="inline" role="math"}[\$X\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> heißt
    *überabzählbar*, wenn [[$X$ ]{.math display="inline"
    role="math"}[$\mathsf{X}$ ]{.mathImpaired display="inline"
    role="math"}[\$X\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> nicht abzählbar ist.

### Beispiel 2.5.

-   [[$\mathbb{N}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{N}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{N}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist abzählbar, denn
    [[$\mathbb{N} = \{ a_{1},a_{2},a_{3},\ldots\}$ ]{.math
    display="inline"
    role="math"}[$\mathsf{\mathbb{N} = \{ a_{1},a_{2},a_{3},\ldots\}}$
    ]{.mathImpaired display="inline" role="math"}[\$\\mathbb{N}= \\{
    a\_1,a\_2,a\_3, \\ldots \\}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->
    mit [[$\forall n \in \mathbb{N}a_{n}:=n$ ]{.math display="inline"
    role="math"}[$\mathsf{\forall n \in \mathbb{N}a_{n}:=n}$
    ]{.mathImpaired display="inline" role="math"}[\$\\forall n \\in
    \\mathbb{N} a\_n := n\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.
-   [[$\mathbb{Z}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{Z}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{Z}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist abzählbar.\
    Definiere etwa: [[$a_{1}:=0,a_{2}:=1,a_{3}:= - 1,a_{4}:=2,\ldots$
    ]{.math display="inline"
    role="math"}[$\mathsf{a_{1}:=0,a_{2}:=1,a_{3}:= - 1,a_{4}:=2,\ldots}$
    ]{.mathImpaired display="inline" role="math"}[\$a\_1:=0, a\_2:=1,
    a\_3:=-1, a\_4:=2, \\ldots\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->

((Seite 19))

-   [[$\mathbb{Q}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{Q}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{Q}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist abzählbar.\
    [[$\Rightarrow$ ]{.math display="inline"
    role="math"}[$\mathsf{\Rightarrow}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\Rightarrow\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> Unendliches Rechteck\
    \
      1                                                                                                                                                                                                                                            2                                                                                                                                                                                                                                            3                                                                                                                                                                                                                                            4                                                                                                                                                                                                                                            [[$\ldots$ ]{.math display="inline" role="math"}[$\mathsf{\ldots}$ ]{.mathImpaired display="inline" role="math"}[\$\\ldots\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->
      -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
      [[$\frac{1}{2}$ ]{.math display="inline" role="math"}[$\mathsf{\frac{1}{2}}$ ]{.mathImpaired display="inline" role="math"}[\$\\frac{1}{2}\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->   [[$\frac{2}{2}$ ]{.math display="inline" role="math"}[$\mathsf{\frac{2}{2}}$ ]{.mathImpaired display="inline" role="math"}[\$\\frac{2}{2}\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->   [[$\frac{3}{2}$ ]{.math display="inline" role="math"}[$\mathsf{\frac{3}{2}}$ ]{.mathImpaired display="inline" role="math"}[\$\\frac{3}{2}\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->   [[$\frac{4}{2}$ ]{.math display="inline" role="math"}[$\mathsf{\frac{4}{2}}$ ]{.mathImpaired display="inline" role="math"}[\$\\frac{4}{2}\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->   [[$\ldots$ ]{.math display="inline" role="math"}[$\mathsf{\ldots}$ ]{.mathImpaired display="inline" role="math"}[\$\\ldots\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->
      [[$\vdots$ ]{.math display="inline" role="math"}[$\mathsf{\vdots}$ ]{.mathImpaired display="inline" role="math"}[\$\\vdots\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->                  [[$\vdots$ ]{.math display="inline" role="math"}[$\mathsf{\vdots}$ ]{.mathImpaired display="inline" role="math"}[\$\\vdots\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->                  [[$\vdots$ ]{.math display="inline" role="math"}[$\mathsf{\vdots}$ ]{.mathImpaired display="inline" role="math"}[\$\\vdots\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->                  [[$\vdots$ ]{.math display="inline" role="math"}[$\mathsf{\vdots}$ ]{.mathImpaired display="inline" role="math"}[\$\\vdots\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->                  [[$\ddots$ ]{.math display="inline" role="math"}[$\mathsf{\ddots}$ ]{.mathImpaired display="inline" role="math"}[\$\\ddots\$]{.transparent display="inline"}]{.inlineFormula style="display:inline;"}<!--EndOfInlineMath-->

    Dann setze [[$b_{1}:=0,b_{2}:=a_{1},b_{3}:= - a_{1},\ldots$ ]{.math
    display="inline"
    role="math"}[$\mathsf{b_{1}:=0,b_{2}:=a_{1},b_{3}:= - a_{1},\ldots}$
    ]{.mathImpaired display="inline" role="math"}[\$b\_1:=0, b\_2:=a\_1,
    b\_3:=-a\_1, \\ldots\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, um auch die
    negativen Zahlen durchnummerieren zu können.
-   [[$\mathbb{R}$ ]{.math display="inline"
    role="math"}[$\mathsf{\mathbb{R}}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\mathbb{R}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> ist *überabzählbar*.
    ([[$\Rightarrow$ ]{.math display="inline"
    role="math"}[$\mathsf{\Rightarrow}$ ]{.mathImpaired display="inline"
    role="math"}[\$\\Rightarrow\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> es gibt auch viel
    mehr irrationale Zahlen als rationale)

Ab jetzt seien alle Folgen *reelle* Folgen.

### Definition 2.6.

Sei [[$(a_{n})$ ]{.math display="inline" role="math"}[$\mathsf{(a_{n})}$
]{.mathImpaired display="inline" role="math"}[\$(a\_n)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine reelle Folge.
[[$(a_{n})$ ]{.math display="inline" role="math"}[$\mathsf{(a_{n})}$
]{.mathImpaired display="inline" role="math"}[\$(a\_n)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißt *nach oben bzw.
unten beschränkt*, wenn die Menge [[$M = \{ a_{1},a_{2},a_{3}\ldots\}$
]{.math display="inline"
role="math"}[$\mathsf{M = \{ a_{1},a_{2},a_{3}\ldots\}}$ ]{.mathImpaired
display="inline" role="math"}[\$M= \\{ a\_1,a\_2,a\_3 \\ldots
\\}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> nach oben bzw. unten
beschränkt ist. In diesem Fall:
[[$\sup(a_{n})_{n \in \mathbb{N}}:=\sup M$ ]{.math display="inline"
role="math"}[$\mathsf{\sup(a_{n})_{n \in \mathbb{N}}:=\sup M}$
]{.mathImpaired display="inline" role="math"}[\$\\sup (a\_n)\_{n \\in 
\\mathbb{N}}:= \\sup M\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->.\
Analog für die andere Seite.

[[$(a_{n})$ ]{.math display="inline" role="math"}[$\mathsf{(a_{n})}$
]{.mathImpaired display="inline" role="math"}[\$(a\_n)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> heißt *beschränkt*, wenn
[[$(a_{n})$ ]{.math display="inline" role="math"}[$\mathsf{(a_{n})}$
]{.mathImpaired display="inline" role="math"}[\$(a\_n)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> nach oben und nach unten
beschränkt ist.

2.2. Konvergenz
---------------

Der begriff *Konvergenz* ist der zentrale Begriff der Analysis. Wir
betrachten zunächst die Konvergenz reeller Folgen.

Sei [[$(a_{n})$ ]{.math display="inline" role="math"}[$\mathsf{(a_{n})}$
]{.mathImpaired display="inline" role="math"}[\$(a\_n)\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> eine Folge in
[[$\mathbb{R}$ ]{.math display="inline"
role="math"}[$\mathsf{\mathbb{R}}$ ]{.mathImpaired display="inline"
role="math"}[\$\\mathbb{R}\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> und [[$a \in \mathbb{R}$
]{.math display="inline" role="math"}[$\mathsf{a \in \mathbb{R}}$
]{.mathImpaired display="inline" role="math"}[\$a \\in
\\mathbb{R}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->. Was soll
\"[[$\left. a_{n}\rightarrow a \right.$ ]{.math display="inline"
role="math"}[$\mathsf{\left. a_{n}\rightarrow a \right.}$
]{.mathImpaired display="inline" role="math"}[\$a\_n \\rightarrow
a\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> für [[[\$n \\righttarrow
\\infty\$]{.math .inline} ]{.math display="inline" role="math"}[[\$n
\\righttarrow \\infty\$]{.math .inline} ]{.mathImpaired display="inline"
role="math"}[\$n \\righttarrow \\infty\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath-->\" bedeuten?

1\. Schritt: \"Die Folgenglieder [[$a_{n}$ ]{.math display="inline"
role="math"}[$\mathsf{a_{n}}$ ]{.mathImpaired display="inline"
role="math"}[\$a\_n\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> kommen [[$a$ ]{.math
display="inline" role="math"}[$\mathsf{a}$ ]{.mathImpaired
display="inline" role="math"}[\$a\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> beliebig nahe oder
[[$|a_{n} - a|$ ]{.math display="inline"
role="math"}[$\mathsf{|a_{n} - a|}$ ]{.mathImpaired display="inline"
role="math"}[\$\|a\_n-a\|\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> wird beliebig klein, wenn
[[$n$ ]{.math display="inline" role="math"}[$\mathsf{n}$ ]{.mathImpaired
display="inline" role="math"}[\$n\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> groß wird\".

2\. Schritt: So sollte zum Beispiel gelten:

> [[[\$\| a\_n-a\| &lt; \\frac{1}{1000}\$]{.math .inline} ]{.math
> display="inline" role="math"}[[\$\| a\_n-a\| &lt;
> \\frac{1}{1000}\$]{.math .inline} ]{.mathImpaired display="inline"
> role="math"}[\$\| a\_n-a\| \< \\frac{1}{1000}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->
>
> Nur: für welche [[$n$ ]{.math display="inline"
> role="math"}[$\mathsf{n}$ ]{.mathImpaired display="inline"
> role="math"}[\$n\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->?
>
> Idee: ab einem gewissen Index [[$n_{0}$ ]{.math display="inline"
> role="math"}[$\mathsf{n_{0}}$ ]{.mathImpaired display="inline"
> role="math"}[\$n\_0\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> soll für alle
> [[[\$n&gt;n\_0\$]{.math .inline} ]{.math display="inline"
> role="math"}[[\$n&gt;n\_0\$]{.math .inline} ]{.mathImpaired
> display="inline" role="math"}[\$n\>n\_0\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> die obige Ungleichung
> gelten.\
> Ebenso sollte es ein [[$n_{1} \in \mathbb{N}$ ]{.math display="inline"
> role="math"}[$\mathsf{n_{1} \in \mathbb{N}}$ ]{.mathImpaired
> display="inline" role="math"}[\$n\_1 \\in \\mathbb{N}\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> geben mit [[[\$\|
> a\_n-a\| &lt; 10\^{-6}\$]{.math .inline} ]{.math display="inline"
> role="math"}[[\$\| a\_n-a\| &lt; 10\^{-6}\$]{.math .inline}
> ]{.mathImpaired display="inline" role="math"}[\$\| a\_n-a\| \<
> 10\^{-6}\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> für alle
> [[$n \geq n_{1}$ ]{.math display="inline"
> role="math"}[$\mathsf{n \geq n_{1}}$ ]{.mathImpaired display="inline"
> role="math"}[\$n \\geq n\_1\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->.

3\. Schritt: Ist [[[\$\\epsilon &gt; 0\$]{.math .inline} ]{.math
display="inline" role="math"}[[\$\\epsilon &gt; 0\$]{.math .inline}
]{.mathImpaired display="inline" role="math"}[\$\\epsilon \>
0\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> (und [[$\epsilon$ ]{.math
display="inline" role="math"}[$\mathsf{\epsilon}$ ]{.mathImpaired
display="inline" role="math"}[\$\\epsilon\$]{.transparent
display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> belibig klein), so sollte
es stets ein [[$n_{0} = n_{0}(\epsilon) \in \mathbb{N}$ ]{.math
display="inline"
role="math"}[$\mathsf{n_{0} = n_{0}(\epsilon) \in \mathbb{N}}$
]{.mathImpaired display="inline" role="math"}[\$n\_0 = n\_0( \\epsilon )
\\in \\mathbb{N}\$]{.transparent display="inline"}]{.inlineFormula
style="display:inline;"}<!--EndOfInlineMath--> geben, mit

> [[[\$\| a\_n-a\| &lt; \\epsilon\$]{.math .inline} ]{.math
> display="inline" role="math"}[[\$\| a\_n-a\| &lt; \\epsilon\$]{.math
> .inline} ]{.mathImpaired display="inline" role="math"}[\$\| a\_n-a\|
> \< \\epsilon\$]{.transparent display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath--> für alle
> [[$n \geq n_{0}$ ]{.math display="inline"
> role="math"}[$\mathsf{n \geq n_{0}}$ ]{.mathImpaired display="inline"
> role="math"}[\$n \\geq n\_0\$]{.transparent
> display="inline"}]{.inlineFormula
> style="display:inline;"}<!--EndOfInlineMath-->

Diese Überlegungen führen uns zu folgender

### Definition 2.7. {dir="ltr"}

1.  Die Folge [[$(a_{n})$ ]{.math display="inline"
    role="math"}[$\mathsf{(a_{n})}$ ]{.mathImpaired display="inline"
    role="math"}[\$(a\_n)\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> heißt konvergent
    gegen [[$a$ ]{.math display="inline" role="math"}[$\mathsf{a}$
    ]{.mathImpaired display="inline" role="math"}[\$a\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->, wenn gilt:\
    [[[\$\\forall \\epsilon &gt; 0 \\exists n\_0 \\in \\mathbb{N}
    \\forall n \\geq n\_0 \|a\_n-a\| &lt; \\epsilon\$]{.math .inline}
    ]{.math display="inline" role="math"}[[\$\\forall \\epsilon &gt; 0
    \\exists n\_0 \\in \\mathbb{N} \\forall n \\geq n\_0 \|a\_n-a\| &lt;
    \\epsilon\$]{.math .inline} ]{.mathImpaired display="inline"
    role="math"}[\$\\forall \\epsilon \> 0 \\exists n\_0 \\in
    \\mathbb{N} \\forall n \\geq n\_0 \|a\_n-a\| \<
    \\epsilon\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->\
    In diesem Fall heißt [[$a$ ]{.math display="inline"
    role="math"}[$\mathsf{a}$ ]{.mathImpaired display="inline"
    role="math"}[\$a\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> Grenzwert (Limes) von
    [[$(a_{n})$ ]{.math display="inline" role="math"}[$\mathsf{(a_{n})}$
    ]{.mathImpaired display="inline"
    role="math"}[\$(a\_n)\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.\
    Bezeichnung: [[$a = \lim_{n\leftarrow\infty}a_{n}$ ]{.math
    display="inline"
    role="math"}[$\mathsf{a = \lim_{n\leftarrow\infty}a_{n}}$
    ]{.mathImpaired display="inline" role="math"}[\$a=
    \\lim\_{n\\leftarrow\\infty} a\_n\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> oder:
    [[$\left. a_{n}\rightarrow a \right.$ ]{.math display="inline"
    role="math"}[$\mathsf{\left. a_{n}\rightarrow a \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$a\_n \\rightarrow
    a\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> für
    [[$\left. n\rightarrow\infty \right.$ ]{.math display="inline"
    role="math"}[$\mathsf{\left. n\rightarrow\infty \right.}$
    ]{.mathImpaired display="inline" role="math"}[\$n \\rightarrow
    \\infty\$]{.transparent display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath-->.

((Seite20))

1.  Eine Folge [[$(a_{n})$ ]{.math display="inline"
    role="math"}[$\mathsf{(a_{n})}$ ]{.mathImpaired display="inline"
    role="math"}[\$( a\_n )\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> heißt *konvergent*,
    wenn es ein [[$a \in \mathbb{R}$ ]{.math display="inline"
    role="math"}[$\mathsf{a \in \mathbb{R}}$ ]{.mathImpaired
    display="inline" role="math"}[\$a \\in \\mathbb{R}\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> gibt derart, dass
    [[$(a_{n})$ ]{.math display="inline" role="math"}[$\mathsf{(a_{n})}$
    ]{.mathImpaired display="inline"
    role="math"}[\$(a\_n)\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> gegen [[$a$ ]{.math
    display="inline" role="math"}[$\mathsf{a}$ ]{.mathImpaired
    display="inline" role="math"}[\$a\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> konvergiert.
2.  Eine Folge [[$(a_{n})$ ]{.math display="inline"
    role="math"}[$\mathsf{(a_{n})}$ ]{.mathImpaired display="inline"
    role="math"}[\$(a\_n)\$]{.transparent
    display="inline"}]{.inlineFormula
    style="display:inline;"}<!--EndOfInlineMath--> heißt *divergent*,
    wenn sie nicht konvergent ist.

\

\

<!--EndOfVisibleSection-->
:::
