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
        public String Categorie { get; set; }
        public int Ordre { get; set; }
        public Equipe () {}
        public Equipe (int id, String categorie, int ordre) {
            this.Id = id;
            this.Categorie = categorie;
            this.Ordre = ordre;
        }
        public override string ToString() {
            return "Ordre de l'équipe : " + this.Ordre + "\nCatégorie : " + this.Categorie;
        }
    }
}
