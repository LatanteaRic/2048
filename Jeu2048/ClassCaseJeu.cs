using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Jeu2048
{
    public class ClassCaseJeu : Label
    {
        // Liste des couleurs correspondant aux valeurs des cases
        private static readonly List<Color> ListCouleurs = new List<Color>()
        {
            Color.Azure, Color.Azure, Color.Khaki, Color.Orange, Color.OrangeRed, Color.Red,
            Color.LightPink, Color.GreenYellow, Color.Gray, Color.LightBlue, Color.Cyan, Color.Gold
        };

        // Liste des valeurs possibles des cases
        private static readonly List<int> ListValeurs = new List<int>()
        {
            0, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048
        };

        // Propriété statique pour le score total atteint pendant le jeu
        public static int TotalScore { get; set; }

        // Propriété pour la valeur inscrite dans la case
        public int Valeur { get; set; }

        // Constructeur de la classe
        public ClassCaseJeu(int Index, int CaseLeft, int CaseTop)
        {
            // Initialisation des propriétés et de l'apparence de la case
            InitializeCase(Index, CaseLeft, CaseTop);
        }

        // Méthode privée pour l'initialisation de la case
        private void InitializeCase(int Index, int CaseLeft, int CaseTop)
        {
            BackColor = Color.Azure;
            Name = "Case" + Index;
            Size = new Size(130, 130);
            Location = new Point(CaseLeft, CaseTop);
            BorderStyle = BorderStyle.FixedSingle;
            TextAlign = ContentAlignment.MiddleCenter;
            Font = new Font("Tahoma", 28, FontStyle.Bold);
            Valeur = 0;
        }

        /// <summary>
        /// Affichage de la couleur des cases et calcul du score total 
        /// </summary>
        /// <param name="ListCases"></param>
        public static void AfficheCouleur(List<ClassCaseJeu> ListCases)
        {
            // Réinitialisation du score total
            TotalScore = 0;

            // Parcours de toutes les cases
            for (int i = 0; i <= 15; i++)
            {
                int Index = i;
                // Trouver l'index de la valeur dans la liste des valeurs possibles
                int IndexValeur = ListValeurs.FindIndex(p => p == ListCases[Index].Valeur);
                // Attribution de la couleur correspondante à la case
                ListCases[i].BackColor = ListCouleurs[IndexValeur];
                // Ajout de la valeur de la case au score total
                TotalScore += ListCases[i].Valeur;
            }
        }

        /// <summary>
        /// Déplacement des cases selon la direction
        /// </summary>
        /// <param name="ListIntValues"></param>
        public static void Deplacement(List<int> ListIntValues, List<ClassCaseJeu> ListCases)
        {
            // Parcours de chaque ligne de 4 cases selon le sens bas, haut, droite ou gauche
            // On fusionne les cases de même valeur
            ClassCaseJeu CaseJeu;
            for (int i = 0; i <= ListIntValues.Count - 1; i += 4)
                for (int j = 0; j <= 2; j++) // On ne fait rien pour la dernière case de la ligne ou colonne
                {
                    CaseJeu = ListCases[ListIntValues[i + j]];
                    if (CaseJeu.Valeur != 0)
                        // Test si la fusion est possible avec la case qui suit
                        if (CaseJeu.Valeur == ListCases[ListIntValues[i + j + 1]].Valeur)
                        {
                            CaseJeu.Text = string.Empty; // On vide la case
                            ListCases[ListIntValues[i + j + 1]].Valeur = CaseJeu.Valeur * 2; // On double la case suivante selon la direction
                            ListCases[ListIntValues[i + j + 1]].Text = (CaseJeu.Valeur * 2).ToString();
                            CaseJeu.Valeur = 0;
                        }
                }
            // On fait les décalages pour supprimer les cases vides
            for (int i = 0; i <= ListIntValues.Count - 1; i += 4)
            {
                List<int> Valeurs = new List<int>();
                for (int j = 0; j <= 3; j++)
                {
                    CaseJeu = ListCases[ListIntValues[i + j]];
                    CaseJeu.Text = string.Empty;
                    if (CaseJeu.Valeur != 0)
                        Valeurs.Add(ListCases[ListIntValues[i + j]].Valeur);
                }
                if (Valeurs.Count != 0)
                {
                    while (Valeurs.Count < 4)
                        Valeurs.Insert(0, 0);
                    for (int j = 0; j <= 3; j++)
                    {
                        CaseJeu = ListCases[ListIntValues[i + j]];
                        CaseJeu.Valeur = Valeurs[j];
                        if (CaseJeu.Valeur != 0)
                            CaseJeu.Text = Valeurs[j].ToString();
                    }
                }
            }
        }
    }
}
