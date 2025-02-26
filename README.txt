# Application de gestion de mots de passe

## Description

Ce projet est une application de gestion de mots de passe, permettant de stocker, r�cup�rer et g�rer des mots de passe associ�s � des applications. Les mots de passe sont chiffr�s avec AES ou RSA en fonction du type d'application :  
- **Grand public** : Chiffrement avec AES.  
- **Professionnelle** : Chiffrement avec RSA.  

Le projet est divis� en deux parties : 
- **Back-End** en .NET Core
- **Front-End** en Angular

---

## Pr�requis

Avant de commencer, assurez-vous d'avoir install� les outils suivants :

- **SQL Server Express** pour la base de donn�es.
- **Visual Studio** pour le d�veloppement Back-End.
- **Node.js** pour le d�veloppement Front-End.

---

## Installation

### Base de donn�es

1. Installer **SQL Express**.
2. Ouvrir **SQL Server Management Studio**.
3. Se connecter � `localhost`.
4. Cr�er une base de donn�es nomm�e `apieval`.
5. Lancer les migrations **EF Core** (voir la section API).

### API (Back-End)

1. Cloner le projet avec la commande suivante :
    ```bash
    git clone https://github.com/timotheemillot/evalP2-millot.git
    ```
2. Ouvrir la solution **Visual Studio** pr�sente dans le dossier `API`.
3. Lancer les migrations EF Core en ex�cutant la commande suivante dans la console NuGet :
    ```bash
    dotnet ef database update
    ```
4. Lancer la solution depuis Visual Studio.

### Front-End

1. Cloner le d�p�t du front-end avec la commande suivante :
    ```bash
    git clone https://github.com/timotheemillot/evalP2-millot.git
    ```
2. Acc�dez au dossier `FRONT-EVAL-P2` et ex�cutez la commande suivante dans une fen�tre de commande (CMD) :
    ```bash
    ng serve
    ```
3. Acc�dez � l'application en vous rendant sur `http://localhost:4200`.

---


