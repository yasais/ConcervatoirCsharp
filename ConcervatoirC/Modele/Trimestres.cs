using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcervatoirC.Modele
{
    public class Trimestres
    {
        private string libelle;
        private string datefin;
        private int idEleve;
        private int paye;

        public Trimestres(string libelle, string datefin)
        {
            this.libelle = libelle;
            this.datefin = datefin;
        }

        public Trimestres(int idEleve,  string libelle, string datefin,  int paye)
        {
            this.libelle = libelle;
            this.datefin = datefin;
            this.idEleve = idEleve;
            this.paye = paye;
        }

        public string Libelle { get => libelle; set => libelle = value; }
        public string Datefin { get => datefin; set => datefin = value; }

        public override string ToString()
        {
            return  libelle + "  Date de fin de trimestre : " + datefin;
        }

    }
}
