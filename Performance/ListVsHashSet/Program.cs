using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ListVsHashSet
{
    public class Program
    {
        private static void Main()
        {
            var random = new Random();

            // TODO - 0 check the search of stringToSearch

            var list = new List<string>();
            var hashSet = new HashSet<string>();

            var s1 = new Stopwatch();
            s1.Start();
            for (var x = 0; x < 10000000; x++)
            {
                list.Add("string_" + random.Next());
            }
            Console.WriteLine($"insert into list {s1.ElapsedMilliseconds} ms");

            var s2 = new Stopwatch();
            s2.Start();
            for (var x = 0; x < 10000000; x++)
            {
                hashSet.Add("string_" + random.Next());
            }
            Console.WriteLine($"insert into hashset {s2.ElapsedMilliseconds} ms");

            var stringToSearch = "string_9132123";

            // TODO - 1 check the search of stringToSearch

            // TODO - 2 check the delete of stringToSearch
        }
    }
}
