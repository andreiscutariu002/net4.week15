using System;
using System.Threading;

namespace SimpleThreads
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var currentThreadManagedThreadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"[Main Thread] Hello from thread with id: {currentThreadManagedThreadId}");
        }
    }
}