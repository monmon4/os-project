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
        enum State { ProcessType, ProcessAdd, ProcessFinish };
        Processes processes;
        int i;
        State form_state;

        public Form1()
        {
            InitializeComponent();
            processes = new Processes();
            i = 0;
        }


        private void draw_chart(gant_info info)
        {
            int time = 0;
            for (int i = 0; i < info.index.Count(); i++)
            {
                string s = " ";
                if (info.index[i] == -2)
                {
                    gantt_chart.AppendText("     ");
                    gantt_chart.AppendText("|");
                    s += ("   ");
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
                        s = s + " ";
                    }
                }
                string m =  s ;
                time = info.time[i];

                if (time > 9)
                    m = s.Remove(s.Length - 1);
                textBox2.AppendText(Convert.ToString(time));
                textBox2.AppendText(m);

            }
        }

        private int get_min_interval(gant_info info)
        {
            int min_interval = 2^30 ;//very big interval
            for (int i = 0; i < info.index.Count-1; i++)
            {
                if ((info.time[i + 1] - info.time[i]) < min_interval)
                    min_interval = info.time[i + 1] - info.time[i];
            }
            return min_interval;
        }

        private void put_process(gant_info info, Label process, Label time,int current_time , int next_time, int i, int points_per_timeunit)
        {
            int wid = (next_time - current_time) * points_per_timeunit;
            if (info.index[i] == -2)
            {
                process.Text = " ";
            }
            else
            {
                process.Text = processes.all[info.index[i]].get_name();
                process.AutoSize = true;
                string name = process.Text;
                if (process.Size.Width > wid)
                {
                    for (int j = name.Length; (j > 2) && (process.Size.Width > wid); j--)
                    {
                        process.Text = name.Substring(0, j) + "..";
                    }
                }
            }
            process.AutoSize = false;
            process.Size = new Size(wid, 20);
            process.BringToFront();
        }
        private void draw(gant_info info,int points_per_timeunit,bool double_lines = false)
        {
            int x_pos = 0;
            int y_pos = 47;
            Point names_point = new Point(x_pos, y_pos); //start points
            Point times_point = new Point(0, y_pos + 20);
            Label process = new Label();
            Label time = new Label();
            process.BorderStyle = BorderStyle.FixedSingle;
            process.TextAlign = ContentAlignment.MiddleCenter;
            process.BringToFront();
            time.BringToFront();
            process.Location = names_point;
            time.Location = times_point;
            int middle_time = info.time[info.time.Count - 1] / 2; //if 2 rows
            for (int i = 0; i < info.index.Count; i++)
            {
                time.Text = info.time[i].ToString();
                time.AutoSize = true;
                result.Controls.Add(time);
                time.BringToFront();
                if (info.index[i] != -1)
                {
                    result.Controls.Add(process);
                    if (info.time[i + 1] < middle_time || double_lines == false)
                    {
                        int next_time = info.time[i + 1];
                        int current_time = info.time[i];
                        put_process(info, process, time,current_time, next_time, i, points_per_timeunit);
                    }
                    else
                    {
                        int next_time = middle_time;
                        int current_time = info.time[i];
                        put_process(info, process, time,current_time, next_time, i, points_per_timeunit);
                        //add the middle time to the end of the first row
                        times_point.Offset(process.Width, 0);
                        time = new Label();
                        time.Location = times_point;
                        time.Text = middle_time.ToString();
                        time.AutoSize = true;
                        result.Controls.Add(time);
                        time.BringToFront();
                        //add the middle time to the beggining of the second row and continue the process
                        names_point = new Point(x_pos, y_pos+2*20);//to be below the times labels of the first row
                        times_point = new Point(x_pos, y_pos +3*20);//to be below both the time labels of the first row and the names labels of the second row
                        process = new Label();
                        time = new Label();
                        process.BorderStyle = BorderStyle.FixedSingle;
                        process.TextAlign = ContentAlignment.MiddleCenter;
                        process.Location = names_point;
                        time.Location = times_point;
                        time.Text = middle_time.ToString();
                        time.AutoSize = true;
                        result.Controls.Add(time);
                        time.BringToFront();
                        result.Controls.Add(process);
                        next_time = info.time[i + 1];
                        current_time = middle_time;
                        put_process(info, process, time, current_time,next_time, i, points_per_timeunit);
                        middle_time = -1;// so it never excute this section again
                    }
                    names_point.Offset(process.Width, 0);
                    times_point.Offset(process.Width, 0);
                    process = new Label();
                    time = new Label();
                    process.BorderStyle = BorderStyle.FixedSingle;
                    process.TextAlign = ContentAlignment.MiddleCenter;
                    process.Location = names_point;
                    time.Location = times_point;
                }
            }
        }
        private void draw_chart_alternative(gant_info info)
        {
            Label ref_label = new Label(); // for calculation only used once
            ref_label.Text = "MM.."; 
            result.Controls.Add(ref_label); // to add to the groupbox result
            ref_label.AutoSize = true; //reference label
            ref_label.Visible = false;
            int points_per_timeunit = (result.Width)  /  info.time[info.time.Count - 1];
            int min_width = get_min_interval(info) * points_per_timeunit;
            if( min_width > ref_label.Width)
            {
                draw(info, points_per_timeunit);
            }
            else 
            {
                draw(info, points_per_timeunit * 2,true);//*2 to indicate two rows
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


        private void add_Click(object sender, EventArgs e)
        {
            try
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
                processes_count.Text = i.ToString(); // to send the number of processes
                label5.Text = "";

            }
            catch
            {
                label5.Text = "invalid input";
            }

        }
        

        private float wait(gant_info info) // to get the whole waiting time
        {
            int index = 0, total_time = 0;
            for (int j = 0; j < processes.all.Count(); j++)
            {
                index = info.index.IndexOf(j);
                total_time += info.time[index] - processes.all[j].get_arrive();
            }
            return total_time;

        }
        private void average_wait(gant_info info) // to get the average waiting time
        {

            float total_waiting = wait(info);
            equations.Text = (total_waiting / processes.all.Count()).ToString();
        }

        private void start_Click(object sender, EventArgs e)
        {
            State state = get_state();
            if (state == State.ProcessAdd)
            {
                state = State.ProcessFinish;
                set_state(state);

                gantt_chart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

                gant_info info = new gant_info();
                if (fcfs.Checked)
                {
                    info = processes.start_excution();
                }
                else if (sjf.Checked)
                {
                    if (preem.Checked)
                        info = processes.start_excution(Method.SRJF);
                    else
                        info = processes.start_excution(Method.SJF);
                }
                else if (priority.Checked)
                {
                    if (preem.Checked)
                        info = processes.start_excution(Method.PRP);
                    else
                        info = processes.start_excution(Method.PRN);
                }
                else if (rr.Checked)
                {
                    info = processes.start_excution(Method.RR, Int32.Parse(q.Text));
                }
                draw_chart(info);
                average_wait(info);

            }
            else
            {
                state = State.ProcessAdd;
                set_state(state);
                processes.reset();
            }

        }

        private void set_state(State state)
        {
            bool type_part = false, add_part = false, start_part = false;
            form_state = state;
            if (state == State.ProcessType)
            {
                type_part = true;
                add_part = false;
                start_part = false;
            }
            else if (state == State.ProcessAdd)
            {
                type_part = false;
                add_part = true;
                start_part = true;
            }
            else if (state == State.ProcessFinish)
            {
                type_part = false;
                add_part = false;
                start_part = true;
            }
            type.Enabled = type_part;
            subtype.Enabled = false;
            if (type_part) fcfs.Checked = true;
            done1.Enabled = type_part | add_part;
            done1.Text = type_part ? "Done" : "Modify";
            info.Enabled = add_part;
            groupBox4.Enabled = start_part;
            start.Text = (start_part) & (!add_part) & (!type_part) ? "Restart" : "Start";
            if (type_part)
            {
                processes = new Processes();
                i = 0;
                processes_count.Text = "";
                listView1.Items.Clear();
            }
            if (add_part | type_part)
            {
                gantt_chart.Text = "";
                textBox2.Text = "";
                equations.Text = "";
                
            }
        }
        private State get_state()
        {
            return form_state;
        }

        private void done1_Click(object sender, EventArgs e)
        {
            State state = get_state();
            if (state == State.ProcessType)
            {
                state = State.ProcessAdd;
                set_state(state);
            }
            else
            {
                state = State.ProcessType;
                set_state(state);
            }
        }
    }
}
