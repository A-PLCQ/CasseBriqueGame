using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CasseBriqueGame
{
    class Plateau
    {
        public static int L_PLATEAU = 40;
        public static int H_PLATEAU = 10;
        private Point centre;

        /// <summary>
        /// constructeur de la classe plateau
        /// </summary>
        /// <param name="nvCentre">coordonées du plateau</param>
        public Plateau(Point nvCentre)
        {
            centre = nvCentre;
        }

        /// <summary>
        /// permet de dessiner le plateau
        /// </summary>
        /// <param name="g">objet grpahics</param>
        public void Dessiner(Graphics g)
        {
            //g.FillRectangle(new SolidBrush(Color.Salmon), centre.X - L_PLATEAU / 2, centre.Y - H_PLATEAU / 2, L_PLATEAU, H_PLATEAU);
            //g.DrawRectangle(new Pen(Color.Black, 1), centre.X - L_PLATEAU / 2, centre.Y - H_PLATEAU / 2, L_PLATEAU - 1, H_PLATEAU - 1);

            //2015-12-16 J'ai remplacer le rectangle saumon d'origine par un sprite
            g.DrawImage(PLUMECOCQ_Augustin_WFA.Properties.Resources.sprite, centre.X - L_PLATEAU / 2, centre.Y - H_PLATEAU / 2, L_PLATEAU - 1, H_PLATEAU - 1);
        }

        /// <summary>
        /// permet le déplacement du plateau par rapport au coordonées de la souris
        /// </summary>
        /// <param name="absSouris">abscisse du curseur de la souris</param>
        /// <param name="ordSouris">ordonnée du curseur de la souris</param>
        public void DeplacementPlateau(int absSouris, int ordSouris)
        {
            // quand on est sur le rectangle de jeu alors le plateau et la boule suivent le curseur de la souris
            if (CasseBriqueGame.MARGE + Plateau.L_PLATEAU / 2 < absSouris && absSouris < CasseBriqueGame.MARGE + CasseBriqueGame.LARGEUR - Plateau.L_PLATEAU / 2)
            {
                centre.X = absSouris;
                centre.Y = CasseBriqueGame.ORDONNEE_PLATEAU;
            }

            // si l'on va trop vite avec le pointeur de la souris sur la gauche
            // alors le plateau n'est pas collé au rectangle
            // cela permet de le faire
            if (absSouris < CasseBriqueGame.MARGE + Plateau.L_PLATEAU / 2)
            {
                centre.X = CasseBriqueGame.MARGE + Plateau.L_PLATEAU / 2;
                centre.Y = CasseBriqueGame.ORDONNEE_PLATEAU;
            }

            // si l'on va trop vite avec le pointeur de la souris sur la droite
            // alors le plateau n'est pas collé au rectangle
            // cela permet de le faire
            if (CasseBriqueGame.MARGE + CasseBriqueGame.LARGEUR - Plateau.L_PLATEAU / 2 < absSouris)
            {
                centre.X = CasseBriqueGame.MARGE + CasseBriqueGame.LARGEUR - Plateau.L_PLATEAU / 2;
                centre.Y = CasseBriqueGame.ORDONNEE_PLATEAU;
            }
        }

        /// <summary>
        /// accesseur retournant le centre du plateau
        /// </summary>
        public Point Centre
        {
            get { return centre; }
        }
    }
}
