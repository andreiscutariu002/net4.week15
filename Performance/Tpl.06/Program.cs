using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tpl._06
{
    class Program
    {
        private const string Dir = "C:\\Users\\matebook\\Desktop\\files";

        private static void Main(string[] args)
        {
            var application = new Application(Dir);

            application.Run().GetAwaiter().GetResult();
        }
    }
}
