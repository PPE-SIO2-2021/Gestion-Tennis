using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_convo_Tennis.Classes
{
    public class Journee
    {
        public List<Rencontre> Rencontres { get; set; }
        public Dictionary<Joueur,Boolean> Dispo { get; set; }
        public DateTime Dte { get; set; }
        public Boolean Categorie { get; set; }
        public int Id { get; set; }

        public Journee () {}
        
        public Journee (Boolean id, DateTime dte, Boolean senior) {
            this.Id = id;
            this.Dte = dte;
            this.Categorie = senior;
        }
        public override string ToString() {
            return "Date de journée : " + this.Dte + "\nCatégorie : " + this.Categorie;
        }
    }
}
