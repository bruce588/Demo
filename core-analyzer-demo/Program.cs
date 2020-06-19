using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace core_analyzer_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //看起來沒問題,實際上微軟已經建議不要再使用了
            //請加入nuget:Microsoft.DotNet.Analyzers.Compatibility
            //
            WebClient client = new WebClient();
        }
    }
}
