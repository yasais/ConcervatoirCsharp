using ConcervatoirC.Controleur;
using ConcervatoirC.Modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConcervatoirC.Vue
{
    public partial class ListeEleves : Form
    {
        Seances eleve;
        List<Eleve> lesEleves = new List<Eleve>();
        Seances e;
        private Seance idSeance;

        public ListeEleves(Seances eS)
        {
            InitializeComponent();
            e = eS;

            if (eS == null)
            {
                MessageBox.Show("Aucun eleves n'est inscrit à cette séance");
                return;
            }

            int numSeance = eS.Id;

            lesEleves = Pers.chargementEleve(numSeance);

            affiche();

        }

        public ListeEleves(Seance idSeance)
        {
            this.idSeance = idSeance;
        }

        public void affiche()
        {
            try
            {
                listBoxEleves.DataSource = null;
                listBoxEleves.DataSource = lesEleves;
                listBoxEleves.DisplayMember = "Description";
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void listBoxEleves_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
