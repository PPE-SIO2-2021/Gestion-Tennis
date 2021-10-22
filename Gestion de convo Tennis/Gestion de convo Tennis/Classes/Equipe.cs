using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_convo_Tennis.Classes
{
    public class Equipe
    {
        public int Id { get; set; }
        public Boolean Categorie {get;set;}
        public int Ordre_equipe {get;set;}
        public Equipe () {}
        public Equipe (int id,Boolean categorie, int ordre_equipe) {
            this.Id = id;
            this.Categorie = categorie;
            this.Ordre_equipe = ordre_equipe;
        }
        public override string ToString() {
            return "Ordre de l'équipe : " + this.Ordre_equipe + "\nCatégorie : " + this.Categorie;
        }
    }
}
