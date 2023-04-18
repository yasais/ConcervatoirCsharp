using ConcervatoirC.Controleur;
using ConcervatoirC.DAL;
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
    public partial class ListeDesEleves : Form
    {
        Pers pers;
        List<Eleve> lesEleve = new List<Eleve>();
        List<Trimestres> lesTrimestre = new List<Trimestres>();
        public ListeDesEleves()
        {
            InitializeComponent();
            pers = new Pers();
            lesEleve = pers.GetAllEleves();
            affiche();
        }

        public void affiche()
        {
            try
            {
                listBox1.DataSource = null;
                listBox1.DataSource = lesEleve;
                listBox1.DisplayMember = "Description";
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        public void affiche2()
        {
            try
            {
                listBox2.DataSource = null;
                listBox2.DataSource = lesTrimestre;
                listBox2.DisplayMember = "Description";
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void ListeDesEleves_Load(object sender, EventArgs e)
        {
           
        }

        private void ListeDesEleves_Load_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            Eleve eleveSelectionne = (Eleve)listBox1.SelectedItem;
            int idEleveSelectionne = eleveSelectionne.Id;
            //Methode trimestre
            lesTrimestre = pers.GetAllTrimestres(idEleveSelectionne);

            affiche2();

            //recuprer l'idEleve
            

        }
    }
}
