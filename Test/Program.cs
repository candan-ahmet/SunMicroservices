using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunFramework.Core.Convert;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            var b = s.To<int?>();
            var a = s.To<int>();
            Console.ReadLine();
        }
    }
}
