using ConcervatoirC.Controleur;
using ConcervatoirC.DAL;
using ConcervatoirC.Modele;
using ConcervatoirC.Vue;
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
    public partial class AjoutProf : Form
    {

        /*Détecter la fermeture du form*/
        int SC_CLOSE = 0xF060;
        int WM_SYSCOMMAND = 0x0112;
        bool xClick = false;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND && m.WParam.ToInt32() == SC_CLOSE)
            {
                xClick = true;

                this.Hide();

                /*Ouverture du form précédent*/
                ListeProf listProfesseur = new ListeProf();
                listProfesseur.ShowDialog();

                

            }
            base.WndProc(ref m);
        }


        Instrument Instrument;
        List<Instrument> lesInstruments = new List<Instrument>();
        int id;

        public AjoutProf()
        {
            InitializeComponent();
            
            lesInstruments = Pers.chargementInstrument();
            id = PersonneDAO.recuperationDernierId() + 1;
            affiche();

        }

        public void affiche()
        {
            try
            {
                comboBox1.DataSource = null;
                comboBox1.DataSource = lesInstruments;
                comboBox1.DisplayMember = "Description";
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            string nom = Nom.Text;
            string prenom = Prenom.Text;
            int telephone = Convert.ToInt32(Tel.Text);
            string email = Mail.Text;
            string adresse = Adresse.Text;
            string instrument = comboBox1.Text;
            double salaire = Convert.ToDouble(Salaire.Text);

            Pers.ajoutProf(id, nom, prenom, telephone, email, adresse, instrument, salaire);

           
            //mettre à jour la liste des profs
            /*ListeProf listeProfAJour = (ListeProf)Application.OpenForms["ListeProf"];
            listeProfAJour.reactualisation();*/

            MessageBox.Show("Le professeur a bien été ajouté");

            this.Hide();

            /*Ouverture du form précédent*/
            ListeProf listProfesseur = new ListeProf();
            listProfesseur.ShowDialog();


            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AjoutProf_Load(object sender, EventArgs e)
        {

        }
        
    }
}
