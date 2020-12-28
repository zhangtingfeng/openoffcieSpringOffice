using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleAppZTF
{
    public class DeleteQueue
    {
        private static object qobject =null;

        private static Queue q = new Queue();
        private static System.Timers.Timer aTimer;

        private void Start()
        {
            if (aTimer == null)
            {
                aTimer = new System.Timers.Timer(2000);
                // Hook up the Elapsed event for the timer. 
                aTimer.Elapsed += OnTimedEvent;
                aTimer.AutoReset = true;
                aTimer.Enabled = true;
            }
        }

        public DeleteQueue() {
            if (qobject == null) {
                qobject = this;
            }
        
        }


        public void SetDeleteQueue(String strList)
        {
            Start();
            q.Enqueue(strList);


        }


        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            string ch = "";
            if (q.Count > 0)
            {
                ch = (string)q.Dequeue();
                if (File.Exists(ch)) {
                    File.Delete(ch);
                }            
            }
            Console.WriteLine(ch + "     The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
        }


    }
}
