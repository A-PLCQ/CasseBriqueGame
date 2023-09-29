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
            CasseBriqueGame leJeu = new CasseBriqueGame();
            leJeu.Show();
            this.Close();
        }

        private void Index_Load(object sender, EventArgs e)
        {

        }
    }
}
