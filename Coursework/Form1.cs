using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }  

        private void button1_Click(object sender, EventArgs e)
        {
            FormLoginSP formloginsp = new FormLoginSP();

            formloginsp.student();
            formloginsp.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormLoginSP formloginsp = new FormLoginSP();

            formloginsp.teacher();
            formloginsp.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormLoginSP formloginsp = new FormLoginSP();

            formloginsp.sa();
            formloginsp.ShowDialog();
        }
    }
}
