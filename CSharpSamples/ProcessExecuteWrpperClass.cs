using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSamples
{
    class ProcessExecuteWrpperClass
    {
        public static void Run()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "java.exe";
            startInfo.Arguments = "-jar LuceneTest.jar";
            Process process = Process.Start(startInfo);
        }
    }
}
