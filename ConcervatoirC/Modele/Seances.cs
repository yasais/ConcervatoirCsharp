using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcervatoirC.Modele
{
    public class Seances
    {
        private int id;
        private int numsceance;
        private string tranche;
        private string jour;
        private int niveau;
        private int capacite;

        public Seances(int id, int numsceance, string tranche, string jour, int niveau, int capacite)
        {
            this.id = id;
            this.numsceance = numsceance;
            this.tranche = tranche;
            this.jour = jour;
            this.niveau = niveau;
            this.capacite = capacite;
        }

        public int Id { get => id; set => id = value; }
        public int Numsceance { get => numsceance; set => numsceance = value; }
        public string Tranche { get => tranche; set => tranche = value; }
        public string Jour { get => jour; set => jour = value; }
        public int Niveau { get => niveau; set => niveau = value; }
        public int Capacite { get => capacite; set => capacite = value; }

        public override string ToString()
        {
            return " Numéro de la seance: " + numsceance + " ,  Tranche: " + tranche + " ,  Jour: " + jour + " ,  Niveau: " + niveau + " ,  Capacite: " + capacite;
        }
    }
}
