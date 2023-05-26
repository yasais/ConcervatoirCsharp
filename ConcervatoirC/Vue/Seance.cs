using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConcervatoirC.Controleur;
using ConcervatoirC.DAL;
using ConcervatoirC.Modele;

namespace ConcervatoirC.Vue
{
    public partial class Seance : Form
    {
        Seance seance;
        List<Seances> lesSeances = new List<Seances>();
        Prof PrSc;

        public Seance(Prof pr)
        {
            InitializeComponent();
            PrSc = pr;

            int idProf = pr.Id;

            lesSeances = Pers.chargementSeance(idProf);

            if(lesSeances.Count == 0)
            {
                button1.Hide();
                button2.Hide();
                MessageBox.Show("Pas de séance pour ce professeur");
                
            }
            else
            {
                button1.Show();
                button2.Show();
            }

            affiche();

        }

        public void affiche()
        {
            try
            {
                listBoxSeance.DataSource = null;
                listBoxSeance.DataSource = lesSeances;
                listBoxSeance.DisplayMember = "Description";
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Seances idSeance = (Seances)listBoxSeance.SelectedItem;
            
            ListeEleves afficherEleve = new ListeEleves(idSeance);
            afficherEleve.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Seances seance = (Seances)listBoxSeance.SelectedItem;

            this.Hide();

            ModifierSeance modifierSeance = new ModifierSeance(seance);
            modifierSeance.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
            
            AjouterUneSeance ajouterUneSeance = new AjouterUneSeance(PrSc);
            ajouterUneSeance.ShowDialog();
        }
    }
}
