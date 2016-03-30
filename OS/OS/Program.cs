using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
class gant_info //type to hold the index and the start time of each process
{
    public List<int> index ;
    public List<int> time  ;
    public gant_info() // a class contains list of start time and indexes of running processes
    {
        List<int> index = new List<int>();
        List<int> time = new List<int>() ;
    }
}

enum Method { FCFS, SJF, SRJF, PRP, PRN, RR }; //defining scheduling types
namespace OS
{
    
    class Process //hold the process information
    {
        string name;//the name of the process
        int arrive;//the arriving time of the process
        int burst;
        int remaining;
        int prio;

        public Process()
        {
            set_info("", 0, 0, 0);
        }

        public Process(string n, int a, int b, int p) //with priority
        {
            set_info(n, a, b, p);
        }

        public Process(string n, int a, int b) //without priority 
        {
            set_info(n, a, b);
        }

        public void set_info(string n, int a, int b) //without priority
        {
            name = n;
            arrive = a;
            burst = b;
            remaining = burst;
        }


        public void set_info(string n, int a, int b, int p) //with priority
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

        public void reset()
        {
            remaining = burst;
        }

       
    }

    //-----------------------------------------------------------------

    class Processes //hold all the processes
    {
        public List<Process> all; // contains all the processes
        List<int> index_list;
        List<int> time_list;
        List<int> sorted_arrive; // holds indexes for processes sorted by they arrival time
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

        public void reset() //resets all the lists of this class
        {
            index_list = new List<int>();
            time_list = new List<int>();
            sorted_arrive = new List<int>();
            s = 0;
            for (int i = 0; i < all.Count; i++)
            {
                all[i].reset();
            }

        }

        private void sort() // to sort the processes by their arrival time
        {
            sorted_arrive = new List<int>();
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

        private int get_least(int time, Method method = Method.SJF) //to get least time
        {
            int index = -1; // indicates the end
            for (int i = 0; i < all.Count(); i++)
            {
                if (all[i].get_remaining() != 0)
                {
                    if (time == -1 && (index == -1 || index == -2 || all[index].get_arrive() > all[i].get_arrive()))
                        index = i; // get least arrival
                    else if (all[i].get_arrive() > time && index == -1)
                        index = -2; // indicate a gap
                    else if (((index == -1 || index == -2 || all[index].get_remaining() > all[i].get_remaining()) && all[i].get_arrive() <= time) && (method == Method.SJF || method == Method.SRJF))
                        index = i; // get least remaining
                    else if (((index == -1 || index == -2 || all[index].get_prio() > all[i].get_prio()) && all[i].get_arrive() <= time) && (method == Method.PRN || method == Method.PRP))
                        index = i;//get least priority
                }
            }
            return index;
        }

        public int get_next_time(int time) // to get the arrival time of the next process of preemtive scheduling
        {
            int index = 0;
            for (int i = 0; i < all.Count(); i++)
            {
                if ((all[i].get_arrive() > time && all[i].get_arrive() < all[index].get_arrive() ) || all[index].get_arrive() <= time)
                    index = i;
            }
            return all[index].get_arrive();
        }


        private int get_next(int time) // to get the index of the next process of FCFS&RR
        {
            if (s!=0 && all[sorted_arrive[s-1]].get_remaining() == 0)
            {
                sorted_arrive.RemoveAt(s-1);
                s--;
            }
            if (s == sorted_arrive.Count()) s = 0;
            if (sorted_arrive.Count() == 0) return -1;//-1 indicates the end
            else if (all[sorted_arrive[s]].get_arrive() <= time)
            {
                s++;
                return sorted_arrive[s - 1];
            }

            else if (s == 0) return -2; //-2 indicates a gap
            else
            {
                s = 1;
                return sorted_arrive[s - 1];
            }          
        }

        public gant_info start_excution(Method method = Method.FCFS, int q = -1) //execution of all scheduling be arranging the processes
        {
            sort();
            int index = 0;
            int time = 0;
            int next_time = 0;
            while (true)
            {
                //preemtives 
                if (time == next_time && (method == Method.SRJF || method == Method.PRP)) 
                    next_time = get_next_time(time);
                //---
                //get the index
                if (method == Method.FCFS || method == Method.RR)
                    index = get_next(time);
                else
                    index = get_least(time,method);
                //---
                //to fix the times
                time_list.Add(time);
                if (index == -2)
                {
                    time = all[get_least(-1)].get_arrive();
                    index_list.Add(-2);
                    continue;
                }
                index_list.Add(index);
                if (index == -1) break;
                if (method == Method.FCFS || method == Method.SJF || method == Method.PRN || (method == Method.SRJF || method == Method.PRP && next_time <= time))
                {
                    time = time + all[index].get_remaining();
                    all[index].excute_all();
                }
                else if ((method == Method.RR && q != -1) || method == Method.SRJF || method == Method.PRP)
                {
                    if (method == Method.SRJF || method == Method.PRP) q = next_time - time;
                    int x = all[index].excute(q);
                    time = x < 0 ? time + q + x : time + q;
                }
                //----
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
