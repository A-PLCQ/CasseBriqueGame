using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CasseBriqueGame
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //2015-12-15 Ajout de la page d'acceuil
            CasseBriqueGame leJeu = new CasseBriqueGame();
            leJeu.Show();
            this.Close();
        }

        private void Index_Load(object sender, EventArgs e)
        {

        }
    }
}
