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
            string x="   " + textBox1.Text + "   ";
            string y = "|";
            string m = "       ";
            int z = 0;
            int time = z+(int)(numericUpDown1.Value) + (int)(numericUpDown2.Value);
            textBox2.AppendText(Convert.ToString(z);
            textBox2.AppendText(m);
            textBox2.AppendText(Convert.ToString(time));
            textBox5.AppendText(x);               
            textBox5.AppendText(y);
            
                
             
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
/*string x = "  " + process_name.Text + "  ";
            string y = "|";
            int time = 0 + Convert.ToInt32(burst.Text) + Convert.ToInt32(arrival_time.Text);
            // if (process)
            {
                for (int i = 0; i < (int)(numericUpDown1.Value); i++)
                {

                    textBox5.AppendText(x);
                }
            }
            //else
            {
                textBox5.AppendText(y);
                textBox5.AppendText(Convert.ToString(time));
            }
 */
