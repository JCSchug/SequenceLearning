# SequenceLearning
Inhalt:
1. [Experimentablauf](#experiment)
1. [Ablauf der Anwendung](#anwendung)
1. [Funktionalität der Anwendung und Sicherung der Daten](#funktionen)
1. [Erstellen (Builden) von Unity Projekten](#build)
1. [Hilfreiche Quellen](#support)

<a name="experiment"></a>
## Experimentablauf
<dl>Bei dem Experiment werden vier weiße Kreise auf einem schwarzen Hintergrund dargestellt. </dl>
<dl>Diese leuchten einzeln und (teilweise) zufällig auf, die Aufgabe des Probanden besteht darin die korrekt zugeordnete Taste schnellstmöglichst zu betätigen. </dl> 
<dl>Die Idee bei dem Experiment ist es nach einer gewissen Anzahl von zufälligen Sequenzen, eine geordnete (nicht zufällige) Sequenz zu starten. </dl>
<dl> Interessant ist es dann beim letzten Fragebogen zu sehen, ob ein Proband die geordnete Sequenz erkannt hat. </dl>
<dl>Die räumlich zugeordneten Tasten sind A,S und K,L. </dl>
<dl> Dass heißt der erste Kreis von links aus gesehen ist von der Taste A belegt, der zweite Kreis von links mit der Taste S usw. .  </dl> 

<a name="anwendung"></a> 
## Ablauf der Anwendung

<dl> Beim Start der Anwendung öffnet sich zu Beginn das Hauptmenü. Von hier aus kann ein Task gestartet oder die Anwendung gestoppt werden.  </dl>
<dl> Wählt man die Schaltfläche "Start" aus so öffnet sich als nächstes Fenster eine kurze Erläuterung über den Ablauf des Experiments.  </dl>
<dl> Weitere Fragen zum Verständnis der gestellten Aufgabe können dann anschließend gestellt werden. </dl>
<dl> Sind alle Fragen beantwortet so kann durch das Betätigen der Schaltfläche "Weiter" der erste Fragebogen des Experimentes geöffnet werden.  </dl>
<dl> Dieser Fragebogen dient zur pseudonomisierten Datenerhebung der Probanden. </dl>
 <dl>Nach Abschließen des Fragebogens startet als nächstes zuerst eine Demoversion des Experiments, diese dient dazu die anfänglichen Fehler bei dem eigentlichen Experiment zu minimieren, damit möglichst viele Daten für die Studie relevant sind.</dl>
<dl> Die Demoversion kann bis zu dreimal neugestartet werden.  </dl>
<dl>Nach dem Beenden der Demoversion startet das tatsächliche Experiment. </dl>
<dl>Ist das Experiment beendet erscheint ein Fenster in dem unverkennbar markiert darauf hingewiesen wird, dass das Experiment beendet ist. </dl>
 <dl>Durch das Auswählen des "Zum Fragebogen" Buttons wird der letzte Fragebogen geöffnet.</dl> 
 <dl>Dieser beschäftigt sich mit der Wahrnehmung des Probanden während des Experimentes.  </dl>
 
<a name="funktionen"></a>
## Funktionalität der Anwendung und Sicherung der Daten

<dl>Zum Verwalten der Anzahl der Probanden wird die txt Datei "count.txt" benutzt, die geöffnet und verändert werden kann.</dl>
<dl>Zu finden ist die .txt Datei bei Windows unter "AppData/LocalLow/DefaultCompany/Methodik der Forschung/NR".  </dl>
<dl>Die Ergebnisse der Fragebögen sind in Windows jeweils unter "AppData\LocalLow\DefaultCompany\Methodik der Forschung\CSV\Questionaire_DATA" (Fragebogen zur Datenerhebung) und "AppData\LocalLow\DefaultCompany\Methodik der Forschung\CSV\Questionaire_FINAL" (Abschließender Fragebogen).  </dl>
<dl> Die Ergebnisse des Experiments sind unter "AppData\LocalLow\DefaultCompany\Methodik der Forschung\CSV\Testing" zu finden.</dl>  
<dl>Alle Testdaten werden im .csv Format gespeichert, somit kann eine problemblose Integrierung zum Beispiel in R Studio erfolgen.</dl>

<a name="build"></a>
## Erstellen (Builden) von Unity Projekten
Es gibt bereits eine erstellte .exe Datei in diesem Projekt (zu finden im Ornder "build"). Haben Sie aber Änderungen an dem Projekt vorgenommen und möchten nun das Projekt neu erstellen so befolgen Sie folgende Schritte:
* Überprüfen Sie zu erst, ob alle Übergänge zu den verschiedenen Szenen erfolgreich waren, indem Sie im Unity Editor auf die Play Taste drücken und führen Sie dann anschließend eine manuelle Testphase durch. Die Szenenübergänge werden im aktuellen Projekt über die C# Skripte "MainMenuIntercation.cs","OnCreateQuestionaire_DATA.cs","DEMO.cs","IntroductionSwitcher.cs","StartSession.cs" und "OnCreateQuestionaire_FINAL.cs" geregelt.
* Achten Sie dringend darauf, das die Build-Order korrekt angpasst ist, dazu gehen Sie im Unity Editor auf "File -> Build Settings", nun sollte ein Fenster wie in [Abbildung 1](#buildbild) erscheinen. Dort sehen Sie die Build-Order in numerischer Reihenfolge, dass heißt Ihre Start-Szene beginnt vorner mit einer 0, Ihre zweite mit einer 1 , usw. .
* Diese Anwendung wurde mit einem Windows System entwickelt und ausgeführt, Tests auf anderen Plattformen wurde noch nicht durchgeführt. Deshalb wäre der nächste Schritt das Builden oder auch Erstellen gennant. hierbei lassen Sie alle Einstellungen wie in [Abbildung 1](#buildbild) gezeigt und wählen dann "Build and Run" aus.
* Anschließend können Sie einen Ordner auswählen, in dem Sie die fertig erstellte Anwendung abspeichern möchten. Empfehlenswert ist der "build"- Ordner der diesem Projekt schon zugeordnet ist, da Sie so immer alles zentral in Ihrem Projektverzeichnis verwalten können.
* Sollte sich eine bereits fertig erstellte Anwendung in dem "build" Verzeichnis befinden, so können Sie die darin enthaltenen Datei erhalten lassen und die Anwendung einfach nochmal erstellen lassen. Im Normalfall sollten die alten Dateien gelöscht und durch die neuen erstellten Dateien ersetzt werden. Sollte jedoch ein Fehler auftauchen, so löschen Sie einfach den Inhalt des "build" Verzeichnisses.

<a name="buildbild"></a>
![alt text](https://github.com/Anker13/SequenceLearning/blob/master/Pictures/BuildStructure.PNG "Abbildung 1: Build-Struktur in Unity")

<a name="support"></a>
## Hilfreiche Quellen 
Hier sind noch einige interessante Quellen, falls Sie sich mit der Erstellung neuer Szenen oder UI-Elementen (für das Erstellen eines neuen Fragebogens zum Beispiel) beschäftigen möchten:
* [Unity-Dokumentation rund um das UI-System in Unity (sehr einsteigerfreundlich)](https://docs.unity3d.com/2018.3/Documentation/Manual/UISystem.html)
* [Was sind Szenen in Unity? Und wie erstelle ich diese?](https://docs.unity3d.com/2018.3/Documentation/Manual/CreatingScenes.html)
* [Wie kann ich am Besten eigene 2D-Texturen in mein vorhandenes UI integrieren?](https://docs.unity3d.com/2018.3/Documentation/Manual/Sprites.html)
* Falls Sie Fragen zur Anwendung haben, so können Sie diese in den "Issues" Reiter dieses Repositories stellen. 
