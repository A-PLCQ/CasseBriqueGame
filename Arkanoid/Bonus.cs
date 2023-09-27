using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CasseBriqueGame
{
    class Bonus
    {
        public static int H_BONUS = 10;
        public static int L_BONUS = 30;

        private Point centre;
        private int num;

        /// <summary>
        /// constructeur de la classe bonus
        /// </summary>
        /// <param name="nvCentre">coordonnées du bonus</param>
        /// <param name="nvNum">numéro du bonus</param>
        public Bonus(Point nvCentre, int nvNum)
        {
            centre = nvCentre;
            num = nvNum;
        }

        /// <summary>
        /// permet de dessiner un bonus
        /// </summary>
        /// <param name="g">objet graphics</param>
        public void Dessiner(Graphics g)
        {
            if (num == 1)
                g.FillRectangle(new SolidBrush(Color.Yellow), centre.X, centre.Y, L_BONUS, H_BONUS);
            if (num == 2)
                g.FillRectangle(new SolidBrush(Color.Orange), centre.X, centre.Y, L_BONUS, H_BONUS);
            if (num == 3)
                g.FillRectangle(new SolidBrush(Color.Violet), centre.X, centre.Y, L_BONUS, H_BONUS);
            if (num == 4)
                g.FillRectangle(new SolidBrush(Color.Pink), centre.X, centre.Y, L_BONUS, H_BONUS);
            if (num == 5)
                g.FillRectangle(new SolidBrush(Color.Maroon), centre.X, centre.Y, L_BONUS, H_BONUS);
            if (num == 6)
                g.FillRectangle(new SolidBrush(Color.Aqua), centre.X, centre.Y, L_BONUS, H_BONUS);
            if (num != 0)
                g.DrawRectangle(new Pen(Color.Black, 1), centre.X, centre.Y, L_BONUS - 1, H_BONUS - 1);
        }

        /// <summary>
        /// deplacement du bonus
        /// </summary>
        public void DeplacementBonus()
        {
            centre.Y += 10;
        }

        /// <summary>
        /// permet d'obtenir les bonus une fois qu'ils sont récupérés
        /// </summary>
        /// <param name="nbParties">nombre de parties restantes</param>
        /// <param name="accrocheBonus">détermine si bonus accroche est activé</param>
        public void AvoirBonus(ref int nbParties, ref bool accrocheBonus)
        {
            //2015-12-16 Tous les bonus peuvent maintenant s'additionner

            // bonus : augmentation taille plateau
            if (num == 1)
            {

                //2015/12/16 Vérifie que le plateau est plus petit que 100 avant de l'agrandir
                if (Plateau.L_PLATEAU < 100)
                {
                    //augmente la largeur du plateau de 20 pixels
                    Plateau.L_PLATEAU += 20;
                    CasseBriqueGame.score += 10;
                }

            }

            // bonus : vie en plus
            if (num == 2)
            {
                ++nbParties;

                CasseBriqueGame.score += 10;
            }

            // bonus : réduction taille plateau
            if (num == 3)
            {
                //2015/12/16 Vérifie que le plateau est supérieur à 20 pixels pour ne pas le faire disparaître
                if (Plateau.L_PLATEAU > 20)
                {
                    Plateau.L_PLATEAU -= 20;
                    CasseBriqueGame.score += 10;
                }
            }

            // bonus : score + 30
            if (num == 4)
            {
                CasseBriqueGame.score += 30;
            }

            // on active le bonus accroche boule quand il le faut
            if (num == 5)
            {
                accrocheBonus = true;
                CasseBriqueGame.score += 10;
            }
            //2015-12-16 Ajout du bonus de vitesse de la boule
            if(num == 6)
            {
                CasseBriqueGame.vitesse += 5;
            }

            if (PLUMECOCQ_Augustin_WFA.Properties.Settings.Default.high_score < CasseBriqueGame.score)
                PLUMECOCQ_Augustin_WFA.Properties.Settings.Default.high_score = CasseBriqueGame.score;
            PLUMECOCQ_Augustin_WFA.Properties.Settings.Default.Save();

            // on reinitialise le bonus
            // quand num égal 0 on le dessine pas
            num = 0;
        }

        /// <summary>
        /// accesseur retournant les coordonées du bonus
        /// </summary>
        public Point Centre
        {
            get { return centre; }
        }

        /// <summary>
        /// accesseur retournant le numéro du bonus
        /// </summary>
        public int Num
        {
            get { return num; }
        }
    }
}
