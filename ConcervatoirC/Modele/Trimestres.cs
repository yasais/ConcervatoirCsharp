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
        private string datePaiement;

        public Trimestres(string libelle, string datefin)
        {
            this.libelle = libelle;
            this.datefin = datefin;
        }

        public Trimestres(int idEleve,  string libelle, string datePaiement,  int paye)
        {
            this.libelle = libelle;
            this.datePaiement = datePaiement;
            this.idEleve = idEleve;
            this.paye = paye;
        }

        public string Libelle { get => libelle; set => libelle = value; }
        public string Datefin { get => datefin; set => datefin = value; }
        public int Paye { get => paye; set => paye = value; }

        public override string ToString()
        {
            if(paye == 1)
            {
                return libelle + ", payé le : " + datePaiement;   
            }
            else
            {
                return libelle + " date de paiement maximum : " + datefin;

            }
        }

    }
}
