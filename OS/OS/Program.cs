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
        public int get_remaining()
        {
            return remaining;
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
        List<int> index_list;
        List<int> time_list;
        List<int> sorted_arrive;
        int s;
        

        public Processes()
        {
            all = new List<Process>();
            index_list =new  List<int>();
            time_list = new List<int>();
            sorted_arrive = new List<int>();
            s = 0;
           
        }

        public void add_process(Process process)
        {
            all.Add(process);
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
                }
                sorted_arrive.Add(index);
               index = ( index == all.Count()-1) ? index - 1: index+1;
            }
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
        public gant_info rr(int q)
        {
            sort();
            int index = 0;
            int time = 0;
  
            while (true)
            {
                index = get_next(time);
                time_list.Add(time);
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
