namespace Jeu2048
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.info = new System.Windows.Forms.Label();
            this.Score = new System.Windows.Forms.Label();
            this.Paneljeu = new System.Windows.Forms.Panel();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.NouvellePartieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // info
            // 
            this.info.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info.Location = new System.Drawing.Point(53, 605);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(569, 119);
            this.info.TabIndex = 6;
            this.info.Text = resources.GetString("info.Text");
            // 
            // Score
            // 
            this.Score.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Score.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score.Location = new System.Drawing.Point(280, 24);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(155, 36);
            this.Score.TabIndex = 5;
            this.Score.Text = "0";
            this.Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Paneljeu
            // 
            this.Paneljeu.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Paneljeu.Location = new System.Drawing.Point(73, 63);
            this.Paneljeu.Name = "Paneljeu";
            this.Paneljeu.Size = new System.Drawing.Size(528, 528);
            this.Paneljeu.TabIndex = 4;
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NouvellePartieToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(674, 24);
            this.MenuStrip1.TabIndex = 10;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // NouvellePartieToolStripMenuItem
            // 
            this.NouvellePartieToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NouvellePartieToolStripMenuItem.Name = "NouvellePartieToolStripMenuItem";
            this.NouvellePartieToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.NouvellePartieToolStripMenuItem.Text = "Nouvelle partie";
            this.NouvellePartieToolStripMenuItem.Click += new System.EventHandler(this.NouvellePartieToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 749);
            this.Controls.Add(this.MenuStrip1);
            this.Controls.Add(this.info);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.Paneljeu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jeu 2048";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label info;
        internal System.Windows.Forms.Label Score;
        internal System.Windows.Forms.Panel Paneljeu;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem NouvellePartieToolStripMenuItem;
    }
}

