# Thoughts about TeX-Formulas and readability for blind users

| Table of Abbreviations: | Javascript | CSS  |
| ----------------------- | ---------- | ---- |
| English                 | EJ         | EC   |
| German                  | GJ         | GC   |

(V0.1.9)



https://de.wikipedia.org/wiki/Brailleschrift#Codetabelle_f%C3%BCr_die_deutsche_Sprache

See page 41 here:  https://web.archive.org/web/20110911011244/http://www.blista.de/download/druckerei/system_d_blindenschrift_7620.pdf



### Typographic questions:

How are `{` and `}` rendered?



###Filter for blind version:

Commands required to be left out in blind version of TeX-formulas (purely visual improvements):

- `\limits`
- `\mathbb{<argument>}` replace with `\<argument>`?
- `\left` and `\right` 
- `\quad` although this can have relevance in separating expressions (end of line indication of applied operation to both sides of an equation).
- replace `\text{<argument>}` and `\mobx{<argument>}` or `\intertext{<argument>}` by `<argument>`?
- replace `\ldots`with `...`
- 



Possible other improvements:

- replace `\cdot` with `\times`?
- remove `\`at beginning of `\in`?
- `>`and `<`: `>`replaced by \less and \greater? "*Das `>` wird verwendet, wenn alle nachfolgenden Zeichen als Großbuchstaben betrachtet werden sollen*"



---

# Inline:

Latex wird in accEpub.txt gespeichert

Und pandoc gibt es in formulaResult.txt zurück

`C:\Users\Zauberherrscher\AppData\Local\Temp\AccessibleEPUB`



Included Packages in inline-conversion:

amssymb (`\mathbb{}`), amsmath (`\text{}`)



Not working:

- `\limits` ?
- `\dotsm` needs to be typed as `\cdots`. But \dotsm is included in amsmath.
- 



> 10.01.2019 15:45 - 17:15

### Capabilities of ~~MathML~~ Pandoc LaTeX to MathML:

[MathML Torture Test](https://mdn.mozillademos.org/en-US/docs/Mozilla/MathML_Project/MathML_Torture_Test$samples/MathML_Torture_Test?revision=1449367)



From https://pandoc.org/MANUAL.html#character-encoding :

When using LaTeX, the following packages need to be available (they are included with all recent versions of [TeX Live](http://www.tug.org/texlive/)): [`amsfonts`](https://ctan.org/pkg/amsfonts), [`amsmath`](https://ctan.org/pkg/amsmath), [`lm`](https://ctan.org/pkg/lm), [`unicode-math`](https://ctan.org/pkg/unicode-math), [`ifxetex`](https://ctan.org/pkg/ifxetex), [`ifluatex`](https://ctan.org/pkg/ifluatex), [`listings`](https://ctan.org/pkg/listings) (if the `--listings` option is used), [`fancyvrb`](https://ctan.org/pkg/fancyvrb), [`longtable`](https://ctan.org/pkg/longtable), [`booktabs`](https://ctan.org/pkg/booktabs), [`graphicx`](https://ctan.org/pkg/graphicx) and [`grffile`](https://ctan.org/pkg/grffile) (if the document contains images), [`hyperref`](https://ctan.org/pkg/hyperref), [`xcolor`](https://ctan.org/pkg/xcolor) (with `colorlinks`), [`ulem`](https://ctan.org/pkg/ulem), [`geometry`](https://ctan.org/pkg/geometry) (with the `geometry` variable set), [`setspace`](https://ctan.org/pkg/setspace) (with `linestretch`), and [`babel`](https://ctan.org/pkg/babel) (with `lang`).

The use of `xelatex` or `lualatex` as the LaTeX engine requires [`fontspec`](https://ctan.org/pkg/fontspec). `xelatex` uses [`polyglossia`](https://ctan.org/pkg/polyglossia) (with `lang`), [`xecjk`](https://ctan.org/pkg/xecjk), and [`bidi`](https://ctan.org/pkg/bidi) (with the `dir` variable set). If the `mathspec` variable is set, `xelatex` will use [`mathspec`](https://ctan.org/pkg/mathspec) instead of [`unicode-math`](https://ctan.org/pkg/unicode-math). The [`upquote`](https://ctan.org/pkg/upquote) and [`microtype`](https://ctan.org/pkg/microtype) packages are used if available, and [`csquotes`](https://ctan.org/pkg/csquotes) will be used for [typography](https://pandoc.org/MANUAL.html#typography) if `\usepackage{csquotes}` is present in the template or included via `/H/--include-in-header`. The [`natbib`](https://ctan.org/pkg/natbib), [`biblatex`](https://ctan.org/pkg/biblatex), [`bibtex`](https://ctan.org/pkg/bibtex), and [`biber`](https://ctan.org/pkg/biber) packages can optionally be used for [citation rendering](https://pandoc.org/MANUAL.html#citation-rendering).





---

# Figures:

##Live-Preview:

Not working:

- `\{`and `\}`
- `\mathbb{}`
- 

