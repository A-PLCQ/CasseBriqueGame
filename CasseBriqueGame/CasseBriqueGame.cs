using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Media;
using System.Windows.Forms;

namespace CasseBriqueGame
{
    public partial class CasseBriqueGame : Form
    {
        public static int MARGE = 60;
        public static int HAUTEUR = 400;
        public static int LARGEUR = 300;
        public static int ORDONNEE_PLATEAU = 420;
        public static int vitesse;        

        #region Déclaration variables

        private int absPlateau;     // abscisse du plateau
        private Point tmp;          // point temporaire
        private int nbParties;      // nombre de parties qu'il reste pour le joueur
        private int level;          // level
        private Bonus bonus;        // variable pour les bonus
        private int ordBonus;       // ordonnée du bonus
        private int absBonus;       // abscisse du bonus
        private bool descBonus;     // savoir s'il y a un bonus en train de descendre
        private bool accrocheBonus; // savoir si le bonus accroche boule est activé
        private int ordBoule;       // ordonnée de la boule
        private int absBoule;       // abscisse de la boule
        public static int score;          // score du joeur
        private bool debut;         // début de partie : true
        private bool gauche;        // deplacement de la boule gauche_droite
        private bool haut;          // deplacement de la boule haut_bas
        private bool gameOver;      // quand la partie est finie

        private Plateau plateau;
        private BlocBrique bloc;
        private Boule boule;

        #endregion

        /// <summary>
        /// constructeur de la classe  CasseBriqueGame, permet d'initialiser l' CasseBriqueGame
        /// </summary>
        public CasseBriqueGame()
        {
            InitializeComponent();
            vitesse = 5;
            grpPerdu.Visible = false;

            if (PLUMECOCQ_Augustin_WFA.Properties.Settings.Default.high_score != 0)
                labelMeilleurScore.Text = "Meilleur score : " + PLUMECOCQ_Augustin_WFA.Properties.Settings.Default.high_score;
            else
                labelMeilleurScore.Text = "Aucun meilleur score.";

            tmp = new Point();

            // au départ le score est de 0
            score = 0;
            labelScore.Text = "Votre score est : " + score;

            // au départ aucun bonus
            bonus = new Bonus(new Point(), 0);
            descBonus = false;
            accrocheBonus = false;

            // on débute la partie avec deux parties (+ celle en cours)
            nbParties = 2;
            labelNbParties.Text = "Il vous reste " + nbParties + " parties.";

            // on comence la partie en partant a droite et en haut
            gauche = false;
            haut = true;

            // on commence la partie au level one
            level = 1;
            labelLevel.Text = "Level " + level;

            debut = true;
            gameOver = false;
            timer.Enabled = false;

            // on initialise le plateau et la boule au milieu du rectangle
            absPlateau = MARGE + LARGEUR / 2;
            plateau = new Plateau(new Point(absPlateau, ORDONNEE_PLATEAU));
            boule = new Boule(new Point(MARGE + LARGEUR / 2, ORDONNEE_PLATEAU - Boule.DIAMETRE / 2 - Plateau.H_PLATEAU / 2));
            bloc = new BlocBrique(level);
        }

        /// <summary>
        /// méthode OnPaint permet de dessiner le formulaire et les objets plateau, bonus, boule, et bloc
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.bloc.Dessiner(e.Graphics);
            this.plateau.Dessiner(e.Graphics);
            this.bonus.Dessiner(e.Graphics);
            this.boule.Dessiner(e.Graphics);
        }

        /// <summary>
        /// mouseMove qui permet de déplacer le plateau
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BougerPlateau(object sender, MouseEventArgs e)
        {
            // quand on est sur le rectangle de jeu on change de curseur
            if (e.Y > MARGE && e.Y < MARGE + HAUTEUR && e.X > MARGE && e.X < MARGE + LARGEUR)
            {
                Cursor.Current = null;
            }

            if (!gameOver && debut)
                boule.DeplacementSurPlateau(e.X, e.Y);

            if (!gameOver)
                plateau.DeplacementPlateau(e.X, e.Y);

            if (debut)
                Refresh();
        }

        /// <summary>
        /// mouseClick, permettant de lancer la boule quand elle est sur le plateau
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DebutPartie(object sender, MouseEventArgs e)
        {
            if (!gameOver && debut)
            {
                timer.Enabled = true;
                debut = false;
                absBoule = boule.Centre.X;
                ordBoule = boule.Centre.Y;
            }
        }

        /// <summary>
        /// mise à jour du label affichant le nombre de parties restantes
        /// </summary>
        private void MAJLabelNbParties()
        {
            // si nbParties est égal à -1 cela signifie que le joueur
            // à utiliser toutes ses parties
            if (nbParties == -1)
            {
               
                grpPerdu.Visible = true;
                label8.Visible = false;
                pictureBox1.Visible = false;
                gameOver = true;
            }
            // actualisation du label strNbParties
            else
            {
                if (nbParties == 0 || nbParties == 1)
                    labelNbParties.Text = "Il vous reste " + nbParties + " partie.";
                else
                    labelNbParties.Text = "Il vous reste " + nbParties + " parties.";
            }
        }

        /// <summary>
        /// evenement survenant à chaque periode du timer, permet le déplacement de la boule
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerTick(object sender, EventArgs e)
        {
            boule.DeplacementBoule(ref gauche, ref haut, plateau.Centre.X, vitesse);

            // si la boule touche le bas du rectangle on arrête le timer
            // on se repositionne à l'état début
            if (boule.Centre.Y > MARGE + HAUTEUR - Boule.DIAMETRE / 2)
            {
                debut = true;
                timer.Enabled = false;
                gauche = false;
                haut = true;
                // bonus accroche boule désactivé
                accrocheBonus = false;

                // on annule les bonus qui changent la taille du plateau
                Plateau.L_PLATEAU = 40;

                vitesse = 5;

                // on replace la boule sur le plateau
                boule.Centre = new Point(plateau.Centre.X, ORDONNEE_PLATEAU - Boule.DIAMETRE / 2 - Plateau.H_PLATEAU / 2);

                // on perd une partie
                --nbParties;
                MAJLabelNbParties();
            }

            bool incassable = false;
            // on regarde si la boule touche une brique
            // si oui et suivant son niveau de fragilité on la supprime
            if (bloc.ToucherBrique(boule.Centre, ref tmp, ref incassable))
            {
                if (boule.Centre.Y > tmp.Y && boule.Centre.Y < tmp.Y + Bonus.H_BONUS && tmp.X + Bonus.L_BONUS / 2 > boule.Centre.X)
                    gauche = true;
                if (boule.Centre.Y > tmp.Y && boule.Centre.Y < tmp.Y + Bonus.H_BONUS && tmp.X + Bonus.L_BONUS / 2 < boule.Centre.X)
                    gauche = false;
                if (boule.Centre.X > tmp.X && boule.Centre.X < tmp.X + Bonus.L_BONUS && tmp.Y + Bonus.H_BONUS / 2 < boule.Centre.Y)
                    haut = false; 
                if (boule.Centre.X > tmp.X && boule.Centre.X < tmp.X + Bonus.L_BONUS && tmp.Y + Bonus.H_BONUS / 2 > boule.Centre.Y)
                    haut = true;

                // si la brique touchée n'est pas incassable
                if (!incassable)
                {
                    score += 5;
                    labelScore.Text = "Votre score est : " + score;

                    if (PLUMECOCQ_Augustin_WFA.Properties.Settings.Default.high_score < score)
                        PLUMECOCQ_Augustin_WFA.Properties.Settings.Default.high_score = score;
                    PLUMECOCQ_Augustin_WFA.Properties.Settings.Default.Save();

                    // si un bonus n'est pas déjà entrain de descendre
                    if (!descBonus)
                    {
                        Random rdm = new Random();
                        int aleatoire = rdm.Next(1, 10);

                        if (aleatoire == 4)
                        {
                            ordBonus = tmp.Y;
                            absBonus = tmp.X;      
                            bonus = new Bonus(new Point(absBonus, ordBonus), rdm.Next(1,7));
                            Refresh();

                            timerBonus.Enabled = true;
                            descBonus = true;
                        }
                    }
                }
            }

            // bonus : boule s'accroche au plateau
            if (accrocheBonus)
            {
                // si la boule touche le plateau alors elle reste accrochée
                if (boule.Centre.Y + Boule.DIAMETRE / 2 < ORDONNEE_PLATEAU + Plateau.H_PLATEAU / 2 && boule.Centre.Y + Boule.DIAMETRE / 2 > ORDONNEE_PLATEAU - Plateau.H_PLATEAU / 2 && boule.Centre.X + Boule.DIAMETRE / 2 > plateau.Centre.X - Plateau.L_PLATEAU / 2 && boule.Centre.X - Boule.DIAMETRE / 2 < plateau.Centre.X + Plateau.L_PLATEAU / 2)
                {
                    debut = true;
                    timer.Enabled = false;
                    // on replace la boule sur le plateau
                    boule.Centre = new Point(plateau.Centre.X, ORDONNEE_PLATEAU - Boule.DIAMETRE / 2 - Plateau.H_PLATEAU / 2);
                }
            }

            // s'il ne reste aucune brique
            if (bloc.Gagne())
            {
                // arret du bonus
                accrocheBonus = false;
                // arret du timer
                timer.Enabled = false;
                // on commence une nouvelle partie
                debut = true;
                // on change de niveau
                ++level;
                // on affiche le niveau courant
                labelLevel.Text = "Level " + level;
                // on charge les nouvelles briques
                bloc = new BlocBrique(level);
                // on redéssine la boule sur le plateau
                boule = new Boule(new Point(plateau.Centre.X, plateau.Centre.Y - Plateau.H_PLATEAU / 2 - Boule.DIAMETRE / 2));
                // on annule les bonus qui changent la taille du plateau
                Plateau.L_PLATEAU = 40;
             
                vitesse = 5;
            }

            // on raffraichit le formulaire
            Refresh();
        }

        /// <summary>
        /// bouton "Pause" ou "Reprendre" du formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PauseClick(object sender, EventArgs e)
        {
            // si le joueur n'a pas perdu
            if (!gameOver)
            {
                if (boutonPause.Text == "Pause")
                {
                    timer.Enabled = false;
                    boutonPause.Text = "Reprendre";
                }
                else
                {
                    timer.Enabled = true;
                    boutonPause.Text = "Pause";
                }
            }
        }

        /// <summary>
        /// bouton "Rejouer" du formulaire, réinitialise la partie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RejouerClick(object sender, EventArgs e)
        {
            grpPerdu.Visible = false;
            label8.Visible = true;
            pictureBox1.Visible = true;
            if (PLUMECOCQ_Augustin_WFA.Properties.Settings.Default.high_score != 0)
                labelMeilleurScore.Text = "Meilleur score : " + PLUMECOCQ_Augustin_WFA.Properties.Settings.Default.high_score;
            else
                labelMeilleurScore.Text = "Aucun meilleur score.";

            // au départ le score est de 0
            score = 0;
            labelScore.Text = "Votre score est : " + score;

            // au départ aucun bonus
            bonus = new Bonus(new Point(), 0);
            descBonus = false;
            accrocheBonus = false;

            // nombre de parties à 2
            nbParties = 2;
            labelNbParties.Text = "Il vous reste " + nbParties + " parties.";

            // on comence la partie en partant a droite et en haut
            gauche = false;
            haut = true;

            // on recomence au premier niveau
            level = 1;
            labelLevel.Text = "Level " + level;

            debut = true;
            gameOver = false;
            timer.Enabled = false;

            // on initialise le plateau au milieu du rectangle
            absPlateau = MARGE + LARGEUR / 2;
            plateau = new Plateau(new Point(absPlateau, ORDONNEE_PLATEAU));
            boule = new Boule(new Point(MARGE + LARGEUR / 2, ORDONNEE_PLATEAU - Boule.DIAMETRE / 2 - Plateau.H_PLATEAU / 2));
            bloc = new BlocBrique(level);
            Refresh();
        }

        /// <summary>
        /// evenement survenant à chaque periode du timerBonus, permet le déplacement des bonus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerBonusTick(object sender, EventArgs e)
        {
            bonus.DeplacementBonus();

            // s'il depasse le plateau il est effacé
            if (bonus.Centre.Y - Bonus.H_BONUS / 2 > ORDONNEE_PLATEAU + Plateau.H_PLATEAU / 2 || debut)
            {
                bonus = new Bonus(new Point(), 0);
                timerBonus.Enabled = false;
                descBonus = false;
            }
            else
            {
                // s'il touche le plateau
                if (bonus.Centre.Y + Bonus.H_BONUS / 2 > ORDONNEE_PLATEAU - Plateau.H_PLATEAU / 2 && bonus.Centre.X + Bonus.L_BONUS / 2 > plateau.Centre.X - Plateau.L_PLATEAU / 2 && bonus.Centre.X - Bonus.L_BONUS / 2 < plateau.Centre.X + Plateau.L_PLATEAU / 2)
                {
                    bonus.AvoirBonus(ref nbParties, ref accrocheBonus);
                    labelScore.Text = "Votre score est : " + score;
                    labelNbParties.Text = "Il vous reste " + nbParties + " parties.";
                    descBonus = false;
                }
            }
            Refresh();
        }

        private void CasseBriqueGame_Load(object sender, EventArgs e)
        {

        }
    }
}