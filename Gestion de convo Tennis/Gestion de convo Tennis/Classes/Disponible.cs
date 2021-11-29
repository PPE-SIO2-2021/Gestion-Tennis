using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_convo_Tennis.Classes
{
    public class Disponible
    {
        public Boolean IsDispo { get; set; }

        public Disponible () {}

        public Disponible (Boolean isdispo) {
            this.IsDispo = isdispo;
        }

        public override string ToString() {
            return "Dispo : " + this.IsDispo;
        }

    }
}
