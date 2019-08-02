using System;
using System.IO;
using System.Threading;

namespace SimpleThreads
{
    internal class Program
    {
        private const string FileName = "output2.txt";

        private static object locker = new Object();

        private static void Main(string[] args)
        {
            var currentThreadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"[Main Thread] Hello from thread with id: {currentThreadId}");

            var thread1 = new Thread(RunOnThread1);
            thread1.Start();

            var thread2 = new Thread(RunOnThread2);
            thread2.Start();

            var thread3 = new Thread(RunOnThread3);
            thread3.Start();

            //RunOnThread1();
            //RunOnThread2();
            //RunOnThread3();

            Console.WriteLine("Main thread finished");
            Console.ReadKey();
        }

        private static void RunOnThread1()
        {
            var currentThreadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"[Thread 1] Hello from thread with id: {currentThreadId}");

            Thread.Sleep(TimeSpan.FromSeconds(10));

            Console.WriteLine($"[Thread 1] End job on thread id: {currentThreadId}");
        }

        private static void RunOnThread2()
        {
            var currentThreadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"[Thread 2] Hello from thread with id: {currentThreadId}");

            Thread.Sleep(TimeSpan.FromSeconds(10));

            Console.WriteLine($"[Thread 2] End job on thread id: {currentThreadId}");
        }

        private static void RunOnThread3()
        {
            var currentThreadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"[Thread 3] Hello from thread with id: {currentThreadId}");

            Thread.Sleep(TimeSpan.FromSeconds(10));

            Console.WriteLine($"[Thread 3] End job on thread id: {currentThreadId}");
        }
    }
}