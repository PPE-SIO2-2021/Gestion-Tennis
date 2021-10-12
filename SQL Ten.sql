DROP DATABASE IF EXISTS tennis;
CREATE DATABASE tennis;
USE tennis;

CREATE TABLE Equipe(
   id_equipe INT AUTO_INCREMENT PRIMARY KEY ,
   categorie_equipe VARCHAR(50),
   ordre_equipe INT
);

CREATE TABLE Journée(
   id_journée INT AUTO_INCREMENT PRIMARY KEY,
   dte_journee DATE,
   categorie_journee VARCHAR(50),
);

CREATE TABLE Rencontre(
   id_rencontre INT AUTO_INCREMENT PRIMARY KEY,
   adversaire VARCHAR(50),
   lieu VARCHAR(50),
   dte_rencontre DATE,
   heure TIME,
   fk_id_journée VARCHAR(50) NOT NULL,
   fk_id_equipe INT NOT NULL,
   FOREIGN KEY(fk_id_journée) REFERENCES Journée(id_journée),
   FOREIGN KEY(fk_id_equipe) REFERENCES Equipe(id_equipe)
);

CREATE TABLE Classement(
   id_classement INT AUTO_INCREMENT PRIMARY KEY,
   ordre_class INT,
   libelle VARCHAR(50)
);

CREATE TABLE Joueur(
   id_joueur INT AUTO_INCREMENT PRIMARY KEY,
   nom VARCHAR(50),
   prenom VARCHAR(50),
   categorie_joueur VARCHAR(50),
   certificat VARCHAR(50),
   licence VARCHAR(50),
   fk_id_classement INT NOT NULL,
   FOREIGN KEY(fk_id_classement) REFERENCES Classement(id_classement)
);

CREATE TABLE Convoque(
   fk_id_joueur INT,
   fk_id_rencontre VARCHAR(50),
   PRIMARY KEY(fk_id_joueur, fk_id_rencontre),
   FOREIGN KEY(fk_id_joueur) REFERENCES Joueur(id_joueur),
   FOREIGN KEY(fk_id_rencontre) REFERENCES Rencontre(id_rencontre)
);

CREATE TABLE Disponible(
   fk_id_joueur INT,
   fk_id_journée VARCHAR(50),
   is_dispo LOGICAL NOT NULL,
   PRIMARY KEY(fk_id_joueur, fk_id_journée),
   FOREIGN KEY(fk_id_joueur) REFERENCES Joueur(id_joueur),
   FOREIGN KEY(fk_id_journée) REFERENCES Journée(id_journée)
);
