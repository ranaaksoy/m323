Terminal Pacman – Projektzusammenfassung

Dieses Projekt ist eine einfache, im Terminal laufende Version des klassischen Pacman-Spiels, entwickelt mit C# (.NET). Ziel des Projekts ist es, grundlegende Konzepte der Spieleentwicklung sowie verschiedene Programmierparadigmen (insbesondere funktionale und objektorientierte Programmierung) zu erlernen.

⸻

Konzept

Das Spiel kombiniert zwei Programmieransätze:

* Immutable (funktional)
    Der Spielzustand wird über unveränderliche Datenstrukturen (GameState, Position) verwaltet. Jede Spielaktion erzeugt einen neuen Zustand.
* Mutable (imperativ)
    Die Spielschleife, Eingabe und Darstellung laufen klassisch über veränderbare Logik.

⸻

Ziel des Spiels

* Punkte (.) einsammeln → Score erhöhen
* Power-Pellets (o) aktivieren → Geister werden verwundbar
* Ghost vermeiden oder bei Power-Up besiegen
* Nicht vom Geist erwischt werden

⸻

Spiel-Features

* Intelligenter Geist mit einfacher KI (verfolgt den Spieler)
* Power-Pellet System
* Score-System
* Game Over Logik
* Farbige Terminal-Ausgabe
* Map-basiertes Levelsystem

⸻

Architektur

Das Projekt ist modular aufgebaut:

* Game → Spielschleife & Rendering
* GameLogic → reine Spielregeln (funktional)
* GameState → kompletter Spielzustand (immutable)
* Map → Spielfeldstruktur
* Position → Koordinaten (immutable record)

⸻

Steuerung

* ↑ ↓ ← → → Bewegung von Pacman

⸻

Lernziele

Dieses Projekt zeigt:

* Game Loop Prinzip
* 2D Arrays und Kartenlogik
* Konsolensteuerung in C#
* Funktionale Programmierung (Immutable State)
* Objektorientierte Strukturierung
* Einfache KI-Logik

⸻

Fazit

Das Projekt ist eine Lernimplementierung eines klassischen Arcade-Spiels, optimiert für Verständnis von Architektur, State-Management und grundlegender KI in C#.