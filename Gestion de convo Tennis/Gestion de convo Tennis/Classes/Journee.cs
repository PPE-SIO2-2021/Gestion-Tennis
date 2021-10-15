using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_convo_Tennis.Classes
{
    public class Journee
    {
        public DateTime Dte { get; set; }
        public Boolean Senior { get; set; }

        public Journee () {}
        
        public Journee (DateTime dte, Boolean senior) {
            this.Dte = dte;
            this.Senior = senior;
        }
        public override string ToString() {
            return "Date de journée : " + this.Dte + "\nCatégorie : " + this.Senior;
        }
    }
}
