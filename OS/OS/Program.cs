using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OS
{
    class Process
    {
        string name;
        int arrive;
        int burst;
        int remaining;
        int prio;

        public Process()
        {
            set_info("", 0, 0, 0);
        }

        public Process(string n, int a, int b, int p)
        {
            set_info(n, a, b, p);
        }

        public void set_info(string n, int a, int b, int p)
        {
            name = n;
            arrive = a;
            burst = b;
            prio = p;
            remaining = burst;
        }

        public string get_name()
        {
            return name;
        }

        public int get_arrive()
        {
            return arrive;
        }

        public int get_burst()
        {
            return burst;
        }

        public int get_prio()
        {
            return prio;
        }

        public int excute(int time)
        {
            return remaining - time;
        }

        public string get_info()
        {
            return name + " " + arrive.ToString() + " " + burst.ToString() + " " + prio.ToString();
        }
    }

    //-----------------------------------------------------------------

    class Processes
    {
        List<Process> all;
        public Process p;

        public Processes()
        {
            all = new List<Process>();
            p = new Process();
        }

        public void add_process(Process process)
        {
            all.Add(process);
        }
        public Process get_process(int i)
        {
            return all[i];
        }
    }


    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
