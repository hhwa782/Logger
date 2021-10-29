using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyClient2
{
    class Logger
    {
        StreamWriter sw;
        // Default
        static int OpenLogFile(string opf)
        {
            string logDir = Path.Combine(Environment.CurrentDirectory, "Log", DateTime.Now.ToString("yyyy-MM"));
            string logFile = Path.Combine(logDir, DateTime.Now.ToString("dd-HH") + ".txt");

            if (Directory.Exists(logDir) == false) Directory.CreateDirectory(logDir);
            if (File.Exists(logFile) == false) File.Create(logFile);

            return 0;
        }

        static int CloseLogFile()
        {
            //sw.Close();

            return 0;
        }

        static int Write(string wr)
        {
            //sw.WriteLine(wr);
            
            return 0;
        }
    }
}
