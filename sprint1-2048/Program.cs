using System;

namespace Console2048
{
    class Program
    {
        // Déclaration de la grille du jeu et du générateur de nombres aléatoires
        static int[,] grille = new int[4, 4];
        static Random random = new Random();

        // Méthode principale du jeu
        static void Main()
        {
            // Initialisation du jeu
            InitialiserJeu();
            // Affichage de la grille initiale
            AfficherGrille();

            // Boucle principale du jeu
            while (true)
            {
                // Lecture de la touche appuyée par le joueur
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                // Sortir de la boucle si la touche "Escape" est pressée
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }

                // Gestion de l'entrée utilisateur
                GererEntree(keyInfo);
                // Affichage de la grille après chaque mouvement
                AfficherGrille();
            }
        }

        // Initialisation du jeu en générant deux tuiles aléatoires
        static void InitialiserJeu()
        {
            GenererTuileAleatoire();
            GenererTuileAleatoire();
        }

        // Affichage de la grille de jeu dans la console
        static void AfficherGrille()
        {
            Console.Clear();
            Console.WriteLine("Jeu 2048");
            Console.WriteLine();

            for (int ligne = 0; ligne < 4; ligne++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Console.Write($"{grille[ligne, col],-6}");
                }
                Console.WriteLine();
            }
        }

        // Gestion de l'entrée utilisateur pour déplacer les tuiles
        static void GererEntree(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    Deplacer(Direction.Haut);
                    break;
                case ConsoleKey.DownArrow:
                    Deplacer(Direction.Bas);
                    break;
                case ConsoleKey.LeftArrow:
                    Deplacer(Direction.Gauche);
                    break;
                case ConsoleKey.RightArrow:
                    Deplacer(Direction.Droite);
                    break;
            }
        }

        // Méthode de déplacement principal qui appelle les méthodes spécifiques de déplacement
        static void Deplacer(Direction direction)
        {
            bool deplace = false;

            switch (direction)
            {
                case Direction.Haut:
                    for (int col = 0; col < 4; col++)
                        deplace |= DeplacerColonneHaut(col);
                    break;
                case Direction.Bas:
                    for (int col = 0; col < 4; col++)
                        deplace |= DeplacerColonneBas(col);
                    break;
                case Direction.Gauche:
                    for (int ligne = 0; ligne < 4; ligne++)
                        deplace |= DeplacerLigneGauche(ligne);
                    break;
                case Direction.Droite:
                    for (int ligne = 0; ligne < 4; ligne++)
                        deplace |= DeplacerLigneDroite(ligne);
                    break;
            }

            // Si le déplacement a eu lieu, générer une nouvelle tuile
            if (deplace)
                GenererTuileAleatoire();
        }

        // Méthode de déplacement d'une colonne vers le haut
        static bool DeplacerColonneHaut(int col)
        {
            bool deplace = false;

            for (int ligne = 1; ligne < 4; ligne++)
            {
                if (grille[ligne, col] != 0)
                {
                    int ligneCourante = ligne;
                    while (ligneCourante > 0 && grille[ligneCourante - 1, col] == 0)
                    {
                        grille[ligneCourante - 1, col] = grille[ligneCourante, col];
                        grille[ligneCourante, col] = 0;
                        ligneCourante--;
                        deplace = true;
                    }
                }
            }

            return deplace;
        }

        // Méthode de déplacement d'une colonne vers le bas
        static bool DeplacerColonneBas(int col)
        {
            bool deplace = false;

            for (int ligne = 2; ligne >= 0; ligne--)
            {
                if (grille[ligne, col] != 0)
                {
                    int ligneCourante = ligne;
                    while (ligneCourante < 3 && grille[ligneCourante + 1, col] == 0)
                    {
                        grille[ligneCourante + 1, col] = grille[ligneCourante, col];
                        grille[ligneCourante, col] = 0;
                        ligneCourante++;
                        deplace = true;
                    }
                }
            }

            return deplace;
        }

        // Méthode de déplacement d'une ligne vers la gauche
        static bool DeplacerLigneGauche(int ligne)
        {
            bool deplace = false;

            for (int col = 1; col < 4; col++)
            {
                if (grille[ligne, col] != 0)
                {
                    int colCourante = col;
                    while (colCourante > 0 && grille[ligne, colCourante - 1] == 0)
                    {
                        grille[ligne, colCourante - 1] = grille[ligne, colCourante];
                        grille[ligne, colCourante] = 0;
                        colCourante--;
                        deplace = true;
                    }
                }
            }

            return deplace;
        }

        // Méthode de déplacement d'une ligne vers la droite
        static bool DeplacerLigneDroite(int ligne)
        {
            bool deplace = false;

            for (int col = 2; col >= 0; col--)
            {
                if (grille[ligne, col] != 0)
                {
                    int colCourante = col;
                    while (colCourante < 3 && grille[ligne, colCourante + 1] == 0)
                    {
                        grille[ligne, colCourante + 1] = grille[ligne, colCourante];
                        grille[ligne, colCourante] = 0;
                        colCourante++;
                        deplace = true;
                    }
                }
            }

            return deplace;
        }

        // Génération d'une nouvelle tuile aléatoire
        static void GenererTuileAleatoire()
        {
            int cellulesVides = CompterCellulesVides();

            if (cellulesVides == 0)
                return;

            int indiceAleatoire = random.Next(cellulesVides);
            int compteur = 0;

            for (int ligne = 0; ligne < 4; ligne++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (grille[ligne, col] == 0)
                    {
                        if (compteur == indiceAleatoire)
                        {
                            // Assigner une valeur de 2 ou 4 à la nouvelle tuile
                            grille[ligne, col] = (random.Next(1, 11) == 1) ? 4 : 2;
                            return;
                        }
                        compteur++;
                    }
                }
            }
        }

        // Compter le nombre de cellules vides dans la grille
        static int CompterCellulesVides()
        {
            int compteur = 0;

            for (int ligne = 0; ligne < 4; ligne++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (grille[ligne, col] == 0)
                    {
                        compteur++;
                    }
                }
            }

            return compteur;
        }

        // Enumération des directions de déplacement
        enum Direction
        {
            Haut,
            Bas,
            Gauche,
            Droite
        }
    }
}
