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
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;

namespace Coursework
{
    public partial class FormLoginSP : Form
    {
        public FormLoginSP()
        {
            InitializeComponent();
        }
        public bool saStatus = false;
        public bool newUser = false;
        public void student()
        {
            radioButton1.Checked = true;
            radioButton2.Visible = false;
            comboBox1.Visible = true;
        }
        public void teacher()
        {
            radioButton2.Checked = true;
            radioButton1.Visible = false;
            comboBox1.Visible = true;
        }

        public void sa()
        {
            saStatus = true;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            comboBox1.Visible = false;
        }

        public void newUsr()
        {

            radioButton1.Visible = true;
            radioButton2.Visible = true;
            comboBox1.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saStatus == true)
            {
                try
                {
                    if (newUser == true)
                    {
                        if (radioButton1.Checked == true)
                        {
                            try
                            {
                                string file2 = System.Windows.Forms.Application.StartupPath + @"\Logins\loginstudent.txt";
                                string vvod2 = textBox1.Text.ToString() + " " + textBox2.Text.ToString() + " " + comboBox1.Text.ToString();

                                //проверка, вдруг такая учетка уже есть

                                string[] readText2 = File.ReadAllLines(file2);
                                bool status2 = false;
                                for (int i = 0; i < readText2.Length; i++)
                                {
                                    if (readText2[i] == vvod2)
                                    {
                                        status2 = true;
                                        break;
                                    }
                                }
                                if (status2 == false)
                                {
                                    vvod2 += Environment.NewLine;
                                    File.AppendAllText(file2, vvod2);
                                    MessageBox.Show("Учетная запись студента добавлена");
                                }
                                else
                                {
                                    MessageBox.Show("Учетная запись студента уже была");
                                }
                                radioButton1.Checked = false;
                                //
                            }
                            catch
                            {
                                MessageBox.Show("ОШИБКА");
                            }
                        }
                        if (radioButton2.Checked == true)
                        {
                            try
                            {
                                string file2 = System.Windows.Forms.Application.StartupPath + @"\Logins\loginteacher.txt";
                                string vvod2 = textBox1.Text.ToString() + " " + textBox2.Text.ToString() + " " + comboBox1.Text.ToString();
                                
                                //проверка, вдруг такая учетка уже есть

                                string[] readText2 = File.ReadAllLines(file2);
                                bool status2 = false;
                                for (int i = 0; i < readText2.Length; i++)
                                {
                                    if (readText2[i] == vvod2)
                                    {
                                        status2 = true;
                                        break;
                                    }
                                }
                                if (status2 == false)
                                {
                                    vvod2 += Environment.NewLine;
                                    File.AppendAllText(file2, vvod2);
                                    MessageBox.Show("Учетная запись преподавателя добавлена");
                                }
                                else
                                {
                                    MessageBox.Show("Учетная запись преподавателя уже была");
                                }
                                radioButton2.Checked = false;
                                //
                            }
                            catch
                            {
                                MessageBox.Show("ОШИБКА");
                            }
                        }

                        goto A;
                    }

                    string file = Application.StartupPath + @"\Logins\loginsa.txt";
                    string[] readText = File.ReadAllLines(file);
                    string vvod = textBox1.Text.ToString() + " " + textBox2.Text.ToString();
                    bool status = false;
                    for (int i = 0; i < readText.Length; i++)
                    {
                        if (readText[i] == vvod)
                        {
                            status = true;
                            newUser = true;
                            newUsr();
                            MessageBox.Show("Учетная запись системного администратора найдена");
                            break;
                        }
                    }
                    if (status == true)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }

                A:
                    ;
                }
                catch
                {

                }
            }

            if (radioButton1.Checked == true)
            {
                try
                {
                    string file = Application.StartupPath + @"\Logins\loginstudent.txt";
                    string[] readText = File.ReadAllLines(file);
                    string vvod = textBox1.Text.ToString() + " " + textBox2.Text.ToString() + " " + comboBox1.Text.ToString();
                    bool status = false;
                    for (int i = 0; i < readText.Length; i++)
                    {
                        if (readText[i] == vvod)
                        {
                            status = true;
                            MessageBox.Show("Учетная запись студента найдена");
                            break;
                        }
                    }
                    if (status == true)
                    {

                        Projects projects = new Projects();
                        projects.zamena(comboBox1.Text, textBox1.Text);
                        projects.ShowDialog();
                        
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин, пароль или номер группы");
                    }

                }
                catch
                {
                    
                }
            }
            if (radioButton2.Checked == true)
            {
                try
                {
                    string file = Application.StartupPath + @"\Logins\loginteacher.txt";
                    string[] readText = File.ReadAllLines(file);
                    string vvod = textBox1.Text.ToString() + " " + textBox2.Text.ToString() + " " + comboBox1.Text.ToString();
                    bool status = false;
                    for (int i = 0; i < readText.Length; i++)
                    {
                        if (readText[i] == vvod)
                        {
                            status = true;
                            MessageBox.Show("Учетная запись преподавателя найдена");
                            break;
                        }
                    }
                    if (status == true)
                    {
                        Projects projects = new Projects();
                        projects.test();
                        projects.zamena(comboBox1.Text,"");
                        projects.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Неверный логин, пароль или номер группы");
                    }

                }
                catch
                {
                    
                }
            }
            
        }
    }
}
