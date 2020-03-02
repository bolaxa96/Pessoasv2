using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            label1.BackColor= System.Drawing.Color.Blue;
            label1.ForeColor= System.Drawing.Color.Blue;
            label2.BackColor = System.Drawing.Color.Blue;
            label2.ForeColor = System.Drawing.Color.Blue;
           // label3.Size = (150, 14);
            button1.Text = "SignIn  ";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
           // Application.Run(f);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
