using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_convo_Tennis.Classes
{
    public class Joueur
    {
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public Int Age { get; set; }
        public String License { get; set; }
        public String Certificat { get; set; }
        public Boolean Categorie { get; set; }

        public Joueur(){}

        public Joueur(String nom, String prenom, Int age, String license, String certificat, Boolean categorie)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Age = age;
            this.License = license;
            this.Certificat = certificat;
            this.Categorie = categorie;
        }
        public override string ToString()
        {
            return "Nom Prénom, categorie" + "\n" + this.Nom + this.Prenom + ", " + this.Categorie + "\n License : " + this.License + "\n Certificat : " + this.Certificat;
        }
    }
}
