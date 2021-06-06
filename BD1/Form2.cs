using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BD;

namespace BD1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            textBoxServ.Text = "localhost";
            textBoxSec.Text = "SSPI";
            textBoxDB.Text = "BD";
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Program.Server = textBoxServ.Text;
            Program.Secure = textBoxSec.Text;
            Program.DBLog = textBoxDB.Text;
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
