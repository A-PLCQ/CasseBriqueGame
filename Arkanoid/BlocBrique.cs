using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Media;

namespace CasseBriqueGame
{
    class BlocBrique
    {
        private int level = 0;
        public Brique[][] bloc;
        private int NB_COL = 10;
        private int NB_LIGN = 4;

        /// <summary>
        /// constructeur de la classe BlocBrique
        /// </summary>
        /// <param name="level">détermine le niveau a créer</param>
        public BlocBrique(int level)
        {
            this.level = level;
            CreerNiveau();
        }

        //2015-12-14 Méthode qui crée les niveaux pour enlever le code du constructeur
        public void CreerNiveau ()
        {
            int i, j, colonne;

            bloc = new Brique[NB_LIGN][];
            for (i = 0; i < bloc.Length; ++i)
                bloc[i] = new Brique[NB_COL];

            //////////////////////////////////////////////
            /////            NIVEAU 1                 ////
            //////////////////////////////////////////////
            if (level == 1)
            {
                bloc[0][0] = new Brique(new Point(CasseBriqueGame.MARGE + 120, CasseBriqueGame.MARGE + 10), 3);
                bloc[0][1] = new Brique(new Point(CasseBriqueGame.MARGE + 150, CasseBriqueGame.MARGE + 10), 3);
                bloc[0][2] = new Brique(new Point(CasseBriqueGame.MARGE, CasseBriqueGame.MARGE + 30), 2);
                bloc[0][3] = new Brique(new Point(CasseBriqueGame.MARGE + 90, CasseBriqueGame.MARGE + 30), 1);
                bloc[0][4] = new Brique(new Point(CasseBriqueGame.MARGE + 180, CasseBriqueGame.MARGE + 30), 1);
                bloc[0][5] = new Brique(new Point(CasseBriqueGame.MARGE + 270, CasseBriqueGame.MARGE + 30), 2);
                bloc[0][6] = new Brique(new Point(CasseBriqueGame.MARGE + 30, CasseBriqueGame.MARGE + 50), 1);
                bloc[0][7] = new Brique(new Point(CasseBriqueGame.MARGE + 120, CasseBriqueGame.MARGE + 50), 3);
                bloc[0][8] = new Brique(new Point(CasseBriqueGame.MARGE + 150, CasseBriqueGame.MARGE + 50), 3);
                bloc[0][9] = new Brique(new Point(CasseBriqueGame.MARGE + 240, CasseBriqueGame.MARGE + 50), 1);
                bloc[1][0] = new Brique(new Point(CasseBriqueGame.MARGE + 60, CasseBriqueGame.MARGE + 70), 2);
                bloc[1][1] = new Brique(new Point(CasseBriqueGame.MARGE + 210, CasseBriqueGame.MARGE + 70), 2);
                bloc[1][2] = new Brique(new Point(CasseBriqueGame.MARGE + 30, CasseBriqueGame.MARGE + 90), 1);
                bloc[1][3] = new Brique(new Point(CasseBriqueGame.MARGE + 90, CasseBriqueGame.MARGE + 90), 1);
                bloc[1][4] = new Brique(new Point(CasseBriqueGame.MARGE + 180, CasseBriqueGame.MARGE + 90), 1);
                bloc[1][5] = new Brique(new Point(CasseBriqueGame.MARGE + 240, CasseBriqueGame.MARGE + 90), 1);
                bloc[1][6] = new Brique(new Point(CasseBriqueGame.MARGE + 120, CasseBriqueGame.MARGE + 140), 2);
                bloc[1][7] = new Brique(new Point(CasseBriqueGame.MARGE + 150, CasseBriqueGame.MARGE + 140), 2);
                bloc[1][8] = new Brique(new Point(CasseBriqueGame.MARGE + 30, CasseBriqueGame.MARGE + 140), 3);
                bloc[1][9] = new Brique(new Point(CasseBriqueGame.MARGE + 60, CasseBriqueGame.MARGE + 140), 2);
                bloc[2][0] = new Brique(new Point(CasseBriqueGame.MARGE + 90, CasseBriqueGame.MARGE + 140), 2);
                bloc[2][1] = new Brique(new Point(CasseBriqueGame.MARGE + 120, CasseBriqueGame.MARGE + 140), 2);
                bloc[2][2] = new Brique(new Point(CasseBriqueGame.MARGE + 150, CasseBriqueGame.MARGE + 140), 2);
                bloc[2][3] = new Brique(new Point(CasseBriqueGame.MARGE + 180, CasseBriqueGame.MARGE + 140), 2);
                bloc[2][4] = new Brique(new Point(CasseBriqueGame.MARGE + 210, CasseBriqueGame.MARGE + 140), 2);
                bloc[2][5] = new Brique(new Point(CasseBriqueGame.MARGE + 240, CasseBriqueGame.MARGE + 140), 3);
                bloc[2][6] = new Brique(new Point(CasseBriqueGame.MARGE + 90, CasseBriqueGame.MARGE + 190), 2);
                bloc[2][7] = new Brique(new Point(CasseBriqueGame.MARGE + 120, CasseBriqueGame.MARGE + 190), 1);
                bloc[2][8] = new Brique(new Point(CasseBriqueGame.MARGE + 150, CasseBriqueGame.MARGE + 190), 1);
                bloc[2][9] = new Brique(new Point(CasseBriqueGame.MARGE + 180, CasseBriqueGame.MARGE + 190), 2);
            }
            //////////////////////////////////////////////
            /////            NIVEAU 2                 ////
            //////////////////////////////////////////////
            if (level == 2)
            {
                colonne = CasseBriqueGame.MARGE;
                for (j = 0; j < NB_COL; ++j)
                {
                    bloc[0][j] = new Brique(new Point(colonne, CasseBriqueGame.MARGE + Brique.H_BRIQUE * 2), 1);
                    colonne += Brique.L_BRIQUE;
                }
                // les sourcils
                bloc[1][0] = new Brique(new Point(CasseBriqueGame.MARGE + 60, CasseBriqueGame.MARGE + 60), 1);
                bloc[1][1] = new Brique(new Point(CasseBriqueGame.MARGE + 90, CasseBriqueGame.MARGE + 60), 1);
                bloc[1][2] = new Brique(new Point(CasseBriqueGame.MARGE + 180, CasseBriqueGame.MARGE + 60), 1);
                bloc[1][3] = new Brique(new Point(CasseBriqueGame.MARGE + 210, CasseBriqueGame.MARGE + 60), 1);
                bloc[1][4] = new Brique(new Point(CasseBriqueGame.MARGE + 30, CasseBriqueGame.MARGE + 70), 1);
                bloc[1][5] = new Brique(new Point(CasseBriqueGame.MARGE + 240, CasseBriqueGame.MARGE + 70), 1);
                bloc[1][6] = new Brique(new Point(CasseBriqueGame.MARGE, CasseBriqueGame.MARGE + 80), 1);
                bloc[1][7] = new Brique(new Point(CasseBriqueGame.MARGE, CasseBriqueGame.MARGE + 90), 1);
                bloc[1][8] = new Brique(new Point(CasseBriqueGame.MARGE + 270, CasseBriqueGame.MARGE + 80), 1);
                bloc[1][9] = new Brique(new Point(CasseBriqueGame.MARGE + 270, CasseBriqueGame.MARGE + 90), 1);
                // les yeux
                bloc[2][0] = new Brique(new Point(CasseBriqueGame.MARGE + 60, CasseBriqueGame.MARGE + 110), 3);
                bloc[2][1] = new Brique(new Point(CasseBriqueGame.MARGE + 90, CasseBriqueGame.MARGE + 110), 3);
                bloc[2][2] = new Brique(new Point(CasseBriqueGame.MARGE + 180, CasseBriqueGame.MARGE + 110), 3);
                bloc[2][3] = new Brique(new Point(CasseBriqueGame.MARGE + 210, CasseBriqueGame.MARGE + 110), 3);
                bloc[2][4] = new Brique(new Point(CasseBriqueGame.MARGE + 60, CasseBriqueGame.MARGE + 120), 3);
                bloc[2][5] = new Brique(new Point(CasseBriqueGame.MARGE + 90, CasseBriqueGame.MARGE + 120), 3);
                bloc[2][6] = new Brique(new Point(CasseBriqueGame.MARGE + 180, CasseBriqueGame.MARGE + 120), 3);
                bloc[2][7] = new Brique(new Point(CasseBriqueGame.MARGE + 210, CasseBriqueGame.MARGE + 120), 3);
                // le nez
                bloc[2][8] = new Brique(new Point(CasseBriqueGame.MARGE + 120, CasseBriqueGame.MARGE + 150), 1);
                bloc[2][9] = new Brique(new Point(CasseBriqueGame.MARGE + 110, CasseBriqueGame.MARGE + 160), 1);
                bloc[3][0] = new Brique(new Point(CasseBriqueGame.MARGE + 110, CasseBriqueGame.MARGE + 170), 1);
                // la bouche
                bloc[3][1] = new Brique(new Point(CasseBriqueGame.MARGE + 30, CasseBriqueGame.MARGE + 190), 2);
                bloc[3][2] = new Brique(new Point(CasseBriqueGame.MARGE + 60, CasseBriqueGame.MARGE + 200), 2);
                bloc[3][3] = new Brique(new Point(CasseBriqueGame.MARGE + 90, CasseBriqueGame.MARGE + 210), 2);
                bloc[3][4] = new Brique(new Point(CasseBriqueGame.MARGE + 120, CasseBriqueGame.MARGE + 220), 2);
                bloc[3][5] = new Brique(new Point(CasseBriqueGame.MARGE + 150, CasseBriqueGame.MARGE + 220), 2);
                bloc[3][6] = new Brique(new Point(CasseBriqueGame.MARGE + 180, CasseBriqueGame.MARGE + 210), 2);
                bloc[3][7] = new Brique(new Point(CasseBriqueGame.MARGE + 210, CasseBriqueGame.MARGE + 200), 2);
                bloc[3][8] = new Brique(new Point(CasseBriqueGame.MARGE + 240, CasseBriqueGame.MARGE + 190), 2);
            }
            //////////////////////////////////////////////
            /////            NIVEAU 3                 ////
            //////////////////////////////////////////////
            if (level == 3)
            {
                bloc[0][0] = new Brique(new Point(CasseBriqueGame.MARGE + 30, CasseBriqueGame.MARGE + 60), 1);
                bloc[0][1] = new Brique(new Point(CasseBriqueGame.MARGE + 60, CasseBriqueGame.MARGE + 60), 2);
                bloc[0][2] = new Brique(new Point(CasseBriqueGame.MARGE + 90, CasseBriqueGame.MARGE + 60), 1);
                bloc[0][3] = new Brique(new Point(CasseBriqueGame.MARGE + 120, CasseBriqueGame.MARGE + 60), 2);
                bloc[0][4] = new Brique(new Point(CasseBriqueGame.MARGE + 150, CasseBriqueGame.MARGE + 60), 1);
                bloc[0][5] = new Brique(new Point(CasseBriqueGame.MARGE + 180, CasseBriqueGame.MARGE + 60), 2);
                bloc[0][6] = new Brique(new Point(CasseBriqueGame.MARGE + 210, CasseBriqueGame.MARGE + 60), 1);
                bloc[0][7] = new Brique(new Point(CasseBriqueGame.MARGE + 240, CasseBriqueGame.MARGE + 60), 3);
                bloc[3][5] = new Brique(new Point(CasseBriqueGame.MARGE + 240, CasseBriqueGame.MARGE + 70), 1);
                bloc[0][8] = new Brique(new Point(CasseBriqueGame.MARGE + 240, CasseBriqueGame.MARGE + 80), 3);
                bloc[0][9] = new Brique(new Point(CasseBriqueGame.MARGE + 240, CasseBriqueGame.MARGE + 90), 1);
                bloc[3][6] = new Brique(new Point(CasseBriqueGame.MARGE + 240, CasseBriqueGame.MARGE + 100), 3);
                bloc[1][0] = new Brique(new Point(CasseBriqueGame.MARGE + 240, CasseBriqueGame.MARGE + 110), 1);
                bloc[1][1] = new Brique(new Point(CasseBriqueGame.MARGE + 240, CasseBriqueGame.MARGE + 120), 3);
                bloc[3][4] = new Brique(new Point(CasseBriqueGame.MARGE + 240, CasseBriqueGame.MARGE + 130), 1);
                bloc[1][2] = new Brique(new Point(CasseBriqueGame.MARGE + 240, CasseBriqueGame.MARGE + 140), 3);
                bloc[1][3] = new Brique(new Point(CasseBriqueGame.MARGE + 240, CasseBriqueGame.MARGE + 150), 1);
                bloc[1][4] = new Brique(new Point(CasseBriqueGame.MARGE + 210, CasseBriqueGame.MARGE + 150), 2);
                bloc[1][5] = new Brique(new Point(CasseBriqueGame.MARGE + 180, CasseBriqueGame.MARGE + 150), 1);
                bloc[1][6] = new Brique(new Point(CasseBriqueGame.MARGE + 150, CasseBriqueGame.MARGE + 150), 2);
                bloc[1][7] = new Brique(new Point(CasseBriqueGame.MARGE + 120, CasseBriqueGame.MARGE + 150), 1);
                bloc[1][8] = new Brique(new Point(CasseBriqueGame.MARGE + 90, CasseBriqueGame.MARGE + 150), 2);
                bloc[1][9] = new Brique(new Point(CasseBriqueGame.MARGE + 60, CasseBriqueGame.MARGE + 150), 1);
                bloc[2][0] = new Brique(new Point(CasseBriqueGame.MARGE + 30, CasseBriqueGame.MARGE + 150), 3);
                bloc[2][1] = new Brique(new Point(CasseBriqueGame.MARGE + 30, CasseBriqueGame.MARGE + 140), 1);
                bloc[3][9] = new Brique(new Point(CasseBriqueGame.MARGE + 30, CasseBriqueGame.MARGE + 130), 3);
                bloc[2][2] = new Brique(new Point(CasseBriqueGame.MARGE + 30, CasseBriqueGame.MARGE + 120), 1);
                bloc[2][3] = new Brique(new Point(CasseBriqueGame.MARGE + 30, CasseBriqueGame.MARGE + 110), 3);
                bloc[3][7] = new Brique(new Point(CasseBriqueGame.MARGE + 30, CasseBriqueGame.MARGE + 100), 1);
                bloc[2][4] = new Brique(new Point(CasseBriqueGame.MARGE + 30, CasseBriqueGame.MARGE + 90), 3);
                bloc[2][5] = new Brique(new Point(CasseBriqueGame.MARGE + 60, CasseBriqueGame.MARGE + 90), 1);
                bloc[2][6] = new Brique(new Point(CasseBriqueGame.MARGE + 90, CasseBriqueGame.MARGE + 90), 2);
                bloc[2][7] = new Brique(new Point(CasseBriqueGame.MARGE + 120, CasseBriqueGame.MARGE + 90), 1);
                bloc[2][8] = new Brique(new Point(CasseBriqueGame.MARGE + 150, CasseBriqueGame.MARGE + 90), 2);
                bloc[2][9] = new Brique(new Point(CasseBriqueGame.MARGE + 180, CasseBriqueGame.MARGE + 90), 1);
                bloc[3][8] = new Brique(new Point(CasseBriqueGame.MARGE + 180, CasseBriqueGame.MARGE + 100), 2);
                bloc[3][0] = new Brique(new Point(CasseBriqueGame.MARGE + 180, CasseBriqueGame.MARGE + 110), 1);
                bloc[3][1] = new Brique(new Point(CasseBriqueGame.MARGE + 180, CasseBriqueGame.MARGE + 120), 2);
                bloc[3][2] = new Brique(new Point(CasseBriqueGame.MARGE + 150, CasseBriqueGame.MARGE + 120), 1);
                bloc[3][3] = new Brique(new Point(CasseBriqueGame.MARGE + 120, CasseBriqueGame.MARGE + 120), 2);
            }
        }

        /// <summary>
        /// permet de dessiner toutes les briques
        /// </summary>
        /// <param name="g">objects graphics</param>
        public void Dessiner(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.DarkBlue, 3), CasseBriqueGame.MARGE - 1, CasseBriqueGame.MARGE - 1, CasseBriqueGame.LARGEUR + 2, CasseBriqueGame.HAUTEUR + 2);

            for (int i = 0; i < NB_LIGN; ++i)
                for (int j = 0; j < NB_COL; ++j)
                    if (bloc[i][j] != null)
                        bloc[i][j].Dessiner(g);
        }

        /// <summary>
        /// permet de savoir si la boule a touché une brique
        /// </summary>
        /// <param name="point">coordonnées de la boule</param>
        /// <param name="briqueTouchee">coordonnées de la brique touchée</param>
        /// <param name="incassable">détermine si la brique touchée est incassable ou non</param>
        /// <returns>retourne true si la boule a touché une brique sinon retourne false</returns>
        public bool ToucherBrique(Point point, ref Point briqueTouchee, ref bool incassable)
        {
            bool modif = false;

            for (int i = 0; i < NB_LIGN; ++i)
                for (int j = 0; j < NB_COL; ++j)
                {
                    if (bloc[i][j] != null)
                    {
                        Rectangle rect = new Rectangle(bloc[i][j].Centre, new Size(Brique.L_BRIQUE, Brique.H_BRIQUE));
                        if (rect.Contains(point) || rect.Contains(new Point(point.X-Boule.DIAMETRE/2,point.Y))
                            || rect.Contains(new Point(point.X + Boule.DIAMETRE / 2, point.Y))
                            || rect.Contains(new Point(point.X, point.Y - Boule.DIAMETRE / 2))
                            || rect.Contains(new Point(point.X, point.Y + Boule.DIAMETRE / 2)))
                        {
                            briqueTouchee = bloc[i][j].Centre;

                            if (bloc[i][j].Fragilite == 3)
                            {
                                modif = true;
                                incassable = true;
                            }
                            if (bloc[i][j].Fragilite == 2)
                            {
                                --bloc[i][j].Fragilite;
                                modif = true;
                            }
                            else
                            {
                                if (bloc[i][j].Fragilite == 1)
                                {
                                    bloc[i][j] = null;
                                    modif = true;
                                    //2015-12-16 Ajout du bruit d'explosion lorsqu'un bloc est détruit
                                    SoundPlayer explosion = new SoundPlayer(@"..\..\Sons\explosion.wav");
                                    explosion.Play();
                                }
                            }
                        }
                    }
                }

            return modif;
        }

        /// <summary>
        /// permet de savoir s'il reste des briques dans le niveau
        /// </summary>
        /// <returns>retourne true s'il reste aucune brique sinon false</returns>
        public bool Gagne()
        {
            bool gagne = true;

            for (int i = 0; i < NB_LIGN; ++i)
                for (int j = 0; j < NB_COL; ++j)
                    if (bloc[i][j] != null && bloc[i][j].Fragilite != 3)
                        gagne = false;
            return gagne;
        }
    }
}
