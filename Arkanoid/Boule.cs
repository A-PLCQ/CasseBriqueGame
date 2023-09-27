using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CasseBriqueGame
{
    class Boule
    {
        public static int DIAMETRE = 12;
        private Point centre;

        /// <summary>
        /// constructeur de la classe Boule
        /// </summary>
        /// <param name="nvCentre">definit le centre de la boule</param>
        public Boule(Point nvCentre)
        {
            centre = nvCentre;
        }

        /// <summary>
        /// permet de dessiner la boule
        /// </summary>
        /// <param name="g">object graphics</param>
        public void Dessiner(Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; // anticrénelage
            //g.FillEllipse(new SolidBrush(Color.Blue), centre.X - DIAMETRE / 2, centre.Y - DIAMETRE / 2, DIAMETRE, DIAMETRE);
            g.DrawImage(PLUMECOCQ_Augustin_WFA.Properties.Resources.boule, centre.X - DIAMETRE / 2, centre.Y - DIAMETRE / 2, DIAMETRE, DIAMETRE);
        }

        /// <summary>
        /// permet le déplacement de la boule lorsqu'elle est sur le plateau
        /// </summary>
        /// <param name="absSouris">abscisse du curseur de la souris</param>
        /// <param name="ordSouris">ordonnée du curseur de la souris</param>
        public void DeplacementSurPlateau(int absSouris, int ordSouris)
        {
            if (CasseBriqueGame.MARGE + Plateau.L_PLATEAU / 2 < absSouris && absSouris < CasseBriqueGame.MARGE + CasseBriqueGame.LARGEUR - Plateau.L_PLATEAU / 2)
            {
                centre.X = absSouris;
                centre.Y = CasseBriqueGame.ORDONNEE_PLATEAU - DIAMETRE / 2 - Plateau.H_PLATEAU / 2;
            }

            if (absSouris < CasseBriqueGame.MARGE + Plateau.L_PLATEAU / 2)
            {
                centre.X = CasseBriqueGame.MARGE + Plateau.L_PLATEAU / 2;
                centre.Y = CasseBriqueGame.ORDONNEE_PLATEAU - DIAMETRE / 2 - Plateau.H_PLATEAU / 2;
            }

            if (CasseBriqueGame.MARGE + CasseBriqueGame.LARGEUR - Plateau.L_PLATEAU / 2 < absSouris)
            {
                centre.X = CasseBriqueGame.MARGE + CasseBriqueGame.LARGEUR - Plateau.L_PLATEAU / 2;
                centre.Y = CasseBriqueGame.ORDONNEE_PLATEAU - DIAMETRE / 2 - Plateau.H_PLATEAU / 2;
            }
        }

        /// <summary>
        /// permet le déplacement de la boule dans le jeu
        /// </summary>
        /// <param name="gauche">permet de savoir si la boule se déplace vers la gauche ou la droite</param>
        /// <param name="haut">permet de savoir si la boule se déplace vers le haut ou le bas</param>
        /// <param name="absPlateau">abscisse du plateau</param>
        public void DeplacementBoule(ref bool gauche, ref bool haut, int absPlateau, int vitesse)
        {
            if (gauche && haut)
            {
                centre.X -= vitesse;
                centre.Y -= vitesse;
            }
            if (gauche && !haut)
            {
                centre.X -= vitesse;
                centre.Y += vitesse;
            }
            if (!gauche && haut)
            {
                centre.X += vitesse;
                centre.Y -= vitesse;
            }
            if (!gauche && !haut)
            {
                centre.X += vitesse;
                centre.Y += vitesse;
            }

            // si l'on tape sur le mur de droite alors la boule rebondit vers la gauche
            if (centre.X > CasseBriqueGame.MARGE + CasseBriqueGame.LARGEUR - DIAMETRE / 2)
            {
                gauche = true;
            }

            // si l'on tape sur le mur de gauche alors la boule rebondit vers la droite
            if (centre.X < CasseBriqueGame.MARGE + DIAMETRE / 2)
            {
                gauche = false;
            }

            // si l'on tape sur le mur du haut alors la boule rebondit vers le bas
            if (centre.Y < CasseBriqueGame.MARGE + DIAMETRE / 2)
            {
                haut = false;
            }

            // si l'on tape sur le plateau la boule rebondit vers le haut
            if (centre.Y + DIAMETRE / 2 < CasseBriqueGame.ORDONNEE_PLATEAU + Plateau.H_PLATEAU / 2 && centre.Y + DIAMETRE / 2 > CasseBriqueGame.ORDONNEE_PLATEAU - Plateau.H_PLATEAU / 2 && centre.X + DIAMETRE / 2 > absPlateau - Plateau.L_PLATEAU / 2 && centre.X - DIAMETRE / 2 < absPlateau + Plateau.L_PLATEAU / 2)
            {
                haut = true;
            }
        }

        /// <summary>
        /// accesseur retournant le centre de la boule
        /// </summary>
        public Point Centre
        {
            get { return centre; }
            set { centre = value; }
        }
    }
}
