/// Axel Camp Si-CA1a
/// 12.01.2024
/// Jeu 2048


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace _2048WindowsForms
{
    public partial class Form1 : Form
    {
        // Déclaration des éléments graphiques
        Label[,] lbl = new Label[4, 4];
        int[,] tableau = new int[4, 4];
        Label scoreLabel = new Label();
        int score = 0;
        bool isGameOver = false;
        Color[] color = { Color.Gray, Color.LightBlue, Color.LightCyan, Color.LightGreen, Color.Magenta, Color.Red, Color.Yellow, Color.DarkBlue, Color.DarkCyan, Color.DarkGreen, Color.DarkMagenta, Color.DarkRed, Color.White };

        public Form1()
        {
            InitializeComponent();
            InitializeJeu();
        }

        // Initialisation du jeu
        private void InitializeJeu()
        {
            // Configuration du label affichant le score
            scoreLabel.Bounds = new Rectangle(20, 20 + 100 * 4, 180, 30); // Position en dessous de la grille de jeu
            scoreLabel.Font = new Font("Arial", 16);
            scoreLabel.Text = "Score: 0";
            Controls.Add(scoreLabel);

            // Initialisation de la grille de jeu (labels)
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    lbl[i, j] = new Label();
                    lbl[i, j].Bounds = new Rectangle(20 + 100 * j, 20 + 100 * i, 90, 90);
                    lbl[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    lbl[i, j].Font = new Font("Arial", 20);
                    Controls.Add(lbl[i, j]);
                }
            }

            // Ajout des deux premiers chiffres dans la grille
            AddNewNumber();
            AddNewNumber();
            UpdateBoard();
        }

        // Ajoute un nouveau chiffre (2 ou 4) aléatoirement sur la grille
        private void AddNewNumber()
        {
            Random random = new Random();
            List<int> empty = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (tableau[i, j] == 0)
                    {
                        empty.Add(i * 4 + j);
                    }
                }
            }

            if (empty.Count > 0)
            {
                int index = empty[random.Next(empty.Count)];
                tableau[index / 4, index % 4] = random.NextDouble() < 0.9 ? 2 : 4;
            }
        }

        // Gestion de l'événement de pression d'une touche
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (isGameOver) return;

            int[,] originalTableau = (int[,])tableau.Clone();

            // Déplacement en fonction de la touche pressée
            switch (e.KeyCode)
            {
                case Keys.Left:
                    MoveLeft();
                    break;
                case Keys.Right:
                    MoveRight();
                    break;
                case Keys.Up:
                    MoveUp();
                    break;
                case Keys.Down:
                    MoveDown();
                    break;
            }

            // Si la grille a changé, ajouter un nouveau chiffre
            if (HasBoardChanged(originalTableau, tableau))
            {
                AddNewNumber();
            }

            // Mettre à jour l'affichage de la grille
            UpdateBoard();

            // Vérifier si le joueur a gagné ou si le jeu est terminé
            if (CheckWin())
            {
                MessageBox.Show("Vous avez gagné !");
                isGameOver = true;
            }
            else if (!CanMakeMove())
            {
                MessageBox.Show("Le jeu est fini !");
                isGameOver = true;
            }
        }

        // Mettre à jour l'affichage de la grille
        private void UpdateBoard()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    lbl[i, j].Text = tableau[i, j] == 0 ? string.Empty : tableau[i, j].ToString();
                    lbl[i, j].BackColor = GetColor(tableau[i, j]);
                }
            }
            UpdateScoreDisplay();
        }

        // Obtenir la couleur d'arrière-plan en fonction de la valeur du chiffre
        private Color GetColor(int number)
        {
            int index = (int)Math.Log(number, 2);
            return index >= 0 && index < color.Length ? color[index] : Color.Black;
        }

        // Vérifier si la grille a changé depuis le dernier mouvement
        private bool HasBoardChanged(int[,] original, int[,] current)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (original[i, j] != current[i, j])
                        return true;
                }
            }
            return false;
        }

        // Déplacement des chiffres vers la gauche
        private void MoveLeft()
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 1; col < 4; col++)
                {
                    if (tableau[row, col] == 0) continue;

                    int colIndex = col;
                    while (colIndex > 0 && tableau[row, colIndex - 1] == 0)
                    {
                        tableau[row, colIndex - 1] = tableau[row, colIndex];
                        tableau[row, colIndex] = 0;
                        colIndex--;
                    }

                    if (colIndex > 0 && tableau[row, colIndex - 1] == tableau[row, colIndex])
                    {
                        tableau[row, colIndex - 1] *= 2;
                        score += tableau[row, colIndex - 1];
                        tableau[row, colIndex] = 0;
                    }
                }
            }
        }

        // Déplacement des chiffres vers la droite
        private void MoveRight()
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 2; col >= 0; col--)
                {
                    if (tableau[row, col] == 0) continue;

                    int colIndex = col;
                    while (colIndex < 3 && tableau[row, colIndex + 1] == 0)
                    {
                        tableau[row, colIndex + 1] = tableau[row, colIndex];
                        tableau[row, colIndex] = 0;
                        colIndex++;
                    }

                    if (colIndex < 3 && tableau[row, colIndex + 1] == tableau[row, colIndex])
                    {
                        tableau[row, colIndex + 1] *= 2;
                        score += tableau[row, colIndex + 1];
                        tableau[row, colIndex] = 0;
                    }
                }
            }
        }

        // Déplacement des chiffres vers le haut
        private void MoveUp()
        {
            for (int col = 0; col < 4; col++)
            {
                for (int row = 1; row < 4; row++)
                {
                    if (tableau[row, col] == 0) continue;

                    int rowIndex = row;
                    while (rowIndex > 0 && tableau[rowIndex - 1, col] == 0)
                    {
                        tableau[rowIndex - 1, col] = tableau[rowIndex, col];
                        tableau[rowIndex, col] = 0;
                        rowIndex--;
                    }

                    if (rowIndex > 0 && tableau[rowIndex - 1, col] == tableau[rowIndex, col])
                    {
                        tableau[rowIndex - 1, col] *= 2;
                        score += tableau[rowIndex - 1, col];
                        tableau[rowIndex, col] = 0;
                    }
                }
            }
        }

        // Déplacement des chiffres vers le bas
        private void MoveDown()
        {
            for (int col = 0; col < 4; col++)
            {
                for (int row = 2; row >= 0; row--)
                {
                    if (tableau[row, col] == 0) continue;

                    int rowIndex = row;
                    while (rowIndex < 3 && tableau[rowIndex + 1, col] == 0)
                    {
                        tableau[rowIndex + 1, col] = tableau[rowIndex, col];
                        tableau[rowIndex, col] = 0;
                        rowIndex++;
                    }

                    if (rowIndex < 3 && tableau[rowIndex + 1, col] == tableau[rowIndex, col])
                    {
                        tableau[rowIndex + 1, col] *= 2;
                        score += tableau[rowIndex + 1, col];
                        tableau[rowIndex, col] = 0;
                    }
                }
            }
        }

        // Vérifier s'il est possible de faire un mouvement
        private bool CanMakeMove()
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (tableau[row, col] == 0)
                        return true;

                    if (row < 3 && tableau[row, col] == tableau[row + 1, col])
                        return true;

                    if (col < 3 && tableau[row, col] == tableau[row, col + 1])
                        return true;
                }
            }

            return false;
        }

        // Vérifier si le joueur a gagné
        private bool CheckWin()
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (tableau[row, col] == 2048)
                        return true;
                }
            }
            return false;
        }

        // Mettre à jour l'affichage du score
        private void UpdateScoreDisplay()
        {
            scoreLabel.Text = "Score: " + score.ToString();
        }
    }
}
