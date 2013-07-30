using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TW_Mission_Control
{
    public partial class Form1 : Form
    {
        public User user = new User();
        public Boolean stopProgram = false;

        private DialogResult _loginResult;

        public Form1()
        {
            InitializeComponent();
            while (!user.isLoggedIn())
            {
                dbLogin login = new dbLogin();
                _loginResult = login.ShowDialog();
                if (_loginResult == DialogResult.Cancel)
                {
                    break;
                }
            }
        }

        protected override void OnShown(EventArgs e)
        {
            if (_loginResult == DialogResult.Cancel)
            {
                this.Close(); // which should shut down the app
            }
        }


        /*
         * EVENT HANDLERS:
         */ 

        // MENU Bestand -> Afsluiten
        private void afsluitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // MENU Help -> Over
        private void overToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Over about = new Over();
            about.ShowDialog();
        }
    }
}
