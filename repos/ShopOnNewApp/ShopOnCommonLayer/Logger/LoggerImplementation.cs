using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnCommonLayer.Logger
{
    public class LoggerImplementation : ILogger
    {
        private readonly string folderPath;

        public LoggerImplementation(string folderPath)
        {
            this.folderPath = folderPath;
        }
        public void WriteLog(Exception exception)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string today = folderPath + date + ".txt";
            using (StreamWriter sw = File.AppendText(today))
            {
                sw.WriteLine($"{DateTime.Now}");
                Console.WriteLine("**************************");
                sw.WriteLine(exception.StackTrace);
            }
        }
    }
}
