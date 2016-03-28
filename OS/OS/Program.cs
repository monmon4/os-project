using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
class gant_info
{
    public List<int> index ;
    public List<int> time  ;
    public gant_info() // a class contains list of start time and indexes of running processes
    {
        List<int> index = new List<int>();
        List<int> time = new List<int>() ;
    }
}
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

        public Process(string n, int a, int b)
        {
            set_info1(n, a, b);
        }

        public void set_info1(string n, int a, int b)
        {
            name = n;
            arrive = a;
            burst = b;
            remaining = burst;
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

        public int excute(int time) // to calculate remaining time
        {
            if (time < remaining)
            {
                remaining -= time;
                return remaining;
            }
            else
            {
                int i;
                i = remaining;
                remaining = 0;
                return i - time;
            }
        }

        public void excute_all()
        {
            remaining = 0;
        }
        public int get_remaining()
        {
            return remaining;
        }

        public string get_info()
        {
            return name + " " + arrive.ToString() + " " + burst.ToString() + " " + prio.ToString();
        }

        public string get_info1()
        {
            return name + " " + arrive.ToString() + " " + burst.ToString();
        }
        
    }

    //-----------------------------------------------------------------

    class Processes
    {
        public List<Process> all; // contains all the processes
        List<int> index_list;
        List<int> time_list;
        List<int> sorted_arrive; // for process sorted by they arrival time
        int s;
        List<Process> sorted_prio;
        List<Process> sorted_arri;
        List<Process> sorted_arri_time;

        public Processes()
        {
            all = new List<Process>();
            index_list =new  List<int>();
            time_list = new List<int>();
            sorted_arrive = new List<int>();
            s = 0;
            sorted_prio = new List<Process>();
            sorted_arri = new List<Process>();
            sorted_arri_time = new List<Process>();
           
        }

        public void add_process(Process process)
        {
            all.Add(process);
            sorted_arri.Add(process);
            sorted_arri_time.Add(process);
        }
        public Process get_process(int i)
        {
            return all[i];
        }

        private void sort() // to sort the processes by their arrival time
        {
            int index=0;
            for (int i = 0; i < all.Count(); i++)
            {
                
                for (int j = 0; j < all.Count(); j++)
                {
                    if (sorted_arrive.IndexOf(j) == -1 && all[j].get_arrive() < all[index].get_arrive())
                        index = j;
                    else if (sorted_arrive.IndexOf(j) == -1 && sorted_arrive.IndexOf(index) != -1)
                        index = j;
                }
                sorted_arrive.Add(index); // contains the indexes of all sorted
            }
        }

        private int get_least(int time) //to get least remaining time
        {
            int index = -1; // indicates the end
            for (int i = 0; i < all.Count(); i++)
            {
                if (all[i].get_remaining() != 0)
                {
                    if (time == -1 &&  (index == -1 || index == -2 ||  all[index].get_arrive() > all[i].get_arrive()))
                        index = i; // get least arrival
                    else if (all[i].get_arrive() > time && index == -1)
                        index = -2; // indicate a gap
                    else if ((index == -1 || index == -2 || all[index].get_remaining() > all[i].get_remaining()) && all[i].get_arrive() <= time)
                        index = i; // get least remaining
                }
            }
            return index;
        }

        public int get_next_time(int time) // to get the arrival time of the next process
        {
            int index = 0;
            for (int i = 0; i < all.Count(); i++)
            {
                if ((all[i].get_arrive() > time && all[i].get_arrive() < all[index].get_arrive() ) || all[index].get_arrive() <= time)
                    index = i;
            }
            return all[index].get_arrive();
        }


        private int get_next(int time) // to get the index of the next process
        {
            if (s!=0 && all[sorted_arrive[s-1]].get_remaining() == 0)
            {
                sorted_arrive.RemoveAt(s-1);
                s--;
            }
            if (s == sorted_arrive.Count()) s = 0;
            if (sorted_arrive.Count() == 0) return -1;
            else if (all[sorted_arrive[s]].get_arrive() <= time)
            {
                s++;
                return sorted_arrive[s - 1];
            }

            else if (s == 0) return -2;
            else
            {
                s = 1;
                return sorted_arrive[s - 1];
            }          
        }

        public gant_info rr(int q) //for round robin it takes the quantam 
        {
            sort();
            int index = 0;
            int time = 0;

            while (true)
            {
                index = get_next(time);
                time_list.Add(time);
                if (index == -2)
                {
                    time = all[sorted_arrive[0]].get_arrive();
                    index_list.Add(-2);
                    continue;
                }
                index_list.Add(index);
                if (index == -1) break;
                int x = all[index].excute(q);
                time = x < 0 ? time + q + x : time + q;

            }
            gant_info info = new gant_info();
            info.index = index_list;
            info.time = time_list;
            return info;
        }

        public gant_info sjf()
        {
            int index = 0;
            int time = 0;

            while (true)
            {
                index = get_least(time); //get least remaining time
                time_list.Add(time);
                if (index == -2) // there is a gap
                {
                    time = all[get_least(-1)].get_arrive();
                    index_list.Add(-2);
                    continue;
                }
                index_list.Add(index);
                if (index == -1) break; // the end of processes
                all[index].excute_all(); // execute the process till its end
                time = time + all[index].get_burst();

            }
            gant_info info = new gant_info(); // to store the indexes and their times (already done) in the execution order
            info.index = index_list;
            info.time = time_list;
            return info;
        }

        public gant_info srjf() // preemtive sjf
        {
            int index = 0;
            int time = 0, next_time = 0, excuted_time = 0;

            while (true)
            {
                if (time == next_time) //time= current time, next time= the next arrival time
                    next_time = get_next_time(time); // to get anew next time
                index = get_least(time); //get least remainig time
                time_list.Add(time);
                if (index == -2) // there is a gap
                {
                    time = all[get_least(-1)].get_arrive();
                    index_list.Add(-2);
                    continue;
                }
                index_list.Add(index);
                if (index == -1) break; // the end of processes
                if (next_time <= time) // doesn't happen except at the last arrival
                {
                    time = time + all[index].get_remaining(); // to get the time of the holded proceses
                    all[index].excute_all();

                }
                else // what happens at all the processes
                {
                    excuted_time = all[index].excute(next_time - time); // execute till the next arrival time
                    if (excuted_time < 0) // if the process finished before the next arrival
                        time = next_time + excuted_time;
                    else
                        time = next_time;
                }

            }
            gant_info info = new gant_info();
            info.index = index_list;
            info.time = time_list;
            return info;
        }

        //public gant_info fcfs()
        //{
        //    sort();
        //    int index = 0;
        //    int time = 0;
        //    while (true)
        //    {
        //        index = get_next(time);
        //        time_list.Add(time);
        //        if (index == -2)
        //        {
        //            time = all[sorted_arrive[0]].get_arrive();
        //            index_list.Add(-2);
        //            continue;
        //        }
        //        index_list.Add(index);
        //        if (index == -1) break;
        //        all[index].excute_all();
        //        time = time + all[index].get_burst();
        //    }
        //    gant_info info = new gant_info();
        //    info.index = index_list;
        //    info.time = time_list;
        //    return info;

        //}

        public void sort_prio()
        {

            for (int i = 0; i < sorted_prio.Count() - 1; i++)
            {
                int max_prio_index = 0;
                for (int j = 1; j < sorted_prio.Count() - i; j++) // sorting the max prio in the list 
                {
                    if (sorted_prio[j].get_prio() > sorted_prio[max_prio_index].get_prio())
                    {
                        max_prio_index = j;
                    }
                    else if (sorted_prio[j].get_prio() == sorted_prio[max_prio_index].get_prio())// if 2 equal prio 
                    {
                        if (sorted_prio[j].get_arrive() > sorted_prio[max_prio_index].get_arrive())
                        {
                            max_prio_index = j;
                        }
                    }
                }
                Process temp = sorted_prio[sorted_prio.Count() - 1 - i];
                sorted_prio[sorted_prio.Count() - 1 - i] = sorted_prio[max_prio_index];
                sorted_prio[max_prio_index] = temp;
                // sorted_prio.Add(all[j]); // adding process with small prio



            }
        }
        public void sort_arri()
        {

            for (int i = 0; i < sorted_arri.Count() - 1; i++)
            {
                int max_arri_index = 0;
                for (int j = 1; j < sorted_arri.Count() - i; j++) // sorting the max prio in the list 
                {
                    if (sorted_arri[j].get_arrive() > sorted_arri[max_arri_index].get_arrive())
                    {
                        max_arri_index = j;
                    }
                    else if (sorted_arri[j].get_arrive() == sorted_arri[max_arri_index].get_arrive())// if 2 equal arri 
                    {
                        max_arri_index = j;
                    }
                }
                Process temp = sorted_arri[sorted_arri.Count() - 1 - i];
                sorted_arri[sorted_arri.Count() - 1 - i] = sorted_arri[max_arri_index];
                sorted_arri[max_arri_index] = temp;
            }
        }

        public Process get_sorted_prio(int n)
        {
            sort_prio();
            return sorted_prio[n];
        }

        public Process get_sorted_arri(int n)
        {
            sort_arri();
            return sorted_arri[n];
        }

        public Process get_sorted_arri_time(int n)
        {
            sort_arri();
            return sorted_arri_time[n];
        }


        public void gantt_process1(string name,int arrive,int burst,TextBox box2,TextBox gantt)
        {
            string x = "   " + name + "   ";
            string y = "|";
            string s = null;
            string ss = name;
            for (int i = 0; i < ss.Length; i++)
            {
                s = s + ".";
            }

            string m = "   " + s + "   ";
            int time = 0;
            //process1
            if (arrive == 0)
            {
                time = 0;
                box2.AppendText(Convert.ToString(0));
                box2.AppendText(m);
                time = time + burst;//last time+burst  //new time
                box2.AppendText(Convert.ToString(time));
                gantt.AppendText(x);
                gantt.AppendText(y);
            }

            else if (arrive != 0)
            {
                time = arrive;
                box2.AppendText(Convert.ToString(0)); // no process time
                box2.AppendText("     ");
                gantt.AppendText("     ");
                gantt.AppendText(y);

                box2.AppendText(Convert.ToString(time)); // process arrived
                box2.AppendText(m);
                time = time + burst;
                box2.AppendText(Convert.ToString(time));
                gantt.AppendText(x);
                gantt.AppendText(y);

            }
        }

        public int get_time_p1(int arrive, int burst)
        {
            int time=0;
            if (arrive == 0)
            {
                time = burst;
            }
            else if (arrive != 0)
            {
                time = arrive + burst;
            }

            return time;
        }

        public void gantt_the_rest_processes(string name,int arrive,int burst,int time,TextBox box2,TextBox gantt)
        {
            string y = "|";
            string x = "   " + name + "   ";
            string s = null;
            string ss = name;
            for (int j = 0; j < ss.Length; j++)
            {
                s = s + ".";
            }
            string m = "   " + s + "   ";
            if (arrive < time) // time da bta3 el process elly ablha 
            {
                box2.AppendText(m);
                time = time + burst;//last time+burst  //new time
                box2.AppendText(Convert.ToString(time));
                gantt.AppendText(x);
                gantt.AppendText(y);

            }
            else if (arrive > time)
            {
                time = arrive;
                 // no process time
                box2.AppendText("  ..  ");
                gantt.AppendText("      ");
                gantt.AppendText(y);

                box2.AppendText(Convert.ToString(time)); // process arrived
                box2.AppendText(m);
                time = time + burst;
                box2.AppendText(Convert.ToString(time));
                gantt.AppendText(x);
                gantt.AppendText(y);

            }
        }

        public void gantt_the_rest_processes_prio(int time, TextBox box2, TextBox gantt, TextBox count)
        {
            string x, y, s, ss, m;
            for (int i = 1; i < sorted_arri.Count(); i++)
            {
                y = "|";
                if (sorted_arri[i].get_arrive() < time)
                {
                    for (int a = 1; a < sorted_arri.Count(); a = 1)
                    {
                        if (sorted_arri[a].get_arrive() < time) // time da bta3 el process elly ablha //ba4of el time bta3 kol elly as8r mn el time da 34an a4of el prio bta3hom
                        { //ba4of el time bta3 kol elly as8r mn el time da 34an a7otohm f list w a4of el prio bta3hom el 5atwa el gaya
                            sorted_prio.Add(sorted_arri[a]);
                            sorted_arri.Remove(sorted_arri[a]);
                            // ams7ha 34an mttb34 tany fel iteration elly b3do;
                        }
                    }
                    sort_prio(); // keda 3ml sort prio lel processes elly gat 2bl el time f keda n2dr ntb3hom bel trteb              

                    for (int j = 0; j < sorted_prio.Count(); j++)
                    {
                        x = "   " + sorted_prio[j].get_name() + "   ";
                        s = null;
                        ss = sorted_prio[j].get_name();
                        for (int l = 0; l < ss.Length; l++)
                        {
                            s = s + ".";
                        }
                        m = "   " + s + "   ";
                        box2.AppendText(m);
                        time = time + sorted_prio[j].get_burst();//last time+burst  //new time
                        box2.AppendText(Convert.ToString(time));
                        gantt.AppendText(x);
                        gantt.AppendText(y);

                    }
                    // yms7 el list 34an el iteration elly b3do
                    sorted_prio.Clear();
                }
                else if (sorted_arri[i].get_arrive() > time) // m4 m7tage prio 34an asln mafe4 process mawgoda now
                {
                    time = sorted_arri[i].get_arrive();
                    // no process time
                    box2.AppendText("  .  ");
                    gantt.AppendText("      ");
                    gantt.AppendText(y);

                    x = "   " + sorted_arri[i].get_name() + "   ";
                    s = null;
                    ss = sorted_arri[i].get_name();
                    for (int l = 0; l < ss.Length; l++)
                    {
                        s = s + ".";
                    }
                    m = "   " + s + "   ";

                    box2.AppendText(Convert.ToString(time)); // process arrived
                    box2.AppendText(m);
                    time = time + sorted_arri[i].get_burst();
                    box2.AppendText(Convert.ToString(time));
                    gantt.AppendText(x);
                    gantt.AppendText(y);

                    sorted_arri.Remove(sorted_arri[i]);
                    i--;
                }
            }
        }

        public int get_time(int arrive, int burst, int time)
        {
            if (arrive < time) // time da bta3 el process elly ablha 
            {
                time = time + burst;
            }
            else if (arrive > time)
            {
                time = arrive+burst;
            }
            return time;
        }

        public int get_waiting_time_prio(int T, int WT)
        {
            for (int i = 1; i < sorted_arri_time.Count(); i++)
            {
                if (sorted_arri_time[i].get_arrive() < T)
                {
                    for (int a = 1; a < sorted_arri_time.Count(); a = 1)
                    {
                        if (sorted_arri_time[a].get_arrive() < T) // time da bta3 el process elly ablha //ba4of el time bta3 kol elly as8r mn el time da 34an a4of el prio bta3hom
                        { //ba4of el time bta3 kol elly as8r mn el time da 34an a7otohm f list w a4of el prio bta3hom el 5atwa el gaya
                            sorted_prio.Add(sorted_arri_time[a]);
                            sorted_arri_time.Remove(sorted_arri_time[a]);
                            // ams7ha 34an mttb34 tany fel iteration elly b3do;
                        }
                    }
                    sort_prio();
                    for (int j = 0; j < sorted_prio.Count(); j++)
                    {

                        T = T + sorted_prio[j].get_burst();//last time+burst  //new time
                        WT = WT + T - sorted_prio[j].get_arrive() - sorted_prio[j].get_burst();
                    }
                    sorted_prio.Clear();
                }
                else if (sorted_arri_time[i].get_arrive() > T)
                {
                    T = sorted_arri_time[i].get_arrive() + sorted_arri_time[i].get_burst();
                    WT = WT + T - sorted_arri_time[i].get_arrive() - sorted_arri_time[i].get_burst();
                    sorted_arri_time.Remove(sorted_arri_time[i]);
                    i--;
                }
            }
            return WT;
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
