using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tpl._03
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentThreadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"[Main Thread] Hello from thread with id: {currentThreadId}");

            var task1 = new Task(RunOnThread1);
            task1.Start();

            var task2 = Task.Run(RunOnThread2);

            var task3 = Task.Factory.StartNew(RunOnThread3);

            task1.Wait();
            task2.Wait();
            task3.Wait(TimeSpan.FromSeconds(10));

            //Task.WaitAll(task1, task2, task3);

            Console.WriteLine("[Main Thread] Finished");
            Console.ReadKey();
        }

        private static void RunOnThread1()
        {
            var currentThreadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"[Thread 1] Hello from thread with id: {currentThreadId}");

            Thread.Sleep(TimeSpan.FromSeconds(2));

            Console.WriteLine($"[Thread 1] Finished job on thread id: {currentThreadId}");
        }

        private static void RunOnThread2()
        {
            var currentThreadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"[Thread 2] Hello from thread with id: {currentThreadId}");

            Thread.Sleep(TimeSpan.FromSeconds(2));

            Console.WriteLine($"[Thread 2] Finished job on thread id: {currentThreadId}");
        }

        private static void RunOnThread3()
        {
            var currentThreadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"[Thread 3] Hello from thread with id: {currentThreadId}");

            Thread.Sleep(TimeSpan.FromSeconds(2));

            Console.WriteLine($"[Thread 3] Finished job on thread id: {currentThreadId}");
        }
    }
}
