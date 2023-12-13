using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Jeu2048
{
    public partial class Form1 : Form
    {
        private readonly List<ClassCaseJeu> ListCasesJeu = new List<ClassCaseJeu>();
        private readonly List<int> ListCasesVides = new List<int>();

        private readonly List<int> ListeBas = new List<int>() { 0, 4, 8, 12, 1, 5, 9, 13, 2, 6, 10, 14, 3, 7, 11, 15 };
        private readonly List<int> ListeHaut = new List<int>() { 12, 8, 4, 0, 13, 9, 5, 1, 14, 10, 6, 2, 15, 11, 7, 3 };
        private readonly List<int> ListeDroite = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        private readonly List<int> ListeGauche = new List<int>() { 3, 2, 1, 0, 7, 6, 5, 4, 11, 10, 9, 8, 15, 14, 13, 12 };

        private readonly List<int> Tabgen = new List<int>() { 2, 2, 2, 2, 2, 2, 2, 2, 4, 4, 4 };
        private readonly Random Alea = new Random(DateTime.Now.Millisecond);
        
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Chargement de la form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            int Caseleft, Casetop;
            ClassCaseJeu CaseLabel;
            int Index = 0;
            CaseLabel = null;
            Casetop = 4;
            for (int Row = 0; Row <= 3; Row++)
            {
                Caseleft = 4;
                for (int Col = 0; Col <= 3; Col++)
                {
                    CaseLabel = new ClassCaseJeu(Index, Caseleft, Casetop);
                    ListCasesJeu.Add(CaseLabel);
                    Paneljeu.Controls.Add(CaseLabel);
                    Caseleft += CaseLabel.Width;
                    Index += 1;
                }
                Casetop += CaseLabel.Height;
            }
            InitialiseJeu();
        }

        /// <summary>
        /// Initialisation du jeu
        /// </summary>
        private void InitialiseJeu()
        {
            for (int i = 0; i <= 15; i++)
            {
                ListCasesJeu[i].Valeur = 0;
                ListCasesJeu[i].Text = String.Empty;
            }
            // affichage du premier chiffre
            int IndexCase = Alea.Next(0, 15);
            ListCasesJeu[IndexCase].Valeur = Tabgen[Alea.Next(0, 10)];
            ListCasesJeu[IndexCase].Text = ListCasesJeu[IndexCase].Valeur.ToString();
            AffichageGrille();
        }

        /// <summary>
        /// touches flèches du clavier pour les directions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    ClassCaseJeu.Deplacement(ListeBas, ListCasesJeu);
                    break;
                case Keys.Up:
                    ClassCaseJeu.Deplacement(ListeHaut, ListCasesJeu);
                    break;
                case Keys.Left:
                    ClassCaseJeu.Deplacement(ListeGauche, ListCasesJeu);
                    break;
                case Keys.Right:
                    ClassCaseJeu.Deplacement(ListeDroite, ListCasesJeu);
                    break;
            }
            NouveauChiffre();
            AffichageGrille();
            TestFinJeu();
        }
        
        /// <summary>
        /// On affiche la grille et le score
        /// </summary>
        private void AffichageGrille()
        {
            ClassCaseJeu.AfficheCouleur(ListCasesJeu);
            Score.Text = ClassCaseJeu.TotalScore.ToString();
        }

        /// <summary>
        /// On insère un nouveau chiffre dans une case vide
        /// </summary>
        private void NouveauChiffre()
        {
            ListCasesVides.Clear();
            for (int i = 0; i <= 15; i++)
                if (ListCasesJeu[i].Valeur == 0)
                    ListCasesVides.Add(i);
            if (ListCasesVides.Count == 0)
                return;
            int NouvelleCase = Alea.Next(0, ListCasesVides.Count - 1);
            ListCasesJeu[ListCasesVides[NouvelleCase]].Valeur = Tabgen[Alea.Next(0, 10)];
            ListCasesJeu[ListCasesVides[NouvelleCase]].Text = ListCasesJeu[ListCasesVides[NouvelleCase]].Valeur.ToString();
        }

        /// <summary>
        /// Teste si le jeu est fini et bloqué
        /// </summary>
        private void TestFinJeu()
        {
            Score.Text = ClassCaseJeu.TotalScore.ToString();
            if (ListCasesVides.Count == 0)
                MessageBox.Show("Vous êtes bloqué : fin de jeu !!!!!!!!", "Jeu 2048", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Nouvelle partie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NouvellePartieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitialiseJeu();
        }
    }
}
