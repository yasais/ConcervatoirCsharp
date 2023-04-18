﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConcervatoirC.Controleur;
using ConcervatoirC.Modele;
using ConcervatoirC.Vue;

namespace ConcervatoirC
{
    public partial class Form1 : Form 
    { 
        Pers pers;
        List<Prof> lesPers = new List<Prof>();
        public Form1()
        {
            InitializeComponent();
            pers = new Pers();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        public void affiche()
        {
            try
            {
                listBoxPersonne.DataSource = null;
                listBoxPersonne.DataSource = lesPers;
                listBoxPersonne.DisplayMember = "Description";
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            lesPers = pers.chargementPers();
            affiche();
        }

        private void Seance_Click(object sender, EventArgs e)
        {
            Prof pr = (Prof)listBoxPersonne.SelectedItem;

            Seance afficherSeance = new Seance(pr);
            afficherSeance.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            AjoutProf afficherAjoutProf = new AjoutProf();
            afficherAjoutProf.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Prof pr = (Prof)listBoxPersonne.SelectedItem;
            this.pers.supprimerProf(pr.Id);
            this.Form1_Load_1(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListeDesEleves listeEleves = new ListeDesEleves();
            listeEleves.ShowDialog();

        }

       
    }
}
