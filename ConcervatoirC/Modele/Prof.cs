using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcervatoirC.Modele
{
    public class Prof
    {
        private int id;
        private string nom;
        private string prenom;
        private int tel;
        private string mail;
        private string adresse;
        private string instru;
        private double salaires;



        public Prof(int id, string nom, string prenom, int tel, string mail, string adresse, string instrument, double salaire)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.tel = tel;
            this.mail = mail;
            this.adresse = adresse;
            this.instru = instrument;
            this.salaires = salaire;
        }



        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public int Tel { get => tel; set => tel = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Instru { get => instru; set => instru = value; }
        public double Salaires { get => salaires; set => salaires = value; }

        public override string ToString()
        {
            return " -  Nom: "  + nom + ",  Prenom: " + prenom + ",  Telephone: " + tel + ",  Mail: " + mail + ",  Adresse: " + adresse + ",  Instrument: " + instru + ",  Salaire: " + salaires;

        }



    }
}

