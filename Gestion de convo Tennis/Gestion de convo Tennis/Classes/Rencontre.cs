using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_convo_Tennis.Classes
{
    public class Rencontre
    {
        public List<Equipe> Equipes { get; set; }
        public List<Joueur> Joueurs { get; set; }
        public DateTime Dte { get; set; }
        public String Lieu { get; set; }
        public String Adversaire { get; set; }

        public Rencontre(){}

        public Rencontre(DateTime dte,String lieu, String adversaire) {
            this.Dte = dte;
            this.Lieu = lieu;
            this.Adversaire = adversaire;
        }
        public override string ToString() {
            return "Date de rencontre : " + this.Dte + "\nLieu de rencontre : " + this.Lieu + "\nAdversaire : " + this.Adversaire;
        }
    }
}
