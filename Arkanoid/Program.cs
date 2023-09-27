using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CasseBriqueGame
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Index index = new Index();
            index.Show();
            Application.Run();
        }
    }
}