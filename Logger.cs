using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClientProgram
{
    class Logger
    {
        // Default
        public static int OpenLogFile()
        {
            // Log 폴더 유뮤 확인 후 생성
            string logDir = Path.Combine(Environment.CurrentDirectory, "Log", DateTime.Now.ToString("yyyy-MM"));
            if (Directory.Exists(logDir) == false) Directory.CreateDirectory(logDir);

            // 현재 기준의 [일(d)-시(H)] 파일 유무 확인 후 생성
            if (File.Exists(filePath()) == false) File.Create(filePath());

            return 0;
        }

        public static int CloseLogFile()
        {
            using (var sw = new StreamWriter(filePath(), true, Encoding.UTF8))
            {
                sw.Close();
            }

            return 0;
        }

        public static int Write(string sender, string wr)
        {
            string log = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]") + "<" + sender + "가 보냄> " + wr;

            using (var sw = new StreamWriter(filePath(), true, Encoding.UTF8))
            {
                Console.WriteLine(log);
                sw.WriteLine(log);
            }

            return 0;
        }

        // Plus
        public static string filePath()
        {
            string logDir = Path.Combine(Environment.CurrentDirectory, "Log", DateTime.Now.ToString("yyyy-MM"));
            string logFile;

            int hourNow = Convert.ToInt32(DateTime.Now.ToString("HH"));
            int hourPath = 0;

            if (hourNow % 3 == 0)
            {
                hourPath = hourNow;
            }
            else if (hourNow % 3 == 1 || hourNow % 3 == 2)
            {
                if ((hourNow - 1) % 3 == 0)
                {
                    hourPath = hourNow - 1;
                }
                if ((hourNow - 2) % 3 == 0)
                {
                    hourPath = hourNow - 2;
                }
            }

            logFile = Path.Combine(logDir, DateTime.Now.ToString("dd-") + hourPath + ".txt");

            return logFile;
        }
    }
}
