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
            this.prio = new System.Windows.Forms.TextBox();
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
            this.stop = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.gantt_chart = new System.Windows.Forms.TextBox();
            this.fcfs = new System.Windows.Forms.RadioButton();
            this.type = new System.Windows.Forms.GroupBox();
            this.subtype = new System.Windows.Forms.GroupBox();
            this.q = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.info.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.type.SuspendLayout();
            this.subtype.SuspendLayout();
            this.SuspendLayout();
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(447, 33);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 0;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(9, 60);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(57, 20);
            this.name.TabIndex = 1;
            // 
            // sjf
            // 
            this.sjf.AutoSize = true;
            this.sjf.Location = new System.Drawing.Point(6, 51);
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
            this.rr.Location = new System.Drawing.Point(6, 97);
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
            this.priority.Location = new System.Drawing.Point(6, 74);
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
            // 
            // info
            // 
            this.info.Controls.Add(this.prio);
            this.info.Controls.Add(this.burst);
            this.info.Controls.Add(this.arrive);
            this.info.Controls.Add(this.prior);
            this.info.Controls.Add(this.proocess);
            this.info.Controls.Add(this.burst_time);
            this.info.Controls.Add(this.name);
            this.info.Controls.Add(this.arrive_time);
            this.info.Controls.Add(this.add);
            this.info.Location = new System.Drawing.Point(23, 16);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(538, 96);
            this.info.TabIndex = 4;
            this.info.TabStop = false;
            this.info.Text = "Process info";
            // 
            // prio
            // 
            this.prio.Location = new System.Drawing.Point(332, 60);
            this.prio.Name = "prio";
            this.prio.Size = new System.Drawing.Size(57, 20);
            this.prio.TabIndex = 12;
            // 
            // burst
            // 
            this.burst.Location = new System.Drawing.Point(213, 60);
            this.burst.Name = "burst";
            this.burst.Size = new System.Drawing.Size(57, 20);
            this.burst.TabIndex = 11;
            // 
            // arrive
            // 
            this.arrive.Location = new System.Drawing.Point(115, 60);
            this.arrive.Name = "arrive";
            this.arrive.Size = new System.Drawing.Size(57, 20);
            this.arrive.TabIndex = 10;
            // 
            // prior
            // 
            this.prior.AutoSize = true;
            this.prior.Location = new System.Drawing.Point(338, 38);
            this.prior.Name = "prior";
            this.prior.Size = new System.Drawing.Size(41, 13);
            this.prior.TabIndex = 9;
            this.prior.Text = "priority";
            // 
            // proocess
            // 
            this.proocess.AutoSize = true;
            this.proocess.Location = new System.Drawing.Point(3, 38);
            this.proocess.Name = "proocess";
            this.proocess.Size = new System.Drawing.Size(73, 13);
            this.proocess.TabIndex = 6;
            this.proocess.Text = "Process name";
            // 
            // burst_time
            // 
            this.burst_time.AutoSize = true;
            this.burst_time.Location = new System.Drawing.Point(222, 38);
            this.burst_time.Name = "burst_time";
            this.burst_time.Size = new System.Drawing.Size(32, 13);
            this.burst_time.TabIndex = 8;
            this.burst_time.Text = "Burst";
            // 
            // arrive_time
            // 
            this.arrive_time.AutoSize = true;
            this.arrive_time.Location = new System.Drawing.Point(112, 38);
            this.arrive_time.Name = "arrive_time";
            this.arrive_time.Size = new System.Drawing.Size(61, 13);
            this.arrive_time.TabIndex = 7;
            this.arrive_time.Text = "Arrival time";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listView1);
            this.groupBox4.Location = new System.Drawing.Point(23, 118);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(538, 177);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
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
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(745, 440);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 1;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(658, 440);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 1;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox2);
            this.groupBox5.Controls.Add(this.gantt_chart);
            this.groupBox5.Location = new System.Drawing.Point(23, 301);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(538, 171);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "groupBox5";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(18, 60);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(504, 13);
            this.textBox2.TabIndex = 1;
            // 
            // gantt_chart
            // 
            this.gantt_chart.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gantt_chart.Enabled = false;
            this.gantt_chart.Location = new System.Drawing.Point(18, 34);
            this.gantt_chart.Name = "gantt_chart";
            this.gantt_chart.Size = new System.Drawing.Size(504, 20);
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
            this.type.Location = new System.Drawing.Point(620, 16);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(200, 134);
            this.type.TabIndex = 13;
            this.type.TabStop = false;
            this.type.Text = "Scheduling type";
            // 
            // subtype
            // 
            this.subtype.Controls.Add(this.preem);
            this.subtype.Controls.Add(this.nonpreem);
            this.subtype.Enabled = false;
            this.subtype.Location = new System.Drawing.Point(620, 156);
            this.subtype.Name = "subtype";
            this.subtype.Size = new System.Drawing.Size(200, 88);
            this.subtype.TabIndex = 14;
            this.subtype.TabStop = false;
            this.subtype.Text = "Preemptivety";
            // 
            // q
            // 
            this.q.Location = new System.Drawing.Point(620, 284);
            this.q.Name = "q";
            this.q.Size = new System.Drawing.Size(100, 20);
            this.q.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(620, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Quantam";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 475);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.q);
            this.Controls.Add(this.subtype);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.type);
            this.Controls.Add(this.start);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.info);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.info.ResumeLayout(false);
            this.info.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.type.ResumeLayout(false);
            this.type.PerformLayout();
            this.subtype.ResumeLayout(false);
            this.subtype.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

