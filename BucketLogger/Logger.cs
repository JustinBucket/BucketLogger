using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BucketLogger
{
    public class Logger
    {
        public string LogName { get; set; }

        private string LogPath { get; set; }

        private DateTime LogDate { get; set; }

        private string LogFolder { get; set; }

        public Logger(string logName)
        {
            LogName = LogName;
            GenerateLogFolder();
            LogDate = DateTime.Now;
            LogPath = Path.Combine(LogFolder,$"{LogDate.ToString("ddMMyyyy")} - Log.blf");
            GenerateLogFile();
        }

        private void GenerateLogFolder()
        {
            var runFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var logFolderPath = Path.Combine(runFolder, "Logs");

            if (!Directory.Exists(logFolderPath))
                Directory.CreateDirectory(Path.Combine(runFolder, "Logs"));

            LogFolder = logFolderPath;
        }
        
        private void GenerateLogFile()
        {
            if (!File.Exists(LogPath))
                File.Create(LogPath);
        }

        public void WriteLogLine(LogEntry logMessage)
        {
            using (var sw = File.AppendText(LogPath))
            {
                sw.WriteLine(logMessage.LogLine);
            }
        }
    }
}
