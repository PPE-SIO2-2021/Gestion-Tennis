using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_convo_Tennis.Classes
{
    public class Classement
    {
        public Int Index {get;set;}
        public Int Rang {get;set;}
        public Classement (){}
        public Classement (Int index, Int rang) {
            this.Index=index;
            this.Rang=rang;
        }
        public override string ToString() {
            return "Index : " + this.Index + "\nRang : " + this.Rang;
        }
    }
}
