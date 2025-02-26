# Application de gestion de mots de passe

## Description

Ce projet est une application de gestion de mots de passe, permettant de stocker, récupérer et gérer des mots de passe associés à des applications. Les mots de passe sont chiffrés avec AES ou RSA en fonction du type d'application :  
- **Grand public** : Chiffrement avec AES.  
- **Professionnelle** : Chiffrement avec RSA.  

Le projet est divisé en deux parties : 
- **Back-End** en .NET Core
- **Front-End** en Angular

---

LE PROJET EST TERMINE ET TOUTES LES FONCTIONNALITES DEMANDEES ONT ETE IMPLEMENTEES

---

## Prérequis

Avant de commencer, assurez-vous d'avoir installé les outils suivants :

- **SQL Server Express** pour la base de données.
- **Visual Studio** pour le développement Back-End.
- **Node.js** pour le développement Front-End.

---

## Installation

### Base de données

1. Installer **SQL Express**.
2. Ouvrir **SQL Server Management Studio**.
3. Se connecter en local avec SQLExpress`.
4. Créer une base de données nommée `apieval`.
5. Lancer les migrations **EF Core** (voir la section API).

### API (Back-End)

1. Cloner le projet avec la commande suivante :
    ```bash
    git clone https://github.com/timotheemillot/evalP2-millot.git
    ```
2. Ouvrir la solution **Visual Studio** présente dans le dossier `API`.
3. Lancer les migrations EF Core en exécutant la commande suivante dans la console NuGet :
    ```bash
    dotnet ef database update
    ```
4. Lancer la solution depuis Visual Studio.

### Front-End

1. Cloner le dépôt du front-end avec la commande suivante :
    ```bash
    git clone https://github.com/timotheemillot/evalP2-millot.git
    ```
2. Accédez au dossier `FRONT-EVAL-P2` et exécutez la commande suivante dans une fenêtre de commande (CMD) :
    ```bash
    ng serve
    ```
3. Accédez à l'application en vous rendant sur `http://localhost:4200`.

---


