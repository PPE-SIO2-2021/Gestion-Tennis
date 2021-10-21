using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_convo_Tennis.Classes
{
    public class Classement
    {
        public List<Joueur> Joueurs { get; set; }
        public int Index { get; set; }
        public String Rang { get; set; }
        public Classement() { }
        public Classement(int index, String rang)
        {
            this.Index = index;
            this.Rang = rang;
        }
        public override string ToString()
        {
            return this.Rang + "";
        }
    }
}