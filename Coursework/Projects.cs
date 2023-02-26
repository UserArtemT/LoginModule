using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class Projects : Form
    {

        public bool statusTeacher = false;
        public string group = "";
        public string login = "";
        //public bool statusStudent = false;


        public void zamena(string text1, string text2)
        {
            group = text1;
            login = text2;
        }

        public void test()
        {
            statusTeacher = true;
        }

        private List<string> GetRecursFiles(string start_path)
        {
            List<string> ls = new List<string>();
            try
            {
                string[] folders = Directory.GetDirectories(start_path);
                foreach (string folder in folders)
                { 
                    //if (statusTeacher == true)
                    //{
                        ls.Add("Папка: " + folder);
                    //}
                    ls.AddRange(GetRecursFiles(folder));
                }
                
                string[] files = Directory.GetFiles(start_path);
                foreach (string filename in files)
                {
                    ls.Add("Файл: " + filename);
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return ls;
        }
        

        public Projects()
        {
            InitializeComponent();
        }

        private void Projects_Load(object sender, EventArgs e)
        {
            FormLoginSP formLoginSP = new FormLoginSP();

            string path = Application.StartupPath + @"\Projects\" + group+"\\"+login;

            List<string> ls = GetRecursFiles(path);
            foreach (string fname in ls)
            {
                richTextBox1.Text += fname+Environment.NewLine;
            }
        }
    }
}
