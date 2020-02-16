using System;
using System.Collections.Generic;
using System.Threading;

namespace Lesson5Console
{    
    class Program
    {
        private static object lockObject = new object();
        public static int res = 1;

        static void Main(string[] args)
        {            
            int n = 6;

            for(int i = 1; i <= n; i++)
            {                
                ThreadPool.QueueUserWorkItem(new WaitCallback(Calc), i);
            }

            Console.ReadKey();
            Console.WriteLine(res);
        }

        public static void Calc(object n)
        {
            lock (lockObject)
            {
                Console.WriteLine($"Поток {Thread.CurrentThread.Name} - {n}" );
                res *= (int)n;
            }            
        }                
    }    
}
