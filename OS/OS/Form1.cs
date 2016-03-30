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
        /* defines three states of using the program 
         ProcessType: choosing type of scheduling, 
         ProcessAdd: adding more processes,
         ProcessFinish: program has finished and displays the results*/
        enum State { ProcessType, ProcessAdd, ProcessFinish };

        Processes processes;
        int i;
        State form_state;
        List<Label> gantt_labels;
        private int result_width ;

        public Form1()
        {
            InitializeComponent();
            processes = new Processes();
            i = 0;
            gantt_labels = new List<Label>();
            result_width =  (int)(result.Width * 0.95);
        }


        private void draw_chart(gant_info info)//old way to draw gantt_chart
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

        // the used gantt chart//
        private int get_min_interval(gant_info info) // return the least time a process is executed
        {
            int min_interval = 2^30 ;//very big interval
            for (int i = 0; i < info.index.Count-1; i++)
            {
                if ((info.time[i + 1] - info.time[i]) < min_interval)
                    min_interval = info.time[i + 1] - info.time[i];
            }
            return min_interval;
        }

        private void put_process(gant_info info,int i , Label process,int offset) //modify the name and the size of a process in the gantt chart
        {
            if (info.index[i] == -2)//indicates a gap
            {
                process.Text = " ";
            }
            else
            {
                process.Text = processes.all[info.index[i]].get_name();
                process.AutoSize = true;
                string name = process.Text;

                if (process.Size.Width > offset)//if the process name is larger than its size
                {
                    for (int j = name.Length; (j > 2) && (process.Size.Width > offset); j--)
                    {
                        process.Text = name.Substring(0, j) + "..";
                    }
                }
            }
            process.AutoSize = false;
            process.Size = new Size(offset, 20);
            process.BringToFront();
        }

        //styling the process name and time and set their location at the gantt chart
        public void setup_index_time_labels(Label process, Label time, Point location = new Point() ,int offset = 0, int row = 1 )
        {
            result.Controls.Add(time);
            result.Controls.Add(process);
            gantt_labels.Add(time);
            gantt_labels.Add(process);

            int x_pos = 0;
            int y_pos = 50;
            Point names_point;
            Point times_point;
            if (offset == -1) //indicates new row
            {
                names_point = new Point(x_pos, y_pos * row); //start points
                times_point = new Point(x_pos, y_pos * row + 20);
            }
            else
            {
                names_point = location;
                times_point = location;
                names_point.Offset(offset, 0);
                times_point.Offset(offset, 20);
            }
            process.BorderStyle = BorderStyle.FixedSingle;
            process.TextAlign = ContentAlignment.MiddleCenter;
            process.BringToFront();
            time.AutoSize = true;
            time.BringToFront();
            process.Location = names_point;
            time.Location = times_point;
        }

        //the new gantt chart
        private void draw(gant_info info,int points_per_timeunit,bool double_lines = false)
        {
            int width = 0, offset= width;
            int row = 1;
            bool new_row = true;
            bool first_element_new_row = false;
            Point location = new Point();
            for (int i = 0; i < info.index.Count; i++)
            {
                Label process = new Label();
                Label time = new Label();
                setup_index_time_labels(process, time, location, new_row ? -1 : width, row);
                time.Text = info.time[i].ToString();
                if (info.index[i] != -1)
                {
                    int next_time = info.time[i + 1];
                    int current_time = info.time[i];
                    width = (next_time - current_time)* points_per_timeunit;
                    Point check_validity = new Point(process.Location.X + width, process.Location.Y);
                    if (new_row == true && first_element_new_row == true)
                    {
                        put_process(info, i, process, width);
                        new_row = false;
                        first_element_new_row = false;
                    }
                    else if (check_validity.X < result_width || double_lines == false)
                    {
                        offset = width;
                        put_process(info, i, process, width);
                        new_row = false;
                        first_element_new_row = false;
                    }
                    else
                    {
                        offset =(int)( result_width  - process.Location.X);
                        put_process(info,i, process, offset);
                        new_row = true;
                        info.time[i] = (offset / points_per_timeunit) + info.time[i];
                        Label unnecessary = new Label();
                        time = new Label();
                        location = process.Location;
                        setup_index_time_labels(unnecessary, time, location, offset, row);
                        unnecessary.Visible = false;
                        time.Text = info.time[i].ToString();
                        offset = width;
                        i--;
                        row++;
                        first_element_new_row = true;
                    }
                    width = process.Width;
                    location = process.Location;
                }
                else
                {
                    process.Visible = false;
                }
            }
        }
        private void draw_chart_alternative(gant_info info)//to determine how many raws will be drawn(1 or 2)
        {
            Label ref_label = new Label(); // for calculation only used once
            ref_label.Text = "MM.."; 
            result.Controls.Add(ref_label); // to add to the groupbox result
            ref_label.AutoSize = true; //reference label
            ref_label.Visible = false;
            int points_per_timeunit = (result_width)  /  info.time[info.time.Count - 1];
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
        //-----------------------------------------------------------

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
        
        //calculations of average waiting time
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
        //------------------------------

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
                average_wait(info);
                draw_chart_alternative(info);
            }
            else
            {
                state = State.ProcessAdd;
                set_state(state);
                processes.reset();
            }

        }

        private void erase_gantt_chart()
        {
            while (gantt_labels.Count > 0)
            {
                result.Controls.Remove(gantt_labels[0]);
                gantt_labels.Remove(gantt_labels[0]);
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
                //gantt_chart.Text = "";
                //textBox2.Text = "";
                erase_gantt_chart();
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
