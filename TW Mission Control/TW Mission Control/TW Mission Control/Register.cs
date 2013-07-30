using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace TW_Mission_Control
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                mainConfig conf = new mainConfig();
                Encryption ecn = new Encryption();
                string encPass = ecn.CreatePasswordHash(textBox2.Text.Trim(), conf.secret);
                string userName = textBox1.Text.ToLower().Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR!" + ex.Message);
            }
        }
    }
}
