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
        Processes processes;
        int i;

        public Form1()
        {
            InitializeComponent();
            processes = new Processes();
            i = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }


        private void sjf_CheckedChanged(object sender, EventArgs e)
        {
            if (sjf.Checked)
            {
                subtype.Enabled = true;
            }
           
        }

        private void fcfs_CheckedChanged(object sender, EventArgs e)
        {
            if (fcfs.Checked)
            {
                subtype.Enabled = false;
            }
        }

        private void priority_CheckedChanged(object sender, EventArgs e)
        {
            if (priority.Checked)
            {
                subtype.Enabled = true;
            }
        }

        private void rr_CheckedChanged(object sender, EventArgs e)
        {
            if (rr.Checked)
            {
                subtype.Enabled = false;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            Process process = new Process(name.Text, Int32.Parse(arrive.Text), Int32.Parse(burst.Text), Int32.Parse(prio.Text));
            processes.add_process(process);
            i++;
           
            // Loop through and add 50 items to the ListBox.
        
               
                string[] arr = new string[5]; 
                ListViewItem itm; 
                 arr[0] = i.ToString();
                 arr[1] = name.Text;
                 arr[2] = arrive.Text;
                 arr[3] = burst.Text;
                 arr[4] = prio.Text;
                itm = new ListViewItem(arr); 
                listView1.Items.Add(itm);

            
        }

        
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gantt_chart_TextChanged(object sender, EventArgs e)
        {

        }

        private void start_Click(object sender, EventArgs e)
        {
            gant_info info = new gant_info();
            if (fcfs.Checked)
            {
            }
            else if (sjf.Checked)
            {
            }
            else if (priority.Checked)
            {
            }
            else if (rr.Checked)
            {
               info =  processes.rr(Int32.Parse(q.Text));
               for (int i = 0; i < info.index.Count(); i++)
               {
                   if (info.index[i] != -1)
                   {
                       string x = " " + processes.get_process(info.index[i]).get_name() + " ";
                       string y = "|";
                       gantt_chart.AppendText(x);
                       gantt_chart.AppendText(y);
                   }
                   string m = "       ";
                   int z = 0;
                   int time = info.time[i]  ;
                   textBox2.AppendText(Convert.ToString(time));
                   textBox2.AppendText(m);
                   
               }
            }

            /*string x="   " + name.Text + "   ";
            string y = "|";
            string m = "       ";
            int z = 0;
            int time = z+Int32.Parse(arrive.Text) + Int32.Parse(burst.Text);
            textBox2.AppendText(Convert.ToString(z));
            textBox2.AppendText(m);
            textBox2.AppendText(Convert.ToString(time));
            gantt_chart.AppendText(x);               
            gantt_chart.AppendText(y);*/
        }
    }
}
