using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_convo_Tennis.Classes
{
    public class Equipe
    {
        public Boolean Categorie {get;set;}
        public Int Ordre_equipe {get;set;}
        public Equipe () {}
        public Equipe (Boolean categorie, Int ordre_equipe) {
            this.Categorie = categorie;
            this.Ordre_equipe = ordre_equipe;
        }
        public override string ToString() {
            return "Ordre de l'équipe : " + this.Ordre_equipe + "\nCatégorie : " + this.Categorie;
        }
    }
}
