<u>Fortschrittsübersicht:</u>

| Abschnitt       | Inhalt skizziert   | Inhalt abgeschlossen | Korrekturgelesen | Feinschliff |
| --------------- | ------------------ | -------------------- | ---------------- | ----------- |
| 1 (Einführung)  | :heavy_check_mark: | :x:                  | :x:              | :x:         |
| 2 (Bearbeitung) |                    |                      |                  |             |
| ...             |                    |                      |                  |             |



# Accessible EPUB Editor: Anleitung

<u>Software-Version: 0.1.8,</u>

<u>Dokumentenversion: 0.1 (Deutsch)</u>



## Das Accessible EPUB-Format

Als *Accessible EPUB*-Dateien werden .EPUB-Dateien bezeichnet, welche als alleinstehende Datei mehrere Versionen des selben Dokumentes in sich tragen. So bietet eine Datei den gleichen Inhalt in verschiedenen Ausführungen: zugänglich für Blinde (interpretierbar für Braille-Zeilen und Screen-Reader), für Sehgeschädigte (mit hohem Kontrast und angepasster Formatierung) und für nicht eingeschränkte Nutzer.



## Funktionsprinzip

Um solche Dateien zu erstellen wurde der Accessible EPUB-Editor entwickelt, er bietet ein Arbeitsumfeld in welchem durch wenige Klicks zwischen den verschiedenen Versionen umhergewechselt werden kann. Außerdem die Werkzeuge, um beim Einfügen von Inhalten die verschiedenen Anwendungsfälle abzudecken.



## Installation

Accessible EPUB ist erhältich für Microsoft​ Windows 10 und kann alleinstehend installiert werden, es verwendet keine Software-Abhängigkeiten.

Die Installationsdatei muss heruntergeladen werden und bedarf 50 MB freien Festplattenspeicher. Für das installierte Programm sind 170 MB freier Festplattenspeicher vonnöten.

### Vorgang:

Speichern Sie die Installationsdatei auf Ihrer Festplatte, und führen Sie sie aus.

Wählen Sie einen Speicherort für das Programm auf Ihrer Festplatte, und folgen Sie den weiteren Anweisungen der Installationsroutine.

Nach einer erfolgreichen Installation sollte das Programm "Accessible EPUB" in ihrer Programmliste, und optional eine Verknüpfung dazu auf Ihrem  Desktop erscheinen.



## Eine Neue Accessible EPUB-Datei anlegen:

Führen Sie das Programm aus, Sie erhalten folgendes Fenster:

![Abbildung 1:](Screenshots\Accessible EPUB-000003.png)

Die Schaltfläche "Neu" öffnet ein Dialogfenster um den Speicherort der neuen Datei auszuwählen, wählen Sie einen geeigneten Ordner und Namen hierfür.

In dem folgenden Fenster können Sie die Angaben zu dem Dokument eintragen:

![Neue Datei erstellen](Screenshots\Neue Datei-000005.png)



Die Angaben enthalten:

- den Titel des Dokumentes, dieser ist  unabhängig vom gewählten Dateinamen.

- den Verfasser des Dokumentes um  z.B. Bücher einem Autor zuweisen zu können.

- den Verlag als optionale Kategorisierung.

- die Sprache des Dokumentes (zurzeit nur Englisch oder Deutsch). Diese Angabe ist essentiell, da Screen Reader diese Angabe als Referenz für die Interpretation des Dokumentes benutzen.

- das Dateiformat der Datei, welches bestimmt durch welche Befehlssprache die Funktion gesteuert wird um zwischen den Ausführungen des Inhaltes umherzuwechseln.
  Dieser Parameter sollte mit Bedacht gewählt werden, da nicht jedes E-Book Leseprogramm mit beiden Optionen kompatibel ist. Als Beispiel sei folgende Tabelle genannt:

| Android      | iOS                | Windows             |
| ------------ | ------------------ | ------------------- |
| Reasily: CSS |                    | Readium: CSS        |
|              | Marvin: JavaScript | Calibre: JavaScript |

Drücken Sie auf die Schalftfläche "OK", um das Dokument fertig zu erstellen und die Datei in den gewählten Speicherordner schreiben zu lassen. Sie sehen nun das Hauptfenster des Editors und das leere Dokument.

