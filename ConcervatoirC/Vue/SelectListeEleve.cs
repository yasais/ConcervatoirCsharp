using ConcervatoirC.Controleur;
using ConcervatoirC.Modele;
using Mysqlx.Crud;
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
    public partial class SelectListeEleve : Form
    {
        Pers pers;
        List<Eleve> lesEleve = new List<Eleve>();
        Seances seance;


        public SelectListeEleve(Seances s)
        {
            InitializeComponent();
            pers = new Pers();
            seance = s;
            recuperationEleveDispo();

            Console.WriteLine("Test 1");
        }


        int SC_CLOSE = 0xF060;
        int WM_SYSCOMMAND = 0x0112;
        bool xClick = false;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND && m.WParam.ToInt32() == SC_CLOSE)
            {
                xClick = true;
                this.Hide();
                ListeEleves listEleve = new ListeEleves(seance);
                listEleve.ShowDialog();
            }
                
            base.WndProc(ref m);
        }



        public void recuperationEleveDispo()
        {

            Console.WriteLine("Test 2");
            List<Eleve> lesEleveExclus = new List<Eleve>();
            List<Eleve> listeEleve = new List<Eleve>();
            List<Eleve> listeEleveSeance = new List<Eleve>();

            int numSeance = seance.Numsceance;
            string tranche = seance.Tranche;
            string jour = seance.Jour;
            
            lesEleveExclus = pers.EleveExclu(jour, tranche);

            listeEleve = Pers.getAllEleves();

            Console.WriteLine("Total : " + listeEleve.Count);

            foreach (Eleve eleve in listeEleve)
            {
                int compteur = 0;
                
                foreach (Eleve eleveExclu in lesEleveExclus)
                {
                    if (eleve.Id != eleveExclu.Id)
                    {
                        compteur++; 
                    }
                }
                
                if (compteur == lesEleveExclus.Count)
                {
                    Console.WriteLine("Eleve inclus");
                    listeEleveSeance.Add(eleve);
                }

            }
            
            listBox1.DataSource = null;
            listBox1.DataSource = listeEleveSeance;
            listBox1.DisplayMember = "Description";





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
        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Eleve eleveSelectionne = (Eleve)listBox1.SelectedItem;
            int idEleveSelectionne = eleveSelectionne.Id;
        }

        private void buttonAddEleve_Click(object sender, EventArgs e)
        {
            Eleve el = (Eleve)listBox1.SelectedItem;
            int numSeance = seance.Numsceance;
            int idEleve = el.Id;
            int idProf = seance.Id;
            Pers.ajouterCetEleve(idProf, idEleve, numSeance);

            MessageBox.Show("Eleve ajouté");

            this.Hide();
            ListeEleves listEleve = new ListeEleves(seance);
            listEleve.ShowDialog();
        }
    }
}
