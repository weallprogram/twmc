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
    public partial class dbLogin : Form
    {
        mainConfig config = new mainConfig();
        Encryption encryption = new Encryption();

        public dbLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string encUser = encryption.SimpleEncryptWithPassword(userName, config.secret);
            textBox2.Text = encUser;
            // textBox3.Text = encryption.SimpleDecryptWithPassword(encUser, config.secret);
            // this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Register reg = new Register();
            reg.ShowDialog();
            reg.Dispose();
            this.Visible = true;
        }
    }
}
