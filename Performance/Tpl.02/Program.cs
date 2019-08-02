using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tpl._02
{
    class Program
    {
        static void Main(string[] args)
        {
            const long number = 100000;

            var list = new ConcurrentBag<long>();

            Parallel.For(0, number,
                index =>
                {
                    //lock (list)
                    //{
                        list.Add(index);
                    //}
                });

            //for (int i = 0; i < number; i++)
            //{
            //    list.Add(i);
            //}

            Console.WriteLine($"Nr of elements: {list.Count}" );
        }
    }
}
