using ConcervatoirC.Controleur;
using ConcervatoirC.DAL;
using ConcervatoirC.Modele;
using Google.Protobuf.WellKnownTypes;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

                //Gestion de laffichage coloré
                listBox2.DrawMode = DrawMode.OwnerDrawFixed;
                listBox2.DrawItem += new DrawItemEventHandler(ListBox2_DrawItem);
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void ListeDesEleves_Load(object sender, EventArgs e)
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


        //Gstion de la couleur pour payé ou non payé
        private void ListBox2_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {

            Trimestres trim = lesTrimestre[e.Index];
            int etatPaiement = trim.Paye;


            e.DrawBackground();
            Brush myBrush = Brushes.Black;


            if (etatPaiement == 0)
            {
                myBrush = Brushes.Red;
            }
            else
            {
                myBrush = Brushes.Green;
            }

            e.Graphics.DrawString(listBox2.Items[e.Index].ToString(),
                e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //utilisation de InsertionTrimestrePaye
            Eleve eleveSelectionne = (Eleve)listBox1.SelectedItem;
            int idEleve = eleveSelectionne.Id;
            //get trimestre
            Trimestres trim = (Trimestres)listBox2.SelectedItem;
            string libelleTrimestre = trim.Libelle;

            Pers.InsertionTrimestrePaye(idEleve,libelleTrimestre);

            //refresh

            lesTrimestre = pers.GetAllTrimestres(idEleve);

            affiche2();




        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Trimestres)listBox2.SelectedItem != null)
            {
                Trimestres trim = (Trimestres)listBox2.SelectedItem;
                int etatPaiement = trim.Paye;

                if (etatPaiement == 0)
                {
                    string datePaiement = trim.Datefin;

                    DateTime dateTrimestre = DateTime.ParseExact(datePaiement,"dd/MM/yyyy", new CultureInfo("fr-FR", true));
                    DateTime todayDate = DateTime.Today;

                    if (dateTrimestre >= todayDate)
                    {
                        button1.Show();
                    }
                    else
                    {
                        button1.Hide();
                    }
                }
                else
                {
                    button1.Hide();
                }
            }
            else
            {
                button1.Hide();
            }
        }
    }
}
