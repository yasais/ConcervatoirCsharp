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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ConcervatoirC.Vue
{
    public partial class AjouterUneSeance : Form
    {
        Seances seance;
        Pers controleur = new Pers();
        Prof pr;
        int idProf;
        int showNumSeance;
        public AjouterUneSeance(Prof PrSc)
        {
            InitializeComponent();
            pr = PrSc;
            idProf = pr.Id;
            showNumSeance = Pers.getNumSeance()+1;
            Console.WriteLine(showNumSeance);

        }

        private void AjouterUneSeance_Load(object sender, EventArgs e)
        {

        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string jour = comboBox1.Text;
            List<TrancheHoraire> horaireDispo = controleur.horaireDispo(idProf, jour);

            comboBox2.DataSource = null;
            comboBox2.DataSource = horaireDispo;
            comboBox2.DisplayMember = "Description";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string jour = comboBox1.Text;
            string tranche = comboBox2.Text;
            int niveau = Convert.ToInt32(comboBox3.Text);
            int capacite = Convert.ToInt32(textBox2.Text);

            Pers.ajoutSeance(showNumSeance, idProf,  tranche, jour, niveau, capacite);

            MessageBox.Show("Seance ajoutée");


        }
    }
}
