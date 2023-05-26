namespace ConcervatoirC.Vue
{
    partial class SelectListeEleve
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonAddEleve = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(46, 23);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(707, 276);
            this.listBox1.TabIndex = 11;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // buttonAddEleve
            // 
            this.buttonAddEleve.Location = new System.Drawing.Point(302, 354);
            this.buttonAddEleve.Name = "buttonAddEleve";
            this.buttonAddEleve.Size = new System.Drawing.Size(150, 47);
            this.buttonAddEleve.TabIndex = 12;
            this.buttonAddEleve.Text = "Ajouter cet élève";
            this.buttonAddEleve.UseVisualStyleBackColor = true;
            this.buttonAddEleve.Click += new System.EventHandler(this.buttonAddEleve_Click);
            // 
            // SelectListeEleve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonAddEleve);
            this.Controls.Add(this.listBox1);
            this.Name = "SelectListeEleve";
            this.Text = "Selectionner l\'élève à ajouter";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonAddEleve;
    }
}