using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Tpl._01
{
    class Program
    {
        static void Main(string[] args)
        {
            const decimal number = 10000000;
            
            var list = new List<decimal>();
            for (decimal i = 0; i < number; i++)
            {
                list.Add(i);
            }

            var sw = new Stopwatch();
            sw.Start();

            decimal sum = 0;
            object locker = new object();

            //foreach (var element in list)
            //{
            //    sum += element;
            //}

            Parallel.ForEach(list, value =>
            {
                lock (locker)
                {
                    sum = sum + value;
                }
            });

            Console.WriteLine($"Sum of first {number} elements is {sum}. Elapsed: {sw.ElapsedMilliseconds} ms");
        }
    }
}
