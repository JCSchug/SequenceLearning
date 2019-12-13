# SequenceLearning
Inhalt:
1. [Experimentablauf](#experiment)
1. [Ablauf der Anwendung](#anwendung)
1. [Funktionalität der Anwendung und Sicherung der Daten](#funktionen)
1. [Erstellen (Builden) von Unity Projekten](#build)
1. [Hilfreiche Quellen](#support)

<a name="experiment"></a>
## Experimentablauf
Bei dem Experiment werden vier weiße Kreise auf einem schwarzen Hintergrund dargestellt. Diese leuchten einzeln und (teilweise) zufällig auf, die Aufgabe des Probanden besteht darin die korrekt zugeordnete Taste schnellstmöglichst zu betätigen.  
Die Idee bei dem Experiment ist es nach einer gewissen Anzahl von zufälligen Sequenzen, eine geordnete (nicht zufällige) Sequenz zu starten. Interessant ist es dann beim letzten Fragebogen zu sehen, ob ein Proband die geordnete Sequenz erkannt hat. 
Die räumlich zugeordneten Tasten sind A,S und K,L. Dass heißt der erste Kreis von links aus gesehen ist von der Taste A belegt, der zweite Kreis von links mit der Taste S usw. . 
<a name="anwendung"></a>
## Ablauf der Anwendung
Beim Start der Anwendung öffnet sich zu Beginn das Hauptmenü. Von hier aus kann ein Task gestartet oder die Anwendung gestoppt werden.  
Wählt man die Schaltfläche "Start" aus so öffnet sich als nächstes Fenster eine kurze Erläuterung über den Ablauf des Experiments.  
Weitere Fragen zum Verständnis der gestellten Aufgabe können dann anschließend gestellt werden. Sind alle Fragen beantwortet so kann durch das Betätigen der Schaltfläche "Weiter" der erste Fragebogen des Experimentes geöffnet werden.  
Dieser Fragebogen dient zur pseudonomisierten Datenerhebung der Probanden. Nach Abschließen des Fragebogens startet als nächstes zuerst eine Demoversion des Experiments, diese dient dazu die anfänglichen Fehler bei dem eigentlichen Experiment zu minimieren, damit möglichst viele Daten für die Studie relevant sind. Die Demoversion kann bis zu dreimal neugestartet werden.  
Nach dem Beenden der Demoversion startet das tatsächliche Experiment. Ist das Experiment beendet erscheint ein Fenster in dem unverkennbar markiert darauf hingewiesen wird, dass das Experiment beendet ist. Durch das Auswählen des "Zum Fragebogen" Buttons wird der letzte Fragebogen geöffnet. Dieser beschäftigt sich mit der Wahrnehmung des Probanden während des Experimentes.  
<a name="funktionen"></a>
## Funktionalität der Anwendung und Sicherung der Daten
Zum Verwalten der Anzahl der Probanden wird die txt Datei "count.txt" benutzt, die geöffnet und verändert werden kann. Zu finden ist die .txt Datei bei Windows unter "AppData/LocalLow/DefaultCompany/Methodik der Forschung/NR".  
Die Ergebnisse der Fragebögen sind in Windows jeweils unter "AppData\LocalLow\DefaultCompany\Methodik der Forschung\CSV\Questionaire_DATA" (Fragebogen zur Datenerhebung) und "AppData\LocalLow\DefaultCompany\Methodik der Forschung\CSV\Questionaire_FINAL" (Abschließender Fragebogen).  
Die Ergebnisse des Experiments sind unter "AppData\LocalLow\DefaultCompany\Methodik der Forschung\CSV\Testing" zu finden.  
Alle Testdaten werden im .csv Format gespeichert, somit kann eine problemblose Integrierung zum Beispiel in R Studio erfolgen.
### Aufbau und Erläuterung der .csv-Dateien

<a name="build"></a>
## Erstellen (Builden) von Unity Projekten
<a name="support"></a>
## Hilfreiche Quellen 
