using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
class gant_info
{
    public List<int> index ;
    public List<int> time  ;
    public gant_info()
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

        public int excute(int time)
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
        public List<Process> all;
        List<int> index_list;
        List<int> time_list;
        List<int> sorted_arrive;
        int s;
        List<Process> sorted_prio;
        List<Process> sorted_arri;
        

        public Processes()
        {
            all = new List<Process>();
            index_list =new  List<int>();
            time_list = new List<int>();
            sorted_arrive = new List<int>();
            s = 0;
            sorted_prio = new List<Process>();
            sorted_arri = new List<Process>();
           
        }

        public void add_process(Process process)
        {
            all.Add(process);
            sorted_prio.Add(process);
            sorted_arri.Add(process);
        }
        public Process get_process(int i)
        {
            return all[i];
        }

        private void sort()
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
                sorted_arrive.Add(index);
            }
        }

        private int get_least(int time)
        {
            int index = -1;
            for (int i = 0; i < all.Count(); i++)
            {
                if (all[i].get_remaining() != 0)
                {
                    if (time == -1 &&  (index == -1 || index == -2 ||  all[index].get_arrive() > all[i].get_arrive()))
                        index = i;
                    else if (all[i].get_arrive() > time && index == -1)
                        index = -2;
                    else if ((index == -1 || index == -2 || all[index].get_remaining() > all[i].get_remaining()) && all[i].get_arrive() <= time)
                        index = i;
                }
            }
            return index;
        }

        public int get_next_time(int time)
        {
            int index = 0;
            for (int i = 0; i < all.Count(); i++)
            {
                if ((all[i].get_arrive() > time && all[i].get_arrive() < all[index].get_arrive() ) || all[index].get_arrive() <= time)
                    index = i;
            }
            return all[index].get_arrive();
        }

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
            return sorted_arri [n];
        }


        /*private int get_least_arrival()
        { 
            int index=0;
            for (int i = 0; i < all.Count(); i++)
            {
                if (all[i].get_arrive() < all[index].get_arrive())
                    index = i;
            }
                return index;
        }*/
        private int get_next(int time)
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

        public void gantt_process1(string name,int arrive,int burst,TextBox box2,TextBox gantt)
        {
            string x = "   " + name + "   ";
            string y = "|";
            string s = ".";
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
            string s = ".";
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

        public gant_info rr(int q)
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
                index = get_least(time);
                time_list.Add(time);
                if (index == -2)
                {
                    time = all[get_least(-1)].get_arrive();
                    index_list.Add(-2);
                    continue;
                }
                index_list.Add(index);
                if (index == -1) break;
                all[index].excute_all();
                time = time + all[index].get_burst();

            }
            gant_info info = new gant_info();
            info.index = index_list;
            info.time = time_list;
            return info;
        }

        public gant_info srjf()
        {
            int index = 0;
            int time = 0, next_time = 0, excuted_time = 0;

            while (true)
            {
                if(time == next_time)
                    next_time = get_next_time(time);
                index = get_least(time);
                time_list.Add(time);
                if (index == -2)
                {
                    time = all[get_least(-1)].get_arrive();
                    index_list.Add(-2);
                    continue;
                }
                index_list.Add(index);
                if (index == -1) break;
                if (next_time <= time)
                {
                    time = time + all[index].get_remaining();
                    all[index].excute_all();
                    
                }
                else
                {
                    excuted_time = all[index].excute(next_time - time);
                    if (excuted_time < 0)
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
