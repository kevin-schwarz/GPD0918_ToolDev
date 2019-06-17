using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
    class Program
    {

        static void Main(string[] args)
        {
            (new Thread(Work)).Start();

            Work();
        }

        private static int x;

        private static object lockObj = new object();

        private static void Work()
        {
            while(true)
                lock(lockObj)
                    Console.WriteLine(x++);
        }

    }
}
