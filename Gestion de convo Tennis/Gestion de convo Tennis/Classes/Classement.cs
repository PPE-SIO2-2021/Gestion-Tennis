using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_convo_Tennis.Classes
{
    public class Classement
    {
        public int Index {get;set;}
        public int Rang {get;set;}
        public Classement (){}
        public Classement (int index, int rang) {
            this.Index=index;
            this.Rang=rang;
        }
        public override string ToString() {
            return "Index : " + this.Index + "\nRang : " + this.Rang;
        }
    }
}
