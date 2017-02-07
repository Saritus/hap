# HAP

[Download](http://www.google.de)

## Werbung

<video width="100%" controls>
  <source src="https://github.com/Saritus/hap/blob/master/docs/advertisingvideo.mp4?raw=true" type="video/mp4">
<a href="https://github.com/Saritus/hap/blob/master/docs/advertisingvideo.mp4?raw=true">Zum Video</a>
</video>

## Anwendung

<video width="100%" controls>
  <source src="https://github.com/Saritus/hap/blob/master/docs/applicationvideo.mp4?raw=true" type="video/mp4">
<a href="https://github.com/Saritus/hap/blob/master/docs/applicationvideo.mp4?raw=true">Zum Video</a>
</video>

## Projekt

<img src="https://cdn.rawgit.com/Saritus/hap/master/docs/classdiagram.png" alt="Klassendiagramm" height="300">

## Lokale Daten

Die lokalen Daten bestehen aus den Drops und den Bildern.

#### Drops

<img src="https://github.com/Saritus/hap/blob/master/docs/drop.png?raw=true" alt="Drop" width="100%">

Die Grundlage von hap sind die sogenannten Drops. Das, was für den Kalender der Termin ist, ist für HAP der Drop. Er speichert Informationen, wie ID, Name, Beschreibung, Kategorie, Ort, Zeit und Bild. Außerdem wird im Drop gekennzeichnet, ob ein Nutzer diesen Drop ignoriert hat.

#### ImageStorage

Der ImageStorage ist für die lokale Verwaltung von Bildern zuständig. Er besitzt ein Nachschlagewerk, welches jedem Bild einen eindeutigen Verweis zugeordnet. Das sorgt dafür, dass Drops, die das gleiche Bild besitzen, dieses nicht mehrfach an unterschiedlichen Stellen gespeichert haben müssen. Außerdem kümmert sich der ImageStorage um das Herunterladen von Bildern aus dem Internet, sollte es sich bei dem eingetragenen Verweis um eine URL handeln.

Programmiert ist der ImageStorage nach dem Prinzip des [Singleton-Patterns][singleton], welches dafür sorgt, dass unterschiedliche Activities auf dieselbe Instanz zugreifen können, ohne sie mittels eines Parameters zu übergeben.

## DropManager

<img src="https://github.com/Saritus/hap/blob/master/docs/dropmanager.png?raw=true" alt="DropManager" width="100%">

Der Objektmanager verwaltet die lokalen Daten.

## Verbindung

<img src="https://github.com/Saritus/hap/blob/master/docs/fakeconnector.png?raw=true" alt="FakeConnector" width="100%">

Die Verbindung wird über einen Connector aufgebaut, der die Drops aus einer externen Quelle lädt.

## Interface

#### Ladebildschirm

<img src="https://cdn.rawgit.com/Saritus/hap/master/docs/LoadingScreen.png" alt="LoadingScreen" height="300">

Während des Ladebildschirms werden die bisher heruntergeladenen und erstellten Drop aus einer Datei geladen. Anschließend wird geprüft, ob es neue Drops auf dem Server gibt, so dass diese ebenfalls dem DropManager hinzugefügt werden können. Sollte es bei den neuen Drops auch neue Bilder geben, so werden auch diese heruntergeladen und im ImageStorage vermerkt.

#### Hauptbildschirm

<img src="https://cdn.rawgit.com/Saritus/hap/master/docs/MainScreen.png" alt="MainScreen" height="300">

In der MainActivity werden alle im Objektmanager vorhandenen Drops als Buttons an der richtigen Stelle auf der Karte angezeigt.

#### Dropliste

<img src="https://cdn.rawgit.com/Saritus/hap/master/docs/History.png" alt="History" height="300">

In der HistoryActivity werden alle Drops des DropManager, sortiert nach ihrem jeweiligen Startdatum, in der Listenansicht angezeigt. Dafür wird für jeden Drop ein TableItem erstellt, welches die ID, den Namen, den Ort, die Startzeit und das Logo entsprechend der Kategorie des Drop besitzt. Diese TableItems werden dann der ListView hinzugefügt.

#### Detailansicht

<img src="https://cdn.rawgit.com/Saritus/hap/master/docs/DropDetail.png" alt="DropDetail" height="300">

In der DropDetailsActivity werden die Interface-Elemente der DropDetailsView mit den Daten eines bestimmten Drops gefüllt.

#### Neuen Drop erstellen

<img src="https://cdn.rawgit.com/Saritus/hap/master/docs/NewDrop.png" alt="NewDrop" height="300">

In der NewDropActivity werden die vom Nutzer eingegebenen Daten ausgewertet und als neuer Drop abgespeichert.

## Beteiligte

Projektmanager: [Tom Ille](https://github.com/JamesTheButler)

Konzeptor: Konstantin George

Gestaltung: [Thomas Theling](https://www.thomastheling.com)

Front-End: [Julian Fuchs](https://github.com/Julian93MI)

Back-End: [Sebastian Mischke](https://github.com/Saritus)

[singleton]: https://msdn.microsoft.com/en-us/library/ff650316.aspx
