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
        Seances Se;
        private Seance idSeance;

        public ListeEleves(Seances eS)
        {
            InitializeComponent();
            Se = eS;
            int numSeance = eS.Numsceance;

            lesEleves = Pers.chargementEleve(numSeance);

            affiche();

            if (lesEleves.Count == 0)
            {
                MessageBox.Show("Aucun eleves n'est inscrit à cette séance");
            }
            

      
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SelectListeEleve listeEleves = new SelectListeEleve(Se);
            listeEleves.ShowDialog();
        }

       
    }
}
