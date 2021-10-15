using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_convo_Tennis.Classes
{
    public class Classement
    {
        public int Id { get; set; }
        public int Index {get;set;}
        public int Rang {get;set;}
        
        public Classement (){}
        public Classement (int unId,int index, int rang) {
            this.Id = unId;
            this.Index = index;
            this.Rang = rang;
        }
        public override string ToString() {
            return "ID : " + Id + " Index : " + this.Index + "\nRang : " + this.Rang;
        }
    }
}
