using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CasseBriqueGame
{
    class Brique
    {
        public static int H_BRIQUE = 10;
        public static int L_BRIQUE = 30;

        private int fragilite;
        private Point centre;

        /// <summary>
        /// constructeur de la classe brique
        /// </summary>
        /// <param name="nvCentre">coordonnées de la brique</param>
        /// <param name="nvFragilite">détermine le niveau de fragilité de la brique</param>
        public Brique(Point nvCentre, int nvFragilite)
        {
            centre = nvCentre;
            fragilite = nvFragilite;
        }

        /// <summary>
        /// permet de déssiner une brique
        /// </summary>
        /// <param name="g">objects graphics</param>
        public void Dessiner(Graphics g)
        {
            if (fragilite == 1)
                g.FillRectangle(new SolidBrush(Color.Red), centre.X, centre.Y, L_BRIQUE, H_BRIQUE);
            if (fragilite == 2)
                g.FillRectangle(new SolidBrush(Color.Green), centre.X, centre.Y, L_BRIQUE, H_BRIQUE);
            if (fragilite == 3)
                //g.FillRectangle(new SolidBrush(Color.Gray), centre.X, centre.Y, L_BRIQUE, H_BRIQUE);
            g.DrawImage(PLUMECOCQ_Augustin_WFA.Properties.Resources.brique, centre.X, centre.Y, L_BRIQUE, H_BRIQUE);
            g.DrawRectangle(new Pen(Color.Black, 1), centre.X, centre.Y, L_BRIQUE - 1, H_BRIQUE - 1);
        }

        /// <summary>
        /// accesseur retournant les coordonnées de la brique
        /// </summary>
        public Point Centre
        {
            get { return centre; }
        }

        /// <summary>
        /// accesseur du niveau de fragilité
        /// </summary>
        public int Fragilite
        {
            get { return fragilite; }
            set { fragilite = value; }
        }
    }
}
