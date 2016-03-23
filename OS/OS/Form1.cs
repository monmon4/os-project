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
                prio.Enabled = false;
                q.Enabled = false;
            }
           
        }

        private void fcfs_CheckedChanged(object sender, EventArgs e)
        {
            if (fcfs.Checked)
            {
                subtype.Enabled = false;
                prio.Enabled = false;
                q.Enabled = false;
            }
        }

        private void priority_CheckedChanged(object sender, EventArgs e)
        {
            if (priority.Checked)
            {
                subtype.Enabled = true;
                prio.Enabled = true;
                q.Enabled = false;
            }
        }

        private void rr_CheckedChanged(object sender, EventArgs e)
        {
            if (rr.Checked)
            {
                subtype.Enabled = false;
                prio.Enabled = false;
                q.Enabled = true;
            }
        }

        private void arrive_TextChanged(object sender, EventArgs e)
        {
            if (priority.Checked)
            {
                if (nonpreem.Checked)
                {
                    arrive.Text = "0";
                    MessageBox.Show("Please consider that we assume all process arrive @ 0 time ...");

                }
            }
        }
        private void add_Click(object sender, EventArgs e)
        {
            if (priority.Checked)
            {
                Process process = new Process(name.Text, Int32.Parse(arrive.Text), Int32.Parse(burst.Text), Int32.Parse(prio.Text));
                processes.add_process(process);


            }
            else
            {
                Process process = new Process(name.Text, Int32.Parse(arrive.Text), Int32.Parse(burst.Text));
                processes.add_process(process);
            }
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
            gantt_chart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            
            int time = 0;
            gant_info info = new gant_info();
            if (fcfs.Checked)
            {
                string x = "   " + processes.get_sorted_arri(0).get_name() + "   ";
                string y = "|";
                string s = ".";
                string ss = processes.get_sorted_arri(0).get_name();
                for (int i = 0; i < ss.Length; i++)
                {
                    s = s + ".";
                }

                string m = "   " + s + "   ";

                //process1
                if (processes.get_sorted_arri(0).get_arrive() == 0)
                {
                    time = 0;
                    textBox2.AppendText(Convert.ToString(0));
                    textBox2.AppendText(m);
                    time = time + processes.get_process(0).get_burst();//last time+burst  //new time
                    textBox2.AppendText(Convert.ToString(time));
                    gantt_chart.AppendText(x);
                    gantt_chart.AppendText(y);

                }

                else if (processes.get_sorted_arri(0).get_arrive() != 0)
                {
                    time = processes.get_sorted_arri(0).get_arrive();
                    textBox2.AppendText(Convert.ToString(0)); // no process time
                    textBox2.AppendText("     ");
                    gantt_chart.AppendText("     ");
                    gantt_chart.AppendText(y);

                    textBox2.AppendText(Convert.ToString(time)); // process arrived
                    textBox2.AppendText(m);
                    time = time + processes.get_sorted_arri(0).get_burst();
                    textBox2.AppendText(Convert.ToString(time));
                    gantt_chart.AppendText(x);
                    gantt_chart.AppendText(y);

                }
                //the rest
                for (int i = 1; i < Int32.Parse(processes_count.Text); i++)
                {
                    s = ".";
                    ss = processes.get_sorted_arri(i).get_name();
                    for (int j = 0; j < ss.Length; j++)
                    {
                        s = s + ".";
                    }
                    m = "   " + s + "   ";
                    x = "   " + processes.get_sorted_arri(i).get_name() + "   ";
                    if (processes.get_sorted_arri(i).get_arrive() < time) // time da bta3 el process elly ablha 
                    {
                        textBox2.AppendText(m);
                        time = time + processes.get_sorted_arri(i).get_burst();//last time+burst  //new time
                        textBox2.AppendText(Convert.ToString(time));
                        gantt_chart.AppendText(x);
                        gantt_chart.AppendText(y);

                    }
                    else if (processes.get_sorted_arri(i).get_arrive() > time)
                    {
                        time = processes.get_sorted_arri(i).get_arrive();
                        textBox2.AppendText(Convert.ToString(0)); // no process time
                        textBox2.AppendText("     ");
                        gantt_chart.AppendText("     ");
                        gantt_chart.AppendText(y);

                        textBox2.AppendText(Convert.ToString(time)); // process arrived
                        textBox2.AppendText(m);
                        time = time + processes.get_sorted_arri(i).get_burst();
                        textBox2.AppendText(Convert.ToString(time));
                        gantt_chart.AppendText(x);
                        gantt_chart.AppendText(y);

                    }
                }
            }
            else if (sjf.Checked)
            {
            }
            else if (priority.Checked)
            {
                string x = "   " + processes.get_sorted_prio(0).get_name() + "   ";
                string y = "|";
                string s = ".";
                string ss;


                if (nonpreem.Checked)
                {
                    //process1
                    ss = processes.get_sorted_prio(0).get_name();
                    for (int i = 0; i < ss.Length; i++)
                    {
                        s = s + ".";
                    }

                    string m = "   " + s + "   ";

                    if (processes.get_sorted_prio(0).get_arrive() == 0)
                    {
                        time = 0;
                        textBox2.AppendText(Convert.ToString(0));
                        textBox2.AppendText(m);
                        time = time + processes.get_sorted_prio(0).get_burst();//last time+burst  //new time
                        textBox2.AppendText(Convert.ToString(time));
                        gantt_chart.AppendText(x);
                        gantt_chart.AppendText(y);

                    }

                    else if (processes.get_sorted_prio(0).get_arrive() != 0)
                    {

                        time = processes.get_sorted_prio(0).get_arrive();
                        textBox2.AppendText(Convert.ToString(0)); // no process time
                        textBox2.AppendText("     ");
                        gantt_chart.AppendText("     ");
                        gantt_chart.AppendText(y);

                        textBox2.AppendText(Convert.ToString(time)); // process arrived
                        textBox2.AppendText(m);
                        time = time + processes.get_sorted_prio(0).get_burst();
                        textBox2.AppendText(Convert.ToString(time));
                        gantt_chart.AppendText(x);
                        gantt_chart.AppendText(y);

                    }
                    //the rest
                    for (int i = 1; i < Int32.Parse(processes_count.Text); i++)
                    {
                        s = ".";
                        ss = processes.get_sorted_prio(i).get_name();
                        for (int j = 0; j < ss.Length; j++)
                        {
                            s = s + ".";
                        }

                        m = "   " + s + "   ";
                        x = "   " + processes.get_sorted_prio(i).get_name() + "   ";
                        if (processes.get_sorted_prio(i).get_arrive() < time) // time da bta3 el process elly ablha 
                        {
                            textBox2.AppendText(m);
                            time = time + processes.get_sorted_prio(i).get_burst();//last time+burst  //new time
                            textBox2.AppendText(Convert.ToString(time));
                            gantt_chart.AppendText(x);
                            gantt_chart.AppendText(y);

                        }
                        else if (processes.get_sorted_prio(i).get_arrive() > time)
                        {
                            time = processes.get_sorted_prio(i).get_arrive();
                            textBox2.AppendText(Convert.ToString(0)); // no process time
                            textBox2.AppendText("     ");
                            gantt_chart.AppendText("     ");
                            gantt_chart.AppendText(y);

                            textBox2.AppendText(Convert.ToString(time)); // process arrived
                            textBox2.AppendText(m);
                            time = time + processes.get_sorted_prio(i).get_burst();
                            textBox2.AppendText(Convert.ToString(time));
                            gantt_chart.AppendText(x);
                            gantt_chart.AppendText(y);

                        }
                    }
                }
            }
            else if (rr.Checked)
            {
               info =  processes.rr(Int32.Parse(q.Text));
               for (int i = 0; i < info.index.Count(); i++)
               {

                   if (info.index[i] == -2)
                   {
                       gantt_chart.AppendText("     ");
                       gantt_chart.AppendText("|");
                   }
                   else if (info.index[i] != -1)
                   {
                       string x = " " + processes.get_process(info.index[i]).get_name() + " ";
                       string y = "|";
                       gantt_chart.AppendText(x);
                       gantt_chart.AppendText(y);
                   }
                   string s = ".";
                   string ss = processes.get_process(info.index[i]).get_name();
                   for (int j = 0; j < ss.Length; j++)
                   {
                       s = s + ".";
                   }
                   string m = "   " + s + "   ";
                   int z = 0;
                   time = info.time[i]  ;
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

        private void preem_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
