using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuoRiWeiLai.Framework
{
    public static partial class ZuoRiWeiLaiHelper
    {
        public static void WriteLine(string value)
        {
            Console.WriteLine(value);
            Trace.WriteLine(value);
        }
        public static void WriteLine(string format, object arg0)
        {
            Console.WriteLine(format, arg0);
            Trace.WriteLine(string.Format(format, arg0));
        }
        public static string MapPath(string path)
        {
            return AppDomain.CurrentDomain.BaseDirectory + path;
        }
    }
}
