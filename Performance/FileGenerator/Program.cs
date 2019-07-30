using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yakaas.Words;

namespace FileGenerator
{
    class Program
    {
        class Line
        {
            public int Id { get; set; }

            public string Word { get; set; }

            public string AsLine
            {
                get { return $"{Id} {Word}"; }
            }
        }

        static void Main(string[] args)
        {
            var list = Generate(4000000);
            File.AppendAllLines("data.txt", list.Select(x=>x.AsLine).ToList());
        }

        private static IEnumerable<Line> Generate(int len)
        {
            var random = new Random();

            for (int i = 0; i < len; i++)
            {
                yield return new Line
                {
                    Id = random.Next(0, 100),
                    Word = RandomString(random, 2)
                };
            }
        }

        private static string RandomString(Random random, int size, bool lowerCase = true)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 1; i < size + 1; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            else
                return builder.ToString();
        }
    }
}
