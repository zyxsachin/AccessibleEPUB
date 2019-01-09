# Thoughts about TeX-Formulas and readability for blind users



(V0.1.9)



https://de.wikipedia.org/wiki/Brailleschrift#Codetabelle_f%C3%BCr_die_deutsche_Sprache

See page 41 here:  https://web.archive.org/web/20110911011244/http://www.blista.de/download/druckerei/system_d_blindenschrift_7620.pdf



### Typograhpic questions:

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



### Inline:

Included Packages in inline-conversion:

amssymb (`\mathbb{}`), amsmath (`\text{}`)



Not working:

- `\limits`



### Figures:

Not working:

- `\{`and `\}`
- `\mathbb{}`
- 