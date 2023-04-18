namespace ConcervatoirC.Vue
{
    partial class ListeEleves
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
            this.listBoxEleves = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxEleves
            // 
            this.listBoxEleves.FormattingEnabled = true;
            this.listBoxEleves.ItemHeight = 16;
            this.listBoxEleves.Location = new System.Drawing.Point(32, 96);
            this.listBoxEleves.Name = "listBoxEleves";
            this.listBoxEleves.Size = new System.Drawing.Size(735, 276);
            this.listBoxEleves.TabIndex = 0;
            this.listBoxEleves.SelectedIndexChanged += new System.EventHandler(this.listBoxEleves_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(220, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(355, 31);
            this.label3.TabIndex = 8;
            this.label3.Text = "La listes des élèves du cours";
            // 
            // ListeEleves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxEleves);
            this.Name = "ListeEleves";
            this.Text = "ListeEleves";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxEleves;
        private System.Windows.Forms.Label label3;
    }
}