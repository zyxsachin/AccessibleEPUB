Format:

### In general:

The table of contents is written three times in the document?

```powershell
pandoc HM-Skript_Css.epub -o HM-Skript_Css.odt

[WARNING] Duplicate identifier 'toc_0' at input line 1278 column 50
[WARNING] Duplicate identifier 'toc_1' at input line 1278 column 1336
[WARNING] Duplicate identifier 'toc_2' at input line 1278 column 1795
[WARNING] Duplicate identifier 'toc_3' at input line 1278 column 2026
[WARNING] Duplicate identifier 'toc_4' at input line 1278 column 3926
[WARNING] Duplicate identifier 'toc_5' at input line 1278 column 4495
[WARNING] Duplicate identifier 'toc_6' at input line 1278 column 4737
[WARNING] Duplicate identifier 'toc_7' at input line 1278 column 4796
[WARNING] Duplicate identifier 'toc_8' at input line 1278 column 7753
[WARNING] Duplicate identifier 'toc_9' at input line 1278 column 7824
[WARNING] Duplicate identifier 'toc_10' at input line 1278 column 7856
[WARNING] Duplicate identifier 'toc_11' at input line 1284 column 172
[WARNING] Duplicate identifier 'toc_12' at input line 1290 column 291
[WARNING] Duplicate identifier 'toc_13' at input line 1368 column 193
[WARNING] Duplicate identifier 'toc_0' at input line 2538 column 50
[WARNING] Duplicate identifier 'toc_1' at input line 2538 column 1336
[WARNING] Duplicate identifier 'toc_2' at input line 2538 column 1795
[WARNING] Duplicate identifier 'toc_3' at input line 2538 column 2026
[WARNING] Duplicate identifier 'toc_4' at input line 2538 column 3926
[WARNING] Duplicate identifier 'toc_5' at input line 2538 column 4495
[WARNING] Duplicate identifier 'toc_6' at input line 2538 column 4737
[WARNING] Duplicate identifier 'toc_7' at input line 2538 column 4796
[WARNING] Duplicate identifier 'toc_8' at input line 2538 column 7753
[WARNING] Duplicate identifier 'toc_9' at input line 2538 column 7824
[WARNING] Duplicate identifier 'toc_10' at input line 2538 column 7856
[WARNING] Duplicate identifier 'toc_11' at input line 2544 column 172
[WARNING] Duplicate identifier 'toc_12' at input line 2550 column 291
[WARNING] Duplicate identifier 'toc_13' at input line 2628 column 193
```





### converting epub to odt:

`pandoc HM-Skript_Css.epub -o HM-Skript_Css.odt` 

All three versions are displayed 



### converting epub to pdf

`pandoc HM-Skript_Css.epub -o HM-Skript_Css.pdf`

requires rsvg to convert svgs to rastergraphics LaTeX can handle.



### converting epub to markdown

Seems to work pretty well (fast).

`pandoc HM-Skript_Css.epub -o HM-Skript_Css.md`

Although handling the file is buggy.

