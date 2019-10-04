using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketLogger
{
    public enum LogLevel
    {
        Trace,
        Info,
        Warning,
        Error,
        Critical
    }
    public class LogEntry
    {
        private DateTime LogTime { get; set; }
        
        public Dictionary<string, string> LogMessage { get; set; }
        
        public LogLevel MessageLevel { get; set; }

        public string LogLine { get; set; }

        public LogEntry()
        {
            LogMessage = new Dictionary<string, string>();
        }

        public LogEntry(LogLevel messageLevel) : this()
        {
            MessageLevel = messageLevel;
        }

        public LogEntry(LogLevel messageLevel, Dictionary<string, string> logMessage) : this(messageLevel)
        {
            LogMessage = logMessage;
        }

        public void GenerateLogLine()
        {
            var jsonMessage = JsonConvert.SerializeObject(LogMessage, Formatting.None);
            LogLine = $"{MessageLevel}, {LogTime}, {jsonMessage}";
        }
    }
}
