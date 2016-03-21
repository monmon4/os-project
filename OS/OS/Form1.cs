using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string x="       ";
            string y = "|";
            int time=5;
            bool process=true;
           // if (process)
            {       for (int i = 0; i < time; i++)
                {
                    
                    textBox5.AppendText(x);
                }
            }
            //else
            {
                textBox5.AppendText(y);
                textBox5.AppendText(Convert.ToString(time));
            }
        }
    }
}
