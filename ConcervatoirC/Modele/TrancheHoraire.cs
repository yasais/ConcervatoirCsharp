using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcervatoirC.Modele
{
    public class TrancheHoraire
    {
        private string tranche;

        public TrancheHoraire(string tranche)
        {
            this.tranche = tranche;
        }

        public override string ToString()
        {
            return this.tranche;
        }
    }
}
