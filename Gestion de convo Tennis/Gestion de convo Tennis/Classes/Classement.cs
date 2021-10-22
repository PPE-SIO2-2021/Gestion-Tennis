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
        public int Id { get; set; }
        public int Index { get; set; }
        public String Rang { get; set; }

        public Classement() { }

        public Classement(int, id, int index, String rang)
        {
            this.Id = id;
            this.Index = index;
            this.Rang = rang;
        }
        public override string ToString()
        {
            return "ID : " + this.Id + "\nIndex : " + this.Index + "Rang : "+this.Rang;
        }
    }
}