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
        public Classement Classement { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public int Age { get; set; }
        public String Mail { get; set; }
        public String License { get; set; }
        public String Certificat { get; set; }
        public String Categorie { get; set; }

        public Joueur(){}

        public Joueur(int id, String nom, String prenom, int age, String mail, String license, String certificat, String categorie)
        {
            this.Id = id;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Age = age;
            this.Mail = mail;
            this.License = license;
            this.Certificat = certificat;
            this.Categorie = categorie;
        }
        public Joueur(int id, String nom, String prenom, int age, String mail, String license, String certificat, String categorie, Classement classement)
        {
            this.Id = id;
            this.Classement = classement;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Age = age;
            this.Mail = mail;
            this.License = license;
            this.Certificat = certificat;
            this.Categorie = categorie;
        }
        public override string ToString()
        {
            return "Nom : " + this.Nom + " Prénom : " + this.Prenom + " categorie : " + this.Categorie + "\n License : " + this.License + "\n Certificat : " + this.Certificat;
        }
    }
}
