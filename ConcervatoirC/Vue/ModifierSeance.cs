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
using ConcervatoirC.Modele;

namespace ConcervatoirC.Vue
{
    public partial class ModifierSeance : Form
    {
        Seances seance;
        Pers controleur = new Pers();
        Prof pr;
        int idProf;
        public ModifierSeance(Seances seance)
        {
            InitializeComponent();
            this.seance = seance;
            pr = controleur.findProfById(seance.Id);

            textBox1.Text = seance.Id.ToString();
            textBox2.Text = pr.Nom;
            idProf = pr.Id;
            textBox3.Text = seance.Capacite.ToString();

            comboBox2.Text = seance.Jour.ToString();


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
                Seance seance = new Seance(pr);
                seance.ShowDialog();
            }
            base.WndProc(ref m);
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string heure = (string)comboBox1.GetItemText(comboBox1.SelectedItem);
                string jour = (string)comboBox2.GetItemText(comboBox2.SelectedItem);

                if (heure != "" && jour != "")
                {
                    controleur.modifieDateSeance(jour, heure, this.seance.Numsceance);

                    MessageBox.Show("Modifications réusites");
                    this.Hide();
                    Seance seance = new Seance(pr);
                    seance.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Vous devez selectioner un jour et une tranche horaire");
                }
            }
            catch (Exception emp)
            {

                MessageBox.Show(emp.ToString());

            }
        }

        

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string jour = comboBox2.Text;
            List<TrancheHoraire> horaireDispo = controleur.horaireDispo(idProf, jour);

            comboBox1.DataSource = null;
            comboBox1.DataSource = horaireDispo;
            comboBox1.DisplayMember = "Description";

            


        }


        
    }
    }

