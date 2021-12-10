using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_de_convo_Tennis.Classes;

namespace Gestion_de_convo_Tennis.Classes
{
    public class Joueur
    {
        public int Id { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public int Age { get; set; }
        public String Mail { get; set; }
        public String Categorie { get; set; }
        public String Certificat { get; set; }
        public String Licence { get; set; }
        public Classement Classement { get; set; }

        public Joueur(){}

        //CONSCTRUCTEUR D'EVENEMENTS DB
        public Joueur(int id, String nom, String prenom, int age, String mail, String categorie, String certificat, String licence)
        {
            this.Id = id;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Age = age;
            this.Mail = mail;
            this.Categorie = categorie;
            this.Certificat = certificat;
            this.Licence = licence;
        }
        public Joueur(int id, String nom, String prenom, int age, String mail, String categorie, String certificat, String licence, Classement classement)
        {
            this.Id = id;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Age = age;
            this.Mail = mail;
            this.Categorie = categorie;
            this.Certificat = certificat;
            this.Licence = licence;
            this.Classement = classement;
        }

        //CONSTRUCTEURS LOGICIEL
        public Joueur(String nom, String prenom, int age, String mail, String categorie)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Age = age;
            this.Mail = mail;
            this.Categorie = categorie;
            this.Certificat = "";
            this.Licence = "";
        }
        public Joueur(String nom, String prenom, int age, String mail, String categorie, Classement classement)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Age = age;
            this.Mail = mail;
            this.Categorie = categorie;
            this.Certificat = "";
            this.Licence = "";
            this.Classement = classement;
        }
    }
}
