namespace OS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.add = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.TextBox();
            this.sjf = new System.Windows.Forms.RadioButton();
            this.rr = new System.Windows.Forms.RadioButton();
            this.priority = new System.Windows.Forms.RadioButton();
            this.nonpreem = new System.Windows.Forms.RadioButton();
            this.preem = new System.Windows.Forms.RadioButton();
            this.info = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.warning = new System.Windows.Forms.Label();
            this.prio = new System.Windows.Forms.TextBox();
            this.q = new System.Windows.Forms.TextBox();
            this.burst = new System.Windows.Forms.TextBox();
            this.arrive = new System.Windows.Forms.TextBox();
            this.prior = new System.Windows.Forms.Label();
            this.proocess = new System.Windows.Forms.Label();
            this.burst_time = new System.Windows.Forms.Label();
            this.arrive_time = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.start = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.stop = new System.Windows.Forms.Button();
            this.processes_count = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.equations = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.gantt_chart = new System.Windows.Forms.TextBox();
            this.fcfs = new System.Windows.Forms.RadioButton();
            this.type = new System.Windows.Forms.GroupBox();
            this.subtype = new System.Windows.Forms.GroupBox();
            this.done1 = new System.Windows.Forms.Button();
            this.info.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.type.SuspendLayout();
            this.subtype.SuspendLayout();
            this.SuspendLayout();
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(447, 51);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 0;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(9, 51);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(57, 20);
            this.name.TabIndex = 1;
            // 
            // sjf
            // 
            this.sjf.AutoSize = true;
            this.sjf.Location = new System.Drawing.Point(74, 28);
            this.sjf.Name = "sjf";
            this.sjf.Size = new System.Drawing.Size(42, 17);
            this.sjf.TabIndex = 8;
            this.sjf.TabStop = true;
            this.sjf.Text = "SJF";
            this.sjf.UseVisualStyleBackColor = true;
            this.sjf.CheckedChanged += new System.EventHandler(this.sjf_CheckedChanged);
            // 
            // rr
            // 
            this.rr.AutoSize = true;
            this.rr.Location = new System.Drawing.Point(230, 28);
            this.rr.Name = "rr";
            this.rr.Size = new System.Drawing.Size(39, 17);
            this.rr.TabIndex = 10;
            this.rr.TabStop = true;
            this.rr.Text = "RR";
            this.rr.UseVisualStyleBackColor = true;
            this.rr.CheckedChanged += new System.EventHandler(this.rr_CheckedChanged);
            // 
            // priority
            // 
            this.priority.AutoSize = true;
            this.priority.Location = new System.Drawing.Point(146, 28);
            this.priority.Name = "priority";
            this.priority.Size = new System.Drawing.Size(59, 17);
            this.priority.TabIndex = 9;
            this.priority.TabStop = true;
            this.priority.Text = "Priority";
            this.priority.UseVisualStyleBackColor = true;
            this.priority.CheckedChanged += new System.EventHandler(this.priority_CheckedChanged);
            // 
            // nonpreem
            // 
            this.nonpreem.AutoSize = true;
            this.nonpreem.Location = new System.Drawing.Point(6, 51);
            this.nonpreem.Name = "nonpreem";
            this.nonpreem.Size = new System.Drawing.Size(97, 17);
            this.nonpreem.TabIndex = 12;
            this.nonpreem.Text = "nonPreemptive";
            this.nonpreem.UseVisualStyleBackColor = true;
            // 
            // preem
            // 
            this.preem.AutoSize = true;
            this.preem.Location = new System.Drawing.Point(6, 28);
            this.preem.Name = "preem";
            this.preem.Size = new System.Drawing.Size(79, 17);
            this.preem.TabIndex = 11;
            this.preem.Text = "Preemptive";
            this.preem.UseVisualStyleBackColor = true;
            this.preem.CheckedChanged += new System.EventHandler(this.preem_CheckedChanged);
            // 
            // info
            // 
            this.info.Controls.Add(this.label1);
            this.info.Controls.Add(this.warning);
            this.info.Controls.Add(this.prio);
            this.info.Controls.Add(this.q);
            this.info.Controls.Add(this.burst);
            this.info.Controls.Add(this.arrive);
            this.info.Controls.Add(this.prior);
            this.info.Controls.Add(this.proocess);
            this.info.Controls.Add(this.burst_time);
            this.info.Controls.Add(this.name);
            this.info.Controls.Add(this.arrive_time);
            this.info.Controls.Add(this.add);
            this.info.Enabled = false;
            this.info.Location = new System.Drawing.Point(23, 113);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(538, 100);
            this.info.TabIndex = 4;
            this.info.TabStop = false;
            this.info.Text = "Process info";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(346, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Quantam";
            // 
            // warning
            // 
            this.warning.AutoSize = true;
            this.warning.Location = new System.Drawing.Point(127, 76);
            this.warning.Name = "warning";
            this.warning.Size = new System.Drawing.Size(0, 13);
            this.warning.TabIndex = 13;
            // 
            // prio
            // 
            this.prio.Location = new System.Drawing.Point(258, 51);
            this.prio.Name = "prio";
            this.prio.Size = new System.Drawing.Size(57, 20);
            this.prio.TabIndex = 12;
            // 
            // q
            // 
            this.q.Location = new System.Drawing.Point(347, 51);
            this.q.Name = "q";
            this.q.Size = new System.Drawing.Size(60, 20);
            this.q.TabIndex = 15;
            // 
            // burst
            // 
            this.burst.Location = new System.Drawing.Point(169, 51);
            this.burst.Name = "burst";
            this.burst.Size = new System.Drawing.Size(57, 20);
            this.burst.TabIndex = 11;
            // 
            // arrive
            // 
            this.arrive.Location = new System.Drawing.Point(87, 51);
            this.arrive.Name = "arrive";
            this.arrive.Size = new System.Drawing.Size(57, 20);
            this.arrive.TabIndex = 10;
            this.arrive.TextChanged += new System.EventHandler(this.arrive_TextChanged);
            // 
            // prior
            // 
            this.prior.AutoSize = true;
            this.prior.Location = new System.Drawing.Point(261, 28);
            this.prior.Name = "prior";
            this.prior.Size = new System.Drawing.Size(41, 13);
            this.prior.TabIndex = 9;
            this.prior.Text = "priority";
            // 
            // proocess
            // 
            this.proocess.AutoSize = true;
            this.proocess.Location = new System.Drawing.Point(6, 28);
            this.proocess.Name = "proocess";
            this.proocess.Size = new System.Drawing.Size(73, 13);
            this.proocess.TabIndex = 6;
            this.proocess.Text = "Process name";
            // 
            // burst_time
            // 
            this.burst_time.AutoSize = true;
            this.burst_time.Location = new System.Drawing.Point(183, 28);
            this.burst_time.Name = "burst_time";
            this.burst_time.Size = new System.Drawing.Size(32, 13);
            this.burst_time.TabIndex = 8;
            this.burst_time.Text = "Burst";
            // 
            // arrive_time
            // 
            this.arrive_time.AutoSize = true;
            this.arrive_time.Location = new System.Drawing.Point(85, 28);
            this.arrive_time.Name = "arrive_time";
            this.arrive_time.Size = new System.Drawing.Size(61, 13);
            this.arrive_time.TabIndex = 7;
            this.arrive_time.Text = "Arrival time";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listView1);
            this.groupBox4.Controls.Add(this.start);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.stop);
            this.groupBox4.Controls.Add(this.processes_count);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(23, 219);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(538, 196);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.Location = new System.Drawing.Point(18, 28);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(379, 137);
            this.listView1.TabIndex = 15;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "index";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "name";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "arrive";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "burst";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "priority";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(430, 97);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 1;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(417, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "No. of processes";
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(430, 126);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 1;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            // 
            // processes_count
            // 
            this.processes_count.Enabled = false;
            this.processes_count.Location = new System.Drawing.Point(430, 44);
            this.processes_count.Name = "processes_count";
            this.processes_count.Size = new System.Drawing.Size(53, 20);
            this.processes_count.TabIndex = 14;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.equations);
            this.groupBox5.Controls.Add(this.textBox2);
            this.groupBox5.Controls.Add(this.gantt_chart);
            this.groupBox5.Location = new System.Drawing.Point(23, 421);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(538, 124);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Result";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Average waiting time =";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Gantt Chart";
            // 
            // equations
            // 
            this.equations.BackColor = System.Drawing.SystemColors.Control;
            this.equations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.equations.Enabled = false;
            this.equations.Location = new System.Drawing.Point(146, 98);
            this.equations.Name = "equations";
            this.equations.Size = new System.Drawing.Size(376, 13);
            this.equations.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(18, 72);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(504, 13);
            this.textBox2.TabIndex = 1;
            // 
            // gantt_chart
            // 
            this.gantt_chart.BackColor = System.Drawing.SystemColors.Control;
            this.gantt_chart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gantt_chart.Enabled = false;
            this.gantt_chart.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gantt_chart.Location = new System.Drawing.Point(18, 47);
            this.gantt_chart.Name = "gantt_chart";
            this.gantt_chart.Size = new System.Drawing.Size(504, 13);
            this.gantt_chart.TabIndex = 0;
            this.gantt_chart.TextChanged += new System.EventHandler(this.gantt_chart_TextChanged);
            // 
            // fcfs
            // 
            this.fcfs.AutoSize = true;
            this.fcfs.Location = new System.Drawing.Point(6, 28);
            this.fcfs.Name = "fcfs";
            this.fcfs.Size = new System.Drawing.Size(50, 17);
            this.fcfs.TabIndex = 11;
            this.fcfs.TabStop = true;
            this.fcfs.Text = "FCFS";
            this.fcfs.UseVisualStyleBackColor = true;
            this.fcfs.CheckedChanged += new System.EventHandler(this.fcfs_CheckedChanged);
            // 
            // type
            // 
            this.type.Controls.Add(this.fcfs);
            this.type.Controls.Add(this.sjf);
            this.type.Controls.Add(this.rr);
            this.type.Controls.Add(this.priority);
            this.type.Location = new System.Drawing.Point(23, 12);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(292, 76);
            this.type.TabIndex = 13;
            this.type.TabStop = false;
            this.type.Text = "Scheduling type";
            // 
            // subtype
            // 
            this.subtype.Controls.Add(this.preem);
            this.subtype.Controls.Add(this.nonpreem);
            this.subtype.Enabled = false;
            this.subtype.Location = new System.Drawing.Point(345, 12);
            this.subtype.Name = "subtype";
            this.subtype.Size = new System.Drawing.Size(117, 76);
            this.subtype.TabIndex = 14;
            this.subtype.TabStop = false;
            this.subtype.Text = "Preemptivety";
            // 
            // done1
            // 
            this.done1.Location = new System.Drawing.Point(486, 34);
            this.done1.Name = "done1";
            this.done1.Size = new System.Drawing.Size(75, 23);
            this.done1.TabIndex = 16;
            this.done1.Text = "Done";
            this.done1.UseVisualStyleBackColor = true;
            this.done1.Click += new System.EventHandler(this.done1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 557);
            this.Controls.Add(this.done1);
            this.Controls.Add(this.subtype);
            this.Controls.Add(this.type);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.info);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.info.ResumeLayout(false);
            this.info.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.type.ResumeLayout(false);
            this.type.PerformLayout();
            this.subtype.ResumeLayout(false);
            this.subtype.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button add;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.GroupBox info;
        private System.Windows.Forms.Label proocess;
        private System.Windows.Forms.RadioButton sjf;
        private System.Windows.Forms.RadioButton rr;
        private System.Windows.Forms.RadioButton priority;
        private System.Windows.Forms.RadioButton nonpreem;
        private System.Windows.Forms.RadioButton preem;
        private System.Windows.Forms.TextBox prio;
        private System.Windows.Forms.TextBox burst;
        private System.Windows.Forms.TextBox arrive;
        private System.Windows.Forms.Label prior;
        private System.Windows.Forms.Label burst_time;
        private System.Windows.Forms.Label arrive_time;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton fcfs;
        private System.Windows.Forms.GroupBox type;
        private System.Windows.Forms.GroupBox subtype;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TextBox gantt_chart;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox q;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label warning;
        private System.Windows.Forms.TextBox equations;
        private System.Windows.Forms.TextBox processes_count;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button done1;
    }
}

