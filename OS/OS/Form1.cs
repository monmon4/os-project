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

        private void draw_chart(gant_info info)
        {
            int time = 0;
            for (int i = 0; i < info.index.Count(); i++)
            {
                string s = ".";
                if (info.index[i] == -2)
                {
                    gantt_chart.AppendText("     ");
                    gantt_chart.AppendText("|");
                }
                else if (info.index[i] != -1)
                {
                    string ss = processes.get_process(info.index[i]).get_name();
                    string x = " " + ss + " ";
                    string y = "|";
                    gantt_chart.AppendText(x);
                    gantt_chart.AppendText(y);
                    for (int j = 0; j < ss.Length; j++)
                    {
                        s = s + ".";
                    }
                }
                string m =  s ;
                time = info.time[i];
                textBox2.AppendText(Convert.ToString(time));
                textBox2.AppendText(m);

            }
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
                string[] arr = new string[5]; 
                ListViewItem itm; 
                 arr[0] = i.ToString();
                 arr[1] = name.Text;
                 arr[2] = arrive.Text;
                 arr[3] = burst.Text;
                 arr[4] = prio.Text;
                itm = new ListViewItem(arr); 
                listView1.Items.Add(itm);
                processes_count.Text = i.ToString();

            
        }

        
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gantt_chart_TextChanged(object sender, EventArgs e)
        {

        }

        private float wait(gant_info info)
        {
            int index = 0, total_time = 0;
            for (int j = 0; j < processes.all.Count(); j++)
            {
                index = info.index.IndexOf(j);
                total_time += info.time[index] - processes.all[j].get_arrive();
            }
            return total_time;

        }
        private void average_wait(gant_info info)
        {

            float total_waiting = wait(info);
            equations.Text = (total_waiting / processes.all.Count()).ToString();
        }

        private void start_Click(object sender, EventArgs e)
        {
            gantt_chart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            
            int time = 0;
            gant_info info = new gant_info();
            if (fcfs.Checked)
            {
                processes.gantt_process1(processes.get_sorted_arri(0).get_name(), processes.get_sorted_arri(0).get_arrive(), processes.get_sorted_arri(0).get_burst(), textBox2,gantt_chart);
               time= processes.get_time_p1(processes.get_sorted_arri(0).get_arrive(), processes.get_sorted_arri(0).get_burst());
               int waiting_time= time - processes.get_sorted_arri(0).get_arrive()- processes.get_sorted_arri(0).get_burst();
                //the rest
                for (int i = 1; i < Int32.Parse(processes_count.Text); i++)
                {
                    processes.gantt_the_rest_processes(processes.get_sorted_arri(i).get_name(), processes.get_sorted_arri(i).get_arrive(), processes.get_sorted_arri(i).get_burst(),time, textBox2, gantt_chart);
                    time = processes.get_time(processes.get_sorted_arri(i).get_arrive(), processes.get_sorted_arri(i).get_burst(), time);
                       waiting_time=waiting_time  + time -processes.get_sorted_arri(i).get_arrive()- processes.get_sorted_arri(i).get_burst() ; 
                }
                decimal Avg_WT =(decimal)waiting_time / Convert.ToDecimal(processes_count.Text);
                equations.AppendText(Convert.ToString(Avg_WT) + "  sec");
            }
            else if (sjf.Checked)
            {
                if (preem.Checked)
                    info = processes.srjf();
                else
                    info = processes.sjf();
                draw_chart(info);
                average_wait(info);
            }
            else if (priority.Checked)
            {
                if (nonpreem.Checked)
                {
                    processes.gantt_process1(processes.get_sorted_prio(0).get_name(), processes.get_sorted_prio(0).get_arrive(), processes.get_sorted_prio(0).get_burst(), textBox2, gantt_chart);
                    time = processes.get_time_p1(processes.get_sorted_prio(0).get_arrive(), processes.get_sorted_prio(0).get_burst());
                    int waiting_time = time - processes.get_sorted_prio(0).get_arrive() - processes.get_sorted_prio(0).get_burst();
                    //the rest
                    for (int i = 1; i < Int32.Parse(processes_count.Text); i++)
                    {
                        processes.gantt_the_rest_processes(processes.get_sorted_prio(i).get_name(), processes.get_sorted_prio(i).get_arrive(), processes.get_sorted_prio(i).get_burst(), time, textBox2, gantt_chart);
                        time = processes.get_time(processes.get_sorted_prio(i).get_arrive(), processes.get_sorted_prio(i).get_burst(), time);
                        waiting_time = waiting_time + time - processes.get_sorted_prio(0).get_arrive() - processes.get_sorted_prio(0).get_burst();

                    }
                    decimal Avg_WT = (decimal)waiting_time / Convert.ToDecimal(processes_count.Text);
                    equations.AppendText(Convert.ToString(Avg_WT) + "  sec");
                }
            }
            else if (rr.Checked)
            {
               info =  processes.rr(Int32.Parse(q.Text));
                draw_chart(info);
                average_wait(info);
               
            }

            

        }

        private void preem_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void done1_Click(object sender, EventArgs e)
        {
            info.Enabled = true;
            groupBox4.Enabled = true;
            type.Enabled = false;
            subtype.Enabled = false;
            done1.Enabled = false;

        }
    }
}
