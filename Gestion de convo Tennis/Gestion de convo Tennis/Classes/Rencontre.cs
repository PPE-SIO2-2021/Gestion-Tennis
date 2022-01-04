using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_convo_Tennis.Classes
{
    public class Rencontre
    {
        public Equipe Equipe { get; set; }
        public List<Joueur> Joueurs { get; set; }
        public DateTime DteHeure { get; set; }
        public String Lieu { get; set; }
        public String Adversaire { get; set; }

        public Rencontre(){}

        public Rencontre(DateTime dte,String lieu, String adversaire) {
            this.DteHeure = dte;
            this.Lieu = lieu;
            this.Adversaire = adversaire;
            this.Joueurs = new List<Joueur>();

        }
        public override string ToString() {
            return "Date de rencontre : " + this.DteHeure + "\nLieu de rencontre : " + this.Lieu + "\nAdversaire : " + this.Adversaire;
        }
    }
}
