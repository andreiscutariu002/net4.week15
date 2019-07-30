using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter
{
    class Program
    {
        private const string FileName = "DataSimple.txt";

        static void Main(string[] args)
        {
            var line = File.ReadLines(FileName);
            Console.WriteLine(line.First());
        }
    }
}
