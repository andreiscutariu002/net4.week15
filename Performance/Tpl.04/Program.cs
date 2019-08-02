using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tpl._04
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<List<int>> task1 = new Task<List<int>>(Method1);

            Task<int> task2 = task1.ContinueWith(taskPrecedent => Method2(taskPrecedent.Result));

            Task task3 = task2.ContinueWith(taskPrecedent => Method3(taskPrecedent.Result));

            task1.Start();

            //var list = task1.Result;

            //foreach (var i in list)
            //{
            //    Console.WriteLine(i);
            //}

            task3.Wait();
            Console.WriteLine("End");

            Console.ReadKey();
        }

        public static List<int> Method1()
        {
            Console.WriteLine("Creating list");

            var currentThreadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"[Method1] Hello from thread with id: {currentThreadId}");

            Console.WriteLine();

            return new List<int>{1, 2, 4};
        }

        public static int Method2(List<int> result)
        {
            Console.WriteLine($"Sum of {result.Count} elements");
            var currentThreadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"[Method2] Hello from thread with id: {currentThreadId}");

            Console.WriteLine();

            return result.Sum();
        }

        public static void Method3(int sum)
        {
            var currentThreadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"[Method3] Hello from thread with id: {currentThreadId}");

            Console.WriteLine($"Sum is {sum}");

            Console.WriteLine();
        }
    }
}
