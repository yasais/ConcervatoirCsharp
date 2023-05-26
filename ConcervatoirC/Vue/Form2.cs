using ConcervatoirC.Controleur;
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
    public partial class Form2 : Form
    {

        Pers pers = new Pers();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string login = textBox1.Text;
            string mdp = textBox2.Text;
            
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(mdp))
            {
                MessageBox.Show("Veuillez entrer votre login et mot de passe.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool connect = pers.AuthAdmin(login, mdp);

            if (connect == true)
            {
                this.Hide();
                Console.WriteLine("connection reussi");
                ListeProf afficherProf = new ListeProf();
                afficherProf.ShowDialog();
            }
            else
            {
                Console.WriteLine("connection echoué");
            }
                




          


        }

      
    }
}
