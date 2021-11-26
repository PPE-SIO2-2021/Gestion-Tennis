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
        public Dictionary<Joueur, Boolean> Dispo { get; set; }
        public DateTime Date { get; set; }
        public String Categorie { get; set; }
        public int Id { get; set; }

        public Journee () {}
        
        public Journee (int id, DateTime dte, String categorie) {
            this.Id = id;
            this.Date = dte;
            this.Categorie = categorie;
            this.Dispo = new Dictionary<Joueur, Boolean>();
        }
        public override string ToString() {
            return "Date de journée : " + this.Date + "\nCatégorie : " + this.Categorie;
        }
    }
}
